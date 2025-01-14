/*
 * Calculator API
 *
 * API for performing basic arithmetic operations and user authentication
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Calculator_MatrixJobExam.Models.CalculatorObjects
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class CalcRequest : IEquatable<CalcRequest>
    {
        /// <summary>
        /// Gets or Sets Number1
        /// </summary>
        [Required]

        [DataMember(Name = "Number1")]
        public double? Number1 { get; set; }

        /// <summary>
        /// Gets or Sets Number2
        /// </summary>
        [Required]

        [DataMember(Name = "Number2")]
        public double? Number2 { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CalcRequest" /> class.
        /// </summary>
        public CalcRequest()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CalcRequest" /> class with two numbers.
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        public CalcRequest(double? number1, double? number2)
        {
            Number1 = number1;
            Number2 = number2;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CalcRequest {\n");
            sb.Append("  Number1: ").Append(Number1).Append("\n");
            sb.Append("  Number2: ").Append(Number2).Append("\n");
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
            return obj.GetType() == GetType() && Equals((CalcRequest)obj);
        }

        /// <summary>
        /// Returns true if CalcRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of CalcRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CalcRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Number1 == other.Number1 ||
                    Number1 != null &&
                    Number1.Equals(other.Number1)
                ) &&
                (
                    Number2 == other.Number2 ||
                    Number2 != null &&
                    Number2.Equals(other.Number2)
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
                if (Number1 != null)
                    hashCode = hashCode * 59 + Number1.GetHashCode();
                if (Number2 != null)
                    hashCode = hashCode * 59 + Number2.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(CalcRequest left, CalcRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CalcRequest left, CalcRequest right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
