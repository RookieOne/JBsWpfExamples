using System;
using System.Windows;
using System.Windows.Controls;

namespace SemanticXaml.Controls
{
    public class DisplayDateRange : Control
    {
        static DisplayDateRange()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (DisplayDateRange),
                                                     new FrameworkPropertyMetadata(typeof (DisplayDateRange)));

            StartProperty = DependencyProperty.Register("Start",
                                                        typeof (DateTime?),
                                                        typeof(DisplayDateRange));

            EndProperty = DependencyProperty.Register("End",
                                                      typeof (DateTime?),
                                                      typeof(DisplayDateRange));
        }

        public static readonly DependencyProperty StartProperty;

        public static readonly DependencyProperty EndProperty;

        public DateTime? Start
        {
            get { return (DateTime?) GetValue(StartProperty); }
            set { SetValue(StartProperty, value); }
        }

        public DateTime? End
        {
            get { return (DateTime?) GetValue(EndProperty); }
            set { SetValue(EndProperty, value); }
        }
    }
}