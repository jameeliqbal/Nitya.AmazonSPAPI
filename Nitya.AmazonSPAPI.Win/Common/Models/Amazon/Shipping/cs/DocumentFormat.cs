/* 
 * Amazon Shipping API
 *
 * The Amazon Shipping API is designed to support outbound shipping use cases both for orders originating on Amazon-owned marketplaces as well as external channels/marketplaces. With these APIs, you can request shipping rates, create shipments, cancel shipments, and track shipments.
 *
 * OpenAPI spec version: v2
 * Contact: swa-api-core@amazon.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = Amazon.SellingPartnerAPI.Orders.Client.SwaggerDateConverter;

namespace Common.Models.Amzn.Shipping
{
    /// <summary>
    /// The file format of the document.
    /// </summary>
    /// <value>The file format of the document.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum DocumentFormat
    {
        
        /// <summary>
        /// Enum PDF for value: PDF
        /// </summary>
        [EnumMember(Value = "PDF")]
        PDF = 1,
        
        /// <summary>
        /// Enum PNG for value: PNG
        /// </summary>
        [EnumMember(Value = "PNG")]
        PNG = 2,
        
        /// <summary>
        /// Enum ZPL for value: ZPL
        /// </summary>
        [EnumMember(Value = "ZPL")]
        ZPL = 3
    }

}