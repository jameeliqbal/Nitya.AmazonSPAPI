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
    Public Partial Class CollectOnDelivery
        Implements IEquatable(Of CollectOnDelivery), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional amount As Currency = Nothing)
            If amount Is Nothing Then
                Throw New InvalidDataException("amount is a required property for CollectOnDelivery and cannot be null")
            Else
                Me.Amount = amount
            End If
        End Sub

        <DataMember(Name:="amount", EmitDefaultValue:=False)>
        Public Property Amount As Currency

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class CollectOnDelivery {" & vbLf)
            sb.Append("  Amount: ").Append(Amount).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, CollectOnDelivery))
        End Function

        Public Function Equals(ByVal input As CollectOnDelivery) As Boolean
            If input Is Nothing Then Return False
            Return (Me.Amount = input.Amount OrElse (Me.Amount IsNot Nothing AndAlso Me.Amount.Equals(input.Amount)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.Amount IsNot Nothing Then hashCode = hashCode * 59 + Me.Amount.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
