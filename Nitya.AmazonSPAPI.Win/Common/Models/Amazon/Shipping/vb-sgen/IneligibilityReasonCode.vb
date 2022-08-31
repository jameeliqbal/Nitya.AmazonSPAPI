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
    Public Enum IneligibilityReasonCode
        <EnumMember(Value:="NO_COVERAGE")>
        NOCOVERAGE = 1
        <EnumMember(Value:="PICKUP_SLOT_RESTRICTION")>
        PICKUPSLOTRESTRICTION = 2
        <EnumMember(Value:="UNSUPPORTED_VAS")>
        UNSUPPORTEDVAS = 3
        <EnumMember(Value:="VAS_COMBINATION_RESTRICTION")>
        VASCOMBINATIONRESTRICTION = 4
        <EnumMember(Value:="SIZE_RESTRICTIONS")>
        SIZERESTRICTIONS = 5
        <EnumMember(Value:="WEIGHT_RESTRICTIONS")>
        WEIGHTRESTRICTIONS = 6
        <EnumMember(Value:="LATE_DELIVERY")>
        LATEDELIVERY = 7
        <EnumMember(Value:="PROGRAM_CONSTRAINTS")>
        PROGRAMCONSTRAINTS = 8
        <EnumMember(Value:="TERMS_AND_CONDITIONS_NOT_ACCEPTED")>
        TERMSANDCONDITIONSNOTACCEPTED = 9
        <EnumMember(Value:="UNKNOWN")>
        UNKNOWN = 10
    End Enum
End Namespace
