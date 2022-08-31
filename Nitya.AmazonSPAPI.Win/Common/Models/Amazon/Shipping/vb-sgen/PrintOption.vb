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
    Public Partial Class PrintOption
        Implements IEquatable(Of PrintOption), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional supportedDPIs As List(Of Dpi) = Nothing, ByVal Optional supportedPageLayouts As List(Of PageLayout) = Nothing, ByVal Optional supportedFileJoiningOptions As List(Of NeedFileJoining) = Nothing, ByVal Optional supportedDocumentDetails As List(Of SupportedDocumentDetail) = Nothing)
            If supportedPageLayouts Is Nothing Then
                Throw New InvalidDataException("supportedPageLayouts is a required property for PrintOption and cannot be null")
            Else
                Me.SupportedPageLayouts = supportedPageLayouts
            End If

            If supportedFileJoiningOptions Is Nothing Then
                Throw New InvalidDataException("supportedFileJoiningOptions is a required property for PrintOption and cannot be null")
            Else
                Me.SupportedFileJoiningOptions = supportedFileJoiningOptions
            End If

            If supportedDocumentDetails Is Nothing Then
                Throw New InvalidDataException("supportedDocumentDetails is a required property for PrintOption and cannot be null")
            Else
                Me.SupportedDocumentDetails = supportedDocumentDetails
            End If

            Me.SupportedDPIs = supportedDPIs
        End Sub

        <DataMember(Name:="supportedDPIs", EmitDefaultValue:=False)>
        Public Property SupportedDPIs As List(Of Dpi)
        <DataMember(Name:="supportedPageLayouts", EmitDefaultValue:=False)>
        Public Property SupportedPageLayouts As List(Of PageLayout)
        <DataMember(Name:="supportedFileJoiningOptions", EmitDefaultValue:=False)>
        Public Property SupportedFileJoiningOptions As List(Of NeedFileJoining)
        <DataMember(Name:="supportedDocumentDetails", EmitDefaultValue:=False)>
        Public Property SupportedDocumentDetails As List(Of SupportedDocumentDetail)

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class PrintOption {" & vbLf)
            sb.Append("  SupportedDPIs: ").Append(SupportedDPIs).Append(vbLf)
            sb.Append("  SupportedPageLayouts: ").Append(SupportedPageLayouts).Append(vbLf)
            sb.Append("  SupportedFileJoiningOptions: ").Append(SupportedFileJoiningOptions).Append(vbLf)
            sb.Append("  SupportedDocumentDetails: ").Append(SupportedDocumentDetails).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, PrintOption))
        End Function

        Public Function Equals(ByVal input As PrintOption) As Boolean
            If input Is Nothing Then Return False
            Return (Me.SupportedDPIs = input.SupportedDPIs OrElse Me.SupportedDPIs IsNot Nothing AndAlso Me.SupportedDPIs.SequenceEqual(input.SupportedDPIs)) AndAlso (Me.SupportedPageLayouts = input.SupportedPageLayouts OrElse Me.SupportedPageLayouts IsNot Nothing AndAlso Me.SupportedPageLayouts.SequenceEqual(input.SupportedPageLayouts)) AndAlso (Me.SupportedFileJoiningOptions = input.SupportedFileJoiningOptions OrElse Me.SupportedFileJoiningOptions IsNot Nothing AndAlso Me.SupportedFileJoiningOptions.SequenceEqual(input.SupportedFileJoiningOptions)) AndAlso (Me.SupportedDocumentDetails = input.SupportedDocumentDetails OrElse Me.SupportedDocumentDetails IsNot Nothing AndAlso Me.SupportedDocumentDetails.SequenceEqual(input.SupportedDocumentDetails))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.SupportedDPIs IsNot Nothing Then hashCode = hashCode * 59 + Me.SupportedDPIs.GetHashCode()
            If Me.SupportedPageLayouts IsNot Nothing Then hashCode = hashCode * 59 + Me.SupportedPageLayouts.GetHashCode()
            If Me.SupportedFileJoiningOptions IsNot Nothing Then hashCode = hashCode * 59 + Me.SupportedFileJoiningOptions.GetHashCode()
            If Me.SupportedDocumentDetails IsNot Nothing Then hashCode = hashCode * 59 + Me.SupportedDocumentDetails.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
