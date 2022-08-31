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
    Public Partial Class RequestedDocumentSpecification
        Implements IEquatable(Of RequestedDocumentSpecification), IValidatableObject

        <DataMember(Name:="format", EmitDefaultValue:=False)>
        Public Property Format As DocumentFormat

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional format As DocumentFormat = Nothing, ByVal Optional size As DocumentSize = Nothing, ByVal Optional dpi As Dpi = Nothing, ByVal Optional pageLayout As PageLayout = Nothing, ByVal Optional needFileJoining As NeedFileJoining = Nothing, ByVal Optional requestedDocumentTypes As List(Of DocumentType) = Nothing)
            If format Is Nothing Then
                Throw New InvalidDataException("format is a required property for RequestedDocumentSpecification and cannot be null")
            Else
                Me.Format = format
            End If

            If size Is Nothing Then
                Throw New InvalidDataException("size is a required property for RequestedDocumentSpecification and cannot be null")
            Else
                Me.Size = size
            End If

            If needFileJoining Is Nothing Then
                Throw New InvalidDataException("needFileJoining is a required property for RequestedDocumentSpecification and cannot be null")
            Else
                Me.NeedFileJoining = needFileJoining
            End If

            If requestedDocumentTypes Is Nothing Then
                Throw New InvalidDataException("requestedDocumentTypes is a required property for RequestedDocumentSpecification and cannot be null")
            Else
                Me.RequestedDocumentTypes = requestedDocumentTypes
            End If

            Me.Dpi = dpi
            Me.PageLayout = pageLayout
        End Sub

        <DataMember(Name:="size", EmitDefaultValue:=False)>
        Public Property Size As DocumentSize
        <DataMember(Name:="dpi", EmitDefaultValue:=False)>
        Public Property Dpi As Dpi
        <DataMember(Name:="pageLayout", EmitDefaultValue:=False)>
        Public Property PageLayout As PageLayout
        <DataMember(Name:="needFileJoining", EmitDefaultValue:=False)>
        Public Property NeedFileJoining As NeedFileJoining
        <DataMember(Name:="requestedDocumentTypes", EmitDefaultValue:=False)>
        Public Property RequestedDocumentTypes As List(Of DocumentType)

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class RequestedDocumentSpecification {" & vbLf)
            sb.Append("  Format: ").Append(Format).Append(vbLf)
            sb.Append("  Size: ").Append(Size).Append(vbLf)
            sb.Append("  Dpi: ").Append(Dpi).Append(vbLf)
            sb.Append("  PageLayout: ").Append(PageLayout).Append(vbLf)
            sb.Append("  NeedFileJoining: ").Append(NeedFileJoining).Append(vbLf)
            sb.Append("  RequestedDocumentTypes: ").Append(RequestedDocumentTypes).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, RequestedDocumentSpecification))
        End Function

        Public Function Equals(ByVal input As RequestedDocumentSpecification) As Boolean
            If input Is Nothing Then Return False
            Return (Me.Format = input.Format OrElse (Me.Format IsNot Nothing AndAlso Me.Format.Equals(input.Format))) AndAlso (Me.Size = input.Size OrElse (Me.Size IsNot Nothing AndAlso Me.Size.Equals(input.Size))) AndAlso (Me.Dpi = input.Dpi OrElse (Me.Dpi IsNot Nothing AndAlso Me.Dpi.Equals(input.Dpi))) AndAlso (Me.PageLayout = input.PageLayout OrElse (Me.PageLayout IsNot Nothing AndAlso Me.PageLayout.Equals(input.PageLayout))) AndAlso (Me.NeedFileJoining = input.NeedFileJoining OrElse (Me.NeedFileJoining IsNot Nothing AndAlso Me.NeedFileJoining.Equals(input.NeedFileJoining))) AndAlso (Me.RequestedDocumentTypes = input.RequestedDocumentTypes OrElse Me.RequestedDocumentTypes IsNot Nothing AndAlso Me.RequestedDocumentTypes.SequenceEqual(input.RequestedDocumentTypes))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.Format IsNot Nothing Then hashCode = hashCode * 59 + Me.Format.GetHashCode()
            If Me.Size IsNot Nothing Then hashCode = hashCode * 59 + Me.Size.GetHashCode()
            If Me.Dpi IsNot Nothing Then hashCode = hashCode * 59 + Me.Dpi.GetHashCode()
            If Me.PageLayout IsNot Nothing Then hashCode = hashCode * 59 + Me.PageLayout.GetHashCode()
            If Me.NeedFileJoining IsNot Nothing Then hashCode = hashCode * 59 + Me.NeedFileJoining.GetHashCode()
            If Me.RequestedDocumentTypes IsNot Nothing Then hashCode = hashCode * 59 + Me.RequestedDocumentTypes.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
