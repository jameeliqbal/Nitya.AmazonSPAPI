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
    Public Partial Class PackageDocument
        Implements IEquatable(Of PackageDocument), IValidatableObject

        <DataMember(Name:="type", EmitDefaultValue:=False)>
        Public Property Type As DocumentType
        <DataMember(Name:="format", EmitDefaultValue:=False)>
        Public Property Format As DocumentFormat

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional type As DocumentType = Nothing, ByVal Optional format As DocumentFormat = Nothing, ByVal Optional contents As Contents = Nothing)
            If type Is Nothing Then
                Throw New InvalidDataException("type is a required property for PackageDocument and cannot be null")
            Else
                Me.Type = type
            End If

            If format Is Nothing Then
                Throw New InvalidDataException("format is a required property for PackageDocument and cannot be null")
            Else
                Me.Format = format
            End If

            If contents Is Nothing Then
                Throw New InvalidDataException("contents is a required property for PackageDocument and cannot be null")
            Else
                Me.Contents = contents
            End If
        End Sub

        <DataMember(Name:="contents", EmitDefaultValue:=False)>
        Public Property Contents As Contents

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class PackageDocument {" & vbLf)
            sb.Append("  Type: ").Append(Type).Append(vbLf)
            sb.Append("  Format: ").Append(Format).Append(vbLf)
            sb.Append("  Contents: ").Append(Contents).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, PackageDocument))
        End Function

        Public Function Equals(ByVal input As PackageDocument) As Boolean
            If input Is Nothing Then Return False
            Return (Me.Type = input.Type OrElse (Me.Type IsNot Nothing AndAlso Me.Type.Equals(input.Type))) AndAlso (Me.Format = input.Format OrElse (Me.Format IsNot Nothing AndAlso Me.Format.Equals(input.Format))) AndAlso (Me.Contents = input.Contents OrElse (Me.Contents IsNot Nothing AndAlso Me.Contents.Equals(input.Contents)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.Type IsNot Nothing Then hashCode = hashCode * 59 + Me.Type.GetHashCode()
            If Me.Format IsNot Nothing Then hashCode = hashCode * 59 + Me.Format.GetHashCode()
            If Me.Contents IsNot Nothing Then hashCode = hashCode * 59 + Me.Contents.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
