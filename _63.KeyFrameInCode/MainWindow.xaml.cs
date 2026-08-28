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

namespace _63.KeyFrameInCode
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

        private void myBorder_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LinearGradientBrush brush = myBorder.Background as LinearGradientBrush;

            PointAnimationUsingKeyFrames startPointAnimation= new PointAnimationUsingKeyFrames();
            PointAnimationUsingKeyFrames endPointAnimation= new PointAnimationUsingKeyFrames();
            LinearPointKeyFrame keyFrameStart= new LinearPointKeyFrame();
            LinearPointKeyFrame keyFrameEnd= new LinearPointKeyFrame();
            startPointAnimation.KeyFrames.Add(keyFrameStart);
            endPointAnimation.KeyFrames.Add(keyFrameEnd);

            Random random= new Random();
            double x = random.NextDouble();
            double y = random.NextDouble();
            keyFrameStart.KeyTime = TimeSpan.FromMilliseconds(1500);
            keyFrameStart.Value=new Point(x, y);

            x= random.NextDouble();
            y= random.NextDouble();
            keyFrameEnd.KeyTime = TimeSpan.FromMilliseconds(1500);
            keyFrameEnd.Value=new Point(x, y);

            brush.BeginAnimation(LinearGradientBrush.StartPointProperty, startPointAnimation);
            brush.BeginAnimation(LinearGradientBrush.EndPointProperty, endPointAnimation);

        }
    }
}