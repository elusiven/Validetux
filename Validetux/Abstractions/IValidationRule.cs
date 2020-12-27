namespace Validetux.Abstractions
{
    public interface IValidationRule
    {
        bool IsValid(object obj, string fieldName);

        string ErrorMessage { get; set; }
    }
}
