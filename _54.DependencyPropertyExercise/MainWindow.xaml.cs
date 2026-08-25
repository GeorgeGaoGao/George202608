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

namespace _54.DependencyPropertyExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void myWidget_Completed(object sender, RoutedEventArgs e)
        {
            WidgetUserControl element = (WidgetUserControl)sender;
            //MessageBox.Show($"myWidget_Completed被触发了。");
            myListBox.Items.Add($"myWidget_Completed被触发了。");
            element.RaiseEvent(new RoutedEventArgs(SalesManager.CheckEvent));
        }

        private void myWidget_Check(object sender, RoutedEventArgs e)
        {
            WidgetUserControl control=sender as WidgetUserControl;
            if ((int)(control.Value)%100 > 50)
            {
                myListBox.Items.Add($"当前金额 {control.Value} 该分成了");
            }
            //{ MessageBox.Show($"该分成了"); }
        }
    }
}