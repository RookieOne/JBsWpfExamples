using System;

namespace SemanticXaml.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsTypeOf<T>(this object o)
        {
            return o.GetType() == typeof (T);
        }

        public static void IfIsOfType<T>(this object o, Action<T> action) where T : class
        {
            var t = o as T;
            if (t != null)
                action(t);
        }
    }
}