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
    <JsonConverter(GetType(StringEnumConverter))>
    Public Enum DocumentType
        <EnumMember(Value:="PACKSLIP")>
        PACKSLIP = 1
        <EnumMember(Value:="LABEL")>
        LABEL = 2
        <EnumMember(Value:="RECEIPT")>
        RECEIPT = 3
        <EnumMember(Value:="CUSTOM_FORM")>
        CUSTOMFORM = 4
    End Enum
End Namespace
