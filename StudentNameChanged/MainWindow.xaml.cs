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

namespace StudentNameChanged
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Student Student { get; set; }=new Student();
        public MainWindow()
        {

            InitializeComponent();
            this.DataContext = this;
            Student.Name = "Gao";
            Student.Id = 101;
            this.stackPanel.AddHandler(Student.NameChangedEvent, new RoutedEventHandler(this.StudentNameChangedHandler));
        }

        private void StudentNameChangedHandler(object sender, RoutedEventArgs e)
        {

            string content = $"{(sender as StackPanel).Name}是事件处理方法的sender,它直接得到的RoutedEventArgs里source:{e.Source} " +
                 $"originalSource:{e.OriginalSource}";
            MessageBox.Show(content);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Student.Name = "George";
            RoutedEventArgs args = new RoutedEventArgs(Student.NameChangedEvent, this);
            (sender as Button).RaiseEvent(args);
        }
    }

    public class Student
    {
        public static readonly RoutedEvent NameChangedEvent
            =EventManager.RegisterRoutedEvent("NameChanged",RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),typeof(Student));
           
        public int Id { get; set; }
        private String _name;

        public String Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                   
                   
                }
            }
        }

    }
}