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

        private void myBorder_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LinearGradientBrush brush=myBorder.Background as LinearGradientBrush;
            PointAnimationUsingKeyFrames startPointAnimation = new PointAnimationUsingKeyFrames();
            PointAnimationUsingKeyFrames endPointAnimation = new PointAnimationUsingKeyFrames();

            Random random=new Random();
            double x=random.NextDouble();
            Thread.Sleep(1);
            double y=random.NextDouble();
            PointKeyFrame startKeyFrame = new LinearPointKeyFrame(new Point(x, y), new TimeSpan(0, 0, 2));
            startPointAnimation.KeyFrames.Add(startKeyFrame);

            x=random.NextDouble();
            Thread.Sleep(1);
            y=random.NextDouble();
            PointKeyFrame endKeyFrame = new LinearPointKeyFrame(new Point(x, y), new TimeSpan(0, 0, 3));
            startPointAnimation.KeyFrames.Add(endKeyFrame);

            brush.BeginAnimation(LinearGradientBrush.StartPointProperty, startPointAnimation);
            brush.BeginAnimation(LinearGradientBrush.EndPointProperty, endPointAnimation);
        }
    }
}