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
    /// The post-purchase details of a package that will be shipped using a shipping service.
    /// </summary>
    [DataContract]
    public partial class PackageDocumentDetail :  IEquatable<PackageDocumentDetail>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PackageDocumentDetail" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PackageDocumentDetail() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PackageDocumentDetail" /> class.
        /// </summary>
        /// <param name="packageClientReferenceId">packageClientReferenceId (required).</param>
        /// <param name="packageDocuments">packageDocuments (required).</param>
        /// <param name="trackingId">trackingId.</param>
        public PackageDocumentDetail(PackageClientReferenceId packageClientReferenceId = default(PackageClientReferenceId), PackageDocumentList packageDocuments = default(PackageDocumentList), TrackingId trackingId = default(TrackingId))
        {
            // to ensure "packageClientReferenceId" is required (not null)
            if (packageClientReferenceId == null)
            {
                throw new InvalidDataException("packageClientReferenceId is a required property for PackageDocumentDetail and cannot be null");
            }
            else
            {
                this.PackageClientReferenceId = packageClientReferenceId;
            }
            // to ensure "packageDocuments" is required (not null)
            if (packageDocuments == null)
            {
                throw new InvalidDataException("packageDocuments is a required property for PackageDocumentDetail and cannot be null");
            }
            else
            {
                this.PackageDocuments = packageDocuments;
            }
            this.TrackingId = trackingId;
        }
        
        /// <summary>
        /// Gets or Sets PackageClientReferenceId
        /// </summary>
        [DataMember(Name="packageClientReferenceId", EmitDefaultValue=false)]
        public PackageClientReferenceId PackageClientReferenceId { get; set; }

        /// <summary>
        /// Gets or Sets PackageDocuments
        /// </summary>
        [DataMember(Name="packageDocuments", EmitDefaultValue=false)]
        public PackageDocumentList PackageDocuments { get; set; }

        /// <summary>
        /// Gets or Sets TrackingId
        /// </summary>
        [DataMember(Name="trackingId", EmitDefaultValue=false)]
        public TrackingId TrackingId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PackageDocumentDetail {\n");
            sb.Append("  PackageClientReferenceId: ").Append(PackageClientReferenceId).Append("\n");
            sb.Append("  PackageDocuments: ").Append(PackageDocuments).Append("\n");
            sb.Append("  TrackingId: ").Append(TrackingId).Append("\n");
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
            return this.Equals(input as PackageDocumentDetail);
        }

        /// <summary>
        /// Returns true if PackageDocumentDetail instances are equal
        /// </summary>
        /// <param name="input">Instance of PackageDocumentDetail to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PackageDocumentDetail input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.PackageClientReferenceId == input.PackageClientReferenceId ||
                    (this.PackageClientReferenceId != null &&
                    this.PackageClientReferenceId.Equals(input.PackageClientReferenceId))
                ) && 
                (
                    this.PackageDocuments == input.PackageDocuments ||
                    (this.PackageDocuments != null &&
                    this.PackageDocuments.Equals(input.PackageDocuments))
                ) && 
                (
                    this.TrackingId == input.TrackingId ||
                    (this.TrackingId != null &&
                    this.TrackingId.Equals(input.TrackingId))
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
                if (this.PackageClientReferenceId != null)
                    hashCode = hashCode * 59 + this.PackageClientReferenceId.GetHashCode();
                if (this.PackageDocuments != null)
                    hashCode = hashCode * 59 + this.PackageDocuments.GetHashCode();
                if (this.TrackingId != null)
                    hashCode = hashCode * 59 + this.TrackingId.GetHashCode();
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
