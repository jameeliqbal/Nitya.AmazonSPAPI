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
    Public Partial Class ChargeComponent
        Implements IEquatable(Of ChargeComponent), IValidatableObject

        <JsonConverter(GetType(StringEnumConverter))>
        Public Enum ChargeTypeEnum
            <EnumMember(Value:="TAX")>
            TAX = 1
            <EnumMember(Value:="DISCOUNT")>
            DISCOUNT = 2
        End Enum

        <DataMember(Name:="chargeType", EmitDefaultValue:=False)>
        Public Property ChargeType As ChargeTypeEnum?

        Public Sub New(ByVal Optional amount As Currency = Nothing, ByVal Optional chargeType As ChargeTypeEnum? = Nothing)
            Me.Amount = amount
            Me.ChargeType = chargeType
        End Sub

        <DataMember(Name:="amount", EmitDefaultValue:=False)>
        Public Property Amount As Currency

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class ChargeComponent {" & vbLf)
            sb.Append("  Amount: ").Append(Amount).Append(vbLf)
            sb.Append("  ChargeType: ").Append(ChargeType).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, ChargeComponent))
        End Function

        Public Function Equals(ByVal input As ChargeComponent) As Boolean
            If input Is Nothing Then Return False
            Return (Me.Amount = input.Amount OrElse (Me.Amount IsNot Nothing AndAlso Me.Amount.Equals(input.Amount))) AndAlso (Me.ChargeType = input.ChargeType OrElse (Me.ChargeType IsNot Nothing AndAlso Me.ChargeType.Equals(input.ChargeType)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.Amount IsNot Nothing Then hashCode = hashCode * 59 + Me.Amount.GetHashCode()
            If Me.ChargeType IsNot Nothing Then hashCode = hashCode * 59 + Me.ChargeType.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
