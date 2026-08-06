using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Windows.Input;

namespace _09.CommandExample
{
    public class RelayCommand : ICommand
    {
        //将两个主要方法由外面引入
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        public RelayCommand(Action execute,Func<bool> canExecute=null!)
        {
            this._execute = execute??throw new ArgumentNullException(nameof(execute));
            this._canExecute = canExecute;
        }


        public event EventHandler? CanExecuteChanged;

        public void RaiseCanExecuteChanged()=>CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute();

        public void Execute(object? parameter)=>_execute();

    }
}
