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
            this.grid.AddHandler(Student.StudentNameChanged,new RoutedEventHandler(GridStudentNameChangedHandler));
        }

        private void GridStudentNameChangedHandler(object sender, RoutedEventArgs e)
        {
          
                var student = e.OriginalSource as Student;
                MessageBox.Show($"this event is raised by {sender},student's new name {student.Name}");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Student newStudent=new Student() { Age=18,Name="george"};
            var button = sender as Button;
            RoutedEventArgs args = new RoutedEventArgs(Student.StudentNameChanged,newStudent);
            button.RaiseEvent(args);
        }
    }
    //{
        //public MainWindow()
        //{
        //    InitializeComponent();
        //    this.grid.AddHandler(Student.NameChangedEvent, new RoutedEventHandler(this.StudentNameChangedHandler));

        //    this.myTextbox.TextChanged += MyTextbox_TextChanged;
        //    this.myListBox.SelectionChanged += MyListBox_SelectionChanged;
        //}

        //private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void MyTextbox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void StudentNameChangedHandler(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show((e.OriginalSource as Student).Id.ToString());
        //}

        //private void button_Click(object sender, RoutedEventArgs e)
        //{
        //    Student student = new Student() { Id=101,Name="Tom"};
        //    student.Name = "George";
        //    RoutedEventArgs args = new RoutedEventArgs(Student.NameChangedEvent,student);

        //    (sender as Button).RaiseEvent(args);

        //}
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public static readonly RoutedEvent StudentNameChanged = EventManager.RegisterRoutedEvent("StudentNameChanged", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Student));
        //public class Student
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }

        //    public static readonly RoutedEvent NameChangedEvent
        //        = EventManager.RegisterRoutedEvent("NameChanged", RoutingStrategy.Bubble,
        //            typeof(RoutedEventHandler), typeof(Student));

        //}

        //public class NameChangedEventArgs : RoutedEventArgs
        //{
        //    public NameChangedEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        //    {
        //    }
        //}
    }