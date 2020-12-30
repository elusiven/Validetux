using Validetux.Abstractions;

namespace Validetux.Rules
{
    public abstract class BaseValidationRule : IValidationRule
    {
        public BaseValidationRule()
        {
            IsValid = false;
            ErrorMessage = "Default error message";
        }

        protected internal bool IsValid { get; set; }

        public virtual bool Validate(object obj, string fieldName)
        {
            ConstructErrorMessage(fieldName);
            return IsValid;
        }

        public virtual void ConstructErrorMessage(string fieldName)
        {
            if (!string.IsNullOrEmpty(fieldName))
                ErrorMessage = string.Format(ErrorMessage, fieldName);
        }

        public string ErrorMessage { get; set; }
    }
}