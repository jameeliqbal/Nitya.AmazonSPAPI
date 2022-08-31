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
    /// The size dimensions of the label.
    /// </summary>
    [DataContract]
    public partial class DocumentSize :  IEquatable<DocumentSize>, IValidatableObject
    {
        /// <summary>
        /// The unit of measurement.
        /// </summary>
        /// <value>The unit of measurement.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UnitEnum
        {
            
            /// <summary>
            /// Enum INCH for value: INCH
            /// </summary>
            [EnumMember(Value = "INCH")]
            INCH = 1,
            
            /// <summary>
            /// Enum CENTIMETER for value: CENTIMETER
            /// </summary>
            [EnumMember(Value = "CENTIMETER")]
            CENTIMETER = 2
        }

        /// <summary>
        /// The unit of measurement.
        /// </summary>
        /// <value>The unit of measurement.</value>
        [DataMember(Name="unit", EmitDefaultValue=false)]
        public UnitEnum Unit { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentSize" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DocumentSize() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentSize" /> class.
        /// </summary>
        /// <param name="width">The width of the document measured in the units specified. (required).</param>
        /// <param name="length">The length of the document measured in the units specified. (required).</param>
        /// <param name="unit">The unit of measurement. (required).</param>
        public DocumentSize(decimal? width = default(decimal?), decimal? length = default(decimal?), UnitEnum unit = default(UnitEnum))
        {
            // to ensure "width" is required (not null)
            if (width == null)
            {
                throw new InvalidDataException("width is a required property for DocumentSize and cannot be null");
            }
            else
            {
                this.Width = width;
            }
            // to ensure "length" is required (not null)
            if (length == null)
            {
                throw new InvalidDataException("length is a required property for DocumentSize and cannot be null");
            }
            else
            {
                this.Length = length;
            }
            // to ensure "unit" is required (not null)
            if (unit == null)
            {
                throw new InvalidDataException("unit is a required property for DocumentSize and cannot be null");
            }
            else
            {
                this.Unit = unit;
            }
        }
        
        /// <summary>
        /// The width of the document measured in the units specified.
        /// </summary>
        /// <value>The width of the document measured in the units specified.</value>
        [DataMember(Name="width", EmitDefaultValue=false)]
        public decimal? Width { get; set; }

        /// <summary>
        /// The length of the document measured in the units specified.
        /// </summary>
        /// <value>The length of the document measured in the units specified.</value>
        [DataMember(Name="length", EmitDefaultValue=false)]
        public decimal? Length { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DocumentSize {\n");
            sb.Append("  Width: ").Append(Width).Append("\n");
            sb.Append("  Length: ").Append(Length).Append("\n");
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
            return this.Equals(input as DocumentSize);
        }

        /// <summary>
        /// Returns true if DocumentSize instances are equal
        /// </summary>
        /// <param name="input">Instance of DocumentSize to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DocumentSize input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Width == input.Width ||
                    (this.Width != null &&
                    this.Width.Equals(input.Width))
                ) && 
                (
                    this.Length == input.Length ||
                    (this.Length != null &&
                    this.Length.Equals(input.Length))
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
                if (this.Width != null)
                    hashCode = hashCode * 59 + this.Width.GetHashCode();
                if (this.Length != null)
                    hashCode = hashCode * 59 + this.Length.GetHashCode();
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
            yield break;
        }
    }

}
