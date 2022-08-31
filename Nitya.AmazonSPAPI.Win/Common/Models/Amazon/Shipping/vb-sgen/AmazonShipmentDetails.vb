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
    Public Partial Class AmazonShipmentDetails
        Implements IEquatable(Of AmazonShipmentDetails), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional shipmentId As String = Nothing)
            If shipmentId Is Nothing Then
                Throw New InvalidDataException("shipmentId is a required property for AmazonShipmentDetails and cannot be null")
            Else
                Me.ShipmentId = shipmentId
            End If
        End Sub

        <DataMember(Name:="shipmentId", EmitDefaultValue:=False)>
        Public Property ShipmentId As String

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class AmazonShipmentDetails {" & vbLf)
            sb.Append("  ShipmentId: ").Append(ShipmentId).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, AmazonShipmentDetails))
        End Function

        Public Function Equals(ByVal input As AmazonShipmentDetails) As Boolean
            If input Is Nothing Then Return False
            Return (Me.ShipmentId = input.ShipmentId OrElse (Me.ShipmentId IsNot Nothing AndAlso Me.ShipmentId.Equals(input.ShipmentId)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.ShipmentId IsNot Nothing Then hashCode = hashCode * 59 + Me.ShipmentId.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
