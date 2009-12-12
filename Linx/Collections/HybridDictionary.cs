// -*- mode: csharp; encoding: utf-8; tab-width: 4; c-basic-offset: 4; indent-tabs-mode: nil; -*-
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
// $Id$
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
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Achiral;
using Achiral.Extension;
using XSpect.Extension;

namespace XSpect.Collections
{
    [Serializable()]
    public partial class HybridDictionary<TKey, TValue>
        : IDictionary<TKey, TValue>,
          IList<KeyValuePair<TKey, TValue>>
    {
        private Dictionary<TKey, TValue> _dictionary;

        private List<TKey> _keyList;

        #region Interface Implementations

        public TValue this[TKey key]
        {
            get
            {
                return this._dictionary[key];
            }
            set
            {
                this.SetItems(
                    Make.Sequence(this._keyList.IndexOf(key)),
                    Make.Sequence(key),
                    Make.Sequence(value)
                );
            }
        }
        public KeyValuePair<TKey, TValue> this[Int32 index]
        {
            get
            {
                TKey key = this._keyList[index];
                return new KeyValuePair<TKey, TValue>(key, this._dictionary[key]);
            }
            set
            {
                this.SetItems(
                    Make.Sequence(index),
                    Make.Sequence(value.Key),
                    Make.Sequence(value.Value)
                );
            }
        }

        public Int32 Count
        {
            get
            {
                return this._keyList.Count;
            }
        }

        public Boolean IsReadOnly
        {
            get
            {
                return (this._keyList as IList<TKey>).IsReadOnly;
            }
        }

        ICollection<TKey> IDictionary<TKey, TValue>.Keys
        {
            get
            {
                return this.Keys;
            }
        }

        ICollection<TValue> IDictionary<TKey, TValue>.Values
        {
            get
            {
                return this.Values;
            }
        }

        public void Add(TKey key, TValue value)
        {
            this.InsertItems(
                Make.Sequence(this._keyList.Count),
                Make.Sequence(key),
                Make.Sequence(value)
            );
        }
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            this.InsertItems(
                Make.Sequence(this._keyList.Count),
                Make.Sequence(item.Key),
                Make.Sequence(item.Value)
            );
        }
        public void Add(TValue item)
        {
            this.InsertItems(
                Make.Sequence(this._keyList.Count),
                Make.Sequence(item)
            );
        }

        public void Clear()
        {
            this.ClearDictionary();
        }

        public Boolean Contains(KeyValuePair<TKey, TValue> item)
        {
            return this._dictionary.Contains(item);
        }

        public Boolean ContainsKey(TKey key)
        {
            return this._keyList.Contains(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, Int32 arrayIndex)
        {
            (this as IList<KeyValuePair<TKey, TValue>>).CopyTo(array, arrayIndex);
        }
        public void CopyTo(TValue[] array, Int32 arrayIndex)
        {
            this.Values.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return this._keyList.Select(k => new KeyValuePair<TKey, TValue>(k, this._dictionary[k]))
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Int32 IndexOf(KeyValuePair<TKey, TValue> item)
        {
            return this._keyList.IndexOf(item.Key);
        }

        public void Insert(Int32 index, KeyValuePair<TKey, TValue> item)
        {
            this.InsertItems(
                Make.Sequence(index),
                Make.Sequence(item.Key),
                Make.Sequence(item.Value)
            );
        }
        public void Insert(Int32 index, TValue item)
        {
            this.InsertItems(
                Make.Sequence(index),
                Make.Sequence(item)
            );
        }

        public Boolean Remove(TKey key)
        {
            return this.RemoveItems(Make.Sequence(this._keyList.IndexOf(key)))
                .Single();
        }
        public Boolean Remove(KeyValuePair<TKey, TValue> item)
        {
            return this.RemoveItems(Make.Sequence(this.Keys.IndexOf(item.Key)))
                .Single();
        }
        public Boolean Remove(TValue item)
        {
            return this.RemoveItems(Make.Sequence(this.Values.IndexOf(item)))
                .Single();
        }

        public void RemoveAt(Int32 index)
        {
            this.RemoveItems(Make.Sequence(index));
        }

        public Boolean TryGetValue(TKey key, out TValue value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        #endregion

        public event EventHandler<NotifyDictionaryChangedEventArgs<TKey, TValue>> ItemsAdded;

        public event EventHandler<NotifyDictionaryChangedEventArgs<TKey, TValue>> ItemsMoved;

        public event EventHandler<NotifyDictionaryChangedEventArgs<TKey, TValue>> ItemsRemoved;

        public event EventHandler<NotifyDictionaryChangedEventArgs<TKey, TValue>> ItemsReplaced;

        public event EventHandler<NotifyDictionaryChangedEventArgs<TKey, TValue>> ItemsReset;

        public Func<Int32, TValue, TKey> KeySelector
        {
            get;
            private set;
        }

        public Boolean IsKeySelectorEnforced
        {
            get;
            private set;
        }

        public IList<TKey> Keys
        {
            get
            {
                return this._keyList.AsReadOnly();
            }
        }

        public IList<TValue> Values
        {
            get
            {
                return this._keyList
                    .Select(k => this._dictionary[k])
                    .ToList()
                    .AsReadOnly();
            }
        }

        public HybridDictionary()
            : this(null, false)
        {
        }

        public HybridDictionary(Func<Int32, TValue, TKey> selector)
            : this(selector, true)
        {
        }

        public HybridDictionary(Func<Int32, TValue, TKey> selector, Boolean forced)
        {
            this.KeySelector = selector;
            this.IsKeySelectorEnforced = forced;
            this._dictionary = new Dictionary<TKey, TValue>();
            this._keyList = new List<TKey>();
        }

        public void AddRange(IEnumerable<TKey> keys, IEnumerable<TValue> values)
        {
            this.InsertItems(
                Make.Repeat(this._keyList.Count),
                keys,
                values
            );
        }

        public void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
        {
            this.InsertItems(
                Make.Repeat(this._keyList.Count),
                pairs.Select(p => p.Key),
                pairs.Select(p => p.Value)
            );
        }

        public void AddRange(IEnumerable<TValue> values)
        {
            this.InsertItems(
                Make.Sequence(this._keyList.Count),
                values
            );
        }

        public Boolean ContainsValue(TValue value)
        {
            return this._dictionary.ContainsValue(value);
        }

        public Int32 KeyIndexOf(TKey key)
        {
            return this.Keys.IndexOf(key);
        }

        public Int32 ValueIndexOf(TValue value)
        {
            return this.Values.IndexOf(value);
        }

        // TODO: IndexOf methods etc.

        public void Insert(Int32 index, TKey key, TValue value)
        {
            this.InsertItems(
                Make.Sequence(index),
                Make.Sequence(key),
                Make.Sequence(value)
            );
        }

        public void InsertRange(IEnumerable<Int32> indexes, IEnumerable<TKey> keys, IEnumerable<TValue> values)
        {
            this.InsertItems(
                indexes,
                keys,
                values
            );
        }

        public void InsertRange(IEnumerable<Int32> indexes, IEnumerable<KeyValuePair<TKey, TValue>> pairs)
        {
            this.InsertItems(
                indexes,
                pairs.Select(p => p.Key),
                pairs.Select(p => p.Value)
            );
        }

        public void InsertRange(IEnumerable<Int32> indexes, IEnumerable<TValue> values)
        {
            this.InsertItems(
                indexes,
                values
            );
        }

        public Boolean IsKeyCompliant(Int32 index)
        {
            TKey key;
            return this.KeySelector(index, this._dictionary[key = this._keyList[index]]).Equals(key);
        }

        public IEnumerable<Boolean> RemoveRange(IEnumerable<Int32> indexes)
        {
            return this.RemoveItems(indexes);
        }

        public IEnumerable<Boolean> RemoveRange(Int32 index, Int32 count)
        {
            return this.RemoveRange(Enumerable.Range(index, count));
        }

        public IEnumerable<Boolean> RemoveRange(IEnumerable<TKey> keys)
        {
            return this.RemoveRange(keys.Select(k => this.KeyIndexOf(k)));
        }

        protected virtual void ClearDictionary()
        {
            this._keyList.Clear();
            this._dictionary.Clear();
            this.OnItemsReset();
        }

        protected void InsertItems(IEnumerable<Int32> indexes, IEnumerable<TKey> keys, IEnumerable<TValue> values)
        {
            this.InsertItems(indexes, keys, values, false);
        }

        protected void InsertItems(IEnumerable<Int32> indexes, IEnumerable<TValue> values)
        {
            this.InsertItems(indexes, indexes.ZipWith(values, (i, v) => this.KeySelector(i, v)), values, true);
        }

        protected virtual void InsertItems(IEnumerable<Int32> indexes, IEnumerable<TKey> keys, IEnumerable<TValue> values, Boolean ensureKeysCompliant)
        {
            IEnumerable<Tuple> elements = indexes.ZipWith(
                keys,
                values,
                ensureKeysCompliant || this.KeySelector == null
                    ? Make.Repeat(true)
                    : indexes.ZipWith(
                          keys,
                          values,
                          (i_, k_, v_) => this.KeySelector(i_, v_).Equals(k_)
                      ),
                (i, k, v, c) => new Tuple(i, k, v, c)
            );
            List<Int32> insertedIndexes = new List<Int32>();
            foreach (Tuple e in elements)
            {
                this._dictionary.Add(e.Key, e.Value);
                this._keyList.Insert(e.Index + insertedIndexes.Count(i => i >= e.Index), e.Key);
                insertedIndexes.Add(e.Index);
            }
            this.OnItemsAdded(elements);
        }

        protected virtual IEnumerable<Boolean> RemoveItems(IEnumerable<Int32> indexes)
        {
            IEnumerable<Tuple> elements = indexes.Select(i => new Tuple(i, this[i], this.IsKeyCompliant(i)));
            List<Int32> removedIndexes = new List<Int32>();
            IEnumerable<Boolean> ret = elements.Select(e =>
            {
                this._keyList.RemoveAt(e.Index - removedIndexes.Count(i => i <= e.Index));
                Boolean r = this._dictionary.Remove(e.Key);
                removedIndexes.Add(e.Index);
                return r;
            });
            this.OnItemsRemoved(elements);
            return ret;
        }

        protected virtual void SetItems(IEnumerable<Int32> indexes, IEnumerable<TKey> keys, IEnumerable<TValue> values)
        {
            IEnumerable<Tuple> elements = indexes.ZipWith(
                keys,
                values,
                this.KeySelector == null
                    ? Make.Repeat(true)
                    : indexes.ZipWith(
                          keys,
                          values,
                          (i_, k_, v_) => this.KeySelector(i_, v_).Equals(k_)
                      ),
                (i, k, v, c) => new Tuple(i, k, v, c)
            );
            foreach (Tuple e in elements)
            {
                if (this._keyList[e.Index].Equals(e.Key))
                {
                    this._dictionary[e.Key] = e.Value;
                }
                else
                {
                    this._dictionary.Remove(e.Key);
                    this._keyList[e.Index] = e.Key;
                    this._dictionary.Add(e.Key, e.Value);
                }
                this.OnItemsReplaced(elements, indexes.Select(i => new Tuple(i, this[i], this.IsKeyCompliant(i))));
            }
        }

        private void OnItemsAdded(IEnumerable<Tuple> addedElements)
        {
            this.ItemsAdded(this, new NotifyDictionaryChangedEventArgs<TKey, TValue>(Enumerable.Empty<Tuple>(), addedElements));
        }

        // When OnItemsMoved is used?

        private void OnItemsMoved(IEnumerable<Tuple> oldElements, IEnumerable<Tuple> newElements)
        {
            this.ItemsMoved(this, new NotifyDictionaryChangedEventArgs<TKey, TValue>(oldElements, newElements));
        }

        private void OnItemsRemoved(IEnumerable<Tuple> removedElements)
        {
            this.ItemsRemoved(this, new NotifyDictionaryChangedEventArgs<TKey,TValue>(removedElements, Enumerable.Empty<Tuple>()));
        }

        private void OnItemsReplaced(IEnumerable<Tuple> oldElements, IEnumerable<Tuple> newElements)
        {
            this.ItemsReplaced(this, new NotifyDictionaryChangedEventArgs<TKey, TValue>(oldElements, newElements));
        }

        private void OnItemsReset()
        {
            this.ItemsReset(this, new NotifyDictionaryChangedEventArgs<TKey, TValue>(Enumerable.Empty<Tuple>(), Enumerable.Empty<Tuple>()));
        }
    }
}