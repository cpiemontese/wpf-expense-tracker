using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ExpenseTracker.Validation_Rules
{
    public class NumRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;

            try
            {
                if (input.Length > 0)
                {
                    float parsed = float.Parse(input);
                    if (parsed < 1.0f)
                        return new ValidationResult(false, "Amount must be greater than 0");
                }
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Amount must be a number");
            }

            return ValidationResult.ValidResult;
        }
    }
}
