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
    Public Partial Class GetTrackingResult
        Implements IEquatable(Of GetTrackingResult), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional trackingId As TrackingId = Nothing, ByVal Optional alternateLegTrackingId As AlternateLegTrackingId = Nothing, ByVal Optional eventHistory As List(Of [Event]) = Nothing, ByVal Optional promisedDeliveryDate As DateTime? = Nothing, ByVal Optional summary As TrackingSummary = Nothing)
            If trackingId Is Nothing Then
                Throw New InvalidDataException("trackingId is a required property for GetTrackingResult and cannot be null")
            Else
                Me.TrackingId = trackingId
            End If

            If alternateLegTrackingId Is Nothing Then
                Throw New InvalidDataException("alternateLegTrackingId is a required property for GetTrackingResult and cannot be null")
            Else
                Me.AlternateLegTrackingId = alternateLegTrackingId
            End If

            If eventHistory Is Nothing Then
                Throw New InvalidDataException("eventHistory is a required property for GetTrackingResult and cannot be null")
            Else
                Me.EventHistory = eventHistory
            End If

            If promisedDeliveryDate Is Nothing Then
                Throw New InvalidDataException("promisedDeliveryDate is a required property for GetTrackingResult and cannot be null")
            Else
                Me.PromisedDeliveryDate = promisedDeliveryDate
            End If

            If summary Is Nothing Then
                Throw New InvalidDataException("summary is a required property for GetTrackingResult and cannot be null")
            Else
                Me.Summary = summary
            End If
        End Sub

        <DataMember(Name:="trackingId", EmitDefaultValue:=False)>
        Public Property TrackingId As TrackingId
        <DataMember(Name:="alternateLegTrackingId", EmitDefaultValue:=False)>
        Public Property AlternateLegTrackingId As AlternateLegTrackingId
        <DataMember(Name:="eventHistory", EmitDefaultValue:=False)>
        Public Property EventHistory As List(Of [Event])
        <DataMember(Name:="promisedDeliveryDate", EmitDefaultValue:=False)>
        Public Property PromisedDeliveryDate As DateTime?
        <DataMember(Name:="summary", EmitDefaultValue:=False)>
        Public Property Summary As TrackingSummary

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class GetTrackingResult {" & vbLf)
            sb.Append("  TrackingId: ").Append(TrackingId).Append(vbLf)
            sb.Append("  AlternateLegTrackingId: ").Append(AlternateLegTrackingId).Append(vbLf)
            sb.Append("  EventHistory: ").Append(EventHistory).Append(vbLf)
            sb.Append("  PromisedDeliveryDate: ").Append(PromisedDeliveryDate).Append(vbLf)
            sb.Append("  Summary: ").Append(Summary).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, GetTrackingResult))
        End Function

        Public Function Equals(ByVal input As GetTrackingResult) As Boolean
            If input Is Nothing Then Return False
            Return (Me.TrackingId = input.TrackingId OrElse (Me.TrackingId IsNot Nothing AndAlso Me.TrackingId.Equals(input.TrackingId))) AndAlso (Me.AlternateLegTrackingId = input.AlternateLegTrackingId OrElse (Me.AlternateLegTrackingId IsNot Nothing AndAlso Me.AlternateLegTrackingId.Equals(input.AlternateLegTrackingId))) AndAlso (Me.EventHistory = input.EventHistory OrElse Me.EventHistory IsNot Nothing AndAlso Me.EventHistory.SequenceEqual(input.EventHistory)) AndAlso (Me.PromisedDeliveryDate = input.PromisedDeliveryDate OrElse (Me.PromisedDeliveryDate IsNot Nothing AndAlso Me.PromisedDeliveryDate.Equals(input.PromisedDeliveryDate))) AndAlso (Me.Summary = input.Summary OrElse (Me.Summary IsNot Nothing AndAlso Me.Summary.Equals(input.Summary)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.TrackingId IsNot Nothing Then hashCode = hashCode * 59 + Me.TrackingId.GetHashCode()
            If Me.AlternateLegTrackingId IsNot Nothing Then hashCode = hashCode * 59 + Me.AlternateLegTrackingId.GetHashCode()
            If Me.EventHistory IsNot Nothing Then hashCode = hashCode * 59 + Me.EventHistory.GetHashCode()
            If Me.PromisedDeliveryDate IsNot Nothing Then hashCode = hashCode * 59 + Me.PromisedDeliveryDate.GetHashCode()
            If Me.Summary IsNot Nothing Then hashCode = hashCode * 59 + Me.Summary.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
