using System.Windows;
using System.Windows.Controls;

namespace SemanticXaml.Controls
{
    public class PageTitle : Control
    {
        static PageTitle()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (PageTitle),
                                                     new FrameworkPropertyMetadata(typeof (PageTitle)));

            TitleProperty = DependencyProperty.Register("Title",
                                                        typeof (string),
                                                        typeof (PageTitle));
        }

        public static readonly DependencyProperty TitleProperty;

        public string Title
        {
            get { return (string) GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
    }
}