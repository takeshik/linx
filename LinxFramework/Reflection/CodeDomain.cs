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
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using Achiral;
using Achiral.Extension;
using XSpect;
using XSpect.Collections;
using XSpect.Extension;

namespace XSpect.Reflection
{
    [Serializable()]
    public partial class CodeDomain
        : MarshalByRefObject,
          IDisposable
    {
        private Boolean _disposed;

        private readonly HybridDictionary<AssemblyName, Assembly> _assemblies;

        public CodeManager Parent
        {
            get;
            private set;
        }

        public String Key
        {
            get;
            private set;
        }

        public AppDomain ApplicationDomain
        {
            get;
            private set;
        }

        public IEnumerable<Assembly> Assemblies
        {
            get
            {
                return this._assemblies.Values;
            }
        }

        public CodeDomain(CodeManager parent, String key, AppDomainSetup info)
        {
            this._assemblies = new HybridDictionary<AssemblyName, Assembly>((i, a) => a.GetName());
            this.Parent = parent;
            this.Key = key;
            this.ApplicationDomain = AppDomain.CreateDomain("CodeMgr." + key, null, info);
        }

        public CodeDomain(CodeManager parent, String key, IEnumerable<Action<AppDomainSetup>> infoInitializers)
            : this(
                  parent,
                  key,
                  new AppDomainSetup()
                  {
                      ApplicationName = "CodeManager." + key,
                      LoaderOptimization = LoaderOptimization.MultiDomainHost,
                  }.Let(info => infoInitializers.ForEach(f => f(info))))   
        {
        }

        public CodeDomain(CodeManager parent, String key, params Action<AppDomainSetup>[] infoInitializers)
            : this(parent, key, infoInitializers as IEnumerable<Action<AppDomainSetup>>)
        {
        }

        public CodeDomain(
            CodeManager parent,
            String key,
            String applicationBase,
            IEnumerable<String> privateBinPaths,
            IEnumerable<Action<AppDomainSetup>> infoInitializers
        )
            : this(parent, key, Make.Sequence<Action<AppDomainSetup>>(info =>
              {
                  info.ApplicationBase = applicationBase;
                  info.PrivateBinPath = privateBinPaths != null ? privateBinPaths.Join(";") : null;
                  info.PrivateBinPathProbe = "true";
              }).Concat(infoInitializers))
        {
        }

        public CodeDomain(
            CodeManager parent,
            String key,
            String applicationBase,
            IEnumerable<String> privateBinPaths,
            params Action<AppDomainSetup>[] infoInitializers
        )
            : this(parent, key, applicationBase, privateBinPaths, infoInitializers as IEnumerable<Action<AppDomainSetup>>)
        {
        }

        ~CodeDomain()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (!this._disposed)
            {
                AppDomain.Unload(this.ApplicationDomain);
            }
            this._disposed = true;
        }

        protected void CheckIfDisposed()
        {
            if (this._disposed)
            {
                throw new ObjectDisposedException(this.GetType().Name);
            }
        }

        private Assembly RegisterAssembly(Assembly assembly)
        {
            this._assemblies.Add(assembly);
            return assembly;
        }

        #region Load / LoadFile / LoadFrom

        public Assembly Load(AssemblyName assemblyRef)
        {
            this.CheckIfDisposed();
            return RegisterAssembly(
                new LoadHelper(this.ApplicationDomain, assemblyRef).Load()
            );
        }

        public Assembly Load(String assemblyString)
        {
            this.CheckIfDisposed();
            return RegisterAssembly(
                new LoadHelper(this.ApplicationDomain, assemblyString).Load()
            );
        }

        public Assembly Load(Byte[] rawAssembly)
        {
            this.CheckIfDisposed();
            return RegisterAssembly(
                new LoadHelper(this.ApplicationDomain, rawAssembly).Load()
            );
        }

        public Assembly Load(Byte[] rawAssembly, Byte[] rawSymbolStore)
        {
            this.CheckIfDisposed();
            return RegisterAssembly(
                new LoadHelper(this.ApplicationDomain, rawAssembly, rawSymbolStore).Load()
            );
        }

        public Assembly LoadFile(String path)
        {
            this.CheckIfDisposed();
            return RegisterAssembly(
                new LoadHelper(this.ApplicationDomain, path).LoadFile()
            );
        }

        public Assembly LoadFrom(String assemblyFile)
        {
            this.CheckIfDisposed();
            return RegisterAssembly(
                new LoadHelper(this.ApplicationDomain, assemblyFile).LoadFrom()
            );
        }

        #endregion

        #region Compile

        private Assembly Compile(LanguageSetting language, String source, Boolean generateInMemory)
        {
            this.CheckIfDisposed();
            return RegisterAssembly(new CompileHelper(
                this.ApplicationDomain,
                language.Type
                    .GetConstructor(Create.TypeArray<IDictionary<String, String>>())
                    .Invoke(Make.Array(language.Options)) as CodeDomProvider,
                new CompilerParameters(
                    this.ApplicationDomain.GetAssemblies()
                    .Select(a => a.GetName().FullName)
                    .ToArray()
                )
                {
                    GenerateInMemory = generateInMemory,
                },
                source
            ).Compile());
        }

        public Assembly Compile(LanguageSetting language, String source)
        {
            return this.Compile(language, source, false);
        }

        public Assembly Compile(String language, String source)
        {
            return this.Compile(this.Parent.GetLanguage(language), source);
        }

        public Assembly Compile(FileInfo file)
        {
            return this.Compile(file.Extension, file.ReadAllText());
        }

        public Assembly Compile(String file)
        {
            return this.Compile(new FileInfo(file));
        }

        #endregion

        #region Execute

        public T Execute<T>(
            LanguageSetting language,
            String source,
            IDictionary<String, Object> arguments
        )
        {
            this.CheckIfDisposed();
            return language.IsDynamicLanguage
                ? this.Parent.ScriptRuntime
                      .GetEngineByTypeName(language.Type.AssemblyQualifiedName)
                      .Do(e => e.CreateScriptSourceFromString(source, SourceCodeKind.File)
                          .Execute<T>(e.CreateScope()
                              .Let(s => arguments.ForEach(p => s.SetVariable(p.Key, p.Value)))
                          )
                      )
                : (T) this.Compile(language, source, true).GetTypes()
                      .SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.Static))
                      .Where(m => m.GetParameters()
                          .Select(p => p.ParameterType)
                          .SequenceEqual(typeof(IDictionary<String, Object>).ToEnumerable())
                      )
                      .SingleOrPredicatedSingle(m => m.Name == "Begin")
                      .Invoke(null, Make.Array(arguments));
        }

        public Object Execute(
            LanguageSetting language,
            String source,
            IDictionary<String, Object> arguments
        )
        {
            return this.Execute<Object>(language, source, arguments);
        }

        public T Execute<T>(
            String language,
            String source,
            IDictionary<String, Object> arguments
        )
        {
            return this.Execute<T>(this.Parent.GetLanguage(language), source, arguments);
        }

        public Object Execute(
            String language,
            String source,
            IDictionary<String, Object> arguments
        )
        {
            return this.Execute<Object>(language, source, arguments);
        }

        public T Execute<T>(
            FileInfo file,
            IDictionary<String, Object> arguments
        )
        {
            return this.Execute<T>(this.Parent.GetLanguage(file.Extension), file.ReadAllText(), arguments);
        }

        public Object Execute(
            FileInfo file,
            IDictionary<String, Object> arguments
        )
        {
            return this.Execute<Object>(this.Parent.GetLanguage(file.Extension), file.ReadAllText(), arguments);
        }

        public T Execute<T>(
            String path,
            IDictionary<String, Object> arguments
        )
        {
            return this.Execute<T>(new FileInfo(path), arguments);
        }

        public Object Execute(
            String path,
            IDictionary<String, Object> arguments
        )
        {
            return this.Execute<Object>(new FileInfo(path), arguments);
        }

        #endregion

        #region DoCallback

        public T DoCallback<T>(Callback<T> callback)
        {
            this.CheckIfDisposed();
            return new DoCallbackHelper<T>(this.ApplicationDomain, callback).DoCallback();
        }

        public T DoCallback<T>(ParameterizedCallback<T> callback, Object argument)
        {
            this.CheckIfDisposed();
            return new DoCallbackHelper<T>(this.ApplicationDomain, callback, argument).DoCallback();
        }

        public void DoCallback(Callback callback)
        {
            this.CheckIfDisposed();
            new DoCallbackHelper(this.ApplicationDomain, callback).DoCallback();
        }

        public void DoCallback(ParameterizedCallback callback, Object argument)
        {
            this.CheckIfDisposed();
            new DoCallbackHelper(this.ApplicationDomain, callback, argument).DoCallback();
        }

        #endregion
    }
}