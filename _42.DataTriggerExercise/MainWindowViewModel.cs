using GeorgeWpfDLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;

namespace _42.DataTriggerExercise
{
    public class MainWindowViewModel:ObservableObject
    {
        public ObservableCollection<Person> People { get; set; }
        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { _selectedPerson = value; OnPropertyChanged(); }
        }

        public MainWindowViewModel()
        {
            People = new ObservableCollection<Person>()
            {
                new Person(){Name="YangGuo",Age=30,Address="Zhongnanshan"},
                new Person(){Name="GuoJin",Age=45,Address="XiangFan"},
                new Person(){Name="HuangRong",Age=42,Address="TaoHuaDao"},
            };
        }
    }
}
