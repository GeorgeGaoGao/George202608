using GeorgeWpfDLL;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _15.CalendarExercise2
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private DateTime? _currentSelectedDate;

        public DateTime? CurrentSelectedDate
        {
            get { return _currentSelectedDate; }
            set { _currentSelectedDate = value;OnPropertyChanged(); }
        }

        public ObservableCollection<DateTime> ChosenDates { get; set; }=new ObservableCollection<DateTime>()
        {
            new DateTime(2026,7,1),
            new DateTime(2026,8,1),
            new DateTime(2026,09,01)
        };



        #region SelectedDates附加属性
        public static ObservableCollection<DateTime> GetSelectedDates(DependencyObject obj)
        {
            return (ObservableCollection<DateTime>)obj.GetValue(SelectedDatesProperty);
        }

        public static void SetSelectedDates(DependencyObject obj, ObservableCollection<DateTime> value)
        {
            obj.SetValue(SelectedDatesProperty, value);
        }

        // Using a DependencyProperty as the backing store for SelectedDates.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedDatesProperty =
            DependencyProperty.RegisterAttached("SelectedDates", typeof(ObservableCollection<DateTime>),
                typeof(MainWindowViewModel),
                new PropertyMetadata(null,
                    new PropertyChangedCallback(
                        (s,e) =>
                        {
                            var calendar = s as Calendar;
                            var newDates = (ObservableCollection<DateTime>)e.NewValue;
                            if (calendar.IsLoaded)
                            {
                                foreach (DateTime item in (ObservableCollection<DateTime>)e.NewValue)
                                {
                                    calendar.SelectedDates.Add(item);
                                }
                            }
                            else
                            {
                                calendar.Loaded += (s, e) => {
                                    foreach (var item in newDates)
                                    {
                                        calendar.SelectedDates.Add(item);
                                    }
                                };
                            }
                           
                           
                        }
                        )
                    ));

        #endregion

        #region Password附加属性
        public string MyPassword { get; set; } = "123456";
        public static string GetPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordProperty, value);
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), 
                typeof(MainWindowViewModel), 
                new PropertyMetadata("",new PropertyChangedCallback(
                    (s,e) =>
                    {
                        var passwordBox=s as PasswordBox;
                        passwordBox.Password = e.NewValue.ToString();
                    }
                    )));

        #endregion


        public ICommand ButtonShowInfoCommand { get;  }
        public ICommand ButtonChangeSelectedDateCommand { get; }
        public MainWindowViewModel()
        {
            ButtonShowInfoCommand = new RelayCommand(
                (o) =>
                {
                    MessageBox.Show($"共选了ChosenDates.Count天，" +
                        $"\r\n当前SelectedDate为{CurrentSelectedDate}\r\n今天是{DateTime.Now}");
                }
                );
            ButtonChangeSelectedDateCommand = new RelayCommand(
                (o) =>
                {
                    CurrentSelectedDate = DateTime.Today.AddDays(2);
                }
                );
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
