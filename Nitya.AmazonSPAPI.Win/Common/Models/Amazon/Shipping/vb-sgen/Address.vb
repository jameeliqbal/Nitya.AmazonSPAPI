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
    Public Partial Class Address
        Implements IEquatable(Of Address), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional name As String = Nothing, ByVal Optional addressLine1 As String = Nothing, ByVal Optional addressLine2 As String = Nothing, ByVal Optional addressLine3 As String = Nothing, ByVal Optional companyName As String = Nothing, ByVal Optional stateOrRegion As StateOrRegion = Nothing, ByVal Optional city As City = Nothing, ByVal Optional countryCode As CountryCode = Nothing, ByVal Optional postalCode As PostalCode = Nothing, ByVal Optional email As String = Nothing, ByVal Optional phoneNumber As String = Nothing)
            If name Is Nothing Then
                Throw New InvalidDataException("name is a required property for Address and cannot be null")
            Else
                Me.Name = name
            End If

            If addressLine1 Is Nothing Then
                Throw New InvalidDataException("addressLine1 is a required property for Address and cannot be null")
            Else
                Me.AddressLine1 = addressLine1
            End If

            If stateOrRegion Is Nothing Then
                Throw New InvalidDataException("stateOrRegion is a required property for Address and cannot be null")
            Else
                Me.StateOrRegion = stateOrRegion
            End If

            If city Is Nothing Then
                Throw New InvalidDataException("city is a required property for Address and cannot be null")
            Else
                Me.City = city
            End If

            If countryCode Is Nothing Then
                Throw New InvalidDataException("countryCode is a required property for Address and cannot be null")
            Else
                Me.CountryCode = countryCode
            End If

            If postalCode Is Nothing Then
                Throw New InvalidDataException("postalCode is a required property for Address and cannot be null")
            Else
                Me.PostalCode = postalCode
            End If

            Me.AddressLine2 = addressLine2
            Me.AddressLine3 = addressLine3
            Me.CompanyName = companyName
            Me.Email = email
            Me.PhoneNumber = phoneNumber
        End Sub

        <DataMember(Name:="name", EmitDefaultValue:=False)>
        Public Property Name As String
        <DataMember(Name:="addressLine1", EmitDefaultValue:=False)>
        Public Property AddressLine1 As String
        <DataMember(Name:="addressLine2", EmitDefaultValue:=False)>
        Public Property AddressLine2 As String
        <DataMember(Name:="addressLine3", EmitDefaultValue:=False)>
        Public Property AddressLine3 As String
        <DataMember(Name:="companyName", EmitDefaultValue:=False)>
        Public Property CompanyName As String
        <DataMember(Name:="stateOrRegion", EmitDefaultValue:=False)>
        Public Property StateOrRegion As StateOrRegion
        <DataMember(Name:="city", EmitDefaultValue:=False)>
        Public Property City As City
        <DataMember(Name:="countryCode", EmitDefaultValue:=False)>
        Public Property CountryCode As CountryCode
        <DataMember(Name:="postalCode", EmitDefaultValue:=False)>
        Public Property PostalCode As PostalCode
        <DataMember(Name:="email", EmitDefaultValue:=False)>
        Public Property Email As String
        <DataMember(Name:="phoneNumber", EmitDefaultValue:=False)>
        Public Property PhoneNumber As String

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class Address {" & vbLf)
            sb.Append("  Name: ").Append(Name).Append(vbLf)
            sb.Append("  AddressLine1: ").Append(AddressLine1).Append(vbLf)
            sb.Append("  AddressLine2: ").Append(AddressLine2).Append(vbLf)
            sb.Append("  AddressLine3: ").Append(AddressLine3).Append(vbLf)
            sb.Append("  CompanyName: ").Append(CompanyName).Append(vbLf)
            sb.Append("  StateOrRegion: ").Append(StateOrRegion).Append(vbLf)
            sb.Append("  City: ").Append(City).Append(vbLf)
            sb.Append("  CountryCode: ").Append(CountryCode).Append(vbLf)
            sb.Append("  PostalCode: ").Append(PostalCode).Append(vbLf)
            sb.Append("  Email: ").Append(Email).Append(vbLf)
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input(), Address))
        End Function

        Private Function Equals(ByVal input As Address) As Boolean
            If input Is Nothing Then Return False
            Return (Me.Name = input.Name OrElse (Me.Name IsNot Nothing AndAlso Me.Name.Equals(input.Name))) AndAlso (Me.AddressLine1 = input.AddressLine1 OrElse (Me.AddressLine1 IsNot Nothing AndAlso Me.AddressLine1.Equals(input.AddressLine1))) AndAlso (Me.AddressLine2 = input.AddressLine2 OrElse (Me.AddressLine2 IsNot Nothing AndAlso Me.AddressLine2.Equals(input.AddressLine2))) AndAlso (Me.AddressLine3 = input.AddressLine3 OrElse (Me.AddressLine3 IsNot Nothing AndAlso Me.AddressLine3.Equals(input.AddressLine3))) AndAlso (Me.CompanyName = input.CompanyName OrElse (Me.CompanyName IsNot Nothing AndAlso Me.CompanyName.Equals(input.CompanyName))) AndAlso (Me.StateOrRegion = input.StateOrRegion OrElse (Me.StateOrRegion IsNot Nothing AndAlso Me.StateOrRegion.Equals(input.StateOrRegion))) AndAlso (Me.City = input.City OrElse (Me.City IsNot Nothing AndAlso Me.City.Equals(input.City))) AndAlso (Me.CountryCode = input.CountryCode OrElse (Me.CountryCode IsNot Nothing AndAlso Me.CountryCode.Equals(input.CountryCode))) AndAlso (Me.PostalCode = input.PostalCode OrElse (Me.PostalCode IsNot Nothing AndAlso Me.PostalCode.Equals(input.PostalCode))) AndAlso (Me.Email = input.Email OrElse (Me.Email IsNot Nothing AndAlso Me.Email.Equals(input.Email))) AndAlso (Me.PhoneNumber = input.PhoneNumber OrElse (Me.PhoneNumber IsNot Nothing AndAlso Me.PhoneNumber.Equals(input.PhoneNumber)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            ''''BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.Name IsNot Nothing Then hashCode = hashCode * 59 + Me.Name.GetHashCode()
            If Me.AddressLine1 IsNot Nothing Then hashCode = hashCode * 59 + Me.AddressLine1.GetHashCode()
            If Me.AddressLine2 IsNot Nothing Then hashCode = hashCode * 59 + Me.AddressLine2.GetHashCode()
            If Me.AddressLine3 IsNot Nothing Then hashCode = hashCode * 59 + Me.AddressLine3.GetHashCode()
            If Me.CompanyName IsNot Nothing Then hashCode = hashCode * 59 + Me.CompanyName.GetHashCode()
            If Me.StateOrRegion IsNot Nothing Then hashCode = hashCode * 59 + Me.StateOrRegion.GetHashCode()
            If Me.City IsNot Nothing Then hashCode = hashCode * 59 + Me.City.GetHashCode()
            If Me.CountryCode IsNot Nothing Then hashCode = hashCode * 59 + Me.CountryCode.GetHashCode()
            If Me.PostalCode IsNot Nothing Then hashCode = hashCode * 59 + Me.PostalCode.GetHashCode()
            If Me.Email IsNot Nothing Then
                hashCode = hashCode * 59 + Me.Email.GetHashCode()
            End If
            If Me.PhoneNumber IsNot Nothing Then
                hashCode = hashCode * 59 + Me.PhoneNumber.GetHashCode()
            End If
            Return hashCode

        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            If Me.Name IsNot Nothing AndAlso Me.Name.Length > 50 Then
                Yield New System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be less than 50.", {"Name"})
            End If

            If Me.Name IsNot Nothing AndAlso Me.Name.Length < 1 Then
                Yield New System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be greater than 1.", {"Name"})
            End If

            If Me.AddressLine1 IsNot Nothing AndAlso Me.AddressLine1.Length > 60 Then
                Yield New System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AddressLine1, length must be less than 60.", {"AddressLine1"})
            End If

            If Me.AddressLine1 IsNot Nothing AndAlso Me.AddressLine1.Length < 1 Then
                Yield New System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AddressLine1, length must be greater than 1.", {"AddressLine1"})
            End If

            If Me.AddressLine2 IsNot Nothing AndAlso Me.AddressLine2.Length > 60 Then
                Yield New System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AddressLine2, length must be less than 60.", {"AddressLine2"})
            End If

            If Me.AddressLine2 IsNot Nothing AndAlso Me.AddressLine2.Length < 1 Then
                Yield New System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AddressLine2, length must be greater than 1.", {"AddressLine2"})
            End If

            If Me.AddressLine3 IsNot Nothing AndAlso Me.AddressLine3.Length > 60 Then
                Yield New System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AddressLine3, length must be less than 60.", {"AddressLine3"})
            End If

            If Me.AddressLine3 IsNot Nothing AndAlso Me.AddressLine3.Length < 1 Then
                Yield New System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AddressLine3, length must be greater than 1.", {"AddressLine3"})
            End If

            If Me.Email IsNot Nothing AndAlso Me.Email.Length > 64 Then
                Yield New System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Email, length must be less than 64.", {"Email"})
            End If

            If Me.PhoneNumber IsNot Nothing AndAlso Me.PhoneNumber.Length > 20 Then
                Yield New System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for PhoneNumber, length must be less than 20.", {"PhoneNumber"})
            End If

            If Me.PhoneNumber IsNot Nothing AndAlso Me.PhoneNumber.Length < 1 Then
                Yield New System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for PhoneNumber, length must be greater than 1.", {"PhoneNumber"})
            End If

            Return
        End Function


    End Class
End Namespace
