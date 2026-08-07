using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace _13.ProgressBar
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int TotalWidth { get; set; } = 800;
        private int _leftMargin;

        public int LeftMargin
        {
            get { return _leftMargin; }
            set { _leftMargin = value; OnPropertyChanged(); }
        }

        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; OnPropertyChanged(); }
        }

        public ICommand MainWindowLoadedCommand {  get; set; }
        public MainWindowViewModel()
        {
            MainWindowLoadedCommand = new RelayCommand(
                () => Task.Factory.StartNew(
                    async() =>
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            Value = i;
                            LeftMargin = (int)TotalWidth / 100 * i;
                            await Task.Delay(1000);
                        }
                    }
                    )
                );
        }

        
    }
}
