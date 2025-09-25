using Newtonsoft.Json;

namespace TinkoffPaymentClientApi.ResponseEntity {
  /// <summary>
  /// QR для оплаты СБП
  /// </summary>
  public class QRResponse : TinkoffResponse {
    /// <summary>
    /// Уникальный идентификатор транзакции в системе банка
    /// </summary>
    [JsonRequired]
    public string PaymentId { get; set; } = string.Empty;
    /// <summary>
    /// Идентификатор заказа в системе продавца
    /// </summary>
    [JsonRequired]
    public string OrderId { get; set; } = string.Empty;
    /// <summary>
    /// QR для оплаты
    /// </summary>
    /// <remarks>
    /// пример: https://qr.nspk.ru/AS1000670LSS7DN18SJQDNP4B05KLJL2.........
    /// </remarks>
    [JsonRequired]
    public string? Data { get; set; }
  }
}
