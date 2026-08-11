using GeorgeWpfDLL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _29.TreeViewExplorer
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TreeViewItem> TreeViewItems { get; set; } = new ObservableCollection<TreeViewItem>();
        public ICommand ChooseRootFolderCommand { get; set; }
        public ICommand TreeViewSelectedChangedCommand {  get; set; }
        private string _rootFolder;

        public string RootFolder
        {
            get { return _rootFolder; }
            set { _rootFolder = value; OnPropertyChanged(); }
        }

        public MainWindowViewModel()
        {
            ChooseRootFolderCommand = new RelayCommand(OnChooseRootFolderCommand);
            TreeViewSelectedChangedCommand = new RelayCommand(OnTreeViewSelectedChangedCommand);
        }

        private void OnTreeViewSelectedChangedCommand(object obj)
        {
            TreeView treeView=obj as TreeView;
            TreeViewItem node=treeView.SelectedItem as TreeViewItem;
            MessageBox.Show($"current node's header:{node.Header}");
        }

        private void OnChooseRootFolderCommand(object obj)
        {
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();
            if (openFolderDialog.ShowDialog()==true)
            {
                string rootPath = openFolderDialog.FolderName;
                RootFolder = openFolderDialog.FolderName;
                TreeViewItem rootNode=new TreeViewItem();
                rootNode.Header = "Root";
                LoadNodes(rootNode, rootPath);
                TreeViewItems.Add(rootNode);
            }
        }

        private void LoadNodes(TreeViewItem node, string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            var subDirectoryInfos = directoryInfo.GetDirectories();
            foreach (var subDirectory in subDirectoryInfos)
            {
                TreeViewItem subNode= new TreeViewItem();
                subNode.Header= subDirectory.Name;
                node.Items.Add(subNode);
                LoadNodes(subNode, subDirectory.FullName);
            }
            var subFileInfos=directoryInfo.GetFiles();
            foreach (var file in subFileInfos)
            {
                TreeViewItem fileNode= new TreeViewItem();
                fileNode.Header= file.Name;
                node.Items.Add(fileNode);

            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
