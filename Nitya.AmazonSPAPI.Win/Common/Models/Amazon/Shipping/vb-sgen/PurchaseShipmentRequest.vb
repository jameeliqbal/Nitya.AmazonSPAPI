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
    Public Partial Class PurchaseShipmentRequest
        Implements IEquatable(Of PurchaseShipmentRequest), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional requestToken As RequestToken = Nothing, ByVal Optional rateId As RateId = Nothing, ByVal Optional requestedDocumentSpecification As RequestedDocumentSpecification = Nothing, ByVal Optional requestedValueAddedServices As RequestedValueAddedServiceList = Nothing, ByVal Optional additionalInputs As Dictionary(Of String, Object) = Nothing)
            If requestToken Is Nothing Then
                Throw New InvalidDataException("requestToken is a required property for PurchaseShipmentRequest and cannot be null")
            Else
                Me.RequestToken = requestToken
            End If

            If rateId Is Nothing Then
                Throw New InvalidDataException("rateId is a required property for PurchaseShipmentRequest and cannot be null")
            Else
                Me.RateId = rateId
            End If

            If requestedDocumentSpecification Is Nothing Then
                Throw New InvalidDataException("requestedDocumentSpecification is a required property for PurchaseShipmentRequest and cannot be null")
            Else
                Me.RequestedDocumentSpecification = requestedDocumentSpecification
            End If

            Me.RequestedValueAddedServices = requestedValueAddedServices
            Me.AdditionalInputs = additionalInputs
        End Sub

        <DataMember(Name:="requestToken", EmitDefaultValue:=False)>
        Public Property RequestToken As RequestToken
        <DataMember(Name:="rateId", EmitDefaultValue:=False)>
        Public Property RateId As RateId
        <DataMember(Name:="requestedDocumentSpecification", EmitDefaultValue:=False)>
        Public Property RequestedDocumentSpecification As RequestedDocumentSpecification
        <DataMember(Name:="requestedValueAddedServices", EmitDefaultValue:=False)>
        Public Property RequestedValueAddedServices As RequestedValueAddedServiceList
        <DataMember(Name:="additionalInputs", EmitDefaultValue:=False)>
        Public Property AdditionalInputs As Dictionary(Of String, Object)

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class PurchaseShipmentRequest {" & vbLf)
            sb.Append("  RequestToken: ").Append(RequestToken).Append(vbLf)
            sb.Append("  RateId: ").Append(RateId).Append(vbLf)
            sb.Append("  RequestedDocumentSpecification: ").Append(RequestedDocumentSpecification).Append(vbLf)
            sb.Append("  RequestedValueAddedServices: ").Append(RequestedValueAddedServices).Append(vbLf)
            sb.Append("  AdditionalInputs: ").Append(AdditionalInputs).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, PurchaseShipmentRequest))
        End Function

        Public Function Equals(ByVal input As PurchaseShipmentRequest) As Boolean
            If input Is Nothing Then Return False
            Return (Me.RequestToken = input.RequestToken OrElse (Me.RequestToken IsNot Nothing AndAlso Me.RequestToken.Equals(input.RequestToken))) AndAlso (Me.RateId = input.RateId OrElse (Me.RateId IsNot Nothing AndAlso Me.RateId.Equals(input.RateId))) AndAlso (Me.RequestedDocumentSpecification = input.RequestedDocumentSpecification OrElse (Me.RequestedDocumentSpecification IsNot Nothing AndAlso Me.RequestedDocumentSpecification.Equals(input.RequestedDocumentSpecification))) AndAlso (Me.RequestedValueAddedServices = input.RequestedValueAddedServices OrElse (Me.RequestedValueAddedServices IsNot Nothing AndAlso Me.RequestedValueAddedServices.Equals(input.RequestedValueAddedServices))) AndAlso (Me.AdditionalInputs = input.AdditionalInputs OrElse Me.AdditionalInputs IsNot Nothing AndAlso Me.AdditionalInputs.SequenceEqual(input.AdditionalInputs))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.RequestToken IsNot Nothing Then hashCode = hashCode * 59 + Me.RequestToken.GetHashCode()
            If Me.RateId IsNot Nothing Then hashCode = hashCode * 59 + Me.RateId.GetHashCode()
            If Me.RequestedDocumentSpecification IsNot Nothing Then hashCode = hashCode * 59 + Me.RequestedDocumentSpecification.GetHashCode()
            If Me.RequestedValueAddedServices IsNot Nothing Then hashCode = hashCode * 59 + Me.RequestedValueAddedServices.GetHashCode()
            If Me.AdditionalInputs IsNot Nothing Then hashCode = hashCode * 59 + Me.AdditionalInputs.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
