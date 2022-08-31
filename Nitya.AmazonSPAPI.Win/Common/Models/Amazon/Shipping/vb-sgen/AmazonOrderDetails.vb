Imports System
Imports System.Linq
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Runtime.Serialization
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Converters
Imports System.ComponentModel.DataAnnotations
Imports SwaggerDateConverter = Amazon.SellingPartnerAPI.Orders.Client.SwaggerDateConverter

Namespace Common.Models.Amzn.Shipping
    <DataContract>
    Public Partial Class AmazonOrderDetails
        Implements IEquatable(Of AmazonOrderDetails), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional orderId As String = Nothing)
            If orderId Is Nothing Then
                Throw New InvalidDataException("orderId is a required property for AmazonOrderDetails and cannot be null")
            Else
                Me.OrderId = orderId
            End If
        End Sub

        <DataMember(Name:="orderId", EmitDefaultValue:=False)>
        Public Property OrderId As String

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class AmazonOrderDetails {" & vbLf)
            sb.Append("  OrderId: ").Append(OrderId).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, AmazonOrderDetails))
        End Function

        Public Function Equals(ByVal input As AmazonOrderDetails) As Boolean
            If input Is Nothing Then Return False
            Return (Me.OrderId = input.OrderId OrElse (Me.OrderId IsNot Nothing AndAlso Me.OrderId.Equals(input.OrderId)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.OrderId IsNot Nothing Then hashCode = hashCode * 59 + Me.OrderId.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
