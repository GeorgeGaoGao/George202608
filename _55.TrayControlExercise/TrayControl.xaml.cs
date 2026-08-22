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

namespace _55.TrayControlExercise
{
    /// <summary>
    /// TrayControl.xaml 的交互逻辑
    /// </summary>
    public partial class TrayControl : UserControl
    {


        public int Size
        {
            get { return (int)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Size.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register(nameof(Size), typeof(int), typeof(TrayControl),
                new PropertyMetadata(60, new PropertyChangedCallback(OnSizePropertyChangedCallback)));

        private static void OnSizePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TrayControl control = d as TrayControl;
            control.Initialize();
           
        }

        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Count.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CountProperty =
            DependencyProperty.Register(nameof(Count), typeof(int), typeof(TrayControl),
                new PropertyMetadata(0, new PropertyChangedCallback(OnCountPropertyChangedCallback)));

        private static void OnCountPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TrayControl control = d as TrayControl;
            control.Initialize();
        }

        public int SelectedCount
        {
            get { return (int)GetValue(SelectedCountProperty); }
            set { SetValue(SelectedCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedCountProperty =
            DependencyProperty.Register(nameof(SelectedCount), typeof(int), typeof(TrayControl),
                new PropertyMetadata(0));



        public List<CheckBox> SelectedItems
        {
            get { return (List<CheckBox>)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register(nameof(SelectedItems), typeof(List<CheckBox>), typeof(TrayControl),
                new PropertyMetadata(new List<CheckBox>()));


        public void Initialize()
        {
            SelectedCount = 0;
            SelectedItems.Clear();
            container.Children.Clear();

            if (Count > 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Style = Application.Current.Resources["checkBoxTrayStyle"] as Style;
                    checkBox.Width = Size;
                    checkBox.Height = Size;
                    checkBox.Tag = new Point(1 * 10, Size + i * 2);
                    checkBox.Name ="_"+ i.ToString();

                    checkBox.Checked += (s, e) =>
                    {
                        SelectedCount++;
                        SelectedItems.Add(checkBox);
                    };
                    checkBox.Unchecked += (s, e) =>
                    {
                        SelectedCount--;
                        SelectedItems.Remove(checkBox);
                    };
                    this.container.Children.Add(checkBox);
                }
            }
        }

        public TrayControl()
        {
            InitializeComponent();
            Initialize();
        }
    }
}
