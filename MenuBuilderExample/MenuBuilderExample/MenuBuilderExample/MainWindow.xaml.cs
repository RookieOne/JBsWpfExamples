using System;
using System.Windows;

namespace MenuBuilderExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += (sender, args) => { CreateMenu(); };
        }

        void CreateMenu()
        {
            var wpfMenu = new WpfMenu(this.menu);
            wpfMenu.Add(() => { Console.WriteLine("QUIT"); }, "File", "Quit");
            wpfMenu.Add(() => { Console.WriteLine("VBB is awesome"); }, "Virtual", "Brown", "Bag", "Is", "Awesome");
        }
    }
}