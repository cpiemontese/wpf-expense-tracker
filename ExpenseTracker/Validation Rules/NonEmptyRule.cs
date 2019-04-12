using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ExpenseTracker.Validation_Rules
{
    class NonEmptyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;

            if (input.Length == 0)
                return new ValidationResult(false, "Category must be non-empty");
            return ValidationResult.ValidResult;
        }
    }
}
