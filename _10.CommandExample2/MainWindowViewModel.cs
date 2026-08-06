using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace _10.CommandExample2
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; } = "CommandExample2";
        public RelayCommand ClearCommand { get; set; }
        private string _textContent;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string TextContent
        {
            get => _textContent;
            set
            {
                if (_textContent != value)
                {
                    _textContent = value;
                    OnPropertyChanged();
                    this.ClearCommand.RaiseCanExecuteChanged();
                }
            }

        }
        public MainWindowViewModel()
        {
            this.ClearCommand = new RelayCommand(
                execute: () => TextContent = string.Empty,
                canExecute: () => !string.IsNullOrEmpty(this.TextContent)
                );
        }
    }
}