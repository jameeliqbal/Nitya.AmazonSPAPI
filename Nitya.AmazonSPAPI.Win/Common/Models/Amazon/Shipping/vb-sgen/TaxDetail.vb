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
    Public Partial Class TaxDetail
        Implements IEquatable(Of TaxDetail), IValidatableObject

        <DataMember(Name:="taxType", EmitDefaultValue:=False)>
        Public Property TaxType As TaxType

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional taxType As TaxType = Nothing, ByVal Optional taxRegistrationNumber As String = Nothing)
            If taxType Is Nothing Then
                Throw New InvalidDataException("taxType is a required property for TaxDetail and cannot be null")
            Else
                Me.TaxType = taxType
            End If

            If taxRegistrationNumber Is Nothing Then
                Throw New InvalidDataException("taxRegistrationNumber is a required property for TaxDetail and cannot be null")
            Else
                Me.TaxRegistrationNumber = taxRegistrationNumber
            End If
        End Sub

        <DataMember(Name:="taxRegistrationNumber", EmitDefaultValue:=False)>
        Public Property TaxRegistrationNumber As String

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class TaxDetail {" & vbLf)
            sb.Append("  TaxType: ").Append(TaxType).Append(vbLf)
            sb.Append("  TaxRegistrationNumber: ").Append(TaxRegistrationNumber).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, TaxDetail))
        End Function

        Public Function Equals(ByVal input As TaxDetail) As Boolean
            If input Is Nothing Then Return False
            Return (Me.TaxType = input.TaxType OrElse (Me.TaxType IsNot Nothing AndAlso Me.TaxType.Equals(input.TaxType))) AndAlso (Me.TaxRegistrationNumber = input.TaxRegistrationNumber OrElse (Me.TaxRegistrationNumber IsNot Nothing AndAlso Me.TaxRegistrationNumber.Equals(input.TaxRegistrationNumber)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.TaxType IsNot Nothing Then hashCode = hashCode * 59 + Me.TaxType.GetHashCode()
            If Me.TaxRegistrationNumber IsNot Nothing Then hashCode = hashCode * 59 + Me.TaxRegistrationNumber.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
