using MyWpfDLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _14.CalendarExercise
{
    public class MainWindowViewModel
    {
        public ICommand ChooseDateCommand { get; set; }
        public ObservableCollection<DateTime> ChosenDates { get; set; }


        public static SelectedDatesCollection GetSelectedDates(DependencyObject obj)
        {
            return (SelectedDatesCollection)obj.GetValue(SelectedDatesProperty);
        }

        public static void SetSelectedDates(DependencyObject obj, SelectedDatesCollection value)
        {
            obj.SetValue(SelectedDatesProperty, value);
        }

        // Using a DependencyProperty as the backing store for SelectedDates.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedDatesProperty =
            DependencyProperty.RegisterAttached("SelectedDates", 
                typeof(SelectedDatesCollection), 
                typeof(MainWindowViewModel), new PropertyMetadata(null, (s,e) =>
                {
                    var calendar = s as System.Windows.Controls.Calendar;
                    var targetCollection=GetSelectedDates(calendar);
                    foreach (var item in calendar.SelectedDates)
                    {
                        targetCollection.Add(item);  
                    }
                    ;

                }));


        public DateTime SelectedDate { get; set; }
        public MainWindowViewModel()
        {
            ChooseDateCommand = new RelayCommand(
                () =>
                {
                    MessageBox.Show($"共选择了{ChosenDates.Count}天，当前选择日期是{SelectedDate}");
                }

                );
        }
    }
}
