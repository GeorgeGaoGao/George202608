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

namespace _18.MediaElementExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string file = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }



        private void OpenMedia(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = $"视频文件(.mp4)|*.mp4",
                Multiselect = false
            };
            var result=openFileDialog.ShowDialog();
            if (result==true)
            {
                file = openFileDialog.FileName;
                myMediaElement.MediaOpened -= MyMediaElement_MediaOpened;
                myMediaElement.MediaOpened += MyMediaElement_MediaOpened;
                myMediaElement.Source = new System.Uri(file);
                this.Title = file;
                this.myTextBlock.Text = file;
            }
        }

        private void MyMediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PlayMedia(object sender, RoutedEventArgs e)
        {

        }
        private void StopMedia(object sender, RoutedEventArgs e)
        {

        }

        private void BackwardMedia(object sender, RoutedEventArgs e)
        {

        }

        private void ForwardMedia(object sender, RoutedEventArgs e)
        {

        }



        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}