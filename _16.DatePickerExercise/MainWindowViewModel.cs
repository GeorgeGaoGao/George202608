using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace _16.DatePickerExercise
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private DateTime? _startDate;

        public DateTime? StartDate
        {
            get { return _startDate; }
            set { _startDate = value; OnPropertyChanged(); }
        }
        private DateTime? _endDate;

        public DateTime? EndDate
        {
            get { return _endDate; }
            set { _endDate = value; OnPropertyChanged(); }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand CalculateDatesCommand {  get; set; }
        public MainWindowViewModel()
        {
            CalculateDatesCommand = new RelayCommand(OnCalculateDatesCommand);
        }

        private void OnCalculateDatesCommand()
        {
            if (StartDate==null||EndDate==null)
            {
                MessageBox.Show($"startdate or enddate cannot be empty");
                return;
            }
            var startDate = StartDate.Value.Date;
            var endDate= EndDate.Value.Date;

            if (startDate>endDate)
            {
                DateTime temp = startDate;
                startDate = endDate;
                endDate = temp;
            }

            int totalDays = (endDate - startDate).Days+1;

            MessageBox.Show($"startdate:{StartDate}\r\nenddate:{EndDate}\r\ntotoldays:{totalDays}");
        }
    }
}
