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
    Public Partial Class [Event]
        Implements IEquatable(Of [Event]), IValidatableObject

        <DataMember(Name:="eventCode", EmitDefaultValue:=False)>
        Public Property EventCode As EventCode

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional eventCode As EventCode = Nothing, ByVal Optional location As Location = Nothing, ByVal Optional eventTime As DateTime? = Nothing)
            If eventCode Is Nothing Then
                Throw New InvalidDataException("eventCode is a required property for Event and cannot be null")
            Else
                Me.EventCode = eventCode
            End If

            If eventTime Is Nothing Then
                Throw New InvalidDataException("eventTime is a required property for Event and cannot be null")
            Else
                Me.EventTime = eventTime
            End If

            Me.Location = location
        End Sub

        <DataMember(Name:="location", EmitDefaultValue:=False)>
        Public Property Location As Location
        <DataMember(Name:="eventTime", EmitDefaultValue:=False)>
        Public Property EventTime As DateTime?

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class Event {" & vbLf)
            sb.Append("  EventCode: ").Append(EventCode).Append(vbLf)
            sb.Append("  Location: ").Append(Location).Append(vbLf)
            sb.Append("  EventTime: ").Append(EventTime).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, [Event]))
        End Function

        Public Function Equals(ByVal input As [Event]) As Boolean
            If input Is Nothing Then Return False
            Return (Me.EventCode = input.EventCode OrElse (Me.EventCode IsNot Nothing AndAlso Me.EventCode.Equals(input.EventCode))) AndAlso (Me.Location = input.Location OrElse (Me.Location IsNot Nothing AndAlso Me.Location.Equals(input.Location))) AndAlso (Me.EventTime = input.EventTime OrElse (Me.EventTime IsNot Nothing AndAlso Me.EventTime.Equals(input.EventTime)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.EventCode IsNot Nothing Then hashCode = hashCode * 59 + Me.EventCode.GetHashCode()
            If Me.Location IsNot Nothing Then hashCode = hashCode * 59 + Me.Location.GetHashCode()
            If Me.EventTime IsNot Nothing Then hashCode = hashCode * 59 + Me.EventTime.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
