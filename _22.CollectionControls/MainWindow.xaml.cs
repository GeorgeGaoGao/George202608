using System.ComponentModel;
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

namespace _22.CollectionControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            myListBox.Items.Add(new Person() { Address = "wuhan", Age = 15, Name = "harley" });
            myListBox.Items.Add(new Person() { Address = "guangzhou", Age = 16, Name = "tom" });
            myListBox.Items.Add(new Person() { Address = "beijin", Age = 17, Name = "lisha" });
            this.DataContext = this;
        }

        private string _textToShow;

        public string TextToShow
        {
            get { return _textToShow; }
            set { _textToShow = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextToShow))); }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.myListBox.SelectedItem as Person;
            var selectedValue = this.myListBox.SelectedValue;
            TextToShow = $"selectedItem:{selectedItem.Name} selectedValue:{selectedValue}";
        }
    }
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}