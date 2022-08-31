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
    Public Partial Class [Error]
        Implements IEquatable(Of [Error]), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional code As String = Nothing, ByVal Optional message As String = Nothing, ByVal Optional details As String = Nothing)
            If code Is Nothing Then
                Throw New InvalidDataException("code is a required property for Error and cannot be null")
            Else
                Me.Code = code
            End If

            If message Is Nothing Then
                Throw New InvalidDataException("message is a required property for Error and cannot be null")
            Else
                Me.Message = message
            End If

            Me.Details = details
        End Sub

        <DataMember(Name:="code", EmitDefaultValue:=False)>
        Public Property Code As String
        <DataMember(Name:="message", EmitDefaultValue:=False)>
        Public Property Message As String
        <DataMember(Name:="details", EmitDefaultValue:=False)>
        Public Property Details As String

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class Error {" & vbLf)
            sb.Append("  Code: ").Append(Code).Append(vbLf)
            sb.Append("  Message: ").Append(Message).Append(vbLf)
            sb.Append("  Details: ").Append(Details).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, [Error]))
        End Function

        Public Function Equals(ByVal input As [Error]) As Boolean
            If input Is Nothing Then Return False
            Return (Me.Code = input.Code OrElse (Me.Code IsNot Nothing AndAlso Me.Code.Equals(input.Code))) AndAlso (Me.Message = input.Message OrElse (Me.Message IsNot Nothing AndAlso Me.Message.Equals(input.Message))) AndAlso (Me.Details = input.Details OrElse (Me.Details IsNot Nothing AndAlso Me.Details.Equals(input.Details)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.Code IsNot Nothing Then hashCode = hashCode * 59 + Me.Code.GetHashCode()
            If Me.Message IsNot Nothing Then hashCode = hashCode * 59 + Me.Message.GetHashCode()
            If Me.Details IsNot Nothing Then hashCode = hashCode * 59 + Me.Details.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
