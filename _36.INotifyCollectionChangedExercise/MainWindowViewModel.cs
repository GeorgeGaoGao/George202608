using GeorgeWpfDLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace _36.INotifyCollectionChangedExercise
{
    public class MainWindowViewModel:ObservableObject
    {
        public Person CurrentPerson { get; set; }
        public ObservableCollection<Person> People { get; set; }=new ObservableCollection<Person>();
        public MainWindowViewModel()
        {
            
        }
    }
}
