Namespace Common.Models.Amzn.Orders

    Public Class OrderItem
        Public Property ASIN As String
        Public Property SellerSKU As String
        Public Property OrderItemId As String
        Public Property Title As String
        Public Property QuantityOrdered As Integer
        Public Property QuantityShipped As Integer
        Public Property ProductInfo As ProductInfoDetail
        Public Property PointsGranted As PointsGrantedDetail
        Public Property ItemPrice As Money
        Public Property ShippingPrice As Money
        Public Property ItemTax As Money
        Public Property ShippingTax As Money
        Public Property ShippingDiscount As Money
        Public Property ShippingDiscountTax As Money
        Public Property PromotionDiscount As Money
        Public Property PromotionDiscountTax As Money
        Public Property PromotionIds As List(Of String)
        Public Property CODFee As Money
        Public Property CODFeeDiscount As Money
        Public Property IsGift As Boolean
        Public Property ConditionNote As String
        Public Property ConditionId As String
        Public Property ConditionSubtypeId As String
        Public Property ScheduledDeliveryStartDate As String
        Public Property ScheduledDeliveryEndDate As String
        Public Property PriceDesignation As String
        Public Property TaxCollection As TaxCollections
        Public Property SerialNumberRequired As Boolean
        Public Property IsTransparency As Boolean
        Public Property IossNumber As String
        Public Property StoreChainStoreId As String
        Public Property DeemedResellerCategory As String
    End Class

End Namespace