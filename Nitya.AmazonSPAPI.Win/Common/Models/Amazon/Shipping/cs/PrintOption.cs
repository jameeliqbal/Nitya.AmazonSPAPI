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
    /// The format options available for a label.
    /// </summary>
    [DataContract]
    public partial class PrintOption :  IEquatable<PrintOption>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrintOption" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PrintOption() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PrintOption" /> class.
        /// </summary>
        /// <param name="supportedDPIs">A list of the supported DPI options for a document..</param>
        /// <param name="supportedPageLayouts">A list of the supported page layout options for a document. (required).</param>
        /// <param name="supportedFileJoiningOptions">A list of the supported needFileJoining boolean values for a document. (required).</param>
        /// <param name="supportedDocumentDetails">A list of the supported documented details. (required).</param>
        public PrintOption(List<Dpi> supportedDPIs = default(List<Dpi>), List<PageLayout> supportedPageLayouts = default(List<PageLayout>), List<NeedFileJoining> supportedFileJoiningOptions = default(List<NeedFileJoining>), List<SupportedDocumentDetail> supportedDocumentDetails = default(List<SupportedDocumentDetail>))
        {
            // to ensure "supportedPageLayouts" is required (not null)
            if (supportedPageLayouts == null)
            {
                throw new InvalidDataException("supportedPageLayouts is a required property for PrintOption and cannot be null");
            }
            else
            {
                this.SupportedPageLayouts = supportedPageLayouts;
            }
            // to ensure "supportedFileJoiningOptions" is required (not null)
            if (supportedFileJoiningOptions == null)
            {
                throw new InvalidDataException("supportedFileJoiningOptions is a required property for PrintOption and cannot be null");
            }
            else
            {
                this.SupportedFileJoiningOptions = supportedFileJoiningOptions;
            }
            // to ensure "supportedDocumentDetails" is required (not null)
            if (supportedDocumentDetails == null)
            {
                throw new InvalidDataException("supportedDocumentDetails is a required property for PrintOption and cannot be null");
            }
            else
            {
                this.SupportedDocumentDetails = supportedDocumentDetails;
            }
            this.SupportedDPIs = supportedDPIs;
        }
        
        /// <summary>
        /// A list of the supported DPI options for a document.
        /// </summary>
        /// <value>A list of the supported DPI options for a document.</value>
        [DataMember(Name="supportedDPIs", EmitDefaultValue=false)]
        public List<Dpi> SupportedDPIs { get; set; }

        /// <summary>
        /// A list of the supported page layout options for a document.
        /// </summary>
        /// <value>A list of the supported page layout options for a document.</value>
        [DataMember(Name="supportedPageLayouts", EmitDefaultValue=false)]
        public List<PageLayout> SupportedPageLayouts { get; set; }

        /// <summary>
        /// A list of the supported needFileJoining boolean values for a document.
        /// </summary>
        /// <value>A list of the supported needFileJoining boolean values for a document.</value>
        [DataMember(Name="supportedFileJoiningOptions", EmitDefaultValue=false)]
        public List<NeedFileJoining> SupportedFileJoiningOptions { get; set; }

        /// <summary>
        /// A list of the supported documented details.
        /// </summary>
        /// <value>A list of the supported documented details.</value>
        [DataMember(Name="supportedDocumentDetails", EmitDefaultValue=false)]
        public List<SupportedDocumentDetail> SupportedDocumentDetails { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PrintOption {\n");
            sb.Append("  SupportedDPIs: ").Append(SupportedDPIs).Append("\n");
            sb.Append("  SupportedPageLayouts: ").Append(SupportedPageLayouts).Append("\n");
            sb.Append("  SupportedFileJoiningOptions: ").Append(SupportedFileJoiningOptions).Append("\n");
            sb.Append("  SupportedDocumentDetails: ").Append(SupportedDocumentDetails).Append("\n");
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
            return this.Equals(input as PrintOption);
        }

        /// <summary>
        /// Returns true if PrintOption instances are equal
        /// </summary>
        /// <param name="input">Instance of PrintOption to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PrintOption input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.SupportedDPIs == input.SupportedDPIs ||
                    this.SupportedDPIs != null &&
                    this.SupportedDPIs.SequenceEqual(input.SupportedDPIs)
                ) && 
                (
                    this.SupportedPageLayouts == input.SupportedPageLayouts ||
                    this.SupportedPageLayouts != null &&
                    this.SupportedPageLayouts.SequenceEqual(input.SupportedPageLayouts)
                ) && 
                (
                    this.SupportedFileJoiningOptions == input.SupportedFileJoiningOptions ||
                    this.SupportedFileJoiningOptions != null &&
                    this.SupportedFileJoiningOptions.SequenceEqual(input.SupportedFileJoiningOptions)
                ) && 
                (
                    this.SupportedDocumentDetails == input.SupportedDocumentDetails ||
                    this.SupportedDocumentDetails != null &&
                    this.SupportedDocumentDetails.SequenceEqual(input.SupportedDocumentDetails)
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
                if (this.SupportedDPIs != null)
                    hashCode = hashCode * 59 + this.SupportedDPIs.GetHashCode();
                if (this.SupportedPageLayouts != null)
                    hashCode = hashCode * 59 + this.SupportedPageLayouts.GetHashCode();
                if (this.SupportedFileJoiningOptions != null)
                    hashCode = hashCode * 59 + this.SupportedFileJoiningOptions.GetHashCode();
                if (this.SupportedDocumentDetails != null)
                    hashCode = hashCode * 59 + this.SupportedDocumentDetails.GetHashCode();
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