// -*- mode: csharp; encoding: utf-8; tab-width: 4; c-basic-offset: 4; indent-tabs-mode: nil; -*-
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
// $Id: a7db7754a428ebb526d000b64ab4e48866a29032 $
/* LinxFramework
 *   Practical class library based on Linx Core Library
 *   Part of Linx
 * Linx
 *   Library that Integrates .NET with eXtremes
 * Copyright © 2008-2010 Takeshi KIRIYA (aka takeshik) <takeshik@users.sf.net>
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

namespace XSpect.Reflection
{
    partial class CodeDomain
    {
        [Serializable()]
        public delegate T Callback<T>();

        [Serializable()]
        public delegate T ParameterizedCallback<T>(AppDomainDataAccessor data);

        [Serializable()]
        public delegate void Callback();

        [Serializable()]
        public delegate void ParameterizedCallback(AppDomainDataAccessor data);

        [Serializable()]
        public class DoCallbackHelper
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
                    return "<CodeDomain+DoCallbackHelper.LockObject>_" + this.Prefix;
                }
            }

            protected String ArgumentDataPrefix
            {
                get
                {
                    return "<CodeDomain+DoCallbackHelper.Arguments>_" + this.Prefix + ":";
                }
            }

            protected Delegate CallbackDelegate
            {
                get;
                private set;
            }

            protected IDictionary<String, Object> Arguments
            {
                get;
                private set;
            }

            protected DoCallbackHelper(AppDomain domain, Delegate callback, IDictionary<String, Object> arguments)
            {
                this.Domain = domain;
                this.CallbackDelegate = callback;
                this.Arguments = arguments;
            }

            public DoCallbackHelper(AppDomain domain, Callback callback)
                : this(domain, callback, null)
            {
            }

            public DoCallbackHelper(AppDomain domain, ParameterizedCallback callback, IDictionary<String, Object> arguments)
                : this(domain, (Delegate) callback, arguments)
            {
                this.SetPrefix();
            }

            public void DoCallback()
            {
                if (this.Arguments != null)
                {
                    this.Wind();
                    this.Domain.DoCallBack(() =>
                        ((ParameterizedCallback) this.CallbackDelegate)(new AppDomainDataAccessor(this.Domain, this.ArgumentDataPrefix, true))
                    );
                    this.Unwind();
                }
                else
                {
                    this.Domain.DoCallBack(() => ((Callback) this.CallbackDelegate)());
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
        public class DoCallbackHelper<T>
            : DoCallbackHelper
        {
            protected String ReturnValueDataPrefix
            {
                get
                {
                    return "<CodeDomain+DoCallbackHelper.ReturnValue>_" + this.Prefix;
                }
            }

            public DoCallbackHelper(AppDomain domain, Callback<T> callback)
                : base(domain, callback, null)
            {
                this.SetPrefix();
            }

            public DoCallbackHelper(AppDomain domain, ParameterizedCallback<T> callback, IDictionary<String, Object> arguments)
                : base(domain, callback, arguments)
            {
                this.SetPrefix();
            }

            public new T DoCallback()
            {
                if (this.Arguments != null)
                {
                    this.Wind();
                    this.Domain.DoCallBack(() => AppDomain.CurrentDomain.SetData(
                        this.ReturnValueDataPrefix,
                        ((ParameterizedCallback<T>) this.CallbackDelegate)(new AppDomainDataAccessor(this.Domain, this.ArgumentDataPrefix, true))
                    ));
                    this.Unwind();
                }
                else
                {
                    this.Domain.DoCallBack(() => AppDomain.CurrentDomain.SetData(
                        this.ReturnValueDataPrefix,
                        ((Callback<T>) this.CallbackDelegate)()
                    ));
                }
                T value = (T) this.Domain.GetData(this.ReturnValueDataPrefix);
                this.Domain.SetData(this.ReturnValueDataPrefix, null);
                return value;
            }
        }
    }
}