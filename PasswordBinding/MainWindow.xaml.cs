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

namespace PasswordBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string? _pass;

        public string? Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.Pass = "1236";
            this.DataContext = this;
        }
    }

    public class MyClass
    {


        public static string GetPass(DependencyObject obj)
        {
            return (string)obj.GetValue(PassProperty);
        }

        public static void SetPass(DependencyObject obj, string value)
        {
            obj.SetValue(PassProperty, value);
        }

        // Using a DependencyProperty as the backing store for Pass.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PassProperty =
            DependencyProperty.RegisterAttached("Pass", typeof(string), typeof(MyClass),
                new PropertyMetadata(null, new PropertyChangedCallback(
                    (s, e) =>
                    {
                        var passwordBox = s as PasswordBox;
                        passwordBox?.Password=e.NewValue.ToString();
                    }
                    )));


    }
  
}