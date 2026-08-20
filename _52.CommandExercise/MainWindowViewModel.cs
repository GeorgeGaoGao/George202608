using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace _52.CommandExercise
{
    public class MainWindowViewModel
    {
        public ICommand OpenCommand { get; set; }
        public ICommand BindingACommand { get; set; }
        public ICommand StringCommand { get; set; }
        public ICommand ObjectCommand { get; set; }
        public ICommand TCommand { get; set; }
        public MainWindowViewModel()
        {
            OpenCommand = new RelayCommand();
            BindingACommand = new RelayCommand(OnBindingACommand);
            StringCommand = new RelayCommand(OnStringCommand);
            ObjectCommand = new RelayCommand(OnObjectCommand);
            TCommand = new RelayCommand<Person>(OnTCommand);
        }

        private void OnTCommand(Person person)
        {
            MessageBox.Show($"TCommand.Person's Name:{person.Name} person's Age: {person.Age}");
        }

        private void OnObjectCommand(object obj)
        {
            var person = (Person)obj;
            MessageBox.Show($"ObjectCommand.Person's Name:{person.Name} person's Age: {person.Age}");
        }

        private void OnStringCommand(string str)
        {
            MessageBox.Show($"the string parameter is {str}");
        }

        private void OnBindingACommand()
        {
            MessageBox.Show("执行OnBindingACommand");
        }

        public void OnCommandBinding_Executed(object obj)
        {
            if (obj != null)
            {
                MessageBox.Show($"由vm来执行routeduicommand,得到的参数是{obj.ToString()}");
            }
            else
            {
                MessageBox.Show($"由vm来执行routeduicommand,没得到参数。");
            }

        }
    }
}
