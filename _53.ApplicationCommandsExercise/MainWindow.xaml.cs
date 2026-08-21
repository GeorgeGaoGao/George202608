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

namespace _53.ApplicationCommandsExercise
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

        private void OpenCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
           
        }

        private void OpenCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter="文本文件(*.txt)|*.txt",
                Multiselect=false
            };
            var result=openFileDialog.ShowDialog();
            if (result==true)
            {
               this.myTextBox.Text=  File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void CutCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CutCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.myTextBox.Cut();
        }

        private void PasteCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PasteCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.myTextBox.Paste();
        }

        private void SaveCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var saveFileDialog =new Microsoft.Win32.SaveFileDialog()
            {
                Filter = "文本文件(*.txt)|*.txt",
            };
            var result = saveFileDialog.ShowDialog();
            if (result==true)
            {
                File.WriteAllText(saveFileDialog.FileName,this.myTextBox.Text);
            }
        }
    }
}