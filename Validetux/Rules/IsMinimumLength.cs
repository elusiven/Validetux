using System.Collections;
using Validetux.Abstractions;

namespace Validetux.Rules
{
    public class IsMinimumLength : IValidationRule
    {
        public int Length { get; }

        /// <summary>
        /// Rule for minimum length
        /// </summary>
        /// <param name="length">Specify a minimum length</param>
        /// <param name="errorMessage">Optional error message. {0} = length / {1} = field name</param>
        public IsMinimumLength(int length, string errorMessage = null)
        {
            Length = length;
            ErrorMessage = errorMessage ?? "Minimum value is {0} for {1}";
        }

        public bool IsValid(object obj, string fieldName)
        {
            bool isValid = true;

            ErrorMessage = string.Format(ErrorMessage, Length, fieldName);

            if (obj is string s)
                isValid = s.Length >= Length;

            if (obj is IEnumerable c)
            {
                var count = 0;

                foreach (var item in c)
                {
                    count++;
                }

                isValid = count >= Length;
            }

            if (obj is int i)
                isValid = i >= Length;

            return isValid;
        }

        public string ErrorMessage { get; set; }
    }
}