using System.Windows;

namespace DepProperties.DefaultValue
{
    public class MyObjectWithDefaultValue : DependencyObject
    {
        static MyObjectWithDefaultValue()
        {
            MyTextProperty = DependencyProperty.Register("MyText", typeof (string),
                                                         typeof (MyObjectWithDefaultValue),
                                                         new PropertyMetadata("default"));
            MyAttachedProperty = DependencyProperty.RegisterAttached("MyAttached", typeof (string),
                                                                     typeof (MyObjectWithDefaultValue),
                                                                     new PropertyMetadata("attached"));
            PersonProperty = DependencyProperty.RegisterAttached("Person", typeof (Person),
                                                                 typeof (MyObjectWithDefaultValue),
                                                                 new PropertyMetadata(new Person()));
        }

        public static readonly DependencyProperty MyAttachedProperty;
        public static readonly DependencyProperty MyTextProperty;
        public static readonly DependencyProperty PersonProperty;

        public string MyText
        {
            get { return (string) GetValue(MyTextProperty); }
            set { SetValue(MyTextProperty, value); }
        }

        public static void SetMyAttached(DependencyObject o, string value)
        {
            o.SetValue(MyAttachedProperty, value);
        }

        public static string GetMyAttached(DependencyObject o)
        {
            return o.GetValue(MyAttachedProperty).ToString();
        }

        public static void SetPerson(DependencyObject o, Person value)
        {
            o.SetValue(PersonProperty, value);
        }

        public static Person GetPerson(DependencyObject o)
        {
            return (Person)o.GetValue(PersonProperty);
        }
    }
}