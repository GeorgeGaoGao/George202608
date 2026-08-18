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

namespace _46.TreeViewExercise
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
            TreeViewItem root=new TreeViewItem();
            root.Header = "根结点";

            LoadLogicalTree(root, this);
            this.myTreeView.Items.Add(root);
            
        }

        private void LoadLogicalTree(TreeViewItem root, object element)
        {
            if (element is not DependencyObject)
            {
                return;
            }
            TreeViewItem newTreeViewItem=new TreeViewItem();
            newTreeViewItem.Header = element.GetType().Name;
            root.Items.Add(newTreeViewItem);

            var elements = LogicalTreeHelper.GetChildren(element as DependencyObject);
            foreach (var item in elements)
            {
               LoadLogicalTree(newTreeViewItem, item);
            }
        }
    }
}