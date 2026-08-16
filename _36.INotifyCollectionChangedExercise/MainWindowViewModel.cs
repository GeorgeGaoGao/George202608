using GeorgeWpfDLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Newtonsoft.Json;
using System.IO;

namespace _36.INotifyCollectionChangedExercise
{
    public class MainWindowViewModel:ObservableObject
    {

        public Person CurrentPerson { get; set; } = new Person();
        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { _selectedPerson = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Person> People { get; set; }=new ObservableCollection<Person>();
        public ICommand AddPersonCommand { get; set; }
        public ICommand RemovePersonCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }
        public MainWindowViewModel()
        {
            LoadedWindowCommand = new RelayCommand(LoadPeopleFromFile);
            AddPersonCommand = new RelayCommand(OnAddPersonCommand);
            RemovePersonCommand = new RelayCommand(OnRemovePersonCommand);
            CloseWindowCommand = new RelayCommand(SavePeopleToFile);


        }

        private void LoadPeopleFromFile(object obj)
        {

           string appDirectory=AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(appDirectory, "People.txt");
            if (File.Exists(filePath))
            {
                string peopleJson = File.ReadAllText(filePath);
                ObservableCollection<Person> savedPeople = JsonConvert.DeserializeObject<ObservableCollection<Person>>(peopleJson);
                People.Clear();
                foreach (var item in savedPeople)
                {
                    People.Add(item);
                }
            }

           
        }

        private void SavePeopleToFile(object obj)
        {
           string peopleJson= JsonConvert.SerializeObject(People, Formatting.Indented);

            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(appDirectory, "People.txt");
            File.WriteAllText(filePath, peopleJson);
        }

        private void OnRemovePersonCommand(object obj)
        {
            People.Remove(SelectedPerson);
        }

        private void OnAddPersonCommand(object obj)
        {
            Person person = new Person() { Address=CurrentPerson.Address,Age=CurrentPerson.Age,
                Name=CurrentPerson.Name,Money=CurrentPerson.Money};
            People.Add(person);
        }
    }
}
