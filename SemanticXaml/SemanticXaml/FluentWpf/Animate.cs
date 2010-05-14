using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SemanticXaml.FluentWpf
{
    public class Animate
    {
        public static AnimateBuilder The(DependencyProperty property)
        {
            return new AnimateBuilder(property);
        }
    }

    public class AnimateBuilder
    {
        public AnimateBuilder(DependencyProperty property)
        {
            _property = property;
        }

        readonly DependencyProperty _property;

        public Animate<T> From<T>(T from)
        {
            return new Animate<T>(_property, from);
        }
    }

    public class Animate<T>
    {
        public Animate(DependencyProperty property, T from)
        {
            _property = property;
            _from = from;
        }

        readonly T _from;
        readonly DependencyProperty _property;
        double _delay;
        AnimationTimeline _timeline;
        T _to;

        public Animate<T> To(T to)
        {
            _to = to;
            return this;
        }

        public Animate<T> For(Duration duration)
        {
            if (typeof (T) == typeof (double)
                || typeof(T) == typeof(int))
            {
                double from = Convert.ToDouble(_from);
                double to = Convert.ToDouble(_to);
                _timeline = new DoubleAnimation(from, to, duration);
                _timeline.BeginTime = TimeSpan.FromMilliseconds(_delay);
            }

            return this;
        }

        public Animate<T> UponCompletion(Action completedAction)
        {
            _timeline.Completed += (sender, args) => completedAction();
            return this;
        }

        public Animation Create()
        {
            return new Animation(_property, _timeline);
        }

        public Animate<T> Delay(double delay)
        {
            _delay = delay;
            return this;
        }
    }

    public class Animation
    {
        public Animation(DependencyProperty property, AnimationTimeline timeline)
        {
            _property = property;
            _timeline = timeline;
        }

        readonly DependencyProperty _property;
        readonly AnimationTimeline _timeline;

        public Animation UponCompletion(Action completedAction)
        {
            _timeline.Completed += (sender, args) => completedAction();
            return this;
        }

        public void AnimateOn(UIElement element)
        {
            element.BeginAnimation(_property, _timeline);
        }

        public void AnimateOn(Transform transform)
        {
            transform.BeginAnimation(_property, _timeline);
        }
    }
}