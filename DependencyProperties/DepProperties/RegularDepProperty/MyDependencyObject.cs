using System.Windows;

namespace DepProperties.RegularDepProperty
{
    public class MyDependencyObject : DependencyObject
    {
        static MyDependencyObject()
        {
            MyTextProperty = DependencyProperty.Register("MyText", typeof(string), typeof(MyDependencyObject));
        }

        public static readonly DependencyProperty MyTextProperty;

        public string MyText
        {
            get { return (string)GetValue(MyTextProperty); }
            set { SetValue(MyTextProperty, value); }
        }
    }
}