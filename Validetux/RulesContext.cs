using System.Collections.Generic;
using Validetux.Abstractions;
using Validetux.Models;

namespace Validetux
{
    public class RulesContext<M>
    {
        public ParameterDetails<M> ParamDetails { get; set; }
        public List<IValidationRule> Rules { get; set; }
    }
}