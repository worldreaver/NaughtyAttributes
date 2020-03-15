#if UNITY_EDITOR
using System.Collections.Generic;
using System;

namespace Worldreaver.RectEx
{
    internal static class EnumerableExtension
    {
        public static IEnumerable<TResult> Merge<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> selector)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();
            while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
            {
                yield return selector(firstEnumerator.Current, secondEnumerator.Current);
            }
        }
    }
}
#endif