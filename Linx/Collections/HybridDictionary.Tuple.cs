﻿// -*- mode: csharp; encoding: utf-8; tab-width: 4; c-basic-offset: 4; indent-tabs-mode: nil; -*-
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
// $Id: HybridDictionary.Tuple.cs 36029 2009-11-28 23:18:00Z takeshik $
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

namespace XSpect.Collections
{
    partial class HybridDictionary<TKey, TValue>
    {
        public struct Tuple
        {
            public Int32 Index
            {
                get;
                private set;
            }

            public TKey Key
            {
                get;
                private set;
            }

            public TValue Value
            {
                get;
                private set;
            }

            public Boolean IsKeyCompliant
            {
                get;
                private set;
            }

            public Tuple(Int32 index, TKey key, TValue value, Boolean isKeyCompliant)
                : this()
            {
                this.Index = index;
                this.Key = key;
                this.Value = value;
                this.IsKeyCompliant = isKeyCompliant;
            }

            public Tuple(Int32 index, KeyValuePair<TKey, TValue> pair, Boolean isKeyCompliant)
                : this(index, pair.Key, pair.Value, isKeyCompliant)
            {
            }
        }
    }
}