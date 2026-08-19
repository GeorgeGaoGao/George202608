using GeorgeWpfDLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace _50.DataTemplateExercise
{
    public class MainWindowViewModel:ObservableObject
    {
        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { _selectedPerson = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Person> People { get; set; }=new ObservableCollection<Person>();

        public ICommand AddPersonCommand { get; set; }
        public MainWindowViewModel()
        {
            People.Add(new Person()
            {
                Name="George",Age=52,Address="武汉汉口春天"
            });
            AddPersonCommand = new RelayCommand(OnAddPersonCommand);
            SelectedPerson = People[0];
        }

        private void OnAddPersonCommand(object obj)
        {
            var person = new Person()
            {
                Name = "新人",
                Age = new Random().Next(18, 100),
                Address = DateTime.Now.ToString()
            };
            this.People.Add(person);
        }
    }
}
