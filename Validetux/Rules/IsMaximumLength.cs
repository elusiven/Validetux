using System.Collections;

namespace Validetux.Rules
{
    public class IsMaximumLength : BaseValidationRule
    {
        public int Length { get; }

        /// <summary>
        /// Rule for max length
        /// </summary>
        /// <param name="length">Specify a max length</param>
        /// <param name="errorMessage">Optional error message. {0} = length / {1} = field name</param>
        public IsMaximumLength(int length, string errorMessage = null)
        {
            Length = length;
            ErrorMessage = errorMessage ?? "Maximum value is {0} for {1}";
        }

        public override bool Validate(object obj, string fieldName)
        {
            if (fieldName != null)
                ErrorMessage = string.Format(ErrorMessage, Length, fieldName);

            if (obj is string s)
                IsValid = s.Length <= Length;

            if (obj is IEnumerable c)
            {
                var count = 0;

                foreach (var item in c)
                {
                    count++;
                }

                IsValid = count <= Length;
            }

            if (obj is int i)
                IsValid = i <= Length;

            return IsValid;
        }
    }
}