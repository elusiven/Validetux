using System.Collections.Generic;
using Validetux.Abstractions;
using Validetux.Models;

namespace Validetux
{
    public class RulesContext<M>
    {
        internal ParameterDetails<M> ParamDetails { get; set; }
        internal List<IValidationRule> Rules { get; set; }
    }
}