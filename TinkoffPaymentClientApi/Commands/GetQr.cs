////////////////////////////////////////////////////
// https://developer.tbank.ru/eacq/api/get-qr
////////////////////////////////////////////////////

namespace TinkoffPaymentClientApi.Commands {
  /// <summary>
  /// Сформировать QR
  /// </summary>
  public class GetQr(string paymentId) : BaseCommand {
    internal override string CommandName => "GetQr";

    /// <summary>
    /// Идентификатор платежа в системе банка	
    /// </summary>
    public string? PaymentId { get; set; } = paymentId;

    /// <summary>
    /// Тип возвращаемых данных:
    /// PAYLOAD — в ответе возвращается только.
    /// IMAGE — в ответе возвращается SVG изображение QR.
    /// </summary>
    /// <remarks>
    /// Requirements: [PAYLOAD, IMAGE]. Default: PAYLOAD
    /// </remarks>
    public string DataType { get; set; } = "PAYLOAD";

    /// <summary>
    /// Внутренний идентификатор банка, который выбран для оплаты.
    /// Список доступных BankId запрашивается методом Получить список банков-участников СБП для платежа <see cref="GetQrBankList"/>.
    /// </summary>
    /// <remarks>
    /// При передаче BankId, в ответе в параметре Data будет возвращен deeplink вместо функциональной платежной ссылки (payload).
    /// Следует передавать BankId только для DataType = 'PAYLOAD' или null.
    /// </remarks>
    public string? BankId { get; set; }
  }
}
