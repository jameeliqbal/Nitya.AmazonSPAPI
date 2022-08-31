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
    Public Partial Class PrintOptionList
        Inherits List(Of PrintOption)
        Implements IEquatable(Of PrintOptionList), IValidatableObject

        <JsonConstructorAttribute>
        Public Sub New()
            MyBase.New()
        End Sub

        Public Overrides Function ToString() As String
            Dim sb = New StringBuilder()
            sb.Append("class PrintOptionList {" & vbLf)
            sb.Append("  ").Append(MyBase.ToString().Replace(vbLf, vbLf & "  ")).Append(vbLf)
            sb.Append("}" & vbLf)
            Return sb.ToString()
        End Function

        Public Function ToJson() As String
            Return JsonConvert.SerializeObject(Me, Formatting.Indented)
        End Function

        Public Overrides Function Equals(ByVal input As Object) As Boolean
            Return Me.Equals(TryCast(input, PrintOptionList))
        End Function

        Public Function Equals(ByVal input As PrintOptionList) As Boolean
            If input Is Nothing Then Return False
            Return MyBase.Equals(input)
        End Function

        Public Overrides Function GetHashCode() As Integer
            BEGIN TODO : Visual Basic does not support checked statements!
            Dim hashCode As Integer = MyBase.GetHashCode()
            Return hashCode
            END TODO : Visual Basic does not support checked statements!
        End Function

        Private Iterator Function Validate(ByVal validationContext As ValidationContext) As IEnumerable(Of System.ComponentModel.DataAnnotations.ValidationResult)
            Return
        End Function
    End Class
End Namespace
