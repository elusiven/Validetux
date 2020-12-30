namespace Validetux.Abstractions
{
    public interface IValidationRule
    {
        bool Validate(object obj, string fieldName);

        string ErrorMessage { get; set; }
    }
}