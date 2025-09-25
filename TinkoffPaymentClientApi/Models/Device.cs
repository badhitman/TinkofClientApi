using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.Models {
  /// <summary>
  /// Тип и ОС устройства.
  /// </summary>
  public class Device {
    /// <summary>
    /// Тип устройства
    /// </summary>
    public EDevicesTypes Type { get; set; }

    /// <summary>
    /// ОС устройства.
    /// </summary>
    public string? Os { get; set; }
  }
}
