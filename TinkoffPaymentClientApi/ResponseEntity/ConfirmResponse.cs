﻿using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.ResponseEntity {
  /// <summary>
  /// Данные о подтверждении платежа
  /// </summary>
  public class ConfirmResponse : TinkoffResponse {
    /// <summary>
    /// Идентификатор заказа в системе продавца
    /// </summary>
    public string OrderId { get; set; }
    /// <summary>
    /// Уникальный идентификатор транзакции в системе банка
    /// </summary>
    public string PaymentId { get; set; }
    /// <summary>
    /// Статус платежа
    /// </summary>
    public EStatusResponse Status { get; set; }
  }
}
