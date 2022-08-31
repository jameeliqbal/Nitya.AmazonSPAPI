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
    Public Partial Class TimeWindow
        Implements IEquatable(Of TimeWindow), IValidatableObject

        Public Sub New(ByVal Optional startTime As DateTime? = Nothing, ByVal Optional endTime As DateTime? = Nothing)
            Me.StartTime = startTime
            Me.EndTime = endTime
        End Sub

        <DataMember(Name:="startTime", EmitDefaultValue:=False)>
        Public Property StartTime As DateTime?
        <DataMember(Name:="endTime", EmitDefaultValue:=False)>
        Public Property EndTime As DateTime?

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class TimeWindow {" & vbLf)
            sb.Append("  StartTime: ").Append(StartTime).Append(vbLf)
            sb.Append("  EndTime: ").Append(EndTime).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, TimeWindow))
        End Function

        Public Function Equals(ByVal input As TimeWindow) As Boolean
            If input Is Nothing Then Return False
            Return (Me.StartTime = input.StartTime OrElse (Me.StartTime IsNot Nothing AndAlso Me.StartTime.Equals(input.StartTime))) AndAlso (Me.EndTime = input.EndTime OrElse (Me.EndTime IsNot Nothing AndAlso Me.EndTime.Equals(input.EndTime)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.StartTime IsNot Nothing Then hashCode = hashCode * 59 + Me.StartTime.GetHashCode()
            If Me.EndTime IsNot Nothing Then hashCode = hashCode * 59 + Me.EndTime.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
