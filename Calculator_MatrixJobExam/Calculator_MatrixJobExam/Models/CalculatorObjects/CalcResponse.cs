using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace Calculator_MatrixJobExam.Models.CalculatorObjects
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class CalcResponse : IEquatable<CalcResponse>
    {
        /// <summary>
        /// Gets or Sets Result
        /// </summary>

        [DataMember(Name = "CalcResult")]
        public double? CalcResult { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CalcResponse {\n");
            sb.Append("  Result: ").Append(CalcResult).Append("\n");
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
            return obj.GetType() == GetType() && Equals((CalcResponse)obj);
        }

        /// <summary>
        /// Returns true if CalcResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of CalcResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CalcResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                
                    CalcResult == other.CalcResult ||
                    CalcResult != null &&
                    CalcResult.Equals(other.CalcResult)
                ;
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
                if (CalcResult != null)
                    hashCode = hashCode * 59 + CalcResult.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(CalcResponse left, CalcResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CalcResponse left, CalcResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
