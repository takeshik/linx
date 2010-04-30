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
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace XSpect.Reflection
{
    partial class CodeDomain
    {
        [Serializable()]
        public delegate T Callback<T>();

        [Serializable()]
        public delegate T ParameterizedCallback<T>(Object argument);

        [Serializable()]
        public delegate void Callback();

        [Serializable()]
        public delegate void ParameterizedCallback(Object argument);

        [Serializable()]
        protected sealed class DoCallbackHelper<T>
            : Object
        {
            private readonly AppDomain _domain;

            private readonly Callback<T> _callback;

            private readonly ParameterizedCallback<T> _parameterizedCallback;

            private readonly Object _argument;

            private T _returnValue;

            public DoCallbackHelper(AppDomain domain, Callback<T> callback)
            {
                this._domain = domain;
                this._callback = callback;
            }

            public DoCallbackHelper(AppDomain domain, ParameterizedCallback<T> callback, Object argument)
            {
                this._domain = domain;
                this._parameterizedCallback = callback;
                this._argument = argument;
            }

            public T DoCallback()
            {
                this._domain.DoCallBack(this._callback != null
                    ? (CrossAppDomainDelegate) (() => this._returnValue = this._callback())
                    : () => this._returnValue = this._parameterizedCallback(this._argument)
                );
                return this._returnValue;
            }
        }

        [Serializable()]
        protected sealed class DoCallbackHelper
            : Object
        {
            private readonly AppDomain _domain;

            private readonly Callback _callback;

            private readonly ParameterizedCallback _parameterizedCallback;

            private readonly Object _argument;

            public DoCallbackHelper(AppDomain domain, Callback callback)
            {
                this._domain = domain;
                this._callback = callback;
            }

            public DoCallbackHelper(AppDomain domain, ParameterizedCallback callback, Object argument)
            {
                this._domain = domain;
                this._parameterizedCallback = callback;
                this._argument = argument;
            }

            public void DoCallback()
            {
                this._domain.DoCallBack(this._callback != null
                    ? (CrossAppDomainDelegate) (() => this._callback())
                    : () => this._parameterizedCallback(this._argument)
                );
            }
        }
    }
}