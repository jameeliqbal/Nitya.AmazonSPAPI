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
    Public Partial Class AvailableValueAddedServiceGroup
        Implements IEquatable(Of AvailableValueAddedServiceGroup), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional groupId As String = Nothing, ByVal Optional groupDescription As String = Nothing, ByVal Optional isRequired As Boolean? = Nothing, ByVal Optional valueAddedServices As List(Of ValueAddedService) = Nothing)
            If groupId Is Nothing Then
                Throw New InvalidDataException("groupId is a required property for AvailableValueAddedServiceGroup and cannot be null")
            Else
                Me.GroupId = groupId
            End If

            If groupDescription Is Nothing Then
                Throw New InvalidDataException("groupDescription is a required property for AvailableValueAddedServiceGroup and cannot be null")
            Else
                Me.GroupDescription = groupDescription
            End If

            If isRequired Is Nothing Then
                Throw New InvalidDataException("isRequired is a required property for AvailableValueAddedServiceGroup and cannot be null")
            Else
                Me.IsRequired = isRequired
            End If

            Me.ValueAddedServices = valueAddedServices
        End Sub

        <DataMember(Name:="groupId", EmitDefaultValue:=False)>
        Public Property GroupId As String
        <DataMember(Name:="groupDescription", EmitDefaultValue:=False)>
        Public Property GroupDescription As String
        <DataMember(Name:="isRequired", EmitDefaultValue:=False)>
        Public Property IsRequired As Boolean?
        <DataMember(Name:="valueAddedServices", EmitDefaultValue:=False)>
        Public Property ValueAddedServices As List(Of ValueAddedService)

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class AvailableValueAddedServiceGroup {" & vbLf)
            sb.Append("  GroupId: ").Append(GroupId).Append(vbLf)
            sb.Append("  GroupDescription: ").Append(GroupDescription).Append(vbLf)
            sb.Append("  IsRequired: ").Append(IsRequired).Append(vbLf)
            sb.Append("  ValueAddedServices: ").Append(ValueAddedServices).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, AvailableValueAddedServiceGroup))
        End Function

        Public Function Equals(ByVal input As AvailableValueAddedServiceGroup) As Boolean
            If input Is Nothing Then Return False
            Return (Me.GroupId = input.GroupId OrElse (Me.GroupId IsNot Nothing AndAlso Me.GroupId.Equals(input.GroupId))) AndAlso (Me.GroupDescription = input.GroupDescription OrElse (Me.GroupDescription IsNot Nothing AndAlso Me.GroupDescription.Equals(input.GroupDescription))) AndAlso (Me.IsRequired = input.IsRequired OrElse (Me.IsRequired IsNot Nothing AndAlso Me.IsRequired.Equals(input.IsRequired))) AndAlso (Me.ValueAddedServices = input.ValueAddedServices OrElse Me.ValueAddedServices IsNot Nothing AndAlso Me.ValueAddedServices.SequenceEqual(input.ValueAddedServices))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.GroupId IsNot Nothing Then hashCode = hashCode * 59 + Me.GroupId.GetHashCode()
            If Me.GroupDescription IsNot Nothing Then hashCode = hashCode * 59 + Me.GroupDescription.GetHashCode()
            If Me.IsRequired IsNot Nothing Then hashCode = hashCode * 59 + Me.IsRequired.GetHashCode()
            If Me.ValueAddedServices IsNot Nothing Then hashCode = hashCode * 59 + Me.ValueAddedServices.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
