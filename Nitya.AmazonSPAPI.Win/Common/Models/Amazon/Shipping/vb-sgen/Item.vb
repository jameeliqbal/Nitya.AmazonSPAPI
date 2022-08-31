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
    Public Partial Class Item
        Implements IEquatable(Of Item), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional itemValue As Currency = Nothing, ByVal Optional description As String = Nothing, ByVal Optional itemIdentifier As String = Nothing, ByVal Optional quantity As Integer? = Nothing, ByVal Optional weight As Weight = Nothing, ByVal Optional isHazmat As Boolean? = Nothing, ByVal Optional productType As String = Nothing, ByVal Optional invoiceDetails As InvoiceDetails = Nothing, ByVal Optional serialNumbers As List(Of String) = Nothing, ByVal Optional directFulfillmentItemIdentifiers As DirectFulfillmentItemIdentifiers = Nothing)
            If quantity Is Nothing Then
                Throw New InvalidDataException("quantity is a required property for Item and cannot be null")
            Else
                Me.Quantity = quantity
            End If

            Me.ItemValue = itemValue
            Me.Description = description
            Me.ItemIdentifier = itemIdentifier
            Me.Weight = weight
            Me.IsHazmat = isHazmat
            Me.ProductType = productType
            Me.InvoiceDetails = invoiceDetails
            Me.SerialNumbers = serialNumbers
            Me.DirectFulfillmentItemIdentifiers = directFulfillmentItemIdentifiers
        End Sub

        <DataMember(Name:="itemValue", EmitDefaultValue:=False)>
        Public Property ItemValue As Currency
        <DataMember(Name:="description", EmitDefaultValue:=False)>
        Public Property Description As String
        <DataMember(Name:="itemIdentifier", EmitDefaultValue:=False)>
        Public Property ItemIdentifier As String
        <DataMember(Name:="quantity", EmitDefaultValue:=False)>
        Public Property Quantity As Integer?
        <DataMember(Name:="weight", EmitDefaultValue:=False)>
        Public Property Weight As Weight
        <DataMember(Name:="isHazmat", EmitDefaultValue:=False)>
        Public Property IsHazmat As Boolean?
        <DataMember(Name:="productType", EmitDefaultValue:=False)>
        Public Property ProductType As String
        <DataMember(Name:="invoiceDetails", EmitDefaultValue:=False)>
        Public Property InvoiceDetails As InvoiceDetails
        <DataMember(Name:="serialNumbers", EmitDefaultValue:=False)>
        Public Property SerialNumbers As List(Of String)
        <DataMember(Name:="directFulfillmentItemIdentifiers", EmitDefaultValue:=False)>
        Public Property DirectFulfillmentItemIdentifiers As DirectFulfillmentItemIdentifiers

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class Item {" & vbLf)
            sb.Append("  ItemValue: ").Append(ItemValue).Append(vbLf)
            sb.Append("  Description: ").Append(Description).Append(vbLf)
            sb.Append("  ItemIdentifier: ").Append(ItemIdentifier).Append(vbLf)
            sb.Append("  Quantity: ").Append(Quantity).Append(vbLf)
            sb.Append("  Weight: ").Append(Weight).Append(vbLf)
            sb.Append("  IsHazmat: ").Append(IsHazmat).Append(vbLf)
            sb.Append("  ProductType: ").Append(ProductType).Append(vbLf)
            sb.Append("  InvoiceDetails: ").Append(InvoiceDetails).Append(vbLf)
            sb.Append("  SerialNumbers: ").Append(SerialNumbers).Append(vbLf)
            sb.Append("  DirectFulfillmentItemIdentifiers: ").Append(DirectFulfillmentItemIdentifiers).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, Item))
        End Function

        Public Function Equals(ByVal input As Item) As Boolean
            If input Is Nothing Then Return False
            Return (Me.ItemValue = input.ItemValue OrElse (Me.ItemValue IsNot Nothing AndAlso Me.ItemValue.Equals(input.ItemValue))) AndAlso (Me.Description = input.Description OrElse (Me.Description IsNot Nothing AndAlso Me.Description.Equals(input.Description))) AndAlso (Me.ItemIdentifier = input.ItemIdentifier OrElse (Me.ItemIdentifier IsNot Nothing AndAlso Me.ItemIdentifier.Equals(input.ItemIdentifier))) AndAlso (Me.Quantity = input.Quantity OrElse (Me.Quantity IsNot Nothing AndAlso Me.Quantity.Equals(input.Quantity))) AndAlso (Me.Weight = input.Weight OrElse (Me.Weight IsNot Nothing AndAlso Me.Weight.Equals(input.Weight))) AndAlso (Me.IsHazmat = input.IsHazmat OrElse (Me.IsHazmat IsNot Nothing AndAlso Me.IsHazmat.Equals(input.IsHazmat))) AndAlso (Me.ProductType = input.ProductType OrElse (Me.ProductType IsNot Nothing AndAlso Me.ProductType.Equals(input.ProductType))) AndAlso (Me.InvoiceDetails = input.InvoiceDetails OrElse (Me.InvoiceDetails IsNot Nothing AndAlso Me.InvoiceDetails.Equals(input.InvoiceDetails))) AndAlso (Me.SerialNumbers = input.SerialNumbers OrElse Me.SerialNumbers IsNot Nothing AndAlso Me.SerialNumbers.SequenceEqual(input.SerialNumbers)) AndAlso (Me.DirectFulfillmentItemIdentifiers = input.DirectFulfillmentItemIdentifiers OrElse (Me.DirectFulfillmentItemIdentifiers IsNot Nothing AndAlso Me.DirectFulfillmentItemIdentifiers.Equals(input.DirectFulfillmentItemIdentifiers)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.ItemValue IsNot Nothing Then hashCode = hashCode * 59 + Me.ItemValue.GetHashCode()
            If Me.Description IsNot Nothing Then hashCode = hashCode * 59 + Me.Description.GetHashCode()
            If Me.ItemIdentifier IsNot Nothing Then hashCode = hashCode * 59 + Me.ItemIdentifier.GetHashCode()
            If Me.Quantity IsNot Nothing Then hashCode = hashCode * 59 + Me.Quantity.GetHashCode()
            If Me.Weight IsNot Nothing Then hashCode = hashCode * 59 + Me.Weight.GetHashCode()
            If Me.IsHazmat IsNot Nothing Then hashCode = hashCode * 59 + Me.IsHazmat.GetHashCode()
            If Me.ProductType IsNot Nothing Then hashCode = hashCode * 59 + Me.ProductType.GetHashCode()
            If Me.InvoiceDetails IsNot Nothing Then hashCode = hashCode * 59 + Me.InvoiceDetails.GetHashCode()
            If Me.SerialNumbers IsNot Nothing Then hashCode = hashCode * 59 + Me.SerialNumbers.GetHashCode()
            If Me.DirectFulfillmentItemIdentifiers IsNot Nothing Then hashCode = hashCode * 59 + Me.DirectFulfillmentItemIdentifiers.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
