using System;
using System.Collections.Generic;
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

namespace _54.DependencyPropertyExercise
{
    /// <summary>
    /// WidgetUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class WidgetUserControl : UserControl
    {
        public WidgetUserControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }


        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(string), typeof(WidgetUserControl), new PropertyMetadata("@"));



        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(WidgetUserControl), new PropertyMetadata("请输入抬头"));



        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(double), typeof(WidgetUserControl), 
                new PropertyMetadata(0.0,
                    new PropertyChangedCallback(OnValuePropertyChanged
                        )));

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is WidgetUserControl control&&e.NewValue is double nowValue)
            {
                if (nowValue<control.ValueTarget)
                {
                    control.Icon = "%";
                }
                if (nowValue> control.ValueTarget)
                {
                    control.Icon = "%%";
                }
                if (nowValue>control.ValueTarget+49)
                {
                    control.RaiseCompletedEvent();
                }
            }

        }

        public double ValueTarget
        {
            get { return (double)GetValue(ValueTargetProperty); }
            set { SetValue(ValueTargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ValueTarget.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueTargetProperty =
            DependencyProperty.Register(nameof(ValueTarget), typeof(double), typeof(WidgetUserControl), new PropertyMetadata(0.0));



        public static readonly RoutedEvent CompletedEvent = EventManager.RegisterRoutedEvent(
            name: "CompletedEvent",
            routingStrategy: RoutingStrategy.Bubble,
            handlerType: typeof(RoutedEventHandler),
            ownerType: typeof(WidgetUserControl)
            );
        public event RoutedEventHandler Completed
        {
            add { AddHandler(CompletedEvent, value); }
            remove { RemoveHandler(CompletedEvent, value); }
        }

        public void RaiseCompletedEvent()
        {
            RoutedEventArgs eventArgs = new RoutedEventArgs(CompletedEvent);
            RaiseEvent(eventArgs);
           
        }
    }
}
