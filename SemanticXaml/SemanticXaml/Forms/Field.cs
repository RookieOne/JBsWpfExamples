using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SemanticXaml.Forms
{
    /// <summary>
    /// </summary>
    public class Field : ContentControl
    {
        static Field()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (Field), new FrameworkPropertyMetadata(typeof (Field)));

            ValueProperty = DependencyProperty.Register("Value", typeof (object), typeof (Field),
                                                        new PropertyMetadata(OnValueChanged));
            LabelProperty = DependencyProperty.Register("Label", typeof (string), typeof (Field));
        }

        public static readonly DependencyProperty ValueProperty;
        public static readonly DependencyProperty LabelProperty;

        public object Value
        {
            get { return GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public string Label
        {
            get { return (string) GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var field = d as Field;

            if (field == null)
                return;
            field.InferContent();
        }

        void InferContent()
        {
            BindingExpression expression = BindingOperations.GetBindingExpression(this, ValueProperty);

            object sourceItem =
                typeof (BindingExpression).GetProperty("SourceItem", BindingFlags.NonPublic | BindingFlags.Instance).
                    GetValue(expression, null);
            var propertyName =
                (string)
                typeof (BindingExpression).GetProperty("SourcePropertyName",
                                                       BindingFlags.NonPublic | BindingFlags.Instance).GetValue(
                                                           expression, null);

            Label = propertyName;

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(sourceItem);
            PropertyDescriptor property = properties.Find(propertyName, true);

            Binding binding = BindingOperations.GetBinding(this, ValueProperty);

            if (property.PropertyType == typeof (DateTime))
            {
                var date = new TextBox();
                date.FontSize = 20;
                date.SetBinding(TextBox.TextProperty, binding);

                Content = date;

                return;
            }

            var textBox = new TextBox();
            textBox.SetBinding(TextBox.TextProperty, binding);

            Content = textBox;
        }
    }
}