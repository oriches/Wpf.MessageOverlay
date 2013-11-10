namespace Wpf.MessageOverlay.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            List<T> tmp = source.ToList();
            tmp.ForEach(action);

            return tmp;
        }
    }
}