using System;

namespace Validetux.Rules
{
    public class CustomPredicateRule : BaseValidationRule
    {
        private Func<bool> _predicateFunc;

        public CustomPredicateRule(Func<bool> predicateFunc, string errorMessage)
        {
            _predicateFunc = predicateFunc;
            ErrorMessage = errorMessage;
        }

        public override bool Validate(object obj, string fieldName)
        {
            return _predicateFunc.Invoke();
        }
    }
}