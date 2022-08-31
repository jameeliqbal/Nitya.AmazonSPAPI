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
    Public Partial Class Weight
        Implements IEquatable(Of Weight), IValidatableObject

        <JsonConverter(GetType(StringEnumConverter))>
        Public Enum UnitEnum
            <EnumMember(Value:="GRAM")>
            GRAM = 1
            <EnumMember(Value:="KILOGRAM")>
            KILOGRAM = 2
            <EnumMember(Value:="OUNCE")>
            OUNCE = 3
            <EnumMember(Value:="POUND")>
            POUND = 4
        End Enum

        <DataMember(Name:="unit", EmitDefaultValue:=False)>
        Public Property Unit As UnitEnum

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional unit As UnitEnum = Nothing, ByVal Optional value As Decimal? = Nothing)
            If unit Is Nothing Then
                Throw New InvalidDataException("unit is a required property for Weight and cannot be null")
            Else
                Me.Unit = unit
            End If

            If value Is Nothing Then
                Throw New InvalidDataException("value is a required property for Weight and cannot be null")
            Else
                Me.Value = value
            End If
        End Sub

        <DataMember(Name:="value", EmitDefaultValue:=False)>
        Public Property Value As Decimal?

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class Weight {" & vbLf)
            sb.Append("  Unit: ").Append(Unit).Append(vbLf)
            sb.Append("  Value: ").Append(Value).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, Weight))
        End Function

        Public Function Equals(ByVal input As Weight) As Boolean
            If input Is Nothing Then Return False
            Return (Me.Unit = input.Unit OrElse (Me.Unit IsNot Nothing AndAlso Me.Unit.Equals(input.Unit))) AndAlso (Me.Value = input.Value OrElse (Me.Value IsNot Nothing AndAlso Me.Value.Equals(input.Value)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.Unit IsNot Nothing Then hashCode = hashCode * 59 + Me.Unit.GetHashCode()
            If Me.Value IsNot Nothing Then hashCode = hashCode * 59 + Me.Value.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
