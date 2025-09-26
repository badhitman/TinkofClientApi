using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TinkoffPaymentClientApi.Enums {
  /// <summary>
  /// Типы возвращаемых данных QR СБП/НСПК
  /// </summary>
  [JsonConverter(typeof(StringEnumConverter))]
  public enum EDataTypeQR {
    /// <summary>
    /// Payload
    /// </summary>
    [EnumMember(Value = "PAYLOAD")]
    PAYLOAD,
    /// <summary>
    /// Image SVG
    /// </summary>
    [EnumMember(Value = "IMAGE")]
    IMAGE,
  }
}
