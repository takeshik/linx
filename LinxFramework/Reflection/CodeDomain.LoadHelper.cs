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
using System.Reflection;

namespace XSpect.Reflection
{
    partial class CodeDomain
    {
        [Serializable()]
        protected sealed class LoadHelper
            : MarshalByRefObject
        {
            private enum ArgumentType
            {
                Unknown = 0,
                AssemblyName = 1,
                String = 2,
                ByteArray = 3,
                ByteArrayByteArray = 4,
            }

            private readonly AppDomain _domain;

            private readonly ArgumentType _argumentType;

            private readonly AssemblyName _assemblyRef;

            private readonly String _assemblyStringOrFile;

            private readonly Byte[] _rawAssembly;

            private readonly Byte[] _rawSymbolStore;

            private Assembly _assembly;

            private LoadHelper(AppDomain domain)
            {
                this._domain = domain;
            }

            internal LoadHelper(AppDomain domain, AssemblyName assemblyRef)
                : this(domain)
            {
                this._argumentType = ArgumentType.AssemblyName;
                this._assemblyRef = assemblyRef;
            }

            internal LoadHelper(AppDomain domain, String assemblyStringOrFile)
                : this(domain)
            {
                this._argumentType = ArgumentType.String;
                this._assemblyStringOrFile = assemblyStringOrFile;
            }

            internal LoadHelper(AppDomain domain, Byte[] rawAssembly)
                : this(domain)
            {
                this._argumentType = ArgumentType.ByteArray;
                this._rawAssembly = rawAssembly;
            }

            internal LoadHelper(AppDomain domain, Byte[] rawAssembly, Byte[] rawSymbolStore)
                : this(domain)
            {
                this._argumentType = ArgumentType.ByteArrayByteArray;
                this._rawAssembly = rawAssembly;
                this._rawSymbolStore = rawSymbolStore;
            }

            public Assembly Load()
            {
                switch (this._argumentType)
                {
                    case ArgumentType.AssemblyName:
                        this._domain.DoCallBack(() =>
                            this._assembly = Assembly.Load(this._assemblyRef));
                        break;
                    case ArgumentType.String:
                        this._domain.DoCallBack(() =>
                            this._assembly = Assembly.Load(this._assemblyStringOrFile));
                        break;
                    case ArgumentType.ByteArray:
                        this._domain.DoCallBack(() =>
                            this._assembly = Assembly.Load(this._rawAssembly));
                        break;
                    case ArgumentType.ByteArrayByteArray:
                        this._domain.DoCallBack(() =>
                            this._assembly = Assembly.Load(this._rawAssembly, this._rawSymbolStore));
                        break;
                }
                return this._assembly;
            }

            public Assembly LoadFile()
            {
                this._domain.DoCallBack(() =>
                    this._assembly = Assembly.LoadFile(this._assemblyStringOrFile));
                return this._assembly;
            }

            public Assembly LoadFrom()
            {
                this._domain.DoCallBack(() =>
                    this._assembly = Assembly.LoadFrom(this._assemblyStringOrFile));
                return this._assembly;
            }
        }
    }
}