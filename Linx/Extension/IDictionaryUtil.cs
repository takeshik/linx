// -*- mode: csharp; encoding: utf-8; tab-width: 4; c-basic-offset: 4; indent-tabs-mode: nil; -*-
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
// $Id: a7db7754a428ebb526d000b64ab4e48866a29032 $
/* Linx
 *   Library that Integrates .NET with eXtremes
 * Copyright © 2008-2011 Takeshi KIRIYA (aka takeshik) <takeshik@users.sf.net>
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
using System.IO;
using Achiral.Extension;

namespace XSpect.Extension
{
    public static class IDictionaryUtil
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value)
                ? value
                : defaultValue;
        }

        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.GetValueOrDefault(key, default(TValue));
        }

        public static String Inspect<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return dictionary.Select(p => p.ToString()).Join(Environment.NewLine).If(String.IsNullOrEmpty, "(empty)");
        }

        public static IDictionary<TNewKey, TNewValue> SelectKeyValue<TKey, TValue, TNewKey, TNewValue>(
            this IDictionary<TKey, TValue> dictionary,
            Func<TKey, TNewKey> keySelector,
            Func<TValue, TNewValue> valueSelector
        )
        {
            return dictionary.Select(p => Create.KeyValuePair(keySelector(p.Key), valueSelector(p.Value))).ToDictionary();
        }

        public static IDictionary<TNewKey, TValue> SelectKey<TKey, TValue, TNewKey>(
            this IDictionary<TKey, TValue> dictionary,
            Func<TKey, TNewKey> keySelector
        )
        {
            return dictionary.Select(p => Create.KeyValuePair(keySelector(p.Key), p.Value)).ToDictionary();
        }

        public static IDictionary<TKey, TNewValue> SelectValue<TKey, TValue, TNewValue>(
            this IDictionary<TKey, TValue> dictionary,
            Func<TValue, TNewValue> valueSelector
        )
        {
            return dictionary.Select(p => Create.KeyValuePair(p.Key, valueSelector(p.Value))).ToDictionary();
        }

        public static IDictionary<TValue, TKey> ReverseKeyValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return dictionary.Select(p => Create.KeyValuePair(p.Value, p.Key)).ToDictionary();
        }
    }
}