Namespace Common.Models.Amzn.Orders

    Public Class OrdersList
        Public Property Orders As List(Of Order)
        Public Property NextToken As String
        Public Property LastUpdatedBefore As String
        Public Property CreatedBefore As String
    End Class

End Namespace