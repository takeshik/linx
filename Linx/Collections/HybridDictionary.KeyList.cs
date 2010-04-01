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
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;

namespace XSpect.Collections
{
    partial class HybridDictionary<TKey, TValue>
    {
        public sealed class KeyList
            : IList<TKey>
        {
            private readonly HybridDictionary<TKey, TValue> _dictionary;

            public IEnumerator<TKey> GetEnumerator()
            {
                return this._dictionary._keyList.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            void ICollection<TKey>.Add(TKey item)
            {
                throw new NotSupportedException("This list is read-only.");
            }

            void ICollection<TKey>.Clear()
            {
                throw new NotSupportedException("This list is read-only.");
            }

            public Boolean Contains(TKey item)
            {
                return this._dictionary._keyList.Contains(item);
            }

            public void CopyTo(TKey[] array, Int32 arrayIndex)
            {
                this._dictionary._keyList.CopyTo(array, arrayIndex);
            }

            Boolean ICollection<TKey>.Remove(TKey item)
            {
                throw new NotSupportedException("This list is read-only.");
            }

            public Int32 Count
            {
                get
                {
                    return this._dictionary._keyList.Count;
                }
            }

            Boolean ICollection<TKey>.IsReadOnly
            {
                get
                {
                    return true;
                }
            }

            public Int32 IndexOf(TKey item)
            {
                return this._dictionary._keyList.IndexOf(item);
            }

            void IList<TKey>.Insert(Int32 index, TKey item)
            {
                throw new NotSupportedException("This list is read-only.");
            }

            void IList<TKey>.RemoveAt(Int32 index)
            {
                throw new NotSupportedException("This list is read-only.");
            }

            TKey IList<TKey>.this[Int32 index]
            {
                get
                {
                    return this[index];
                }
                set
                {
                    throw new NotSupportedException("This list is read-only.");
                }
            }

            public TKey this[Int32 index]
            {
                get
                {
                    return this._dictionary._keyList[index];
                }
            }

            public KeyList(HybridDictionary<TKey, TValue> dictionary)
            {
                this._dictionary = dictionary;
            }
        }
    }
}