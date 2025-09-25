using TinkoffPaymentClientApi.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;

namespace TinkoffPaymentClientApi.ResponseEntity {
  /// <summary>
  /// Список банков-участников СБП для платежа
  /// </summary>
  public class QrBankListResponse : TinkoffResponse {
    /// <summary>
    /// Список банков-участников СБП для платежа  <see cref="QrBank"/>
    /// </summary>
    [JsonRequired]
    public JArray? Banklist { get; set; }

    public QrBank[] GetBanks() {
      if (Banklist is null || !Banklist.Any())
        return [];

      return Banklist.First().Children()
        .Select(x => x.First as JObject)
        .Where(x => x is not null)
        .Select(x => x!.ToObject<QrBank>())
        .ToArray()!;
    }
  }
}
