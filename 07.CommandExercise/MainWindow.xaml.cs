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



namespace _07.CommandExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //注册命令
        private RoutedCommand ClearCommand = new RoutedCommand();
        public MainWindow()
        {
            InitializeComponent();
            //初始化命令
            InitializeCommand();
        }

        private void InitializeCommand()
        {
            //1.指定命令源 为命令附加一个快捷键
            this.myButton.Command = this.ClearCommand;
            this.ClearCommand.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt));
            //2.指定命令目标
            this.myButton.CommandTarget = this.myTextBox;

            //3.创建命令关联，三个项目，command, canexecute,executed
            CommandBinding cb=new CommandBinding();
            cb.Command=this.ClearCommand;
            cb.CanExecute += Cb_CanExecute;
            cb.Executed += Cb_Executed;
            //4.将命令关联安置在外围控件上
            this.myStackPanel.CommandBindings.Add(cb);

        }

        private void Cb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.myTextBox.Clear();
        }

        private void Cb_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.myTextBox.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }
    }
    
}