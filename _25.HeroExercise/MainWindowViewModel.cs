using GeorgeWpfDLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace _25.HeroExercise
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Type> HeroTypes { get; set; }=new ObservableCollection<Type>();
        public Type SelectedHero { get; set; }


        public ObservableCollection<MethodInfo>? HeroSkills { get; set; }=new ObservableCollection<MethodInfo>();
       


        public ICommand HeroesSelectionChangedCommand {  get; set; }
        public ICommand SkillDoubleClickCommand {  get; set; }
        public MainWindowViewModel()
        {
            GetAllHeroes();
            HeroesSelectionChangedCommand = new RelayCommand(OnHeroesSelectionChangedCommand);
            SkillDoubleClickCommand = new RelayCommand(OnSkillDoubleClickCommand);
        }

        private void OnSkillDoubleClickCommand(object obj)
        {
            MethodInfo methodInfo=obj as MethodInfo;
            var hero = Activator.CreateInstance(SelectedHero);
            methodInfo.Invoke(hero, null);
        }

        private void OnHeroesSelectionChangedCommand(object obj)
        {
            Type type = obj as Type;
            var methodInfos=type.GetMethods().Where(m => m.IsDefined(typeof(SkillAttribute))).ToList();
            if (methodInfos!=null)
            {
                HeroSkills.Clear();
                foreach (var item in methodInfos)
                {
                    HeroSkills.Add(item);
                }
            }
           
        }

        private void GetAllHeroes()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var dllFiles = Directory.GetFiles(baseDirectory,"*.dll");
            foreach (var dllFile in dllFiles)
            {
                Assembly assembly = Assembly.LoadFrom (dllFile);
                var types=assembly.GetTypes().Where(t=>t.GetCustomAttributes(typeof(HeroAttribute)).Any()).ToList();
                foreach (var type in types)
                {
                    HeroTypes.Add(type);
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
