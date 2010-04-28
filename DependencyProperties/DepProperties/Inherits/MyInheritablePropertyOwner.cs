using System.Windows;

namespace DepProperties.Inherits
{
    public static class MyInheritablePropertyOwner
    {
        static MyInheritablePropertyOwner()
        {
            InheritableProperty = DependencyProperty.RegisterAttached("Inheritable",
                                                                      typeof (string),
                                                                      typeof (MyInheritablePropertyOwner),
                                                                      new FrameworkPropertyMetadata(string.Empty,
                                                                                                    FrameworkPropertyMetadataOptions
                                                                                                        .Inherits));
        }

        public static readonly DependencyProperty InheritableProperty;

        public static void SetInheritable(DependencyObject o, string value)
        {
            o.SetValue(InheritableProperty, value);
        }

        public static string GetInheritable(DependencyObject o)
        {
            return o.GetValue(InheritableProperty).ToString();
        }
    }
}