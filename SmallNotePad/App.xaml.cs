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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (e.Args.Length > 0 && !string.IsNullOrEmpty(e.Args[0]))
            {
                string filePath = e.Args[0];
                if (System.IO.File.Exists(filePath))
                {
                    if (MainWindow is MainWindow mainWindow)
                    {
                        mainWindow.LoadFileFromCommandLine(filePath);
                    }
                }
            }
        }
    }
}
