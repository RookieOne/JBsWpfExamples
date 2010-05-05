using System.IO;
using System.Windows;
using System.Windows.Markup;

namespace NotaDesigner
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //LoadUsingFileWatcher();
        }

        void LoadUsingFileWatcher()
        {
            var watcher = new FileSystemWatcher();

            watcher.Path = @"C:\Projects\NotaDesigner\bin\Debug\Resources";
            watcher.EnableRaisingEvents = true;
            watcher.Changed += (sender, args) => LoadResourceDictionary(args.FullPath);
        }

        void LoadResourceDictionary(string filePath)
        {
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            var dictionary = new XamlReader().LoadAsync(stream);

            Current.Resources.MergedDictionaries.Add(dictionary as ResourceDictionary);
        }
    }
}