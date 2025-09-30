using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TinkoffPaymentClientApi.Commands;
using TinkoffPaymentClientApi.Helpers;

namespace TinkoffPaymentClientApi {
  /// <summary>
  /// TinkoffPaymentClient
  /// </summary>
  public sealed partial class TinkoffPaymentClient {
    static readonly HttpClient DefaultHttpClient = new();

    readonly string
      _termianlKey,
      _password,
      _baseUrl;

    readonly HttpClient _httpClient;

    const string DefaultBaseUrl = "https://securepay.tinkoff.ru/v2/";

    static string ReadToEnd(Stream stream) {
      using StreamReader reader = new StreamReader(stream);
      return reader.ReadToEnd();
    }

    E ProcessResponse<T, E>(int statusCode, string request, Stream bodyStream) where E : class {
      string body = ReadToEnd(bodyStream);
      try {
        if (statusCode == 200)
          return JsonConvert.DeserializeObject<E>(body)!;
      } catch (Exception ex) {
        throw new TinkoffPaymentClientException(string.Format(Properties.Resources.ProcessResponse_ErrorOccuredWhileProcessing0For12Body3,
            typeof(E).Name,
            typeof(T).Name,
            ex.Message,
            body),
          _baseUrl,
          statusCode,
          request,
          body,
          ex);
      }

      throw new TinkoffPaymentClientException(string.Format(Properties.Resources.ProcessResponse_WrongAnswerReveivedFrom0For1Status2Body3,
          _baseUrl,
          typeof(T).Name,
          statusCode,
          body),
        _baseUrl,
        statusCode,
        request,
        body
        );
    }
    Task<E> PostAsync<T, E>(T parameter, CancellationToken token)
     where T : BaseCommand
     where E : class
     => PostAsync<T, E>(parameter, true, token);

    async Task<E> PostAsync<T, E>(T parameter, bool json, CancellationToken token)
     where T : BaseCommand
     where E : class {

      using HttpRequestMessage request = BuildPostRequest(parameter, json, out var requestBody);
      using HttpResponseMessage response = await _httpClient.SendAsync(request, token);
      return ProcessResponse<T, E>((int)response.StatusCode, requestBody, await response.Content.ReadAsStreamAsync());
    }

    HttpRequestMessage BuildPostRequest<T>(T parameter, bool json, out string requestBody)
   where T : BaseCommand {
      parameter.TerminalKey = _termianlKey;
      parameter.Token = TokenGeneratorHelper.GenerateToken(parameter, _password);
      HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + parameter.CommandName);

      string data = JsonConvert.SerializeObject(parameter, new JsonSerializerSettings {
        NullValueHandling = NullValueHandling.Ignore,
      });
      requestBody = data;
      request.Content = json
        ? new StringContent(data, Encoding.UTF8, "application/json")
        : new FormUrlEncodedContent(JsonConvert.DeserializeObject<Dictionary<string, string>>(data)!);

      return request;
    }
#if NET5_0_OR_GREATER
    E Post<T, E>(T parameter, bool json = true)
      where T : BaseCommand
      where E : class {

      using (var request = BuildPostRequest(parameter, json, out var requestBody)) {
        using (var response = _httpClient.Send(request))
          return ProcessResponse<T, E>((int)response.StatusCode, requestBody, response.Content.ReadAsStream());
      }
    }
#else
    string UrlEncode(string data) {
      Dictionary<string, string> dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(data)!;
      StringBuilder sb = new StringBuilder();
      foreach (var kv in dic) {
        sb.AppendFormat("{0}={1}&", kv.Key, WebUtility.UrlEncode(kv.Value));
      }

      return sb.ToString();
    }

    E Post<T, E>(T parameter, bool json = true)
     where T : BaseCommand
     where E : class {
      using HttpWebResponse response = (HttpWebResponse)BuildWebPostRequest(parameter, json, out var requestBody).GetResponse();
      return ProcessResponse<T, E>((int)response.StatusCode, requestBody, response.GetResponseStream());
    }

    HttpWebRequest BuildWebPostRequest<T>(T parameter, bool json, out string requestBody)
   where T : BaseCommand {
      parameter.TerminalKey = _termianlKey;
      parameter.Token = TokenGeneratorHelper.GenerateToken(parameter, _password);
      HttpWebRequest request = WebRequest.CreateHttp(_baseUrl + parameter.CommandName);
      request.Method = "POST";
      request.ContentType = json ? "application/json" : "x-www-form-urlencoded";

      string data = JsonConvert.SerializeObject(parameter, new JsonSerializerSettings {
        NullValueHandling = NullValueHandling.Ignore,
      });

      if (!json)
        data = UrlEncode(data);
      requestBody = data;

      byte[] postBytes = Encoding.UTF8.GetBytes(data);
      request.ContentLength = postBytes.Length;
      using (Stream stream = request.GetRequestStream()) {
        stream.Write(postBytes, 0, postBytes.Length);
      }
      return request;
    }
#endif
  }
}
