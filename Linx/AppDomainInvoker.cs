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

namespace XSpect
{
    [Serializable()]
    public delegate void CrossAppDomainInvoker();

    [Serializable()]
    public delegate void ParameterizedCrossAppDomainInvoker(AppDomainDataAccessor data);

    [Serializable()]
    public delegate T CrossAppDomainInvoker<out T>();

    [Serializable()]
    public delegate T ParameterizedCrossAppDomainInvoker<out T>(AppDomainDataAccessor data);

    [Serializable()]
    public class AppDomainInvoker
        : Object
    {
        protected AppDomain Domain
        {
            get;
            private set;
        }

        protected String Prefix
        {
            get;
            set;
        }

        protected String LockObjectDataPrefix
        {
            get
            {
                return "<AppDomainInvoker.LockObject>_" + this.Prefix;
            }
        }

        protected String ArgumentDataPrefix
        {
            get
            {
                return "<AppDomainInvoker.Arguments>_" + this.Prefix + ":";
            }
        }

        protected Delegate InvokingDelegate
        {
            get;
            private set;
        }

        protected IDictionary<String, Object> Arguments
        {
            get;
            private set;
        }

        protected AppDomainInvoker(AppDomain domain, Delegate invoker, IDictionary<String, Object> arguments)
        {
            this.Domain = domain;
            this.InvokingDelegate = invoker;
            this.Arguments = arguments;
        }

        public AppDomainInvoker(AppDomain domain, CrossAppDomainInvoker callback)
            : this(domain, callback, null)
        {
        }

        public AppDomainInvoker(AppDomain domain, ParameterizedCrossAppDomainInvoker callback, IDictionary<String, Object> arguments)
            : this(domain, (Delegate) callback, arguments)
        {
            this.SetPrefix();
        }

        public void Invoke()
        {
            if (this.Arguments != null)
            {
                this.Wind();
                this.Domain.DoCallBack(() =>
                    ((ParameterizedCrossAppDomainInvoker) this.InvokingDelegate)(new AppDomainDataAccessor(this.Domain, this.ArgumentDataPrefix, true))
                );
                this.Unwind();
            }
            else
            {
                this.Domain.DoCallBack(() => ((CrossAppDomainInvoker) this.InvokingDelegate)());
            }
        }

        protected void SetPrefix()
        {
            this.Prefix = String.Empty;
            do
            {
                this.Prefix = DateTime.UtcNow.Ticks + "-" + Guid.NewGuid().ToString("N");
            } while (this.Domain.GetData(this.LockObjectDataPrefix) != null);
            this.Domain.SetData(this.LockObjectDataPrefix, new Object());
        }

        protected void Wind()
        {
            foreach (KeyValuePair<String, Object> p in this.Arguments)
            {
                this.Domain.SetData(this.ArgumentDataPrefix + p.Key, p.Value);
            }
        }

        protected void Unwind()
        {
            foreach (KeyValuePair<String, Object> p in this.Arguments)
            {
                this.Domain.SetData(this.ArgumentDataPrefix + p.Key, null);
            }
        }
    }

    [Serializable()]
    public class AppDomainInvoker<T>
        : AppDomainInvoker
    {
        protected String ReturnValueDataPrefix
        {
            get
            {
                return "<AppDomainInvoker.ReturnValue>_" + this.Prefix;
            }
        }

        public AppDomainInvoker(AppDomain domain, CrossAppDomainInvoker<T> callback)
            : base(domain, callback, null)
        {
            this.SetPrefix();
        }

        public AppDomainInvoker(AppDomain domain, ParameterizedCrossAppDomainInvoker<T> callback, IDictionary<String, Object> arguments)
            : base(domain, callback, arguments)
        {
            this.SetPrefix();
        }

        public new T Invoke()
        {
            if (this.Arguments != null)
            {
                this.Wind();
                this.Domain.DoCallBack(() => AppDomain.CurrentDomain.SetData(
                    this.ReturnValueDataPrefix,
                    ((ParameterizedCrossAppDomainInvoker<T>) this.InvokingDelegate)(new AppDomainDataAccessor(this.Domain, this.ArgumentDataPrefix, true))
                ));
                this.Unwind();
            }
            else
            {
                this.Domain.DoCallBack(() => AppDomain.CurrentDomain.SetData(
                    this.ReturnValueDataPrefix,
                    ((CrossAppDomainInvoker<T>) this.InvokingDelegate)()
                ));
            }
            T value = (T) this.Domain.GetData(this.ReturnValueDataPrefix);
            this.Domain.SetData(this.ReturnValueDataPrefix, null);
            return value;
        }
    }
}