using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TinkoffPaymentClientApi.Enums {
  /// <summary>
  /// Типы сценариев оплаты.
  /// </summary>
  /// <remarks>
  /// Значение по умолчанию — qr (Оплата).
  /// </remarks>
  [JsonConverter(typeof(StringEnumConverter))]
  public enum EScenariosTypesPayment {
    /// <summary>
    /// Оплата
    /// </summary>
    [EnumMember(Value = "qr")]
    Payment,
    /// <summary>
    /// Привязка счета
    /// </summary>
    [EnumMember(Value = "sub")]
    AccountLinking
  }
}
