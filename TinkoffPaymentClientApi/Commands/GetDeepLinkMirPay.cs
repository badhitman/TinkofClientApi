////////////////////////////////////////////////////
// https://developer.tbank.ru/eacq/api/get-qr
////////////////////////////////////////////////////

namespace TinkoffPaymentClientApi.Commands;

/// <summary>
/// Получить DeepLink (MirPay)
/// </summary>
/// <remarks>
/// Для мерчантов c собственной платежной формой.
/// Метод позволяет получить DeepLink с включенным подписанным JWT-токеном.
/// </remarks>
public class GetDeepLinkMirPay(string paymentId) : BaseCommand {
  internal override string CommandName => "MirPay/GetDeepLink";

  /// <summary>
  /// Идентификатор платежа в системе банка	
  /// </summary>
  public string? PaymentId { get; set; } = paymentId;
}
