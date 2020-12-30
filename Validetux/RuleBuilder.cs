using System;
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
            Rules.Add(new HasMinimumLength(length, errorMessage));
            return this;
        }

        public RuleBuilder HasMaxLength(int length, string errorMessage = null)
        {
            Rules.Add(new HasMaximumLength(length, errorMessage));
            return this;
        }

        public RuleBuilder HasCustomRule(IValidationRule rule)
        {
            Rules.Add(rule);
            return this;
        }

        public RuleBuilder HasCustomRule(Func<bool> predicate, string errorMessage)
        {
            Rules.Add(new CustomPredicateRule(predicate, errorMessage));
            return this;
        }
    }
}