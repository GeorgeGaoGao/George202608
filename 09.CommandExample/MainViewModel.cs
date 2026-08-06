using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace _09.CommandExample
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string? _textContent=string.Empty;

        public string? TextContent
        {
            get =>_textContent; 
            set
            {
                if (_textContent != value)
                {
                    _textContent = value;
                    OnPropertyChanged();
                    ClearCommand.RaiseCanExecuteChanged();
                    
                }
            }
        }

        public RelayCommand ClearCommand { get;}
        public MainViewModel()
        {
           
            ClearCommand = new RelayCommand(
                execute: () => TextContent = string.Empty,
                canExecute: () => !string.IsNullOrEmpty(TextContent)
                );
            
        }

    }

}
