using System.Collections.Generic;
using Validetux.Abstractions;
using Validetux.Rules;

namespace Validetux
{
    public class RuleBuilder
    {
        private List<IValidationRule> _rules = new List<IValidationRule>();

        public List<IValidationRule> Rules
        {
            get
            {
                return _rules;
            }
        }

        public RuleBuilder IsRequired(string errorMessage = null)
        {
            _rules.Add(new IsRequiredValidationRule(errorMessage));
            return this;
        }

        public RuleBuilder HasCustomRule(IValidationRule rule)
        {
            _rules.Add(rule);
            return this;
        }
    }
}