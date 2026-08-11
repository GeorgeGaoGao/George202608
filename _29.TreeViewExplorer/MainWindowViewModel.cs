using GeorgeWpfDLL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace _29.TreeViewExplorer
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TreeViewItem> TreeViewItems { get; set; } = new ObservableCollection<TreeViewItem>();
        public ICommand ChooseRootFolderCommand { get; set; }
        private string _rootFolder;

        public string RootFolder
        {
            get { return _rootFolder; }
            set { _rootFolder = value; OnPropertyChanged(); }
        }

        public MainWindowViewModel()
        {
            ChooseRootFolderCommand = new RelayCommand(OnChooseRootFolderCommand);
           
        }

        private void OnChooseRootFolderCommand(object obj)
        {
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();
            if (openFolderDialog.ShowDialog()==true)
            {
                string selectedPath = openFolderDialog.FolderName;
                RootFolder = openFolderDialog.FolderName;
                TreeViewItem rootNode=new TreeViewItem();
                rootNode.Header = "Root";
                LoadSubNodes(rootNode, selectedPath);
                TreeViewItems.Add(rootNode);
            }
        }

        private void LoadSubNodes(TreeViewItem rootNode, string selectedPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(selectedPath);
            var subDirectoryInfos = directoryInfo.GetDirectories();
            foreach (var subDirectory in subDirectoryInfos)
            {
                TreeViewItem subNode= new TreeViewItem();
                subNode.Header= subDirectory.Name;
                rootNode.Items.Add(subNode);
                LoadSubNodes(subNode, subDirectory.FullName);
            }
            var subFileInfos=directoryInfo.GetFiles();
            foreach (var file in subFileInfos)
            {
                TreeViewItem fileNode= new TreeViewItem();
                fileNode.Header= file.Name;
                rootNode.Items.Add(fileNode);

            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
