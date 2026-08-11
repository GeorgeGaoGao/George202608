using Microsoft.Win32;
using System.IO;
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

namespace _28.TreeViewExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog openFolderDialog = new OpenFolderDialog()
            {
                Title = "请选择一个文件夹"
            };
            if (openFolderDialog.ShowDialog()==true)
            {
                string selectedFolder = openFolderDialog.FolderName;
                this.myTextBox.Text = selectedFolder;
                LoadTreeView(selectedFolder);
            }
        }

        private void LoadTreeView(string selectedFolder)
        {
            //1。设置根节点
            TreeViewItem rootNode=new TreeViewItem();
            rootNode.Header = "根目录";
            //2.加载子文件夹和文件。
            LoadSubDirectory(rootNode, selectedFolder);
            this.myTreeView.Items.Add(rootNode);
        }
        /// <summary>
        /// 递归函数
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="selectedFolder"></param>
        /// <exception cref="NotImplementedException"></exception>

        private void LoadSubDirectory(TreeViewItem rootNode, string selectedFolder)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(selectedFolder);
            var subDirectoryInfos = directoryInfo.GetDirectories();
            foreach (var item in subDirectoryInfos)
            {
                TreeViewItem subNode = new TreeViewItem();
                subNode.Header = item.Name;
                LoadSubDirectory(subNode, item.FullName);
                rootNode.Items.Add(subNode);
            }
            var fileInfos=directoryInfo.GetFiles();
            foreach (var fileInfo in fileInfos)
            {
                TreeViewItem subNode = new TreeViewItem();
                subNode.Header= fileInfo.Name;
                rootNode.Items.Add(subNode);

            }
        }



    }
}