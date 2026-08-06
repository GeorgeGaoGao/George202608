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

namespace AttachedEvent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.grid.AddHandler(Student.NameChangedEvent, new RoutedEventHandler(this.StudentNameChangedHandler));
        }

        private void StudentNameChangedHandler(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((e.OriginalSource as Student).Id.ToString());
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student() { Id=101,Name="Tom"};
            student.Name = "George";
            RoutedEventArgs args = new RoutedEventArgs(Student.NameChangedEvent,student);
            (sender as Button).RaiseEvent(args);

        }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static readonly RoutedEvent NameChangedEvent
            = EventManager.RegisterRoutedEvent("NameChanged", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(Student));
       
    }

    //public class NameChangedEventArgs : RoutedEventArgs
    //{
    //    public NameChangedEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
    //    {
    //    }
    //}
}