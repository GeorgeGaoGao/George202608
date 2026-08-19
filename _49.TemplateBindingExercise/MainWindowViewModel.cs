using GeorgeWpfDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace _49.TemplateBindingExercise
{
    public class MainWindowViewModel:ObservableObject
    {
        public Person CurrentPerson { get; set; }=new Person() { Name="George",Age=52,Address="汉口春天"};

    }
}
