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
    /// Shipment source channel related information.
    /// </summary>
    [DataContract]
    public partial class ChannelDetails :  IEquatable<ChannelDetails>, IValidatableObject
    {
        /// <summary>
        /// The shipment source channel type.
        /// </summary>
        /// <value>The shipment source channel type.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ChannelTypeEnum
        {
            
            /// <summary>
            /// Enum AMAZON for value: AMAZON
            /// </summary>
            [EnumMember(Value = "AMAZON")]
            AMAZON = 1,
            
            /// <summary>
            /// Enum EXTERNAL for value: EXTERNAL
            /// </summary>
            [EnumMember(Value = "EXTERNAL")]
            EXTERNAL = 2
        }

        /// <summary>
        /// The shipment source channel type.
        /// </summary>
        /// <value>The shipment source channel type.</value>
        [DataMember(Name="channelType", EmitDefaultValue=false)]
        public ChannelTypeEnum ChannelType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelDetails" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ChannelDetails() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelDetails" /> class.
        /// </summary>
        /// <param name="channelType">The shipment source channel type. (required).</param>
        /// <param name="amazonOrderDetails">amazonOrderDetails.</param>
        /// <param name="amazonShipmentDetails">amazonShipmentDetails.</param>
        public ChannelDetails(ChannelTypeEnum channelType = default(ChannelTypeEnum), AmazonOrderDetails amazonOrderDetails = default(AmazonOrderDetails), AmazonShipmentDetails amazonShipmentDetails = default(AmazonShipmentDetails))
        {
            // to ensure "channelType" is required (not null)
            if (channelType == null)
            {
                throw new InvalidDataException("channelType is a required property for ChannelDetails and cannot be null");
            }
            else
            {
                this.ChannelType = channelType;
            }
            this.AmazonOrderDetails = amazonOrderDetails;
            this.AmazonShipmentDetails = amazonShipmentDetails;
        }
        

        /// <summary>
        /// Gets or Sets AmazonOrderDetails
        /// </summary>
        [DataMember(Name="amazonOrderDetails", EmitDefaultValue=false)]
        public AmazonOrderDetails AmazonOrderDetails { get; set; }

        /// <summary>
        /// Gets or Sets AmazonShipmentDetails
        /// </summary>
        [DataMember(Name="amazonShipmentDetails", EmitDefaultValue=false)]
        public AmazonShipmentDetails AmazonShipmentDetails { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ChannelDetails {\n");
            sb.Append("  ChannelType: ").Append(ChannelType).Append("\n");
            sb.Append("  AmazonOrderDetails: ").Append(AmazonOrderDetails).Append("\n");
            sb.Append("  AmazonShipmentDetails: ").Append(AmazonShipmentDetails).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ChannelDetails);
        }

        /// <summary>
        /// Returns true if ChannelDetails instances are equal
        /// </summary>
        /// <param name="input">Instance of ChannelDetails to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChannelDetails input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ChannelType == input.ChannelType ||
                    (this.ChannelType != null &&
                    this.ChannelType.Equals(input.ChannelType))
                ) && 
                (
                    this.AmazonOrderDetails == input.AmazonOrderDetails ||
                    (this.AmazonOrderDetails != null &&
                    this.AmazonOrderDetails.Equals(input.AmazonOrderDetails))
                ) && 
                (
                    this.AmazonShipmentDetails == input.AmazonShipmentDetails ||
                    (this.AmazonShipmentDetails != null &&
                    this.AmazonShipmentDetails.Equals(input.AmazonShipmentDetails))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.ChannelType != null)
                    hashCode = hashCode * 59 + this.ChannelType.GetHashCode();
                if (this.AmazonOrderDetails != null)
                    hashCode = hashCode * 59 + this.AmazonOrderDetails.GetHashCode();
                if (this.AmazonShipmentDetails != null)
                    hashCode = hashCode * 59 + this.AmazonShipmentDetails.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}