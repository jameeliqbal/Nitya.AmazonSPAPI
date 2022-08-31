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
    Public Partial Class GetTrackingResponse
        Implements IEquatable(Of GetTrackingResponse), IValidatableObject

        Public Sub New(ByVal Optional payload As GetTrackingResult = Nothing)
            Me.Payload = payload
        End Sub

        <DataMember(Name:="payload", EmitDefaultValue:=False)>
        Public Property Payload As GetTrackingResult

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class GetTrackingResponse {" & vbLf)
            sb.Append("  Payload: ").Append(Payload).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, GetTrackingResponse))
        End Function

        Public Function Equals(ByVal input As GetTrackingResponse) As Boolean
            If input Is Nothing Then Return False
            Return (Me.Payload = input.Payload OrElse (Me.Payload IsNot Nothing AndAlso Me.Payload.Equals(input.Payload)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.Payload IsNot Nothing Then hashCode = hashCode * 59 + Me.Payload.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
