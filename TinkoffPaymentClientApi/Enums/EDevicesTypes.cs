using System.Runtime.Serialization;

namespace TinkoffPaymentClientApi.Enums {
  /// <summary>
  /// Типы устройств.
  /// </summary>
  public enum EDevicesTypes {
    /// <summary>
    /// Desktop
    /// </summary>
    [EnumMember(Value = "desktop")]
    Payment,
    /// <summary>
    /// Mobile
    /// </summary>
    [EnumMember(Value = "mobile")]
    AccountLinking
  }
}
