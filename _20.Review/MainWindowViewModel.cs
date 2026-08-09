using GeorgeWpfDLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _20.Review
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public DateTime? SelectedDate {  get; set; }
        public ObservableCollection<DateTime> SelectedDates { get; set; } = new ObservableCollection<DateTime>()
        {
            new DateTime(2026,07,01),
            new DateTime(2026,08,01),
            new DateTime(2026,09,01)
        };
        #region 附加属性



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
                typeof(MainWindowViewModel), new PropertyMetadata(null,new PropertyChangedCallback(
                    (s,e) =>
                    {
                        ObservableCollection<DateTime> temp=e.NewValue as ObservableCollection<DateTime>;
                        Calendar calendar = s as Calendar;
                        if (calendar.IsLoaded)
                        {
                            foreach (var item in temp)
                            {
                                calendar.SelectedDates.Add(item);
                            }
                        }
                        else
                        {
                            calendar.Loaded += (sender, args) =>
                            {
                                foreach (var item in temp)
                                {
                                    calendar.SelectedDates.Add(item);
                                }
                            };
                        }
                        
                    }
                    )
                    
                    ));




        #endregion


        public ICommand ShowDatesInfoCommand { get; set; }
        public ICommand SelectedDatesChangedCommand { get; set; }
        public MainWindowViewModel()
        {
            ShowDatesInfoCommand = new RelayCommand(OnShowDatesInfoCommand);
            SelectedDatesChangedCommand = new RelayCommand(OnSelectedDatesChangedCommand);
        }

        private void OnSelectedDatesChangedCommand(object obj)
        {
            var calendar = obj as Calendar;
            this.SelectedDates.Clear();
            foreach (var item in calendar.SelectedDates)
            {
                this.SelectedDates.Add(item);
            }
        }

        private void OnShowDatesInfoCommand(object obj)
        {
            if (obj.ToString()=="button A")
            {
                string message = $"selectedDates are :\r\n";
                foreach (var item in SelectedDates)
                {
                   message += item.ToString()+"\r\n" ;
                }
                MessageBox.Show(message);
                
            }
        }
    }
}
