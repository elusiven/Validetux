namespace Validetux.Rules
{
    public class IsRequiredValidationRule : BaseValidationRule
    {
        public override bool Validate(object obj, string fieldName)
        {
            base.Validate(obj, fieldName);

            if (obj is string s)
                IsValid = !string.IsNullOrEmpty(s);
            else
                IsValid = obj != null;

            return IsValid;
        }

        public IsRequiredValidationRule(string errorMessage = null)
        {
            ErrorMessage = errorMessage ?? "{0} field is required";
        }
    }
}