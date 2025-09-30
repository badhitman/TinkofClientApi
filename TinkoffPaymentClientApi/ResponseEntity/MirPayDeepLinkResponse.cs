using Newtonsoft.Json;

namespace TinkoffPaymentClientApi.ResponseEntity {
  /// <summary>
  /// MirPay: Получить DeepLink
  /// </summary>
  public class MirPayDeepLinkResponse : TinkoffResponse {
    /// <summary>
    /// DeepLink, который сформирован и подписан JWT-токеном.
    /// </summary>
    /// <remarks>
    /// пример: mirpay://pay.mironline.ru/inapp/eyJhbGciOiJQUzI1NiIsInR5.........
    /// </remarks>
    [JsonRequired]
    public string? Deeplink { get; set; }
  }
}
