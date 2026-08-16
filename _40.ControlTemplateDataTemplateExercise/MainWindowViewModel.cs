using GeorgeWpfDLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace _40.ControlTemplateDataTemplateExercise
{
    public class MainWindowViewModel:ObservableObject
    {
        public ObservableCollection<Person>  People { get; set; }
        public MainWindowViewModel()
        {
            People = new ObservableCollection<Person>()
            {
                new Person(){Name="George",Age=52,Avatar="%%"},
                new Person(){Name="Tom",Age=52,Avatar="$$"},
                new Person(){Name="Jerry",Age=52,Avatar="**"},
            };
        }
    }
}
