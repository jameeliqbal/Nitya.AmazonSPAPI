Namespace Common.Models.Amzn.Orders

    Public Class Order
        Public Property AmazonOrderId As String
        Public Property SellerOrderId As String
        Public Property PurchaseDate As String
        Public Property LastUpdateDate As String
        Public Property OrderStatus As String
        Public Property FulfillmentChannel As String
        Public Property SalesChannel As String
        Public Property OrderChannel As String
        Public Property ShipServiceLevel As String
        Public Property OrderTotal As Money
        Public Property NumberOfItemsShipped As Integer
        Public Property NumberOfItemsUnshipped As Integer
        Public Property PaymentExecutionDetail As List(Of PaymentExecutionDetailItem)
        Public Property PaymentMethod As String
        Public Property PaymentMethodDetails As List(Of String)
        Public Property MarketplaceId As String
        Public Property ShipmentServiceLevelCategory As String
        Public Property EasyShipShipmentStatus As String
        Public Property CbaDisplayableShippingLabel As String
        Public Property OrderType As String
        Public Property EarliestShipDate As String
        Public Property LatestShipDate As String
        Public Property EarliestDeliveryDate As String
        Public Property LatestDeliveryDate As String
        Public Property IsBusinessOrder As Boolean
        Public Property IsPrime As Boolean
        Public Property IsPremiumOrder As Boolean
        Public Property IsGlobalExpressEnabled As Boolean
        Public Property ReplacedOrderId As String
        Public Property IsReplacementOrder As Boolean
        Public Property PromiseResponseDueDate As String
        Public Property IsEstimatedShipDateSet As Boolean
        Public Property IsSoldByAB As Boolean
        Public Property DefaultShipFromLocationAddress As Address
        Public Property FulfillmentInstruction As FulfillmentInstructions
        Public Property IsISPU As Boolean
    End Class

End Namespace