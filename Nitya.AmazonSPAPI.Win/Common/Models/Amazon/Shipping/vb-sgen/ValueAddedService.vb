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
    Public Partial Class ValueAddedService
        Implements IEquatable(Of ValueAddedService), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional id As String = Nothing, ByVal Optional name As String = Nothing, ByVal Optional cost As Currency = Nothing)
            If id Is Nothing Then
                Throw New InvalidDataException("id is a required property for ValueAddedService and cannot be null")
            Else
                Me.Id = id
            End If

            If name Is Nothing Then
                Throw New InvalidDataException("name is a required property for ValueAddedService and cannot be null")
            Else
                Me.Name = name
            End If

            If cost Is Nothing Then
                Throw New InvalidDataException("cost is a required property for ValueAddedService and cannot be null")
            Else
                Me.Cost = cost
            End If
        End Sub

        <DataMember(Name:="id", EmitDefaultValue:=False)>
        Public Property Id As String
        <DataMember(Name:="name", EmitDefaultValue:=False)>
        Public Property Name As String
        <DataMember(Name:="cost", EmitDefaultValue:=False)>
        Public Property Cost As Currency

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class ValueAddedService {" & vbLf)
            sb.Append("  Id: ").Append(Id).Append(vbLf)
            sb.Append("  Name: ").Append(Name).Append(vbLf)
            sb.Append("  Cost: ").Append(Cost).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, ValueAddedService))
        End Function

        Public Function Equals(ByVal input As ValueAddedService) As Boolean
            If input Is Nothing Then Return False
            Return (Me.Id = input.Id OrElse (Me.Id IsNot Nothing AndAlso Me.Id.Equals(input.Id))) AndAlso (Me.Name = input.Name OrElse (Me.Name IsNot Nothing AndAlso Me.Name.Equals(input.Name))) AndAlso (Me.Cost = input.Cost OrElse (Me.Cost IsNot Nothing AndAlso Me.Cost.Equals(input.Cost)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.Id IsNot Nothing Then hashCode = hashCode * 59 + Me.Id.GetHashCode()
            If Me.Name IsNot Nothing Then hashCode = hashCode * 59 + Me.Name.GetHashCode()
            If Me.Cost IsNot Nothing Then hashCode = hashCode * 59 + Me.Cost.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
