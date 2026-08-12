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

namespace _34.PolyLineExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private bool isNewPolyline=true;
        private Polyline polyline = null!;

        private bool isNewPolygon=true;
        private Polygon polygon = null!;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isNewPolygon)
            {

                polygon = new Polygon();
                polygon.Stroke = Brushes.Red;
                polygon.StrokeThickness = 3;
                ((sender as Window).Content as Grid).Children.Add(polygon);
                isNewPolygon = false;
              
            }
            var point = e.GetPosition(sender as Window);
            polygon.Points.Add(point);
        }

        private void Window_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (polygon.Points.Count>2)
            {
                polygon.Points.Add(polygon.Points[0]);
            }

            isNewPolygon = true;
        }
        //private void Window_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    if (isNewPolyline)
        //    {

        //        polyline = new Polyline();
        //        polyline.Stroke = Brushes.Red;
        //        polyline.StrokeThickness = 3;
        //        ((sender as Window).Content as Grid).Children.Add(polyline);
        //        isNewPolyline = false;
              
        //    }
        //    var point = e.GetPosition(sender as Window);
        //    polyline.Points.Add(point);
        //}

        //private void Window_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    if (polyline.Points.Count>2)
        //    {
        //        polyline.Points.Add(polyline.Points[0]);
        //    }
            
        //    isNewPolyline=true;
        //}
    }
}