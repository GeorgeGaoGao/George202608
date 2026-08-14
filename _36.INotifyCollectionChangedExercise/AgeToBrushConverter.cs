using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace _36.INotifyCollectionChangedExercise
{
    public class AgeToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Brush background = Brushes.Black;

            if (value != null && int.TryParse(value.ToString(), out int age))
            {
                if (age < 20)
                {
                    background = Brushes.LightGreen;
                }
                else if (age < 30)
                {
                    background = Brushes.Green;
                }
                else if (age < 60)
                {
                    background = Brushes.Red;
                }
                else
                {
                    background = Brushes.Gray;
                }
            }

            return background;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TitleMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string title = string.Empty;
            if (values != null && values.Length == 2)
            {
                var ageResult = int.TryParse(values[0].ToString(), out int age);
                var moneyResult = double.TryParse(values[1].ToString(), out double money);
                
                if (ageResult && moneyResult)
                {
                    if (age < 20 && money < 100)
                    {
                        title = "没钱的年青人";
                    }
                    else if (age > 60 && money > 1000)
                    {
                        title = "有钱的老年人";
                    }
                    else
                    {
                        title = "平常人";
                    }
                }
               
            }
            return title;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
