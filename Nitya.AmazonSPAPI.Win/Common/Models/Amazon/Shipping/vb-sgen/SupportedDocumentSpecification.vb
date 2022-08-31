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
    Public Partial Class SupportedDocumentSpecification
        Implements IEquatable(Of SupportedDocumentSpecification), IValidatableObject

        <DataMember(Name:="format", EmitDefaultValue:=False)>
        Public Property Format As DocumentFormat

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional format As DocumentFormat = Nothing, ByVal Optional size As DocumentSize = Nothing, ByVal Optional printOptions As PrintOptionList = Nothing)
            If format Is Nothing Then
                Throw New InvalidDataException("format is a required property for SupportedDocumentSpecification and cannot be null")
            Else
                Me.Format = format
            End If

            If size Is Nothing Then
                Throw New InvalidDataException("size is a required property for SupportedDocumentSpecification and cannot be null")
            Else
                Me.Size = size
            End If

            If printOptions Is Nothing Then
                Throw New InvalidDataException("printOptions is a required property for SupportedDocumentSpecification and cannot be null")
            Else
                Me.PrintOptions = printOptions
            End If
        End Sub

        <DataMember(Name:="size", EmitDefaultValue:=False)>
        Public Property Size As DocumentSize
        <DataMember(Name:="printOptions", EmitDefaultValue:=False)>
        Public Property PrintOptions As PrintOptionList

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class SupportedDocumentSpecification {" & vbLf)
            sb.Append("  Format: ").Append(Format).Append(vbLf)
            sb.Append("  Size: ").Append(Size).Append(vbLf)
            sb.Append("  PrintOptions: ").Append(PrintOptions).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, SupportedDocumentSpecification))
        End Function

        Public Function Equals(ByVal input As SupportedDocumentSpecification) As Boolean
            If input Is Nothing Then Return False
            Return (Me.Format = input.Format OrElse (Me.Format IsNot Nothing AndAlso Me.Format.Equals(input.Format))) AndAlso (Me.Size = input.Size OrElse (Me.Size IsNot Nothing AndAlso Me.Size.Equals(input.Size))) AndAlso (Me.PrintOptions = input.PrintOptions OrElse (Me.PrintOptions IsNot Nothing AndAlso Me.PrintOptions.Equals(input.PrintOptions)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.Format IsNot Nothing Then hashCode = hashCode * 59 + Me.Format.GetHashCode()
            If Me.Size IsNot Nothing Then hashCode = hashCode * 59 + Me.Size.GetHashCode()
            If Me.PrintOptions IsNot Nothing Then hashCode = hashCode * 59 + Me.PrintOptions.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
