using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace _36.INotifyCollectionChangedExercise
{
    public class AgeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
           
            if (int.TryParse(value.ToString(), out int age))
            {
                if (age >=0 && age <= 120)
                {
                    return new ValidationResult(true, null);
                }
            }
            return new ValidationResult(false, "应输入整数0-120");
            
        }
    }
    public class NameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value!=null&&value.ToString().Length>1&&value.ToString().Length<=10)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "长度应处于1-10之间");
        }
    }
    public class MoneyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value!=null&&double.TryParse(value.ToString(),out double money))
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "请输入一个double类型的数值。");
        }
    }
}
