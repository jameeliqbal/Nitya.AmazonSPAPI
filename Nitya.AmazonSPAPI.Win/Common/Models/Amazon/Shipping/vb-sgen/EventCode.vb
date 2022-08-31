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
    Public Enum EventCode
        <EnumMember(Value:="ReadyForReceive")>
        ReadyForReceive = 1
        <EnumMember(Value:="PickupDone")>
        PickupDone = 2
        <EnumMember(Value:="Delivered")>
        Delivered = 3
        <EnumMember(Value:="Departed")>
        Departed = 4
        <EnumMember(Value:="DeliveryAttempted")>
        DeliveryAttempted = 5
        <EnumMember(Value:="Lost")>
        Lost = 6
        <EnumMember(Value:="OutForDelivery")>
        OutForDelivery = 7
        <EnumMember(Value:="ArrivedAtCarrierFacility")>
        ArrivedAtCarrierFacility = 8
        <EnumMember(Value:="Rejected")>
        Rejected = 9
        <EnumMember(Value:="Undeliverable")>
        Undeliverable = 10
        <EnumMember(Value:="PickupCancelled")>
        PickupCancelled = 11
    End Enum
End Namespace
