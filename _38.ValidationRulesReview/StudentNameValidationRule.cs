using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace _38.ValidationRulesReview
{
    public class StudentNameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value!=null&&value.ToString().Length>=1&&value.ToString().Length<=10)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false,"字符数量应在1-10之间");
        }
    }
}
