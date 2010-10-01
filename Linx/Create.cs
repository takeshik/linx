// -*- mode: csharp; encoding: utf-8; tab-width: 4; c-basic-offset: 4; indent-tabs-mode: nil; -*-
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
// $Id: a7db7754a428ebb526d000b64ab4e48866a29032 $
/* Linx
 *   Library that Integrates .NET with eXtremes
 * Copyright © 2008-2010 Takeshi KIRIYA (aka takeshik) <takeshik@users.sf.net>
 * All rights reserved.
 * 
 * This file is part of Linx.
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

namespace XSpect
{
    public static class Create
    {
        public static KeyValuePair<TKey, TValue> KeyValuePair<TKey, TValue>(TKey key, TValue value)
        {
            return new KeyValuePair<TKey, TValue>(key, value);
        }

        public static IDictionary<T, T> Table<T>(params T[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                return new Dictionary<T, T>();
            }
            if (elements.Length % 2 == 1)
            {
                throw new ArgumentException("elements");
            }
            return elements
                .Where((e, i) => i % 2 == 0)
                .Zip(
                    elements.Where((e, i) => i % 2 == 1),
                    KeyValuePair
                )
                .ToDictionary(p => p.Key, p => p.Value);
        }

        public static IDictionary<TKey, TValue> Dictionary<TKey, TValue>(IEnumerable<TKey> keys, IEnumerable<TValue> values)
        {
            return keys
                .Zip(values, KeyValuePair)
                .ToDictionary(p => p.Key, p => p.Value);
        }

        public static Type[] TypeArray()
        {
            return new Type[0];
        }

        public static Type[] TypeArray<T1>()
        {
            return Make.Array(typeof(T1));
        }

        public static Type[] TypeArray<T1, T2>()
        {
            return Make.Array(typeof(T1), typeof(T2));
        }

        public static Type[] TypeArray<T1, T2, T3>()
        {
            return Make.Array(typeof(T1), typeof(T2), typeof(T3));
        }

        public static Type[] TypeArray<T1, T2, T3, T4>()
        {
            return Make.Array(typeof(T1), typeof(T2), typeof(T3), typeof(T4));
        }

        public static Type[] TypeArray<T1, T2, T3, T4, T5>()
        {
            return Make.Array(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5));
        }

        public static Type[] TypeArray<T1, T2, T3, T4, T5, T6>()
        {
            return Make.Array(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6));
        }

        public static Type[] TypeArray<T1, T2, T3, T4, T5, T6, T7>()
        {
            return Make.Array(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7));
        }

        public static Type[] TypeArray<T1, T2, T3, T4, T5, T6, T7, T8>()
        {
            return Make.Array(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8));
        }
    }
}

