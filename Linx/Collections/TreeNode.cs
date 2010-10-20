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
using Achiral.Extension;
using XSpect.Extension;

namespace XSpect.Collections
{
    public class TreeNode<TKey, TValue>
    {
        public TreeNode<TKey, TValue> Parent
        {
            get;
            private set;
        }

        public Int32 Index
        {
            get
            {
                return this.Parent.Children.IndexOfValue(this);
            }
        }

        public TKey Key
        {
            get;
            private set;
        }

        public TValue Value
        {
            get;
            set;
        }

        public Int32 Depth
        {
            get
            {
                return this.Parent != null
                    ? this.Parent.Depth + 1
                    : 0;
            }
        }

        public IEnumerable<TKey> Path
        {
            get
            {
                foreach (TKey keys in this.Parent.Path)
                {
                    yield return keys;
                }
                yield return this.Key;
            }
        }

        public String PathString
        {
            get
            {
                return "/" + this.Path.Select(k => k.ToString()).Join("/");
            }
        }

        public IEnumerable<Int32> IndexPath
        {
            get
            {
                foreach (Int32 index in this.Parent.IndexPath)
                {
                    yield return index;
                }
                yield return this.Index;
            }
        }

        public String IndexPathString
        {
            get
            {
                return ":" + this.IndexPath.Select(i => i.ToString()).Join(":");
            }
        }

        public HybridDictionary<TKey, TreeNode<TKey, TValue>> Children
        {
            get;
            private set;
        }

        public TreeNode<TKey, TValue> this[TKey key]
        {
            get
            {
                return this.Children[key];
            }
            set
            {
                this.Children[key] = value;
            }
        }

        public TreeNode<TKey, TValue> this[Int32 index]
        {
            get
            {
                return this.Children[index].Value;
            }
        }

        public TreeNode(TreeNode<TKey, TValue> parent, TKey key, TValue value, IEnumerable<TreeNode<TKey, TValue>> children)
            : this(parent, key, value, new HybridDictionary<TKey, TreeNode<TKey, TValue>>(
                  parent.Children.KeySelector,
                  parent.Children.IsKeySelectorEnforced
              ).Apply(c => c.AddRange(children)))
        {
        }

        public TreeNode(TKey key, TValue value, HybridDictionary<TKey, TreeNode<TKey, TValue>> children)
            : this(null, key, value, children)
        {
        }

        private TreeNode(TreeNode<TKey, TValue> parent, TKey key, TValue value, HybridDictionary<TKey, TreeNode<TKey, TValue>> children)
        {
            this.Parent = parent;
            this.Key = key;
            this.Value = value;
            this.Children = children;
        }
    }
}