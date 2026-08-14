using System.Configuration;
using System.Data;
using System.Windows;

namespace _37.StartupUriExercise
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Uri uri = new Uri("Shell.xaml",UriKind.Relative);
            this.StartupUri= uri;

        }
    }

}
