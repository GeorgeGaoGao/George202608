using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _23.ListViewExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        
        public MainWindow()
        {
            InitializeComponent();
            //myListView.Items.Add(new Person() { Address = "wuhan", Age = 15, Name = "harley" });
            //myListView.Items.Add(new Person() { Address = "guangzhou", Age = 16, Name = "tom" });
            //myListView.Items.Add(new Person() { Address = "beijin", Age = 17, Name = "lisha" });
            //this.DataContext = this;
        }

        private string _textToShow;

        public string TextToShow
        {
            get { return _textToShow; }
            set { _textToShow = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextToShow))); }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var listView= sender as ListView;
            //var person = listView.SelectedItem as Person ;
            //nameTextBlock.Text = person.Name;
            //ageTextBlock.Text = person.Age.ToString();
            //addressTextBlock.Text = person.Address;
        }
    }
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        //public event PropertyChangedEventHandler? PropertyChanged;
        //public void OnPropertyChanged([CallerMemberName]string propertyName=null)
        //{
        //    PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        //}
    }
}