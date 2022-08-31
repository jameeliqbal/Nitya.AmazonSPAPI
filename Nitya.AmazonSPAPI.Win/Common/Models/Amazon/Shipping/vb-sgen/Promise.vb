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
    Public Partial Class Promise
        Implements IEquatable(Of Promise), IValidatableObject

        Public Sub New(ByVal Optional deliveryWindow As TimeWindow = Nothing, ByVal Optional pickupWindow As TimeWindow = Nothing)
            Me.DeliveryWindow = deliveryWindow
            Me.PickupWindow = pickupWindow
        End Sub

        <DataMember(Name:="deliveryWindow", EmitDefaultValue:=False)>
        Public Property DeliveryWindow As TimeWindow
        <DataMember(Name:="pickupWindow", EmitDefaultValue:=False)>
        Public Property PickupWindow As TimeWindow

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class Promise {" & vbLf)
            sb.Append("  DeliveryWindow: ").Append(DeliveryWindow).Append(vbLf)
            sb.Append("  PickupWindow: ").Append(PickupWindow).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, Promise))
        End Function

        Public Function Equals(ByVal input As Promise) As Boolean
            If input Is Nothing Then Return False
            Return (Me.DeliveryWindow = input.DeliveryWindow OrElse (Me.DeliveryWindow IsNot Nothing AndAlso Me.DeliveryWindow.Equals(input.DeliveryWindow))) AndAlso (Me.PickupWindow = input.PickupWindow OrElse (Me.PickupWindow IsNot Nothing AndAlso Me.PickupWindow.Equals(input.PickupWindow)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.DeliveryWindow IsNot Nothing Then hashCode = hashCode * 59 + Me.DeliveryWindow.GetHashCode()
            If Me.PickupWindow IsNot Nothing Then hashCode = hashCode * 59 + Me.PickupWindow.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
