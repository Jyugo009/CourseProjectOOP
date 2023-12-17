using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExtentions.MyLinq
{
    public static class MyLinq
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return GetFiltered();

            IEnumerable<T> GetFiltered()
            {
                foreach (T item in source)
                {
                    if (predicate(item))
                    {
                        yield return item;
                    }
                }
            }
        }

        public static IEnumerable<T> Skip<T>(this IEnumerable<T> source, int count)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return GetSkippedElements();

            IEnumerable<T> GetSkippedElements()
            {
                int skipped = 0;
                foreach (var item in source)
                {
                    if (++skipped > count)
                    {
                        yield return item;
                    }
                }
            }
        }

        public static IEnumerable<T> SkipWhile<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return GetSkippedElementsWhilePredicateHoldsTrue();

            IEnumerable<T> GetSkippedElementsWhilePredicateHoldsTrue()
            {
                bool keepSkipping = true;

                foreach (var item in source)
                {
                    if (!keepSkipping || !predicate(item))
                    {
                        keepSkipping = false;
                        yield return item;
                    }
                }
            }
        }

        public static IEnumerable<T> Take<T>(this IEnumerable<T> source, int count)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return GetTakenElements();

            IEnumerable<T> GetTakenElements()
            {
                int taken = 0;
                foreach (var item in source)
                {
                    if (taken++ < count)
                    {
                        yield return item;
                    }
                    else break;
                }
            }
        }

        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return GetTakenElementsWhilePredicateHoldsTrue();

            IEnumerable<T> GetTakenElementsWhilePredicateHoldsTrue()
            {
                foreach (var item in source)
                {
                    if (!predicate(item))
                        break;

                    yield return item;
                }
            }
        }

        public static T First<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            foreach (var item in source)
            {
                if (predicate(item))
                    return item; 
            }

            throw new InvalidOperationException("No matching element found.");
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            foreach (var item in source)
            {
                if (predicate(item))
                    return item;
            }

            return default(T);
        }

        public static T Last<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            T lastItem = default(T);

            bool found = false;

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    lastItem = item;
                    found = true;
                }
            }

            if (!found)
                throw new InvalidOperationException("No matching element found.");

            return lastItem;
        }

        public static T LastOrDefault<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            T lastItem = default(T);

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    lastItem = item;
                }
            }

            return lastItem;
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (selector == null) throw new ArgumentNullException(nameof(selector));

            foreach (var item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (selector == null) throw new ArgumentNullException(nameof(selector));

            foreach (TSource item in source)
            {
                foreach (TResult result in selector(item))
                {
                    yield return result;
                }
            }
        }

        public static bool All<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            foreach (var item in source)
            {
                if (!predicate(item))
                    return false;
            }

            return true;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;    
        }

        public static T[] ToArray<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            int size = source.Count();

            var array = new T[size];

            int i = 0;
            foreach (var item in source)
            {
                array[i++] = item;
            }

                return array;
        }

        public static List<T> ToList<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var list = new List<T>();

            foreach (var item in source)
            {
                list.Add(item);
            }
                
            return list;
        }
    }
}