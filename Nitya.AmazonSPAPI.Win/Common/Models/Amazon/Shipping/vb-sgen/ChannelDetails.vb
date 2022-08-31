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
    Public Partial Class ChannelDetails
        Implements IEquatable(Of ChannelDetails), IValidatableObject

        <JsonConverter(GetType(StringEnumConverter))>
        Public Enum ChannelTypeEnum
            <EnumMember(Value:="AMAZON")>
            AMAZON = 1
            <EnumMember(Value:="EXTERNAL")>
            EXTERNAL = 2
        End Enum

        <DataMember(Name:="channelType", EmitDefaultValue:=False)>
        Public Property ChannelType As ChannelTypeEnum

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional channelType As ChannelTypeEnum = Nothing, ByVal Optional amazonOrderDetails As AmazonOrderDetails = Nothing, ByVal Optional amazonShipmentDetails As AmazonShipmentDetails = Nothing)
            If channelType Is Nothing Then
                Throw New InvalidDataException("channelType is a required property for ChannelDetails and cannot be null")
            Else
                Me.ChannelType = channelType
            End If

            Me.AmazonOrderDetails = amazonOrderDetails
            Me.AmazonShipmentDetails = amazonShipmentDetails
        End Sub

        <DataMember(Name:="amazonOrderDetails", EmitDefaultValue:=False)>
        Public Property AmazonOrderDetails As AmazonOrderDetails
        <DataMember(Name:="amazonShipmentDetails", EmitDefaultValue:=False)>
        Public Property AmazonShipmentDetails As AmazonShipmentDetails

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class ChannelDetails {" & vbLf)
            sb.Append("  ChannelType: ").Append(ChannelType).Append(vbLf)
            sb.Append("  AmazonOrderDetails: ").Append(AmazonOrderDetails).Append(vbLf)
            sb.Append("  AmazonShipmentDetails: ").Append(AmazonShipmentDetails).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, ChannelDetails))
        End Function

        Public Function Equals(ByVal input As ChannelDetails) As Boolean
            If input Is Nothing Then Return False
            Return (Me.ChannelType = input.ChannelType OrElse (Me.ChannelType IsNot Nothing AndAlso Me.ChannelType.Equals(input.ChannelType))) AndAlso (Me.AmazonOrderDetails = input.AmazonOrderDetails OrElse (Me.AmazonOrderDetails IsNot Nothing AndAlso Me.AmazonOrderDetails.Equals(input.AmazonOrderDetails))) AndAlso (Me.AmazonShipmentDetails = input.AmazonShipmentDetails OrElse (Me.AmazonShipmentDetails IsNot Nothing AndAlso Me.AmazonShipmentDetails.Equals(input.AmazonShipmentDetails)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.ChannelType IsNot Nothing Then hashCode = hashCode * 59 + Me.ChannelType.GetHashCode()
            If Me.AmazonOrderDetails IsNot Nothing Then hashCode = hashCode * 59 + Me.AmazonOrderDetails.GetHashCode()
            If Me.AmazonShipmentDetails IsNot Nothing Then hashCode = hashCode * 59 + Me.AmazonShipmentDetails.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
