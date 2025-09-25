////////////////////////////////////////////////////
// https://developer.tbank.ru/eacq/api/get-qr-bank-list
////////////////////////////////////////////////////

using TinkoffPaymentClientApi.Enums;
using TinkoffPaymentClientApi.Models;

namespace TinkoffPaymentClientApi.Commands {
  /// <summary>
  /// Получить список банков-участников СБП для платежа
  /// </summary>
  public class GetQrBankList(Device device) : BaseCommand {
    internal override string CommandName => "GetQrBankList";

    /// <summary>
    /// Тип сценария оплаты.
    /// </summary>
    public EScenariosTypesPayment ScenarioType { get; set; }

    /// <summary>
    /// Тип и ОС устройства.
    /// </summary>
    public Device? Device { get; private set; } = device;
  }
}
