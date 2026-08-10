using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace _23.ListViewExercise
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Person> People { get; set; } =new ObservableCollection<Person>() ;
        public MainWindowViewModel()
        {
            People.Add(new Person() { Address = "wuhan", Age = 15, Name = "harley" });
            People.Add(new Person() { Address = "guangzhou", Age = 16, Name = "tom" });
            People.Add(new Person() { Address = "beijin", Age = 17, Name = "lisha" });
        }
        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { _selectedPerson = value;OnPropertyChanged(); }
        }

        


    }
}
