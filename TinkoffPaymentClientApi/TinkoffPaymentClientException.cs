using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TinkoffPaymentClientApi {


  /// <summary>
  /// Исключение при обработке запроса к платежному шлюзу
  /// </summary>
  [Serializable]
  public class TinkoffPaymentClientException : Exception {
    public TinkoffPaymentClientException(string message,
      string baseUrl,
      int statusCode,
      string request,
      string response) : base(message) { 
      BaseUrl = baseUrl;
      StatusCode = statusCode;
      Request = request;
      Response = response;
    }
    public TinkoffPaymentClientException(string message,
      string baseUrl,
      int statusCode,
      string request,
      string response,
      Exception inner) : base(message, inner) { 
      BaseUrl = baseUrl;
      StatusCode = statusCode;
      Request = request;
      Response = response;
    }

    protected TinkoffPaymentClientException(
      SerializationInfo info,
      StreamingContext context) : base() {
      BaseUrl = info.GetString(nameof(BaseUrl))!;
      StatusCode = info.GetInt32(nameof(StatusCode))!;
      Request = info.GetString(nameof(Request))!;
      Response = info.GetString(nameof(Response))!;
    }

    /// <summary>
    /// Базовый адрес платежного шлюза
    /// </summary>
    public string BaseUrl { get; }
    /// <summary>
    /// Код ответа от сервера
    /// </summary>
    public int StatusCode { get; }
    /// <summary>
    /// Тело запроса
    /// </summary>
    public string Request { get; }
    /// <summary>
    /// Тело ответа
    /// </summary>
    public string Response { get; }
  }
}
