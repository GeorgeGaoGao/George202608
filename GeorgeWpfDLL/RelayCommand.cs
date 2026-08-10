using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GeorgeWpfDLL
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecuate=null)
        {

            _execute = execute??throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecuate;
        }

        public event EventHandler? CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object? parameter=null)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter=null)
        {
            _execute(parameter);
        }
    }
}
