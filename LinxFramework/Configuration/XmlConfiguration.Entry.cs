// -*- mode: csharp; encoding: utf-8; tab-width: 4; c-basic-offset: 4; indent-tabs-mode: nil; -*-
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
// $Id: a7db7754a428ebb526d000b64ab4e48866a29032 $
/* LinxFramework
 *   Practical class library based on Linx Core Library
 *   Part of Linx
 * Linx
 *   Library that Integrates .NET with eXtremes
 * Copyright c 2008-2009 Takeshi KIRIYA, XSpect Project <takeshik@users.sf.net>
 * All rights reserved.
 * 
 * This file is part of LinxFramework.
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
using System.Collections.ObjectModel;
using System.Linq;
using Achiral;
using Achiral.Extension;
using XSpect;
using XSpect.Extension;

namespace XSpect.Configuration
{
    partial class XmlConfiguration
    {
        public abstract class Entry
            : Object,
              IEquatable<Entry>
        {
            private static readonly Type _entryType = typeof(Entry<>);

            private String _name;

            private String _description;

            public XmlConfiguration Parent
            {
                get;
                protected set;
            }

            public String Key
            {
                get;
                set;
            }

            public String Name
            {
                get
                {
                    if (this.IsNameDefined)
                    {
                        return this._name;
                    }
                    else
                    {
                        return this.Parent
                            .GetHierarchy(this.Key)
                            .ElementAtOrDefault(1)
                            .Null(e => e.Name);
                    }
                }
                set
                {
                    this.IsNameDefined = value != null;
                    this._name = value;
                }
            }

            public Boolean IsNameDefined
            {
                get
                {
                    return this._name != null;
                }
                set
                {
                    if (value)
                    {
                        this.Name = null;
                    }
                    else if (this._name == null)
                    {
                        this._name = String.Empty;
                    }
                }
            }

            public String Description
            {
                get
                {
                    if (this.IsDescriptionDefined)
                    {
                        return this._description;
                    }
                    else
                    {
                        return this.Parent
                            .GetHierarchy(this.Key)
                            .ElementAtOrDefault(1)
                            .Null(e => e.Description);
                    }
                }
                set
                {
                    this.IsDescriptionDefined = value != null;
                    this._description = value;
                }
            }

            public Boolean IsDescriptionDefined
            {
                get
                {
                    return this._description != null;
                }
                set
                {
                    if (value)
                    {
                        this.Description = null;
                    }
                    else if (this._description == null)
                    {
                        this._description = String.Empty;
                    }
                }
            }

            public abstract Object UntypedValue
            {
                get;
                set;
            }

            public Boolean IsValueDefined
            {
                get;
                set;
            }

            public abstract Type Type
            {
                get;
            }

            public override Boolean Equals(Object obj)
            {
                return obj is Entry && this.Equals(obj as Entry);
            }

            public override Int32 GetHashCode()
            {
                return unchecked
                    ((this.Parent != null ? Parent.GetHashCode() : 0) * 397) ^
                    (this.Key != null ? this.Key.GetHashCode() : 0);
            }

            public override String ToString()
            {
                return String.Format("{0} = {1} ({2}: {3})", this.Key, this.UntypedValue, this.Name ?? "(null)", this.Description ?? "(null)");
            }

            #region Implementation of IEquatable<Entry>

            public Boolean Equals(Entry other)
            {
                if (ReferenceEquals(null, other))
                {
                    return false;
                }
                if (ReferenceEquals(this, other))
                {
                    return true;
                }
                return this.Parent == other.Parent
                    && this.Key == other.Key;
            }

            #endregion

            public TReturn Get<TReturn>()
            {
                return (TReturn) this.UntypedValue;
            }

            public static Entry Create(XmlConfiguration parent, Type type, String key, Object value, String name, String description)
            {
                Entry entry = _entryType
                    .MakeGenericType(type)
                    .GetConstructor(Make.Array(typeof(XmlConfiguration)))
                    .Invoke(Make.Array(parent)) as Entry;
                entry.Key = key;
                entry.UntypedValue = value;
                entry.Name = name;
                entry.Description = description;
                return entry;
            }

            public static Entry Create(XmlConfiguration parent, Type type, String key, String name, String description)
            {
                Entry entry = _entryType
                    .MakeGenericType(type)
                    .GetConstructor(Make.Array(typeof(XmlConfiguration)))
                    .Invoke(Make.Array(parent)) as Entry;
                entry.Key = key;
                entry.IsValueDefined = false;
                entry.Name = name;
                entry.Description = description;
                return entry;
            }

            public static Entry Create(XmlConfiguration parent, Type type, String key, Object value)
            {
                return Create(parent, type, key, value, null, null);
            }

            public static Entry Create(XmlConfiguration parent, Type type, String key)
            {
                return Create(parent, type, key, null, null);
            }
        }

        public class Entry<T>
            : Entry
        {
            private T _value;

            public override Object UntypedValue
            {
                get
                {
                    return this.Value;
                }
                set
                {
                    this.Value = (T) value;
                }
            }

            public override Type Type
            {
                get
                {
                    return typeof(T);
                }
            }

            public T Value
            {
                get
                {
                    if (this.IsValueDefined)
                    {
                        return this._value;
                    }
                    else
                    {
                        return this.Parent
                            .GetHierarchy<T>(this.Key)
                            .ElementAtOrDefault(1)
                            .Null(e => e.Value);
                    }
                }
                set
                {
                    this.IsValueDefined = true;
                    this._value = value;
                }
            }

            public T Get()
            {
                return this.Value;
            }

            public Entry(XmlConfiguration parent)
            {
                this.Parent = parent;
            }

            public static explicit operator T(Entry<T> self)
            {
                return self.Value;
            }
        }
    }
}