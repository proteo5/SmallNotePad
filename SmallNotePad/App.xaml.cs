using System.Configuration;
using System.Data;
using System.Windows;

namespace SmallNotePad
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string[] CommandLineArgs { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            CommandLineArgs = e.Args;
        }
    }
}
