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
    Public Partial Class TrackingSummary
        Implements IEquatable(Of TrackingSummary), IValidatableObject

        <DataMember(Name:="status", EmitDefaultValue:=False)>
        Public Property Status As Status?

        Public Sub New(ByVal Optional status As Status? = Nothing)
            Me.Status = status
        End Sub

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class TrackingSummary {" & vbLf)
            sb.Append("  Status: ").Append(Status).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, TrackingSummary))
        End Function

        Public Function Equals(ByVal input As TrackingSummary) As Boolean
            If input Is Nothing Then Return False
            Return (Me.Status = input.Status OrElse (Me.Status IsNot Nothing AndAlso Me.Status.Equals(input.Status)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.Status IsNot Nothing Then hashCode = hashCode * 59 + Me.Status.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
