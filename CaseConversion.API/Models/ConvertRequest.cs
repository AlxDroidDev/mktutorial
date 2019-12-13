/*
 * Case Conversion API
 *
 * This is a simple API that is meant to be used only as an example
 *
 * OpenAPI spec version: 0.1
 * Contact: you@your-company.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CaseConversion.API.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ConvertRequest : IEquatable<ConvertRequest>
    { 
   
        /// <summary>
        /// Type of convertion to be applied to the input sentence
        /// </summary>
        /// <value>Type of convertion to be applied to the input sentence</value>
        [Required]
        [DataMember(Name="caseType")]
        public ConversionCaseType? CaseType { get; set; }

        /// <summary>
        /// string/sentence to which the selected case conversion will be applied
        /// </summary>
        /// <value>string/sentence to which the selected case conversion will be applied</value>
        [Required]
        [DataMember(Name="sentence")]
        public string Sentence { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConvertRequest {\n");
            sb.Append("  CaseType: ").Append(CaseType).Append("\n");
            sb.Append("  Sentence: ").Append(Sentence).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ConvertRequest)obj);
        }

        /// <summary>
        /// Returns true if ConvertRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of ConvertRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConvertRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    CaseType == other.CaseType ||
                    CaseType != null &&
                    CaseType.Equals(other.CaseType)
                ) && 
                (
                    Sentence == other.Sentence ||
                    Sentence != null &&
                    Sentence.Equals(other.Sentence)
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
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (CaseType != null)
                    hashCode = hashCode * 59 + CaseType.GetHashCode();
                    if (Sentence != null)
                    hashCode = hashCode * 59 + Sentence.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ConvertRequest left, ConvertRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ConvertRequest left, ConvertRequest right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
