using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace _09.CommandExample
{
    public class MainWindowViewModel:INotifyPropertyChanged
    {
        /*窗口上有一个 文本框 和一个 “清除”按钮。
        点击按钮，文本框内容被清空。
        当文本框为空时，按钮自动禁用（CanExecute 返回 false）。
        当用户输入文字后，按钮自动启用（CanExecute 变为 true）。
        用MVVM实现。
        */
        public string Title { get; set; } = "MyCommandExample";
        private string _content = string.Empty;

        public string Content
        {
            get { return _content; }
            set {
                if (_content!=value)
                {
                    _content = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Content)));
                }
                 }
        }

        public ICommand ClearCommand { get; set; }=new RoutedCommand();
        public MainWindowViewModel()
        {
            //1.指定命令源 binding已实现？

            //2。指定命令目标 没有控件名，如何为其指定目标？
            
            //3。创建命令关联
            CommandBinding cb = new CommandBinding();
            cb.Command = this.ClearCommand;
            cb.CanExecute += Cb_CanExecute;
            cb.Executed += Cb_Executed;
          //4.安置命令关联
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Cb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
           Content = string.Empty;
        }

        private void Cb_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Content))
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
