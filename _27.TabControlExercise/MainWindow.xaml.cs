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

namespace _27.TabControlExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TabItem SelectedItem { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            var index=tabControl.SelectedIndex;
            var value=tabControl.SelectedValue;
            var item=tabControl.SelectedItem;
            var content = tabControl.SelectedContent;

            TabItem tabItem = tabControl.SelectedItem as TabItem;

            this.myTextBlock.Text = $"Header:{tabItem.Header}-index:{index}-content:{content}";
        }
    }
}