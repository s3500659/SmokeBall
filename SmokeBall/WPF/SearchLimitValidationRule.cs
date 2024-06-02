using System.Globalization;
using System.Windows.Controls;

namespace WPF
{
    public class SearchLimitValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse((string)value, out int searchLimit))
            {
                if (searchLimit > 0 && searchLimit <= 100)
                {
                    return ValidationResult.ValidResult;
                }
                return new ValidationResult(false, "Search limit must be between 1 and 100.");
            }
            return new ValidationResult(false, "Invalid number.");
        }
    }

}
