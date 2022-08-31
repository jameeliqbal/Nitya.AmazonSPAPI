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
    Public Partial Class PackageDocumentDetail
        Implements IEquatable(Of PackageDocumentDetail), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional packageClientReferenceId As PackageClientReferenceId = Nothing, ByVal Optional packageDocuments As PackageDocumentList = Nothing, ByVal Optional trackingId As TrackingId = Nothing)
            If packageClientReferenceId Is Nothing Then
                Throw New InvalidDataException("packageClientReferenceId is a required property for PackageDocumentDetail and cannot be null")
            Else
                Me.PackageClientReferenceId = packageClientReferenceId
            End If

            If packageDocuments Is Nothing Then
                Throw New InvalidDataException("packageDocuments is a required property for PackageDocumentDetail and cannot be null")
            Else
                Me.PackageDocuments = packageDocuments
            End If

            Me.TrackingId = trackingId
        End Sub

        <DataMember(Name:="packageClientReferenceId", EmitDefaultValue:=False)>
        Public Property PackageClientReferenceId As PackageClientReferenceId
        <DataMember(Name:="packageDocuments", EmitDefaultValue:=False)>
        Public Property PackageDocuments As PackageDocumentList
        <DataMember(Name:="trackingId", EmitDefaultValue:=False)>
        Public Property TrackingId As TrackingId

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class PackageDocumentDetail {" & vbLf)
            sb.Append("  PackageClientReferenceId: ").Append(PackageClientReferenceId).Append(vbLf)
            sb.Append("  PackageDocuments: ").Append(PackageDocuments).Append(vbLf)
            sb.Append("  TrackingId: ").Append(TrackingId).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, PackageDocumentDetail))
        End Function

        Public Function Equals(ByVal input As PackageDocumentDetail) As Boolean
            If input Is Nothing Then Return False
            Return (Me.PackageClientReferenceId = input.PackageClientReferenceId OrElse (Me.PackageClientReferenceId IsNot Nothing AndAlso Me.PackageClientReferenceId.Equals(input.PackageClientReferenceId))) AndAlso (Me.PackageDocuments = input.PackageDocuments OrElse (Me.PackageDocuments IsNot Nothing AndAlso Me.PackageDocuments.Equals(input.PackageDocuments))) AndAlso (Me.TrackingId = input.TrackingId OrElse (Me.TrackingId IsNot Nothing AndAlso Me.TrackingId.Equals(input.TrackingId)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.PackageClientReferenceId IsNot Nothing Then hashCode = hashCode * 59 + Me.PackageClientReferenceId.GetHashCode()
            If Me.PackageDocuments IsNot Nothing Then hashCode = hashCode * 59 + Me.PackageDocuments.GetHashCode()
            If Me.TrackingId IsNot Nothing Then hashCode = hashCode * 59 + Me.TrackingId.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
