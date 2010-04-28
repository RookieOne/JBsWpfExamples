using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SemanticXaml.Forms
{
    /// <summary>
    /// </summary>
    public class Form : ItemsControl
    {
        static Form()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (Form), new FrameworkPropertyMetadata(typeof (Form)));

            TitleProperty = DependencyProperty.Register("Title", typeof (string), typeof (Form));
            EditProperty = DependencyProperty.Register("Edit", typeof (object), typeof (Form),
                                                       new PropertyMetadata(OnEditChanged));
        }

        public static readonly DependencyProperty EditProperty;
        public static readonly DependencyProperty TitleProperty;

        public string Title
        {
            get { return (string) GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public object Edit
        {
            get { return GetValue(EditProperty); }
            set { SetValue(EditProperty, value); }
        }

        static void OnEditChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var form = d as Form;

            if (form == null)
                return;

            form.InferFields();
        }

        void InferFields()
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(Edit);

            foreach (PropertyDescriptor property in properties)
            {
                if (Items.Cast<Field>().Any(f => f.Label == property.Name))
                    continue;

                var binding = new Binding();
                binding.Path = new PropertyPath(property.Name);

                var field = new Field();
                field.SetBinding(Field.ValueProperty, binding);

                Items.Add(field);
            }
        }
    }
}