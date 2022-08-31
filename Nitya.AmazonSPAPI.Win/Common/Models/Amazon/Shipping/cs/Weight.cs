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
    /// The weight in the units indicated.
    /// </summary>
    [DataContract]
    public partial class Weight :  IEquatable<Weight>, IValidatableObject
    {
        /// <summary>
        /// The unit of measurement.
        /// </summary>
        /// <value>The unit of measurement.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UnitEnum
        {
            
            /// <summary>
            /// Enum GRAM for value: GRAM
            /// </summary>
            [EnumMember(Value = "GRAM")]
            GRAM = 1,
            
            /// <summary>
            /// Enum KILOGRAM for value: KILOGRAM
            /// </summary>
            [EnumMember(Value = "KILOGRAM")]
            KILOGRAM = 2,
            
            /// <summary>
            /// Enum OUNCE for value: OUNCE
            /// </summary>
            [EnumMember(Value = "OUNCE")]
            OUNCE = 3,
            
            /// <summary>
            /// Enum POUND for value: POUND
            /// </summary>
            [EnumMember(Value = "POUND")]
            POUND = 4
        }

        /// <summary>
        /// The unit of measurement.
        /// </summary>
        /// <value>The unit of measurement.</value>
        [DataMember(Name="unit", EmitDefaultValue=false)]
        public UnitEnum Unit { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Weight" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Weight() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Weight" /> class.
        /// </summary>
        /// <param name="unit">The unit of measurement. (required).</param>
        /// <param name="value">The measurement value. (required).</param>
        public Weight(UnitEnum unit = default(UnitEnum), decimal? value = default(decimal?))
        {
            // to ensure "unit" is required (not null)
            if (unit == null)
            {
                throw new InvalidDataException("unit is a required property for Weight and cannot be null");
            }
            else
            {
                this.Unit = unit;
            }
            // to ensure "value" is required (not null)
            if (value == null)
            {
                throw new InvalidDataException("value is a required property for Weight and cannot be null");
            }
            else
            {
                this.Value = value;
            }
        }
        

        /// <summary>
        /// The measurement value.
        /// </summary>
        /// <value>The measurement value.</value>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public decimal? Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Weight {\n");
            sb.Append("  Unit: ").Append(Unit).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
            return this.Equals(input as Weight);
        }

        /// <summary>
        /// Returns true if Weight instances are equal
        /// </summary>
        /// <param name="input">Instance of Weight to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Weight input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Unit == input.Unit ||
                    (this.Unit != null &&
                    this.Unit.Equals(input.Unit))
                ) && 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
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
                if (this.Unit != null)
                    hashCode = hashCode * 59 + this.Unit.GetHashCode();
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
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
