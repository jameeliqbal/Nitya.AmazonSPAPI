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
    Public Partial Class ValueAddedServiceDetails
        Implements IEquatable(Of ValueAddedServiceDetails), IValidatableObject

        Public Sub New(ByVal Optional collectOnDelivery As CollectOnDelivery = Nothing)
            Me.CollectOnDelivery = collectOnDelivery
        End Sub

        <DataMember(Name:="collectOnDelivery", EmitDefaultValue:=False)>
        Public Property CollectOnDelivery As CollectOnDelivery

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class ValueAddedServiceDetails {" & vbLf)
            sb.Append("  CollectOnDelivery: ").Append(CollectOnDelivery).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, ValueAddedServiceDetails))
        End Function

        Public Function Equals(ByVal input As ValueAddedServiceDetails) As Boolean
            If input Is Nothing Then Return False
            Return (Me.CollectOnDelivery = input.CollectOnDelivery OrElse (Me.CollectOnDelivery IsNot Nothing AndAlso Me.CollectOnDelivery.Equals(input.CollectOnDelivery)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.CollectOnDelivery IsNot Nothing Then hashCode = hashCode * 59 + Me.CollectOnDelivery.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
