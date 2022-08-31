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
    Public Partial Class DirectFulfillmentItemIdentifiers
        Implements IEquatable(Of DirectFulfillmentItemIdentifiers), IValidatableObject

        <JsonConstructorAttribute>
        Protected Sub New()
        End Sub

        Public Sub New(ByVal Optional lineItemID As String = Nothing, ByVal Optional pieceNumber As String = Nothing)
            If lineItemID Is Nothing Then
                Throw New InvalidDataException("lineItemID is a required property for DirectFulfillmentItemIdentifiers and cannot be null")
            Else
                Me.LineItemID = lineItemID
            End If

            Me.PieceNumber = pieceNumber
        End Sub

        <DataMember(Name:="lineItemID", EmitDefaultValue:=False)>
        Public Property LineItemID As String
        <DataMember(Name:="pieceNumber", EmitDefaultValue:=False)>
        Public Property PieceNumber As String

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class DirectFulfillmentItemIdentifiers {" & vbLf)
            sb.Append("  LineItemID: ").Append(LineItemID).Append(vbLf)
            sb.Append("  PieceNumber: ").Append(PieceNumber).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Overridable Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, DirectFulfillmentItemIdentifiers))
        End Function

        Public Function Equals(ByVal input As DirectFulfillmentItemIdentifiers) As Boolean
            If input Is Nothing Then Return False
            Return (Me.LineItemID = input.LineItemID OrElse (Me.LineItemID IsNot Nothing AndAlso Me.LineItemID.Equals(input.LineItemID))) AndAlso (Me.PieceNumber = input.PieceNumber OrElse (Me.PieceNumber IsNot Nothing AndAlso Me.PieceNumber.Equals(input.PieceNumber)))
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = 41
            If Me.LineItemID IsNot Nothing Then hashCode = hashCode * 59 + Me.LineItemID.GetHashCode()
            If Me.PieceNumber IsNot Nothing Then hashCode = hashCode * 59 + Me.PieceNumber.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
