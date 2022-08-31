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
    Public Enum Status
        <EnumMember(Value:="PreTransit")>
        PreTransit = 1
        <EnumMember(Value:="InTransit")>
        InTransit = 2
        <EnumMember(Value:="Delivered")>
        Delivered = 3
        <EnumMember(Value:="Lost")>
        Lost = 4
        <EnumMember(Value:="OutForDelivery")>
        OutForDelivery = 5
        <EnumMember(Value:="Rejected")>
        Rejected = 6
        <EnumMember(Value:="Undeliverable")>
        Undeliverable = 7
        <EnumMember(Value:="DeliveryAttempted")>
        DeliveryAttempted = 8
        <EnumMember(Value:="PickupCancelled")>
        PickupCancelled = 9
    End Enum
End Namespace
