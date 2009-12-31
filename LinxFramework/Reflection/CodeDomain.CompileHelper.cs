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
        protected class CompileHelper
            : MarshalByRefObject
        {
            private readonly AppDomain _domain;

            private readonly CodeDomProvider _provider;

            private readonly CompilerParameters _parameters;

            private readonly String[] _sources;

            private CompilerResults _results;

            internal CompileHelper(
                AppDomain domain,
                CodeDomProvider provider,
                CompilerParameters parameters,
                params String[] sources
            )
            {
                this._domain = domain;
                this._provider = provider;
                this._parameters = parameters;
                this._sources = sources;
            }

            public Assembly Compile()
            {
                this._domain.DoCallBack(() =>
                {
                    this._results = this._provider.CompileAssemblyFromSource(this._parameters, this._sources);
                });
                if (this._results.Errors.HasErrors)
                {
                    String message = String.Empty;
                    foreach (CompilerError error in this._results.Errors)
                    {
                        message += String.Format(
                            "{0} ({1}, {2}) {3}: {4}{5}",
                            error.FileName,
                            error.Line,
                            error.Column,
                            error.ErrorNumber,
                            error.ErrorText,
                            Environment.NewLine
                        );
                    }
                    throw new InvalidOperationException(message);
                }
                this._results.TempFiles.Delete();
                return this._results.CompiledAssembly;
            }
        }
    }
}