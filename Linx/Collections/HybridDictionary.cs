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
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Achiral;
using Achiral.Extension;
using XSpect.Extension;
using XSpect.Codecs;

namespace XSpect.Collections
{
    [Serializable()]
    public partial class HybridDictionary<TKey, TValue>
        : IDictionary<TKey, TValue>,
          IList<KeyValuePair<TKey, TValue>>,
          INotifyPropertyChanged,
          IXmlSerializable
    {
        private readonly Dictionary<TKey, TValue> _dictionary;

        private readonly List<TKey> _keyList;

        private Boolean _isKeySelectorEnforced;

        #region Interface Implementations

        public event PropertyChangedEventHandler PropertyChanged;

        public TValue this[TKey key]
        {
            get
            {
                return this._dictionary[key];
            }
            set
            {
                this.SetItems(
                    this._keyList.IndexOf(key).ToEnumerable(),
                    key.ToEnumerable(),
                    value.ToEnumerable()
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
                    index.ToEnumerable(),
                    value.Key.ToEnumerable(),
                    value.Value.ToEnumerable()
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
                this._keyList.Count.ToEnumerable(),
                key.ToEnumerable(),
                value.ToEnumerable()
            );
        }
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            this.InsertItems(
                this._keyList.Count.ToEnumerable(),
                item.Key.ToEnumerable(),
                item.Value.ToEnumerable()
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
                index.ToEnumerable(),
                item.Key.ToEnumerable(),
                item.Value.ToEnumerable()
            );
        }

        public Boolean Remove(TKey key)
        {
            return this.RemoveItems(this._keyList.IndexOf(key).ToEnumerable())
                .Single();
        }
        public Boolean Remove(KeyValuePair<TKey, TValue> item)
        {
            return this.RemoveItems(this.Keys.IndexOf(item.Key).ToEnumerable())
                .Single();
        }

        public void RemoveAt(Int32 index)
        {
            this.RemoveItems(index.ToEnumerable());
        }

        public Boolean TryGetValue(TKey key, out TValue value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            new XmlSerializer(typeof(TKey)).Let(sk =>
                new XmlSerializer(typeof(TValue)).Let(sv =>
                    XDocument.Load(reader).Root
                        .Elements("pair")
                        .ForEach(xe => this.Add(
                            (TKey) xe.Element("key").Elements().Single().CreateReader()
                                .Dispose(r => (sk.Deserialize(r))),
                            (TValue) xe.Element("value").Elements().Single().CreateReader()
                                .Dispose(r => (sv.Deserialize(r)))
                        ))
                    )
                );
        }

        public void WriteXml(XmlWriter writer)
        {
            this.Select(p =>
                new XElement("pair",
                    new XElement("key", p.Key.XmlSerialize()),
                    new XElement("value", p.Value.XmlSerialize())
                )
            ).ForEach(xe => xe.WriteTo(writer));
        }

        #endregion

        public event EventHandler<NotifyDictionaryChangedEventArgs<TKey, TValue>> ItemsAdded;

        public event EventHandler<NotifyDictionaryChangedEventArgs<TKey, TValue>> ItemsMoved;

        public event EventHandler<NotifyDictionaryChangedEventArgs<TKey, TValue>> ItemsRemoved;

        public event EventHandler<NotifyDictionaryChangedEventArgs<TKey, TValue>> ItemsReplaced;

        public event EventHandler<NotifyDictionaryChangedEventArgs<TKey, TValue>> ItemsReset;

        public IEqualityComparer<TKey> Comparer
        {
            get;
            private set;
        }

        public Func<Int32, TValue, TKey> KeySelector
        {
            get;
            set;
        }

        public Boolean IsKeySelectorEnforced
        {
            get
            {
                return this._isKeySelectorEnforced;
            }
            set
            {
                if (value && !0.UpTo(this.Count - 1).All(this.IsKeyCompliant))
                {
                    throw new InvalidOperationException("Couldn't set to enforced mode because keys which is not valid with current key selector exists.");
                }
                this._isKeySelectorEnforced = value;
            }
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

        public IList<Tuple> Tuples
        {
            get
            {
                return this.Select((p, i) => new Tuple(i, p.Key, p.Value, this.IsKeyCompliant(i)))
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
            : this(selector, forced, EqualityComparer<TKey>.Default)
        {
        }

        public HybridDictionary(Func<Int32, TValue, TKey> selector, Boolean forced, IEqualityComparer<TKey> comparer)
        {
            this.KeySelector = selector;
            this._isKeySelectorEnforced = forced;
            this.Comparer = comparer;
            this._dictionary = new Dictionary<TKey, TValue>(this.Comparer);
            this._keyList = new List<TKey>();
        }

        public void Add(TValue item)
        {
            this.InsertItems(
                this._keyList.Count.ToEnumerable(),
                item.ToEnumerable()
            );
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
                this._keyList.Count.ToEnumerable(),
                values
            );
        }

        public Boolean Contains(TKey key, TValue value)
        {
            return this.Contains(new KeyValuePair<TKey, TValue>(key, value));
        }

        public Boolean ContainsValue(TValue value)
        {
            return this._dictionary.ContainsValue(value);
        }

        public void CopyToKeys(TKey[] array, Int32 arrayIndex)
        {
            this.Keys.CopyTo(array, arrayIndex);
        }

        public void CopyToValues(TValue[] array, Int32 arrayIndex)
        {
            this.Values.CopyTo(array, arrayIndex);
        }

        public IEnumerable<TKey> GetKeys(TValue value)
        {
            return this.GetKeys(value, EqualityComparer<TValue>.Default);
        }

        public IEnumerable<TKey> GetKeys(TValue value, IEqualityComparer<TValue> comparer)
        {
            return this.Where(p => comparer.Equals(value, p.Value)).Select(p => p.Key);
        }

        public TKey GetKey(TValue value)
        {
            return this.GetKeys(value).Single();
        }

        public TKey GetKey(TValue value, IEqualityComparer<TValue> comparer)
        {
            return this.GetKeys(value, comparer).Single();
        }

        public Int32 IndexOf(TKey key, TValue value)
        {
            return this.IndexOf(new KeyValuePair<TKey, TValue>(key, value));
        }

        public Int32 IndexOfKey(TKey key)
        {
            return this.Keys.IndexOf(key);
        }

        public Int32 IndexOfValue(TValue value)
        {
            return this.Values.IndexOf(value);
        }

        public void Insert(Int32 index, TValue item)
        {
            this.InsertItems(
                index.ToEnumerable(),
                item.ToEnumerable()
            );
        }

        public void Insert(Int32 index, TKey key, TValue value)
        {
            this.InsertItems(
                index.ToEnumerable(),
                key.ToEnumerable(),
                value.ToEnumerable()
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
            return this.KeySelector == null
                || this.KeySelector(index, this._dictionary[key = this._keyList[index]]).Equals(key);
        }

        public Boolean RemoveValue(TValue item)
        {
            return this.RemoveItems(this.Values.IndexOf(item).ToEnumerable())
                .Single();
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
            return this.RemoveRange(keys.Select(k => this.IndexOfKey(k)));
        }

        public Boolean TryGetKey(TValue value, out TKey key)
        {
            return this.TryGetKey(value, EqualityComparer<TValue>.Default, out key);
        }

        public Boolean TryGetKey(TValue value, IEqualityComparer<TValue> comparer, out TKey key)
        {
            IEnumerable<TKey> keys = this.GetKeys(value, comparer);
            return keys.Count() == 1
                ? (key = keys.Single()).True()
                : (key = default(TKey)).False();
        }

        public Boolean TryGetValue(Int32 index, out TValue value)
        {
            return this.Count < index
                ? (value = this[index].Value).True()
                : (value = default(TValue)).False();
        }

        public Boolean TryGetKeyValue(Int32 index, out Nullable<KeyValuePair<TKey, TValue>> value)
        {
            return this.Count < index
                ? (value = this[index]).True()
                : (value = null).False();
        }

        protected virtual void ClearDictionary()
        {
            IEnumerable<Tuple> list = this
                .Select((e, i) => new Tuple(i, e.Key, e.Value, this.IsKeyCompliant(i)))
                .ToList();
            this._keyList.Clear();
            this._dictionary.Clear();
            this.OnItemsReset(list);
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
            if (this.IsKeySelectorEnforced && elements.Any(t => !t.IsKeyCompliant))
            {
                throw new ArgumentException("Invalid (not compliant) key(s).", "keys");
            }
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
            IEnumerable<Tuple> elements = indexes
                .Select(i => new Tuple(i, this[i], this.IsKeyCompliant(i)))
                .ToList();
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
            IEnumerable<Tuple> elements = indexes
                .ZipWith(
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
                )
                .ToList();
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
                this.OnItemsReplaced(
                    elements,
                    indexes
                        .Select(i => new Tuple(i, this[i], this.IsKeyCompliant(i)))
                        .ToList()
                );
            }
        }

        protected virtual void OnItemsAdded(IEnumerable<Tuple> addedElements)
        {
            if (this.ItemsAdded != null)
            {
                this.ItemsAdded(this, new NotifyDictionaryChangedEventArgs<TKey, TValue>(Enumerable.Empty<Tuple>(), addedElements));
            }
            this.OnPropertyChanged("Count");
            this.OnPropertyChanged("Item[]");
        }

        // When OnItemsMoved is used?

        protected virtual void OnItemsMoved(IEnumerable<Tuple> oldElements, IEnumerable<Tuple> newElements)
        {
            if (this.ItemsMoved != null)
            {
                this.ItemsMoved(this, new NotifyDictionaryChangedEventArgs<TKey, TValue>(oldElements, newElements));
            }
            this.OnPropertyChanged("Item[]");
        }

        protected virtual void OnItemsRemoved(IEnumerable<Tuple> removedElements)
        {
            if (this.ItemsRemoved != null)
            {
                this.ItemsRemoved(this, new NotifyDictionaryChangedEventArgs<TKey, TValue>(removedElements, Enumerable.Empty<Tuple>()));
            }
            this.OnPropertyChanged("Count");
            this.OnPropertyChanged("Item[]");
        }

        protected virtual void OnItemsReplaced(IEnumerable<Tuple> oldElements, IEnumerable<Tuple> newElements)
        {
            if (this.ItemsReplaced != null)
            {
                this.ItemsReplaced(this, new NotifyDictionaryChangedEventArgs<TKey, TValue>(oldElements, newElements));
            }
            this.OnPropertyChanged("Item[]");
        }

        protected virtual void OnItemsReset(IEnumerable<Tuple> oldElements)
        {
            if (this.ItemsReset != null)
            {
                this.ItemsReset(this, new NotifyDictionaryChangedEventArgs<TKey, TValue>(oldElements, Enumerable.Empty<Tuple>()));
            }
            this.OnPropertyChanged("Count");
            this.OnPropertyChanged("Item[]");
        }

        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}