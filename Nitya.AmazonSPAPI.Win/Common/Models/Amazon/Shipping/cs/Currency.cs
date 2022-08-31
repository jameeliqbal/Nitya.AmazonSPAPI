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
    /// The monetary value in the currency indicated, in ISO 4217 standard format.
    /// </summary>
    [DataContract]
    public partial class Currency :  IEquatable<Currency>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Currency" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Currency() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Currency" /> class.
        /// </summary>
        /// <param name="value">The monetary value. (required).</param>
        /// <param name="unit">The ISO 4217 format 3-character currency code. (required).</param>
        public Currency(decimal? value = default(decimal?), string unit = default(string))
        {
            // to ensure "value" is required (not null)
            if (value == null)
            {
                throw new InvalidDataException("value is a required property for Currency and cannot be null");
            }
            else
            {
                this.Value = value;
            }
            // to ensure "unit" is required (not null)
            if (unit == null)
            {
                throw new InvalidDataException("unit is a required property for Currency and cannot be null");
            }
            else
            {
                this.Unit = unit;
            }
        }
        
        /// <summary>
        /// The monetary value.
        /// </summary>
        /// <value>The monetary value.</value>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public decimal? Value { get; set; }

        /// <summary>
        /// The ISO 4217 format 3-character currency code.
        /// </summary>
        /// <value>The ISO 4217 format 3-character currency code.</value>
        [DataMember(Name="unit", EmitDefaultValue=false)]
        public string Unit { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Currency {\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Unit: ").Append(Unit).Append("\n");
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
            return this.Equals(input as Currency);
        }

        /// <summary>
        /// Returns true if Currency instances are equal
        /// </summary>
        /// <param name="input">Instance of Currency to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Currency input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
                ) && 
                (
                    this.Unit == input.Unit ||
                    (this.Unit != null &&
                    this.Unit.Equals(input.Unit))
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
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
                if (this.Unit != null)
                    hashCode = hashCode * 59 + this.Unit.GetHashCode();
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
            // Unit (string) maxLength
            if(this.Unit != null && this.Unit.Length > 3)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Unit, length must be less than 3.", new [] { "Unit" });
            }

            // Unit (string) minLength
            if(this.Unit != null && this.Unit.Length < 3)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Unit, length must be greater than 3.", new [] { "Unit" });
            }

            yield break;
        }
    }

}
