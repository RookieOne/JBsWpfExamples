using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SemanticXaml.LabelPanels
{
    public class LabelPanel : Panel
    {
        static LabelPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (LabelPanel),
                                                     new FrameworkPropertyMetadata(typeof (LabelPanel)));

            LabelProperty = DependencyProperty.RegisterAttached("Label",
                                                                typeof (object),
                                                                typeof (LabelPanel));

            OrientationProperty = DependencyProperty.Register("Orientation",
                                                              typeof (Orientation),
                                                              typeof (LabelPanel),
                                                              new PropertyMetadata(Orientation.Vertical,
                                                                                   OnOrientationChanged));
        }

        public LabelPanel()
        {
            _ActualChildren = new List<UIElement>();
            _LayoutStrategy = new VerticalStrategy();
        }

        public static DependencyProperty LabelProperty;
        public static DependencyProperty OrientationProperty;

        readonly List<UIElement> _ActualChildren;

        Grid _Grid;
        bool _GridMustBeRebuilt;
        ILabelPanelLayoutStrategy _LayoutStrategy;

        protected override int VisualChildrenCount
        {
            get { return 1; }
        }

        public Orientation Orientation
        {
            get { return (Orientation) GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public Label GetLabel(UIElement visual)
        {
            var label = new Label();
            var binding = new Binding();
            binding.Source = visual;
            binding.Path = new PropertyPath(LabelProperty);

            label.SetBinding(ContentControl.ContentProperty, binding);

            return label;
        }

        static void OnOrientationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var labelPanel = d as LabelPanel;

            if (labelPanel == null)
                return;

            labelPanel._LayoutStrategy = labelPanel.GetStrategy();
            labelPanel._GridMustBeRebuilt = true;
        }

        public static object GetLabel(DependencyObject obj)
        {
            return obj.GetValue(LabelProperty);
        }

        public static void SetLabel(DependencyObject obj, object value)
        {
            obj.SetValue(LabelProperty, value);
        }

        ILabelPanelLayoutStrategy GetStrategy()
        {
            switch (Orientation)
            {
                case Orientation.Vertical:
                    return new VerticalStrategy();

                case Orientation.Horizontal:
                    return new HorizontalStrategy();

                default:
                    return new VerticalStrategy();
            }
        }

        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            if (visualAdded == _Grid)
                return;

            if (visualAdded != null)
            {
                var uiElement = visualAdded as UIElement;

                Children.Remove(uiElement);
                _ActualChildren.Add(uiElement);
                _GridMustBeRebuilt = true;
            }

            base.OnVisualChildrenChanged(visualAdded, visualRemoved);
        }

        protected override Visual GetVisualChild(int index)
        {
            return _Grid;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            if (_GridMustBeRebuilt)
                BuildGrid();

            _Grid.Measure(availableSize);

            return _Grid.DesiredSize;
        }

        void BuildGrid()
        {
            if (_Grid != null)
            {
                Children.Remove(_Grid);
                _Grid.Children.Clear();
            }


            _Grid = new Grid();
            var gridFacade = new LabelPanelGridFacade(_Grid);
            Children.Add(_Grid);

            foreach (UIElement child in _ActualChildren)
                _LayoutStrategy.AddVisual(GetLabel(child), child, gridFacade);

            _GridMustBeRebuilt = false;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            _Grid.Arrange(new Rect(finalSize));

            return base.ArrangeOverride(finalSize);
        }
    }
}