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
    Public Partial Class DirectPurchaseRequest
        Implements IEquatable(Of DirectPurchaseRequest), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional shipTo As Address = Nothing, ByVal Optional shipFrom As Address = Nothing, ByVal Optional returnTo As Address = Nothing, ByVal Optional packages As PackageList = Nothing, ByVal Optional channelDetails As ChannelDetails = Nothing, ByVal Optional labelSpecifications As RequestedDocumentSpecification = Nothing)
            If channelDetails Is Nothing Then
                Throw New InvalidDataException("channelDetails is a required property for DirectPurchaseRequest and cannot be null")
            Else
                Me.ChannelDetails = channelDetails
            End If

            Me.ShipTo = shipTo
            Me.ShipFrom = shipFrom
            Me.ReturnTo = returnTo
            Me.Packages = packages
            Me.LabelSpecifications = labelSpecifications
        End Sub

        <DataMember(Name:="shipTo", EmitDefaultValue:=False)>
        Public Property ShipTo As Address
        <DataMember(Name:="shipFrom", EmitDefaultValue:=False)>
        Public Property ShipFrom As Address
        <DataMember(Name:="returnTo", EmitDefaultValue:=False)>
        Public Property ReturnTo As Address
        <DataMember(Name:="packages", EmitDefaultValue:=False)>
        Public Property Packages As PackageList
        <DataMember(Name:="channelDetails", EmitDefaultValue:=False)>
        Public Property ChannelDetails As ChannelDetails
        <DataMember(Name:="labelSpecifications", EmitDefaultValue:=False)>
        Public Property LabelSpecifications As RequestedDocumentSpecification

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class DirectPurchaseRequest {" & vbLf)
            sb.Append("  ShipTo: ").Append(ShipTo).Append(vbLf)
            sb.Append("  ShipFrom: ").Append(ShipFrom).Append(vbLf)
            sb.Append("  ReturnTo: ").Append(ReturnTo).Append(vbLf)
            sb.Append("  Packages: ").Append(Packages).Append(vbLf)
            sb.Append("  ChannelDetails: ").Append(ChannelDetails).Append(vbLf)
            sb.Append("  LabelSpecifications: ").Append(LabelSpecifications).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, DirectPurchaseRequest))
        End Function

        Public Function Equals(ByVal input As DirectPurchaseRequest) As Boolean
            If input Is Nothing Then Return False
            Return (Me.ShipTo = input.ShipTo OrElse (Me.ShipTo IsNot Nothing AndAlso Me.ShipTo.Equals(input.ShipTo))) AndAlso (Me.ShipFrom = input.ShipFrom OrElse (Me.ShipFrom IsNot Nothing AndAlso Me.ShipFrom.Equals(input.ShipFrom))) AndAlso (Me.ReturnTo = input.ReturnTo OrElse (Me.ReturnTo IsNot Nothing AndAlso Me.ReturnTo.Equals(input.ReturnTo))) AndAlso (Me.Packages = input.Packages OrElse (Me.Packages IsNot Nothing AndAlso Me.Packages.Equals(input.Packages))) AndAlso (Me.ChannelDetails = input.ChannelDetails OrElse (Me.ChannelDetails IsNot Nothing AndAlso Me.ChannelDetails.Equals(input.ChannelDetails))) AndAlso (Me.LabelSpecifications = input.LabelSpecifications OrElse (Me.LabelSpecifications IsNot Nothing AndAlso Me.LabelSpecifications.Equals(input.LabelSpecifications)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.ShipTo IsNot Nothing Then hashCode = hashCode * 59 + Me.ShipTo.GetHashCode()
            If Me.ShipFrom IsNot Nothing Then hashCode = hashCode * 59 + Me.ShipFrom.GetHashCode()
            If Me.ReturnTo IsNot Nothing Then hashCode = hashCode * 59 + Me.ReturnTo.GetHashCode()
            If Me.Packages IsNot Nothing Then hashCode = hashCode * 59 + Me.Packages.GetHashCode()
            If Me.ChannelDetails IsNot Nothing Then hashCode = hashCode * 59 + Me.ChannelDetails.GetHashCode()
            If Me.LabelSpecifications IsNot Nothing Then hashCode = hashCode * 59 + Me.LabelSpecifications.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
