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
    Public Partial Class PurchaseShipmentResult
        Implements IEquatable(Of PurchaseShipmentResult), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional shipmentId As ShipmentId = Nothing, ByVal Optional packageDocumentDetails As PackageDocumentDetailList = Nothing, ByVal Optional promise As Promise = Nothing)
            If shipmentId Is Nothing Then
                Throw New InvalidDataException("shipmentId is a required property for PurchaseShipmentResult and cannot be null")
            Else
                Me.ShipmentId = shipmentId
            End If

            If packageDocumentDetails Is Nothing Then
                Throw New InvalidDataException("packageDocumentDetails is a required property for PurchaseShipmentResult and cannot be null")
            Else
                Me.PackageDocumentDetails = packageDocumentDetails
            End If

            If promise Is Nothing Then
                Throw New InvalidDataException("promise is a required property for PurchaseShipmentResult and cannot be null")
            Else
                Me.Promise = promise
            End If
        End Sub

        <DataMember(Name:="shipmentId", EmitDefaultValue:=False)>
        Public Property ShipmentId As ShipmentId
        <DataMember(Name:="packageDocumentDetails", EmitDefaultValue:=False)>
        Public Property PackageDocumentDetails As PackageDocumentDetailList
        <DataMember(Name:="promise", EmitDefaultValue:=False)>
        Public Property Promise As Promise

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class PurchaseShipmentResult {" & vbLf)
            sb.Append("  ShipmentId: ").Append(ShipmentId).Append(vbLf)
            sb.Append("  PackageDocumentDetails: ").Append(PackageDocumentDetails).Append(vbLf)
            sb.Append("  Promise: ").Append(Promise).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, PurchaseShipmentResult))
        End Function

        Public Function Equals(ByVal input As PurchaseShipmentResult) As Boolean
            If input Is Nothing Then Return False
            Return (Me.ShipmentId = input.ShipmentId OrElse (Me.ShipmentId IsNot Nothing AndAlso Me.ShipmentId.Equals(input.ShipmentId))) AndAlso (Me.PackageDocumentDetails = input.PackageDocumentDetails OrElse (Me.PackageDocumentDetails IsNot Nothing AndAlso Me.PackageDocumentDetails.Equals(input.PackageDocumentDetails))) AndAlso (Me.Promise = input.Promise OrElse (Me.Promise IsNot Nothing AndAlso Me.Promise.Equals(input.Promise)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.ShipmentId IsNot Nothing Then hashCode = hashCode * 59 + Me.ShipmentId.GetHashCode()
            If Me.PackageDocumentDetails IsNot Nothing Then hashCode = hashCode * 59 + Me.PackageDocumentDetails.GetHashCode()
            If Me.Promise IsNot Nothing Then hashCode = hashCode * 59 + Me.Promise.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
