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
    Public Partial Class IneligibleRate
        Implements IEquatable(Of IneligibleRate), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional serviceId As ServiceId = Nothing, ByVal Optional serviceName As ServiceName = Nothing, ByVal Optional carrierName As CarrierName = Nothing, ByVal Optional carrierId As CarrierId = Nothing, ByVal Optional ineligibilityReasons As List(Of IneligibilityReason) = Nothing)
            If serviceId Is Nothing Then
                Throw New InvalidDataException("serviceId is a required property for IneligibleRate and cannot be null")
            Else
                Me.ServiceId = serviceId
            End If

            If serviceName Is Nothing Then
                Throw New InvalidDataException("serviceName is a required property for IneligibleRate and cannot be null")
            Else
                Me.ServiceName = serviceName
            End If

            If carrierName Is Nothing Then
                Throw New InvalidDataException("carrierName is a required property for IneligibleRate and cannot be null")
            Else
                Me.CarrierName = carrierName
            End If

            If carrierId Is Nothing Then
                Throw New InvalidDataException("carrierId is a required property for IneligibleRate and cannot be null")
            Else
                Me.CarrierId = carrierId
            End If

            If ineligibilityReasons Is Nothing Then
                Throw New InvalidDataException("ineligibilityReasons is a required property for IneligibleRate and cannot be null")
            Else
                Me.IneligibilityReasons = ineligibilityReasons
            End If
        End Sub

        <DataMember(Name:="serviceId", EmitDefaultValue:=False)>
        Public Property ServiceId As ServiceId
        <DataMember(Name:="serviceName", EmitDefaultValue:=False)>
        Public Property ServiceName As ServiceName
        <DataMember(Name:="carrierName", EmitDefaultValue:=False)>
        Public Property CarrierName As CarrierName
        <DataMember(Name:="carrierId", EmitDefaultValue:=False)>
        Public Property CarrierId As CarrierId
        <DataMember(Name:="ineligibilityReasons", EmitDefaultValue:=False)>
        Public Property IneligibilityReasons As List(Of IneligibilityReason)

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class IneligibleRate {" & vbLf)
            sb.Append("  ServiceId: ").Append(ServiceId).Append(vbLf)
            sb.Append("  ServiceName: ").Append(ServiceName).Append(vbLf)
            sb.Append("  CarrierName: ").Append(CarrierName).Append(vbLf)
            sb.Append("  CarrierId: ").Append(CarrierId).Append(vbLf)
            sb.Append("  IneligibilityReasons: ").Append(IneligibilityReasons).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, IneligibleRate))
        End Function

        Public Function Equals(ByVal input As IneligibleRate) As Boolean
            If input Is Nothing Then Return False
            Return (Me.ServiceId = input.ServiceId OrElse (Me.ServiceId IsNot Nothing AndAlso Me.ServiceId.Equals(input.ServiceId))) AndAlso (Me.ServiceName = input.ServiceName OrElse (Me.ServiceName IsNot Nothing AndAlso Me.ServiceName.Equals(input.ServiceName))) AndAlso (Me.CarrierName = input.CarrierName OrElse (Me.CarrierName IsNot Nothing AndAlso Me.CarrierName.Equals(input.CarrierName))) AndAlso (Me.CarrierId = input.CarrierId OrElse (Me.CarrierId IsNot Nothing AndAlso Me.CarrierId.Equals(input.CarrierId))) AndAlso (Me.IneligibilityReasons = input.IneligibilityReasons OrElse Me.IneligibilityReasons IsNot Nothing AndAlso Me.IneligibilityReasons.SequenceEqual(input.IneligibilityReasons))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.ServiceId IsNot Nothing Then hashCode = hashCode * 59 + Me.ServiceId.GetHashCode()
            If Me.ServiceName IsNot Nothing Then hashCode = hashCode * 59 + Me.ServiceName.GetHashCode()
            If Me.CarrierName IsNot Nothing Then hashCode = hashCode * 59 + Me.CarrierName.GetHashCode()
            If Me.CarrierId IsNot Nothing Then hashCode = hashCode * 59 + Me.CarrierId.GetHashCode()
            If Me.IneligibilityReasons IsNot Nothing Then hashCode = hashCode * 59 + Me.IneligibilityReasons.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
