using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodedHomes.Models
{
    public class ObjectValidationResult
    {
        public bool HasErrors
        {
            get { return !this.IsValid; }
        }

        public bool IsValid { get; set; }

        public IList<ValidationResult> Results { get; set; }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ValidationResult result in this.Results)
            {
                sb.AppendLine(result.ErrorMessage);
            }

            return sb.ToString();
        }
    }
}
