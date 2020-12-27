using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validetux
{
    public class ValidationResult
    {
        public bool IsValid => Errors.Count == 0;

        public Dictionary<string, string> Errors { get; set; }

        public ValidationResult()
        {
            Errors = new Dictionary<string, string>();
        }
    }
}
