Namespace Common.Models.Amzn.Orders

    Public Class GetOrderItemsResponse
        'Public Property Payload As List(Of OrderItem)
        'Public Property Errors As List(Of ErrorMessage)

        Public Property Payload As OrderItems
        Public Property Errors As ErrorMessage()


    End Class

    Public Class OrderItems
        Public Property OrderItems As OrderItem()
    End Class

End Namespace