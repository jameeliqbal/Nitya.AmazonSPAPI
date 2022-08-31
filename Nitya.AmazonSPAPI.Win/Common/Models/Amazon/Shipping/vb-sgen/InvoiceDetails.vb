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
    Public Partial Class InvoiceDetails
        Implements IEquatable(Of InvoiceDetails), IValidatableObject

        Public Sub New(ByVal Optional invoiceNumber As String = Nothing, ByVal Optional invoiceDate As DateTime? = Nothing)
            Me.InvoiceNumber = invoiceNumber
            Me.InvoiceDate = invoiceDate
        End Sub

        <DataMember(Name:="invoiceNumber", EmitDefaultValue:=False)>
        Public Property InvoiceNumber As String
        <DataMember(Name:="invoiceDate", EmitDefaultValue:=False)>
        Public Property InvoiceDate As DateTime?

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class InvoiceDetails {" & vbLf)
            sb.Append("  InvoiceNumber: ").Append(InvoiceNumber).Append(vbLf)
            sb.Append("  InvoiceDate: ").Append(InvoiceDate).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, InvoiceDetails))
        End Function

        Public Function Equals(ByVal input As InvoiceDetails) As Boolean
            If input Is Nothing Then Return False
            Return (Me.InvoiceNumber = input.InvoiceNumber OrElse (Me.InvoiceNumber IsNot Nothing AndAlso Me.InvoiceNumber.Equals(input.InvoiceNumber))) AndAlso (Me.InvoiceDate = input.InvoiceDate OrElse (Me.InvoiceDate IsNot Nothing AndAlso Me.InvoiceDate.Equals(input.InvoiceDate)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.InvoiceNumber IsNot Nothing Then hashCode = hashCode * 59 + Me.InvoiceNumber.GetHashCode()
            If Me.InvoiceDate IsNot Nothing Then hashCode = hashCode * 59 + Me.InvoiceDate.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
