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
    Public Partial Class Package
        Implements IEquatable(Of Package), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional dimensions As Dimensions = Nothing, ByVal Optional weight As Weight = Nothing, ByVal Optional insuredValue As Currency = Nothing, ByVal Optional isHazmat As Boolean? = Nothing, ByVal Optional sellerDisplayName As String = Nothing, ByVal Optional charges As ChargeList = Nothing, ByVal Optional packageClientReferenceId As PackageClientReferenceId = Nothing, ByVal Optional items As ItemList = Nothing)
            If dimensions Is Nothing Then
                Throw New InvalidDataException("dimensions is a required property for Package and cannot be null")
            Else
                Me.Dimensions = dimensions
            End If

            If weight Is Nothing Then
                Throw New InvalidDataException("weight is a required property for Package and cannot be null")
            Else
                Me.Weight = weight
            End If

            If insuredValue Is Nothing Then
                Throw New InvalidDataException("insuredValue is a required property for Package and cannot be null")
            Else
                Me.InsuredValue = insuredValue
            End If

            If packageClientReferenceId Is Nothing Then
                Throw New InvalidDataException("packageClientReferenceId is a required property for Package and cannot be null")
            Else
                Me.PackageClientReferenceId = packageClientReferenceId
            End If

            If items Is Nothing Then
                Throw New InvalidDataException("items is a required property for Package and cannot be null")
            Else
                Me.Items = items
            End If

            Me.IsHazmat = isHazmat
            Me.SellerDisplayName = sellerDisplayName
            Me.Charges = charges
        End Sub

        <DataMember(Name:="dimensions", EmitDefaultValue:=False)>
        Public Property Dimensions As Dimensions
        <DataMember(Name:="weight", EmitDefaultValue:=False)>
        Public Property Weight As Weight
        <DataMember(Name:="insuredValue", EmitDefaultValue:=False)>
        Public Property InsuredValue As Currency
        <DataMember(Name:="isHazmat", EmitDefaultValue:=False)>
        Public Property IsHazmat As Boolean?
        <DataMember(Name:="sellerDisplayName", EmitDefaultValue:=False)>
        Public Property SellerDisplayName As String
        <DataMember(Name:="charges", EmitDefaultValue:=False)>
        Public Property Charges As ChargeList
        <DataMember(Name:="packageClientReferenceId", EmitDefaultValue:=False)>
        Public Property PackageClientReferenceId As PackageClientReferenceId
        <DataMember(Name:="items", EmitDefaultValue:=False)>
        Public Property Items As ItemList

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class Package {" & vbLf)
            sb.Append("  Dimensions: ").Append(Dimensions).Append(vbLf)
            sb.Append("  Weight: ").Append(Weight).Append(vbLf)
            sb.Append("  InsuredValue: ").Append(InsuredValue).Append(vbLf)
            sb.Append("  IsHazmat: ").Append(IsHazmat).Append(vbLf)
            sb.Append("  SellerDisplayName: ").Append(SellerDisplayName).Append(vbLf)
            sb.Append("  Charges: ").Append(Charges).Append(vbLf)
            sb.Append("  PackageClientReferenceId: ").Append(PackageClientReferenceId).Append(vbLf)
            sb.Append("  Items: ").Append(Items).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, Package))
        End Function

        Public Function Equals(ByVal input As Package) As Boolean
            If input Is Nothing Then Return False
            Return (Me.Dimensions = input.Dimensions OrElse (Me.Dimensions IsNot Nothing AndAlso Me.Dimensions.Equals(input.Dimensions))) AndAlso (Me.Weight = input.Weight OrElse (Me.Weight IsNot Nothing AndAlso Me.Weight.Equals(input.Weight))) AndAlso (Me.InsuredValue = input.InsuredValue OrElse (Me.InsuredValue IsNot Nothing AndAlso Me.InsuredValue.Equals(input.InsuredValue))) AndAlso (Me.IsHazmat = input.IsHazmat OrElse (Me.IsHazmat IsNot Nothing AndAlso Me.IsHazmat.Equals(input.IsHazmat))) AndAlso (Me.SellerDisplayName = input.SellerDisplayName OrElse (Me.SellerDisplayName IsNot Nothing AndAlso Me.SellerDisplayName.Equals(input.SellerDisplayName))) AndAlso (Me.Charges = input.Charges OrElse (Me.Charges IsNot Nothing AndAlso Me.Charges.Equals(input.Charges))) AndAlso (Me.PackageClientReferenceId = input.PackageClientReferenceId OrElse (Me.PackageClientReferenceId IsNot Nothing AndAlso Me.PackageClientReferenceId.Equals(input.PackageClientReferenceId))) AndAlso (Me.Items = input.Items OrElse (Me.Items IsNot Nothing AndAlso Me.Items.Equals(input.Items)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.Dimensions IsNot Nothing Then hashCode = hashCode * 59 + Me.Dimensions.GetHashCode()
            If Me.Weight IsNot Nothing Then hashCode = hashCode * 59 + Me.Weight.GetHashCode()
            If Me.InsuredValue IsNot Nothing Then hashCode = hashCode * 59 + Me.InsuredValue.GetHashCode()
            If Me.IsHazmat IsNot Nothing Then hashCode = hashCode * 59 + Me.IsHazmat.GetHashCode()
            If Me.SellerDisplayName IsNot Nothing Then hashCode = hashCode * 59 + Me.SellerDisplayName.GetHashCode()
            If Me.Charges IsNot Nothing Then hashCode = hashCode * 59 + Me.Charges.GetHashCode()
            If Me.PackageClientReferenceId IsNot Nothing Then hashCode = hashCode * 59 + Me.PackageClientReferenceId.GetHashCode()
            If Me.Items IsNot Nothing Then hashCode = hashCode * 59 + Me.Items.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
