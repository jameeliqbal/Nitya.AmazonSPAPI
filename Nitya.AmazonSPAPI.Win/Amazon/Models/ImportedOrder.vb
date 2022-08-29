Public Class ImportedOrder

    Public Property AmazonOrderId As String
    Public Property FulfillmentNetwork As String
    Public Property Status As String

    Public Property BuyerFirstName As String
    Public Property BuyerLastName As String

    Public Property PurchaseDate As String
    Public Property DeliveryDate As String

    Public Property ShippingMethod As String
    Public Property ShippingFirstName As String
    Public Property ShippingLastName As String
    Public Property ShippingAddress1 As String
    Public Property ShippingAddress2 As String
    Public Property ShippingCity As String
    Public Property ShippingState As String
    Public Property ShippingCountry As String
    Public Property ShippingZipCode As String
    Public Property ShippingPhone As String
    Public Property ShippingExtension As String

    Public Property Site As String

    Public Property SubTotal As Double
    Public Property TaxTotal As Double
    Public Property ShippingTotal As Double
    Public Property Total As Double

    Public Property Currency As String
    Public Property ConversionRate As Double

    Public Property Items As List(Of Item)

End Class

Public Class Item

End Class