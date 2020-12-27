using Validetux.Abstractions;

namespace Validetux.Rules
{
    public class IsRequiredValidationRule : IValidationRule
    {
        public bool IsValid(object obj, string fieldName)
        {
            if (fieldName != null)
                ErrorMessage = string.Format(ErrorMessage, fieldName);

            var isValid = false;

            if (obj is string s)
                isValid = !string.IsNullOrEmpty(s);
            else
                isValid = obj != null;

            return isValid;
        }

        public string ErrorMessage { get; set; }

        public IsRequiredValidationRule(string errorMessage = null)
        {
            ErrorMessage = errorMessage ?? "{0} field is required";
        }
    }
}
