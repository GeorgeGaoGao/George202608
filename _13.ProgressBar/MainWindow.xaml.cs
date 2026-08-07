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
using System.Windows.Threading;

namespace _13.ProgressBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Loaded += (s, e) =>
            //{
            //    Task.Factory.StartNew(() =>
            //    {
            //        Application.Current.Dispatcher.Invoke(() => this.myTextBlock.Text = "stopped by program");

            //    });
            //};
        }
    }
}