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

namespace _30.MenuExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<MenuModel> Menus { get; set; }= new List<MenuModel>();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            for (int i = 0; i < 5; i++)
            {
                MenuModel parent = new MenuModel();
                parent.Children = new List<MenuModel>();
                parent.Name = $"一级菜单{i}";
                for (int j = 0; j < 10; j++)
                {
                    MenuModel child = new MenuModel();
                    child.Name = $"二级菜单{j}";
                    parent.Children.Add(child);
                }
                Menus.Add(parent);
            }
        }
    }
    public class MenuModel
    {
        public string Name { get; set; }
        public string View { get; set; }
        public List<MenuModel> Children { get; set; }

    }

}