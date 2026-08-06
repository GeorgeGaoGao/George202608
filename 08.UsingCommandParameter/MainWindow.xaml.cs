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

namespace _08.UsingCommandParameter
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

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.myTextBox.Text)) 
            { 
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string content=this.myTextBox.Text.ToString();
            if (e.Parameter.ToString()=="Teacher")
            {
                content = $"New Teacher: {content} 学而不厌，诲人不倦";
                this.myListBox.Items.Add(content);
            }
            if (e.Parameter.ToString()=="Student")
            {
                content = $"New Student: {content} 好好学习，天天向上";
                this.myListBox.Items.Add (content);
            }
        }
    }
}