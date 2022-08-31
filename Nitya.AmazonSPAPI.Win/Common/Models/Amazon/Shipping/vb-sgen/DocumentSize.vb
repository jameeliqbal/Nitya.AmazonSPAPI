﻿Imports System
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
    Public Partial Class DocumentSize
        Implements IEquatable(Of DocumentSize), IValidatableObject

        <JsonConverter(GetType(StringEnumConverter))>
        Public Enum UnitEnum
            <EnumMember(Value:="INCH")>
            INCH = 1
            <EnumMember(Value:="CENTIMETER")>
            CENTIMETER = 2
        End Enum

        <DataMember(Name:="unit", EmitDefaultValue:=False)>
        Public Property Unit As UnitEnum

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional width As Decimal? = Nothing, ByVal Optional length As Decimal? = Nothing, ByVal Optional unit As UnitEnum = Nothing)
            If width Is Nothing Then
                Throw New InvalidDataException("width is a required property for DocumentSize and cannot be null")
            Else
                Me.Width = width
            End If

            If length Is Nothing Then
                Throw New InvalidDataException("length is a required property for DocumentSize and cannot be null")
            Else
                Me.Length = length
            End If

            If unit Is Nothing Then
                Throw New InvalidDataException("unit is a required property for DocumentSize and cannot be null")
            Else
                Me.Unit = unit
            End If
        End Sub

        <DataMember(Name:="width", EmitDefaultValue:=False)>
        Public Property Width As Decimal?
        <DataMember(Name:="length", EmitDefaultValue:=False)>
        Public Property Length As Decimal?

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class DocumentSize {" & vbLf)
            sb.Append("  Width: ").Append(Width).Append(vbLf)
            sb.Append("  Length: ").Append(Length).Append(vbLf)
            sb.Append("  Unit: ").Append(Unit).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, DocumentSize))
        End Function

        Public Function Equals(ByVal input As DocumentSize) As Boolean
            If input Is Nothing Then Return False
            Return (Me.Width = input.Width OrElse (Me.Width IsNot Nothing AndAlso Me.Width.Equals(input.Width))) AndAlso (Me.Length = input.Length OrElse (Me.Length IsNot Nothing AndAlso Me.Length.Equals(input.Length))) AndAlso (Me.Unit = input.Unit OrElse (Me.Unit IsNot Nothing AndAlso Me.Unit.Equals(input.Unit)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.Width IsNot Nothing Then hashCode = hashCode * 59 + Me.Width.GetHashCode()
            If Me.Length IsNot Nothing Then hashCode = hashCode * 59 + Me.Length.GetHashCode()
            If Me.Unit IsNot Nothing Then hashCode = hashCode * 59 + Me.Unit.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
