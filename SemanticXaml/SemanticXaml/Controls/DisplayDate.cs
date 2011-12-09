using System;
using System.Windows;
using System.Windows.Controls;

namespace SemanticXaml.Controls
{
    public class DisplayDate : Control
    {
        static DisplayDate()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (DisplayDate),
                                                     new FrameworkPropertyMetadata(typeof (DisplayDate)));

            DateProperty = DependencyProperty.Register("Date",
                                                       typeof (DateTime?),
                                                       typeof (DisplayDate));
        }

        public static readonly DependencyProperty DateProperty;        
        

        public DateTime? Date
        {
            get { return (DateTime?) GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }
    }
}