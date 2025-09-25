using TinkoffPaymentClientApi.Commands;

namespace TinkoffPaymentClientApi.Models {
  /// <summary>
  /// Банк-участник СБП для платежа
  /// </summary>
  public class QrBank {
    /// <summary>
    /// Внутренний идентификатор банка, который выбран для оплаты.
    /// Список доступных BankId запрашивается методом Получить список банков-участников СБП для платежа <see cref="GetQrBankList"/>.
    /// </summary>
    /// <remarks>
    /// При передаче BankId, в ответе в параметре Data будет возвращен deeplink вместо функциональной платежной ссылки (payload).
    /// Следует передавать BankId только для DataType = 'PAYLOAD' или null.
    /// </remarks>
    public string? BankId { get; set; }

    /// <inheritdoc/>
    public string? NspkBankId { get; set; }

    /// <inheritdoc/>
    public string? BankName { get; set; }

    /// <inheritdoc/>
    public string? BankLogo { get; set; }

    /// <inheritdoc/>
    public int BankOrder { get; set; }
  }
}
