// -*- mode: csharp; encoding: utf-8; tab-width: 4; c-basic-offset: 4; indent-tabs-mode: nil; -*-
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
// $Id: IEnumerableUtil.cs 36039 2009-11-29 13:46:08Z takeshik $
/* Linx
 *   Library that Integrates .NET with eXtremes
 * Copyright © 2008-2009 Takeshi KIRIYA, XSpect Project <takeshik@users.sf.net>
 * All rights reserved.
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a
 * copy of this software and associated documentation files (the "Software"),
 * to deal in the Software without restriction, including without limitation
 * the rights to use, copy, modify, merge, publish, distribute, sublicense,
 * and/or sell copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
 * IN THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Achiral;
using Achiral.Extension;

namespace XSpect.Extension
{
    public static class IEnumerableUtil
    {
        public static IEnumerable<TSource> Trim<TSource>(this IEnumerable<TSource> source, params TSource[] elements)
        {
            return source.TrimStart(elements).TrimEnd(elements);
        }

        public static IEnumerable<TSource> TrimStart<TSource>(this IEnumerable<TSource> source, params TSource[] elements)
        {
            return source.SkipWhile(e => e.Equals(elements));
        }

        public static IEnumerable<TSource> TrimEnd<TSource>(this IEnumerable<TSource> source, params TSource[] elements)
        {
            return source.Reverse().SkipWhile(e => e.Equals(elements)).Reverse();
        }

        public static TSource SingleOrPredicatedSingle<TSource>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicateIfNotSingle)
        {
            return source.Count() < 1 ? source.Single() : source.Single(predicateIfNotSingle);
        }

        public static IEnumerable<TSource> Next<TSource>(this IEnumerable<TSource> source, Func<IEnumerable<TSource>, TSource> generator)
        {
            foreach (TSource e in source)
            {
                yield return e;
            }
            IEnumerable<TSource> previous = source.Reverse();
            while (true)
            {
                yield return (previous = Make.Sequence(generator(previous)).Concat(previous)).First();
            }
        }

        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> collection)
        {
            return collection.ToDictionary(p => p.Key, p => p.Value);
        }

        public static String ToUriQuery(this IEnumerable<KeyValuePair<String, String>> dictionary)
        {
            return dictionary != null && dictionary.Any()
                ? "?" + dictionary.Select(p => p.Key + "=" + p.Value).Join("&")
                : String.Empty;
        }

        public static IEnumerable<TResult> ZipWith<T1, T2, T3, TResult>(
            this IEnumerable<T1> source1,
            IEnumerable<T2> source2,
            IEnumerable<T3> source3,
            Func<T1, T2, T3, TResult> func)
        {
            using (IEnumerator<T1> enumerator1 = source1.GetEnumerator())
            using (IEnumerator<T2> enumerator2 = source2.GetEnumerator())
            using (IEnumerator<T3> enumerator3 = source3.GetEnumerator())
            {
                while (enumerator1.MoveNext() && enumerator2.MoveNext() && enumerator3.MoveNext())
                {
                    yield return func(enumerator1.Current, enumerator2.Current, enumerator3.Current);
                }
            }
        }

        public static IEnumerable<TResult> ZipWith<T1, T2, T3, T4, TResult>(
            this IEnumerable<T1> source1,
            IEnumerable<T2> source2,
            IEnumerable<T3> source3,
            IEnumerable<T4> source4,
            Func<T1, T2, T3, T4, TResult> func)
        {
            using (IEnumerator<T1> enumerator1 = source1.GetEnumerator())
            using (IEnumerator<T2> enumerator2 = source2.GetEnumerator())
            using (IEnumerator<T3> enumerator3 = source3.GetEnumerator())
            using (IEnumerator<T4> enumerator4 = source4.GetEnumerator())
            {
                while (enumerator1.MoveNext() && enumerator2.MoveNext() && enumerator3.MoveNext() && enumerator4.MoveNext())
                {
                    yield return func(enumerator1.Current, enumerator2.Current, enumerator3.Current, enumerator4.Current);
                }
            }
        }

        public static IEnumerable<TResult> ZipWith<T1, T2, T3, TResult>(
            this IEnumerable<T1> source1,
            IEnumerable<T2> source2,
            IEnumerable<T3> source3,
            Func<T1, T2, T3, Int32, TResult> func)
        {
            using (IEnumerator<T1> enumerator1 = source1.GetEnumerator())
            using (IEnumerator<T2> enumerator2 = source2.GetEnumerator())
            using (IEnumerator<T3> enumerator3 = source3.GetEnumerator())
            {
                Int32 index = 0;
                while (enumerator1.MoveNext() && enumerator2.MoveNext() && enumerator3.MoveNext())
                {
                    yield return func(enumerator1.Current, enumerator2.Current, enumerator3.Current, index);
                    ++index;
                }
            }
        }

        public static IEnumerable<TResult> ZipWith<T1, T2, T3, T4, TResult>(
            this IEnumerable<T1> source1,
            IEnumerable<T2> source2,
            IEnumerable<T3> source3,
            IEnumerable<T4> source4,
            Func<T1, T2, T3, T4, Int32, TResult> func)
        {
            using (IEnumerator<T1> enumerator1 = source1.GetEnumerator())
            using (IEnumerator<T2> enumerator2 = source2.GetEnumerator())
            using (IEnumerator<T3> enumerator3 = source3.GetEnumerator())
            using (IEnumerator<T4> enumerator4 = source4.GetEnumerator())
            {
                Int32 index = 0;
                while (enumerator1.MoveNext() && enumerator2.MoveNext() && enumerator3.MoveNext() && enumerator4.MoveNext())
                {
                    yield return func(enumerator1.Current, enumerator2.Current, enumerator3.Current, enumerator4.Current, index);
                    ++index;
                }
            }
        }
    }
}