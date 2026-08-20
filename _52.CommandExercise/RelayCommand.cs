using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace _52.CommandExercise
{
    public class RelayCommand<T> : ICommand

    {
        private Action<T> _action;
        public RelayCommand(Action<T> action)
        {
            _action = action;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _action?.Invoke((T)Convert.ChangeType(parameter, typeof(T)));
        }
    }

    public class RelayCommand : ICommand
    {
        public RelayCommand()
        {

        }
        private Action Action;
        public RelayCommand(Action action)
        {
            Action = action;
        }
        private Action<string> StringAction;
        public RelayCommand(Action<string> action)
        {
            StringAction = action;
        }
        private Action<object> ObjectAction;
        public RelayCommand(Action<object> action)
        {
            ObjectAction = action;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Action?.Invoke();
            StringAction?.Invoke(parameter.ToString());
            ObjectAction?.Invoke(parameter);
        }
    }
}
