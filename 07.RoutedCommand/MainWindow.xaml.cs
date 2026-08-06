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

namespace _07.RoutedCommand20260804
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RoutedCommand ClearCommand=new _07.RoutedCommand
        public MainWindow()
        {
            InitializeComponent();
            InitializeCommand();
        }

        private void InitializeCommand()
        {
            throw new NotImplementedException();
        }
    }
}