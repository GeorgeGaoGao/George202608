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

namespace _47.VisualTreeExercise
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem rootItem = new TreeViewItem();
            rootItem.Header = "根结点";
            LoadVisualTree(rootItem,this);
            this.myTreeView.Items.Add(rootItem);
        }

        private void LoadVisualTree(TreeViewItem rootItem, object element)
        {
            if (element is not DependencyObject)
            {
                return;
            }
            TreeViewItem newTreeViewItem= new TreeViewItem();
            newTreeViewItem.Header=element.GetType().Name;
            rootItem.Items.Add(newTreeViewItem);

            var count = VisualTreeHelper.GetChildrenCount(element as DependencyObject);
            for (int i = 0; i < count; i++)
            {
                LoadVisualTree(newTreeViewItem, VisualTreeHelper.GetChild(element as DependencyObject, i));
            }
            
        }
    }
}