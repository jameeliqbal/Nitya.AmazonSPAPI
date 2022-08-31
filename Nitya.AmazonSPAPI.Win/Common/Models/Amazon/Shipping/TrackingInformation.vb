Namespace Common.Models.Amzn.Shipping
    Public Class TrackingInformation
        Public Property TrackingId As String
        Public Property Summary As TrackingSummary
        Public Property PromisedDeliveryDate As String
        Public Property EventHistory As EventList

    End Class

    Public Class TrackingSummary
        Public Property Status As String
    End Class

    Public Class EventList
        Public Property Events As [Event]()
    End Class
End Namespace