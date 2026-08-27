using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _60.AnimationExercise
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

        private void myGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point mousePoint = e.GetPosition(myGrid);
            ScaleTransform scaleTransform = myEllipse.RenderTransform as ScaleTransform;
            DoubleAnimation animation= new DoubleAnimation();
            animation.To = (mousePoint.X + mousePoint.Y) / 100;
            animation.Duration = new TimeSpan(0, 0, 0, 0, 250);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, animation);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, animation);
        }
    }
}