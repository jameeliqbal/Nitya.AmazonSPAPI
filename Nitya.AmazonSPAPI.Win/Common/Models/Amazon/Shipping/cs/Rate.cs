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
    /// The details of a shipping service offering.
    /// </summary>
    [DataContract]
    public partial class Rate :  IEquatable<Rate>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rate" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Rate() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Rate" /> class.
        /// </summary>
        /// <param name="rateId">rateId (required).</param>
        /// <param name="carrierId">carrierId (required).</param>
        /// <param name="carrierName">carrierName (required).</param>
        /// <param name="serviceId">serviceId (required).</param>
        /// <param name="serviceName">serviceName (required).</param>
        /// <param name="billedWeight">billedWeight.</param>
        /// <param name="totalCharge">totalCharge (required).</param>
        /// <param name="promise">promise (required).</param>
        /// <param name="supportedDocumentSpecifications">supportedDocumentSpecifications (required).</param>
        /// <param name="availableValueAddedServiceGroups">availableValueAddedServiceGroups.</param>
        /// <param name="requiresAdditionalInputs">When true, indicates that additional inputs are required to purchase this shipment service. You must then call the getAdditionalInputs operation to return the JSON schema to use when providing the additional inputs to the purchaseShipment operation. (required).</param>
        public Rate(RateId rateId = default(RateId), CarrierId carrierId = default(CarrierId), CarrierName carrierName = default(CarrierName), ServiceId serviceId = default(ServiceId), ServiceName serviceName = default(ServiceName), Weight billedWeight = default(Weight), Currency totalCharge = default(Currency), Promise promise = default(Promise), SupportedDocumentSpecificationList supportedDocumentSpecifications = default(SupportedDocumentSpecificationList), AvailableValueAddedServiceGroupList availableValueAddedServiceGroups = default(AvailableValueAddedServiceGroupList), bool? requiresAdditionalInputs = default(bool?))
        {
            // to ensure "rateId" is required (not null)
            if (rateId == null)
            {
                throw new InvalidDataException("rateId is a required property for Rate and cannot be null");
            }
            else
            {
                this.RateId = rateId;
            }
            // to ensure "carrierId" is required (not null)
            if (carrierId == null)
            {
                throw new InvalidDataException("carrierId is a required property for Rate and cannot be null");
            }
            else
            {
                this.CarrierId = carrierId;
            }
            // to ensure "carrierName" is required (not null)
            if (carrierName == null)
            {
                throw new InvalidDataException("carrierName is a required property for Rate and cannot be null");
            }
            else
            {
                this.CarrierName = carrierName;
            }
            // to ensure "serviceId" is required (not null)
            if (serviceId == null)
            {
                throw new InvalidDataException("serviceId is a required property for Rate and cannot be null");
            }
            else
            {
                this.ServiceId = serviceId;
            }
            // to ensure "serviceName" is required (not null)
            if (serviceName == null)
            {
                throw new InvalidDataException("serviceName is a required property for Rate and cannot be null");
            }
            else
            {
                this.ServiceName = serviceName;
            }
            // to ensure "totalCharge" is required (not null)
            if (totalCharge == null)
            {
                throw new InvalidDataException("totalCharge is a required property for Rate and cannot be null");
            }
            else
            {
                this.TotalCharge = totalCharge;
            }
            // to ensure "promise" is required (not null)
            if (promise == null)
            {
                throw new InvalidDataException("promise is a required property for Rate and cannot be null");
            }
            else
            {
                this.Promise = promise;
            }
            // to ensure "supportedDocumentSpecifications" is required (not null)
            if (supportedDocumentSpecifications == null)
            {
                throw new InvalidDataException("supportedDocumentSpecifications is a required property for Rate and cannot be null");
            }
            else
            {
                this.SupportedDocumentSpecifications = supportedDocumentSpecifications;
            }
            // to ensure "requiresAdditionalInputs" is required (not null)
            if (requiresAdditionalInputs == null)
            {
                throw new InvalidDataException("requiresAdditionalInputs is a required property for Rate and cannot be null");
            }
            else
            {
                this.RequiresAdditionalInputs = requiresAdditionalInputs;
            }
            this.BilledWeight = billedWeight;
            this.AvailableValueAddedServiceGroups = availableValueAddedServiceGroups;
        }
        
        /// <summary>
        /// Gets or Sets RateId
        /// </summary>
        [DataMember(Name="rateId", EmitDefaultValue=false)]
        public RateId RateId { get; set; }

        /// <summary>
        /// Gets or Sets CarrierId
        /// </summary>
        [DataMember(Name="carrierId", EmitDefaultValue=false)]
        public CarrierId CarrierId { get; set; }

        /// <summary>
        /// Gets or Sets CarrierName
        /// </summary>
        [DataMember(Name="carrierName", EmitDefaultValue=false)]
        public CarrierName CarrierName { get; set; }

        /// <summary>
        /// Gets or Sets ServiceId
        /// </summary>
        [DataMember(Name="serviceId", EmitDefaultValue=false)]
        public ServiceId ServiceId { get; set; }

        /// <summary>
        /// Gets or Sets ServiceName
        /// </summary>
        [DataMember(Name="serviceName", EmitDefaultValue=false)]
        public ServiceName ServiceName { get; set; }

        /// <summary>
        /// Gets or Sets BilledWeight
        /// </summary>
        [DataMember(Name="billedWeight", EmitDefaultValue=false)]
        public Weight BilledWeight { get; set; }

        /// <summary>
        /// Gets or Sets TotalCharge
        /// </summary>
        [DataMember(Name="totalCharge", EmitDefaultValue=false)]
        public Currency TotalCharge { get; set; }

        /// <summary>
        /// Gets or Sets Promise
        /// </summary>
        [DataMember(Name="promise", EmitDefaultValue=false)]
        public Promise Promise { get; set; }

        /// <summary>
        /// Gets or Sets SupportedDocumentSpecifications
        /// </summary>
        [DataMember(Name="supportedDocumentSpecifications", EmitDefaultValue=false)]
        public SupportedDocumentSpecificationList SupportedDocumentSpecifications { get; set; }

        /// <summary>
        /// Gets or Sets AvailableValueAddedServiceGroups
        /// </summary>
        [DataMember(Name="availableValueAddedServiceGroups", EmitDefaultValue=false)]
        public AvailableValueAddedServiceGroupList AvailableValueAddedServiceGroups { get; set; }

        /// <summary>
        /// When true, indicates that additional inputs are required to purchase this shipment service. You must then call the getAdditionalInputs operation to return the JSON schema to use when providing the additional inputs to the purchaseShipment operation.
        /// </summary>
        /// <value>When true, indicates that additional inputs are required to purchase this shipment service. You must then call the getAdditionalInputs operation to return the JSON schema to use when providing the additional inputs to the purchaseShipment operation.</value>
        [DataMember(Name="requiresAdditionalInputs", EmitDefaultValue=false)]
        public bool? RequiresAdditionalInputs { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Rate {\n");
            sb.Append("  RateId: ").Append(RateId).Append("\n");
            sb.Append("  CarrierId: ").Append(CarrierId).Append("\n");
            sb.Append("  CarrierName: ").Append(CarrierName).Append("\n");
            sb.Append("  ServiceId: ").Append(ServiceId).Append("\n");
            sb.Append("  ServiceName: ").Append(ServiceName).Append("\n");
            sb.Append("  BilledWeight: ").Append(BilledWeight).Append("\n");
            sb.Append("  TotalCharge: ").Append(TotalCharge).Append("\n");
            sb.Append("  Promise: ").Append(Promise).Append("\n");
            sb.Append("  SupportedDocumentSpecifications: ").Append(SupportedDocumentSpecifications).Append("\n");
            sb.Append("  AvailableValueAddedServiceGroups: ").Append(AvailableValueAddedServiceGroups).Append("\n");
            sb.Append("  RequiresAdditionalInputs: ").Append(RequiresAdditionalInputs).Append("\n");
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
            return this.Equals(input as Rate);
        }

        /// <summary>
        /// Returns true if Rate instances are equal
        /// </summary>
        /// <param name="input">Instance of Rate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Rate input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.RateId == input.RateId ||
                    (this.RateId != null &&
                    this.RateId.Equals(input.RateId))
                ) && 
                (
                    this.CarrierId == input.CarrierId ||
                    (this.CarrierId != null &&
                    this.CarrierId.Equals(input.CarrierId))
                ) && 
                (
                    this.CarrierName == input.CarrierName ||
                    (this.CarrierName != null &&
                    this.CarrierName.Equals(input.CarrierName))
                ) && 
                (
                    this.ServiceId == input.ServiceId ||
                    (this.ServiceId != null &&
                    this.ServiceId.Equals(input.ServiceId))
                ) && 
                (
                    this.ServiceName == input.ServiceName ||
                    (this.ServiceName != null &&
                    this.ServiceName.Equals(input.ServiceName))
                ) && 
                (
                    this.BilledWeight == input.BilledWeight ||
                    (this.BilledWeight != null &&
                    this.BilledWeight.Equals(input.BilledWeight))
                ) && 
                (
                    this.TotalCharge == input.TotalCharge ||
                    (this.TotalCharge != null &&
                    this.TotalCharge.Equals(input.TotalCharge))
                ) && 
                (
                    this.Promise == input.Promise ||
                    (this.Promise != null &&
                    this.Promise.Equals(input.Promise))
                ) && 
                (
                    this.SupportedDocumentSpecifications == input.SupportedDocumentSpecifications ||
                    (this.SupportedDocumentSpecifications != null &&
                    this.SupportedDocumentSpecifications.Equals(input.SupportedDocumentSpecifications))
                ) && 
                (
                    this.AvailableValueAddedServiceGroups == input.AvailableValueAddedServiceGroups ||
                    (this.AvailableValueAddedServiceGroups != null &&
                    this.AvailableValueAddedServiceGroups.Equals(input.AvailableValueAddedServiceGroups))
                ) && 
                (
                    this.RequiresAdditionalInputs == input.RequiresAdditionalInputs ||
                    (this.RequiresAdditionalInputs != null &&
                    this.RequiresAdditionalInputs.Equals(input.RequiresAdditionalInputs))
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
                if (this.RateId != null)
                    hashCode = hashCode * 59 + this.RateId.GetHashCode();
                if (this.CarrierId != null)
                    hashCode = hashCode * 59 + this.CarrierId.GetHashCode();
                if (this.CarrierName != null)
                    hashCode = hashCode * 59 + this.CarrierName.GetHashCode();
                if (this.ServiceId != null)
                    hashCode = hashCode * 59 + this.ServiceId.GetHashCode();
                if (this.ServiceName != null)
                    hashCode = hashCode * 59 + this.ServiceName.GetHashCode();
                if (this.BilledWeight != null)
                    hashCode = hashCode * 59 + this.BilledWeight.GetHashCode();
                if (this.TotalCharge != null)
                    hashCode = hashCode * 59 + this.TotalCharge.GetHashCode();
                if (this.Promise != null)
                    hashCode = hashCode * 59 + this.Promise.GetHashCode();
                if (this.SupportedDocumentSpecifications != null)
                    hashCode = hashCode * 59 + this.SupportedDocumentSpecifications.GetHashCode();
                if (this.AvailableValueAddedServiceGroups != null)
                    hashCode = hashCode * 59 + this.AvailableValueAddedServiceGroups.GetHashCode();
                if (this.RequiresAdditionalInputs != null)
                    hashCode = hashCode * 59 + this.RequiresAdditionalInputs.GetHashCode();
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
