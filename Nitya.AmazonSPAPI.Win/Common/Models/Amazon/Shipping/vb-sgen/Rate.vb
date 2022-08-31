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
    Public Partial Class Rate
        Implements IEquatable(Of Rate), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional rateId As RateId = Nothing, ByVal Optional carrierId As CarrierId = Nothing, ByVal Optional carrierName As CarrierName = Nothing, ByVal Optional serviceId As ServiceId = Nothing, ByVal Optional serviceName As ServiceName = Nothing, ByVal Optional billedWeight As Weight = Nothing, ByVal Optional totalCharge As Currency = Nothing, ByVal Optional promise As Promise = Nothing, ByVal Optional supportedDocumentSpecifications As SupportedDocumentSpecificationList = Nothing, ByVal Optional availableValueAddedServiceGroups As AvailableValueAddedServiceGroupList = Nothing, ByVal Optional requiresAdditionalInputs As Boolean? = Nothing)
            If rateId Is Nothing Then
                Throw New InvalidDataException("rateId is a required property for Rate and cannot be null")
            Else
                Me.RateId = rateId
            End If

            If carrierId Is Nothing Then
                Throw New InvalidDataException("carrierId is a required property for Rate and cannot be null")
            Else
                Me.CarrierId = carrierId
            End If

            If carrierName Is Nothing Then
                Throw New InvalidDataException("carrierName is a required property for Rate and cannot be null")
            Else
                Me.CarrierName = carrierName
            End If

            If serviceId Is Nothing Then
                Throw New InvalidDataException("serviceId is a required property for Rate and cannot be null")
            Else
                Me.ServiceId = serviceId
            End If

            If serviceName Is Nothing Then
                Throw New InvalidDataException("serviceName is a required property for Rate and cannot be null")
            Else
                Me.ServiceName = serviceName
            End If

            If totalCharge Is Nothing Then
                Throw New InvalidDataException("totalCharge is a required property for Rate and cannot be null")
            Else
                Me.TotalCharge = totalCharge
            End If

            If promise Is Nothing Then
                Throw New InvalidDataException("promise is a required property for Rate and cannot be null")
            Else
                Me.Promise = promise
            End If

            If supportedDocumentSpecifications Is Nothing Then
                Throw New InvalidDataException("supportedDocumentSpecifications is a required property for Rate and cannot be null")
            Else
                Me.SupportedDocumentSpecifications = supportedDocumentSpecifications
            End If

            If requiresAdditionalInputs Is Nothing Then
                Throw New InvalidDataException("requiresAdditionalInputs is a required property for Rate and cannot be null")
            Else
                Me.RequiresAdditionalInputs = requiresAdditionalInputs
            End If

            Me.BilledWeight = billedWeight
            Me.AvailableValueAddedServiceGroups = availableValueAddedServiceGroups
        End Sub

        <DataMember(Name:="rateId", EmitDefaultValue:=False)>
        Public Property RateId As RateId
        <DataMember(Name:="carrierId", EmitDefaultValue:=False)>
        Public Property CarrierId As CarrierId
        <DataMember(Name:="carrierName", EmitDefaultValue:=False)>
        Public Property CarrierName As CarrierName
        <DataMember(Name:="serviceId", EmitDefaultValue:=False)>
        Public Property ServiceId As ServiceId
        <DataMember(Name:="serviceName", EmitDefaultValue:=False)>
        Public Property ServiceName As ServiceName
        <DataMember(Name:="billedWeight", EmitDefaultValue:=False)>
        Public Property BilledWeight As Weight
        <DataMember(Name:="totalCharge", EmitDefaultValue:=False)>
        Public Property TotalCharge As Currency
        <DataMember(Name:="promise", EmitDefaultValue:=False)>
        Public Property Promise As Promise
        <DataMember(Name:="supportedDocumentSpecifications", EmitDefaultValue:=False)>
        Public Property SupportedDocumentSpecifications As SupportedDocumentSpecificationList
        <DataMember(Name:="availableValueAddedServiceGroups", EmitDefaultValue:=False)>
        Public Property AvailableValueAddedServiceGroups As AvailableValueAddedServiceGroupList
        <DataMember(Name:="requiresAdditionalInputs", EmitDefaultValue:=False)>
        Public Property RequiresAdditionalInputs As Boolean?

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class Rate {" & vbLf)
            sb.Append("  RateId: ").Append(RateId).Append(vbLf)
            sb.Append("  CarrierId: ").Append(CarrierId).Append(vbLf)
            sb.Append("  CarrierName: ").Append(CarrierName).Append(vbLf)
            sb.Append("  ServiceId: ").Append(ServiceId).Append(vbLf)
            sb.Append("  ServiceName: ").Append(ServiceName).Append(vbLf)
            sb.Append("  BilledWeight: ").Append(BilledWeight).Append(vbLf)
            sb.Append("  TotalCharge: ").Append(TotalCharge).Append(vbLf)
            sb.Append("  Promise: ").Append(Promise).Append(vbLf)
            sb.Append("  SupportedDocumentSpecifications: ").Append(SupportedDocumentSpecifications).Append(vbLf)
            sb.Append("  AvailableValueAddedServiceGroups: ").Append(AvailableValueAddedServiceGroups).Append(vbLf)
            sb.Append("  RequiresAdditionalInputs: ").Append(RequiresAdditionalInputs).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, Rate))
        End Function

        Public Function Equals(ByVal input As Rate) As Boolean
            If input Is Nothing Then Return False
            Return (Me.RateId = input.RateId OrElse (Me.RateId IsNot Nothing AndAlso Me.RateId.Equals(input.RateId))) AndAlso (Me.CarrierId = input.CarrierId OrElse (Me.CarrierId IsNot Nothing AndAlso Me.CarrierId.Equals(input.CarrierId))) AndAlso (Me.CarrierName = input.CarrierName OrElse (Me.CarrierName IsNot Nothing AndAlso Me.CarrierName.Equals(input.CarrierName))) AndAlso (Me.ServiceId = input.ServiceId OrElse (Me.ServiceId IsNot Nothing AndAlso Me.ServiceId.Equals(input.ServiceId))) AndAlso (Me.ServiceName = input.ServiceName OrElse (Me.ServiceName IsNot Nothing AndAlso Me.ServiceName.Equals(input.ServiceName))) AndAlso (Me.BilledWeight = input.BilledWeight OrElse (Me.BilledWeight IsNot Nothing AndAlso Me.BilledWeight.Equals(input.BilledWeight))) AndAlso (Me.TotalCharge = input.TotalCharge OrElse (Me.TotalCharge IsNot Nothing AndAlso Me.TotalCharge.Equals(input.TotalCharge))) AndAlso (Me.Promise = input.Promise OrElse (Me.Promise IsNot Nothing AndAlso Me.Promise.Equals(input.Promise))) AndAlso (Me.SupportedDocumentSpecifications = input.SupportedDocumentSpecifications OrElse (Me.SupportedDocumentSpecifications IsNot Nothing AndAlso Me.SupportedDocumentSpecifications.Equals(input.SupportedDocumentSpecifications))) AndAlso (Me.AvailableValueAddedServiceGroups = input.AvailableValueAddedServiceGroups OrElse (Me.AvailableValueAddedServiceGroups IsNot Nothing AndAlso Me.AvailableValueAddedServiceGroups.Equals(input.AvailableValueAddedServiceGroups))) AndAlso (Me.RequiresAdditionalInputs = input.RequiresAdditionalInputs OrElse (Me.RequiresAdditionalInputs IsNot Nothing AndAlso Me.RequiresAdditionalInputs.Equals(input.RequiresAdditionalInputs)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.RateId IsNot Nothing Then hashCode = hashCode * 59 + Me.RateId.GetHashCode()
            If Me.CarrierId IsNot Nothing Then hashCode = hashCode * 59 + Me.CarrierId.GetHashCode()
            If Me.CarrierName IsNot Nothing Then hashCode = hashCode * 59 + Me.CarrierName.GetHashCode()
            If Me.ServiceId IsNot Nothing Then hashCode = hashCode * 59 + Me.ServiceId.GetHashCode()
            If Me.ServiceName IsNot Nothing Then hashCode = hashCode * 59 + Me.ServiceName.GetHashCode()
            If Me.BilledWeight IsNot Nothing Then hashCode = hashCode * 59 + Me.BilledWeight.GetHashCode()
            If Me.TotalCharge IsNot Nothing Then hashCode = hashCode * 59 + Me.TotalCharge.GetHashCode()
            If Me.Promise IsNot Nothing Then hashCode = hashCode * 59 + Me.Promise.GetHashCode()
            If Me.SupportedDocumentSpecifications IsNot Nothing Then hashCode = hashCode * 59 + Me.SupportedDocumentSpecifications.GetHashCode()
            If Me.AvailableValueAddedServiceGroups IsNot Nothing Then hashCode = hashCode * 59 + Me.AvailableValueAddedServiceGroups.GetHashCode()
            If Me.RequiresAdditionalInputs IsNot Nothing Then hashCode = hashCode * 59 + Me.RequiresAdditionalInputs.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
