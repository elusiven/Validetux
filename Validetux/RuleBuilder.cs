using System.Collections.Generic;
using Validetux.Abstractions;
using Validetux.Rules;

namespace Validetux
{
    public class RuleBuilder
    {
        internal List<IValidationRule> Rules { get; } = new List<IValidationRule>();

        public RuleBuilder IsRequired(string errorMessage = null)
        {
            Rules.Add(new IsRequiredValidationRule(errorMessage));
            return this;
        }

        public RuleBuilder HasMinLength(int length, string errorMessage = null)
        {
            Rules.Add(new IsMinimumLength(length, errorMessage));
            return this;
        }

        public RuleBuilder HasCustomRule(IValidationRule rule)
        {
            Rules.Add(rule);
            return this;
        }
    }
}