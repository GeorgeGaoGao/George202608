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

namespace _57.BrushExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //SolidColorBrush solidColorBrush = new SolidColorBrush(Color.FromRgb(0,255,0));
            //solidColorBrush.Color = Colors.Lime;
            //this.myBorder.Background = solidColorBrush;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            GradientBrush brush = myBorder.Background as GradientBrush;
            if (brush != null)
            {
                GradientStop gradientStop1 = brush.GradientStops[0];
                GradientStop gradientStop2 = brush.GradientStops[1];

                Point currentPoint = e.GetPosition(myBorder);
                double offset = (currentPoint.X / Width + currentPoint.Y / Height) / 2;

                gradientStop1.Offset = offset;
                gradientStop2.Offset = 1 - offset;
            }


        }

        private void myEllipse_MouseMove(object sender, MouseEventArgs e)
        {
            RadialGradientBrush radial = myEllipse.Fill as RadialGradientBrush;
            double x = e.GetPosition(myEllipse).X / myEllipse.Width;
            double y = e.GetPosition(myEllipse).Y / myEllipse.Height;
            radial.GradientOrigin = new Point(x, y);
        }

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            double offset = e.Delta / 3600.0;
            ImageBrush brush = myGrid.Background as ImageBrush;
            Rect rect = brush.Viewport;
            if (rect == null || rect.Width + offset <= 0 || rect.Height + offset <= 0) return;
            rect.Width += offset;
            rect.Height += offset;
            brush.Viewport = rect;

        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            myVisualEllipse.Visibility = Visibility.Visible;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            myVisualEllipse.Visibility = Visibility.Collapsed;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            double length = myVisualEllipse.ActualWidth * 0.5;
            double radius = length / 2;
            Point currentPoint=e.GetPosition(myImage);
            var viewBoxRect = new Rect(currentPoint.X - radius, currentPoint.Y - radius, length, length);
            (myVisualEllipse.Fill as VisualBrush).Viewbox = viewBoxRect;

            myVisualEllipse.SetValue(Canvas.LeftProperty, currentPoint.X - myVisualEllipse.ActualWidth / 2);
            myVisualEllipse.SetValue(Canvas.TopProperty, currentPoint.Y - myVisualEllipse.ActualHeight / 2);
        }
    }
}