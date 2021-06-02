using System;
using System.Collections.Generic;


namespace JevLogin
{
    internal static class Extensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T obj in source)
            {
                action(obj);
            }
            return source;
        }
    }
}