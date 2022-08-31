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
    Public Partial Class Location
        Implements IEquatable(Of Location), IValidatableObject

        Public Sub New(ByVal Optional stateOrRegion As StateOrRegion = Nothing, ByVal Optional city As City = Nothing, ByVal Optional countryCode As CountryCode = Nothing, ByVal Optional postalCode As PostalCode = Nothing)
            Me.StateOrRegion = stateOrRegion
            Me.City = city
            Me.CountryCode = countryCode
            Me.PostalCode = postalCode
        End Sub

        <DataMember(Name:="stateOrRegion", EmitDefaultValue:=False)>
        Public Property StateOrRegion As StateOrRegion
        <DataMember(Name:="city", EmitDefaultValue:=False)>
        Public Property City As City
        <DataMember(Name:="countryCode", EmitDefaultValue:=False)>
        Public Property CountryCode As CountryCode
        <DataMember(Name:="postalCode", EmitDefaultValue:=False)>
        Public Property PostalCode As PostalCode

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class Location {" & vbLf)
            sb.Append("  StateOrRegion: ").Append(StateOrRegion).Append(vbLf)
            sb.Append("  City: ").Append(City).Append(vbLf)
            sb.Append("  CountryCode: ").Append(CountryCode).Append(vbLf)
            sb.Append("  PostalCode: ").Append(PostalCode).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, Location))
        End Function

        Public Function Equals(ByVal input As Location) As Boolean
            If input Is Nothing Then Return False
            Return (Me.StateOrRegion = input.StateOrRegion OrElse (Me.StateOrRegion IsNot Nothing AndAlso Me.StateOrRegion.Equals(input.StateOrRegion))) AndAlso (Me.City = input.City OrElse (Me.City IsNot Nothing AndAlso Me.City.Equals(input.City))) AndAlso (Me.CountryCode = input.CountryCode OrElse (Me.CountryCode IsNot Nothing AndAlso Me.CountryCode.Equals(input.CountryCode))) AndAlso (Me.PostalCode = input.PostalCode OrElse (Me.PostalCode IsNot Nothing AndAlso Me.PostalCode.Equals(input.PostalCode)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.StateOrRegion IsNot Nothing Then hashCode = hashCode * 59 + Me.StateOrRegion.GetHashCode()
            If Me.City IsNot Nothing Then hashCode = hashCode * 59 + Me.City.GetHashCode()
            If Me.CountryCode IsNot Nothing Then hashCode = hashCode * 59 + Me.CountryCode.GetHashCode()
            If Me.PostalCode IsNot Nothing Then hashCode = hashCode * 59 + Me.PostalCode.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
