using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Validetux.Models;

namespace Validetux
{
    public abstract class AbstractValidator<TM>
    {
        private readonly List<RulesContext<TM>> _ruleContexts = new List<RulesContext<TM>>();

        /// <summary>
        /// Adds rules for given property
        /// </summary>
        /// <param name="propertyFunc"></param>
        /// <returns></returns>
        protected RuleBuilder AddRuleFor(Expression<Func<TM, object>> propertyFunc)
        {
            var ruleBuilder = new RuleBuilder();
            _ruleContexts.Add(new RulesContext<TM>
            {
                ParamDetails = new ParameterDetails<TM>(propertyFunc),
                Rules = ruleBuilder.Rules
            });
            return ruleBuilder;
        }

        /// <summary>
        /// Validates object with set rules in validator
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ValidationResult Validate(TM model)
        {
            var validationResult = new ValidationResult();

            foreach (var validationRuleContext in _ruleContexts)
            {
                validationRuleContext.Rules.ForEach(r =>
                {
                    var fieldName = validationRuleContext.ParamDetails.ParamName;
                    var func = validationRuleContext.ParamDetails.Param;

                    if (r.Validate(func.Invoke(model), fieldName)) return;

                    if (validationResult.Errors.ContainsKey(fieldName))
                    {
                        validationResult.Errors[fieldName].Add(r.ErrorMessage);
                    }
                    else
                    {
                        validationResult.Errors.Add(fieldName, new List<string> { r.ErrorMessage });
                    }
                });
            }

            return validationResult;
        }
    }
}