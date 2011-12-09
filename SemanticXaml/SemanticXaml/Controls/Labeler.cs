using System;
using System.Windows;
using System.Windows.Controls;

namespace SemanticXaml.Controls
{
    public class Labeler : ContentControl
    {
        static Labeler()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (Labeler), new FrameworkPropertyMetadata(typeof (Labeler)));

            ContentTypeProperty = DependencyProperty.Register("ContentType",
                                                              typeof (string),
                                                              typeof (Labeler));

            LabelProperty = DependencyProperty.Register("Label",
                                                        typeof (string),
                                                        typeof (Labeler));
        }

        public static readonly DependencyProperty ContentTypeProperty;

        public static readonly DependencyProperty LabelProperty;

        public string Label
        {
            get { return (string) GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public string ContentType
        {
            get { return (string) GetValue(ContentTypeProperty); }
            set { SetValue(ContentTypeProperty, value); }
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            Type type = newContent.GetType();

            ContentType = type.Name;

            base.OnContentChanged(oldContent, newContent);
        }
    }
}