using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _59.BlurEffectExercise
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

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            double width = myGrid.ActualWidth;
            double height = myGrid.ActualHeight;
            Point center= new Point(width/2, height/2);
            Point mouse=e.GetPosition(myGrid);

            double distance = Math.Sqrt(Math.Pow(mouse.X - center.X, 2) + Math.Pow(mouse.Y - center.Y, 2));
            BlurEffect effect = myEllipse.Effect as BlurEffect;

            effect.Radius = distance/10;
        }
    }
}