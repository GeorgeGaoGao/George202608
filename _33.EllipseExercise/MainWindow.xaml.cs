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

namespace _33.EllipseExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            int number = 9;
            Task.Factory.StartNew(
                () =>
                {
                    while (true)
                    {
                        number = number == 0 ? 9 : number;
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            this.myLine.StrokeDashOffset = number;
                            number--;
                        })
                        );

                        Thread.Sleep(250);
                    }

                }
                );
        }
    }
}