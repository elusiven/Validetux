using System;
using System.Collections.Generic;
using Validetux.Abstractions;

namespace Validetux
{
    public class RulesContext<M>
    {
        public ParameterDetails<M> ParamDetails { get; set; }
        public List<IValidationRule> Rules { get; set; }
    }
}
