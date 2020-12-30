using System.Collections.Generic;

namespace Validetux.Models
{
    public class ValidationResult
    {
        public bool IsValid => Errors.Count == 0;

        public Dictionary<string, List<string>> Errors { get; set; }

        public ValidationResult()
        {
            Errors = new Dictionary<string, List<string>>();
        }
    }
}