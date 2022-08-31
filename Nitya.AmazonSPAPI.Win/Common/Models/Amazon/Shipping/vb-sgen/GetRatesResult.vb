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
    Public Partial Class GetRatesResult
        Implements IEquatable(Of GetRatesResult), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional requestToken As RequestToken = Nothing, ByVal Optional rates As RateList = Nothing, ByVal Optional ineligibleRates As IneligibleRateList = Nothing)
            If requestToken Is Nothing Then
                Throw New InvalidDataException("requestToken is a required property for GetRatesResult and cannot be null")
            Else
                Me.RequestToken = requestToken
            End If

            If rates Is Nothing Then
                Throw New InvalidDataException("rates is a required property for GetRatesResult and cannot be null")
            Else
                Me.Rates = rates
            End If

            Me.IneligibleRates = ineligibleRates
        End Sub

        <DataMember(Name:="requestToken", EmitDefaultValue:=False)>
        Public Property RequestToken As RequestToken
        <DataMember(Name:="rates", EmitDefaultValue:=False)>
        Public Property Rates As RateList
        <DataMember(Name:="ineligibleRates", EmitDefaultValue:=False)>
        Public Property IneligibleRates As IneligibleRateList

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class GetRatesResult {" & vbLf)
            sb.Append("  RequestToken: ").Append(RequestToken).Append(vbLf)
            sb.Append("  Rates: ").Append(Rates).Append(vbLf)
            sb.Append("  IneligibleRates: ").Append(IneligibleRates).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, GetRatesResult))
        End Function

        Public Function Equals(ByVal input As GetRatesResult) As Boolean
            If input Is Nothing Then Return False
            Return (Me.RequestToken = input.RequestToken OrElse (Me.RequestToken IsNot Nothing AndAlso Me.RequestToken.Equals(input.RequestToken))) AndAlso (Me.Rates = input.Rates OrElse (Me.Rates IsNot Nothing AndAlso Me.Rates.Equals(input.Rates))) AndAlso (Me.IneligibleRates = input.IneligibleRates OrElse (Me.IneligibleRates IsNot Nothing AndAlso Me.IneligibleRates.Equals(input.IneligibleRates)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.RequestToken IsNot Nothing Then hashCode = hashCode * 59 + Me.RequestToken.GetHashCode()
            If Me.Rates IsNot Nothing Then hashCode = hashCode * 59 + Me.Rates.GetHashCode()
            If Me.IneligibleRates IsNot Nothing Then hashCode = hashCode * 59 + Me.IneligibleRates.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
