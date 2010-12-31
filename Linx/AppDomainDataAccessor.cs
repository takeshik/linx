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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Achiral;
using Achiral.Extension;

namespace XSpect
{
    [Serializable()]
    public sealed class AppDomainDataAccessor
        : MarshalByRefObject
    {
        private readonly String _prefix;

        public AppDomain Domain
        {
            get;
            private set;
        }

        public Boolean IsReadonly
        {
            get;
            private set;
        }

        public AppDomainDataAccessor(AppDomain domain, String prefix, Boolean isReadonly)
        {
            this.Domain = domain;
            this._prefix = prefix;
            this.IsReadonly = isReadonly;
        }

        public AppDomainDataAccessor(AppDomain domain, String prefix)
            : this(domain, prefix, false)
        {
        }

        public AppDomainDataAccessor(AppDomain domain)
            : this(domain, String.Empty)
        {
        }

        public Object this[String name]
        {
            get
            {
                return this.Domain.GetData(this._prefix + name);
            }
            set
            {
                this.CheckIfReadonly();
                this.Domain.SetData(this._prefix + name, value);
            }
        }

        public T Get<T>(String name)
        {
            return (T) this.Domain.GetData(this._prefix + name);
        }

        public void Set<T>(String name, T data)
        {
            this.CheckIfReadonly();
            this.Domain.SetData(this._prefix + name, data);
        }

        public Boolean Contains(String name)
        {
            return this[this._prefix + name] != null;
        }

        public void Remove(String name)
        {
            this.CheckIfReadonly();
            this[this._prefix + name] = null;
        }

        private void CheckIfReadonly()
        {
            if (this.IsReadonly)
            {
                throw new InvalidOperationException("This accessor cannot set data.");
            }
        }
    }
}