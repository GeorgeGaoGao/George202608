using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoutedEvent2
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
       private void ReportTimeHandler(object sender,ReportTimeEventArgs e)
        {
            FrameworkElement element=( sender as FrameworkElement)!;
            string timeString=e.ClickTime.ToLongTimeString();
            string content = $"{timeString}到达{element.Name}";
            this.listBox.Items.Add(content);

            if (element.Name=="secondGrid")
            {
                e.Handled = true;
            }
        }
    }
    public class TimeButton : Button
    {
        public static readonly RoutedEvent ReportTimeEvent = 
            EventManager.RegisterRoutedEvent("ReportTime", RoutingStrategy.Bubble, 
                typeof(EventHandler<ReportTimeEventArgs>), typeof(TimeButton));
        public event EventHandler<ReportTimeEventArgs> ReportTime
        {
            add { this.AddHandler(ReportTimeEvent, value); }
            remove { this.RemoveHandler(ReportTimeEvent, value); }
        }
        
         protected override void OnClick()
        {
            base.OnClick();
            ReportTimeEventArgs e = new ReportTimeEventArgs(ReportTimeEvent,this);
            e.ClickTime=DateTime.Now;
            this.RaiseEvent(e);
        }
    }
    public class ReportTimeEventArgs : RoutedEventArgs
    {
       

        public ReportTimeEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {
        }
        public DateTime ClickTime { get; set; }
    }
}