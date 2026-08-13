using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomRoutedEvent
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
        private void ReportTimeHandler(object sender, ReportTimeEventArgs e)
        {
            FrameworkElement element = (sender as FrameworkElement)!;
            e.ClickTime = DateTime.Now;
            string timeString=e.ClickTime.ToLongTimeString();
            string content = $"{timeString}到达{element.Name}";
            this.listBox.Items.Add(content);
        }

       
    }

    public class TimeButton : Button
    {
        //注册路由事件
        public static readonly RoutedEvent ReportTimeEvent =
            EventManager.RegisterRoutedEvent("ReportTime", RoutingStrategy.Bubble,
            typeof(EventHandler<ReportTimeEventArgs>), typeof(TimeButton));
        //包装CLR事件
        public event RoutedEventHandler ReportTime
        {
            add { this.AddHandler(ReportTimeEvent, value); }
            remove { this.RemoveHandler(ReportTimeEvent, value); }
        }
        //激发程序
        protected override void OnClick()
        {
            base.OnClick();
            ReportTimeEventArgs e = new ReportTimeEventArgs(ReportTimeEvent, this);
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




    //public class TimeButton : Button
    //{
    //    //注册
    //    public static readonly RoutedEvent ReportTimeEvent =
    //        EventManager.RegisterRoutedEvent("ReportTime", RoutingStrategy.Bubble,
    //            typeof(EventHandler<ReportTimeEVentArgs>), typeof(TimeButton));
    //    //包装CLR事件
    //    public event RoutedEventHandler ReportTime
    //    {
    //        add { this.AddHandler(ReportTimeEvent, value); }
    //        remove { this.RemoveHandler(ReportTimeEvent, value); }
    //    }
    //    //激发程序
    //    protected override void OnClick()
    //    {
    //        base.OnClick();
    //        ReportTimeEVentArgs e = new ReportTimeEVentArgs(ReportTimeEvent, this);
    //        this.RaiseEvent(e);
    //    }
    //}

    //public class ReportTimeEVentArgs : RoutedEventArgs
    //{
    //    public ReportTimeEVentArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
    //    {
    //    }

    //    public DateTime ClickTime { get; set; }

    //}
}