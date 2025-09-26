using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TinkoffPaymentClientApi.Enums {
  /// <summary>
  /// Определяет тип проведения платежа
  /// </summary>
  [JsonConverter(typeof(StringEnumConverter))]
  public enum EPayType {
    /// <summary>
    /// Одностадийная
    /// </summary>
    [EnumMember(Value = "O")]
    OneStagePayment = 1,

    /// <summary>
    /// Двух-стадийная
    /// </summary>
    [EnumMember(Value = "T")]
    TwoStagePayment
  }
}
