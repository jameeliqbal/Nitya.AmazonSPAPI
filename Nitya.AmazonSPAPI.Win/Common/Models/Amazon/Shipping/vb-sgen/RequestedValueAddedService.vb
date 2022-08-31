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
    Public Partial Class RequestedValueAddedService
        Implements IEquatable(Of RequestedValueAddedService), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional id As String = Nothing)
            If id Is Nothing Then
                Throw New InvalidDataException("id is a required property for RequestedValueAddedService and cannot be null")
            Else
                Me.Id = id
            End If
        End Sub

        <DataMember(Name:="id", EmitDefaultValue:=False)>
        Public Property Id As String

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class RequestedValueAddedService {" & vbLf)
            sb.Append("  Id: ").Append(Id).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, RequestedValueAddedService))
        End Function

        Public Function Equals(ByVal input As RequestedValueAddedService) As Boolean
            If input Is Nothing Then Return False
            Return (Me.Id = input.Id OrElse (Me.Id IsNot Nothing AndAlso Me.Id.Equals(input.Id)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.Id IsNot Nothing Then hashCode = hashCode * 59 + Me.Id.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
