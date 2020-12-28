using System;
using System.Collections.Generic;
using Validetux.Models;

namespace Validetux
{
    public abstract class AbstractValidator<M>
    {
        private List<RulesContext<M>> _ruleContexts = new List<RulesContext<M>>();

        protected RuleBuilder RuleFor(Func<M, string> propertyFunc)
        {
            var ruleBuilder = new RuleBuilder();
            _ruleContexts.Add(new RulesContext<M>
            {
                ParamDetails = new ParameterDetails<M>(propertyFunc),
                Rules = ruleBuilder.Rules
            });
            return ruleBuilder;
        }

        /// <summary>
        /// Validates object with set rules in validator
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ValidationResult Validate(M model)
        {
            var validationResult = new ValidationResult();

            foreach (var validationRuleContext in _ruleContexts)
            {
                validationRuleContext.Rules.ForEach(r =>
                {
                    var fieldName = validationRuleContext.ParamDetails.ParamName;
                    var func = validationRuleContext.ParamDetails.Param;

                    if (!r.IsValid(func.Invoke(model),
                        validationRuleContext.ParamDetails.ParamName))
                            validationResult.Errors.Add(fieldName, r.ErrorMessage);

                });
            }

            return validationResult;
        }
    }
}
