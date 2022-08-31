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
    Public Partial Class SupportedDocumentDetail
        Implements IEquatable(Of SupportedDocumentDetail), IValidatableObject

        <DataMember(Name:="name", EmitDefaultValue:=False)>
        Public Property Name As DocumentType

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional name As DocumentType = Nothing, ByVal Optional isMandatory As Boolean? = Nothing)
            If name Is Nothing Then
                Throw New InvalidDataException("name is a required property for SupportedDocumentDetail and cannot be null")
            Else
                Me.Name = name
            End If

            If isMandatory Is Nothing Then
                Throw New InvalidDataException("isMandatory is a required property for SupportedDocumentDetail and cannot be null")
            Else
                Me.IsMandatory = isMandatory
            End If
        End Sub

        <DataMember(Name:="isMandatory", EmitDefaultValue:=False)>
        Public Property IsMandatory As Boolean?

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class SupportedDocumentDetail {" & vbLf)
            sb.Append("  Name: ").Append(Name).Append(vbLf)
            sb.Append("  IsMandatory: ").Append(IsMandatory).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, SupportedDocumentDetail))
        End Function

        Public Function Equals(ByVal input As SupportedDocumentDetail) As Boolean
            If input Is Nothing Then Return False
            Return (Me.Name = input.Name OrElse (Me.Name IsNot Nothing AndAlso Me.Name.Equals(input.Name))) AndAlso (Me.IsMandatory = input.IsMandatory OrElse (Me.IsMandatory IsNot Nothing AndAlso Me.IsMandatory.Equals(input.IsMandatory)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.Name IsNot Nothing Then hashCode = hashCode * 59 + Me.Name.GetHashCode()
            If Me.IsMandatory IsNot Nothing Then hashCode = hashCode * 59 + Me.IsMandatory.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
