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
    Public Partial Class Currency
        Implements IEquatable(Of Currency), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional value As Decimal? = Nothing, ByVal Optional unit As String = Nothing)
            If value Is Nothing Then
                Throw New InvalidDataException("value is a required property for Currency and cannot be null")
            Else
                Me.Value = value
            End If

            If unit Is Nothing Then
                Throw New InvalidDataException("unit is a required property for Currency and cannot be null")
            Else
                Me.Unit = unit
            End If
        End Sub

        <DataMember(Name:="value", EmitDefaultValue:=False)>
        Public Property Value As Decimal?
        <DataMember(Name:="unit", EmitDefaultValue:=False)>
        Public Property Unit As String

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class Currency {" & vbLf)
            sb.Append("  Value: ").Append(Value).Append(vbLf)
            sb.Append("  Unit: ").Append(Unit).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, Currency))
        End Function

        Public Function Equals(ByVal input As Currency) As Boolean
            If input Is Nothing Then Return False
            Return (Me.Value = input.Value OrElse (Me.Value IsNot Nothing AndAlso Me.Value.Equals(input.Value))) AndAlso (Me.Unit = input.Unit OrElse (Me.Unit IsNot Nothing AndAlso Me.Unit.Equals(input.Unit)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.Value IsNot Nothing Then hashCode = hashCode * 59 + Me.Value.GetHashCode()
            If Me.Unit IsNot Nothing Then hashCode = hashCode * 59 + Me.Unit.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            If Me.Unit IsNot Nothing AndAlso Me.Unit.Length > 3 Then
                Yield New System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Unit, length must be less than 3.", {"Unit"})
            End If

            If Me.Unit IsNot Nothing AndAlso Me.Unit.Length < 3 Then
                Yield New System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Unit, length must be greater than 3.", {"Unit"})
            End If

            Return
        End Function
    End Class
End Namespace
