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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Achiral.Extension;
using Microsoft.Scripting.Hosting;
using XSpect.Collections;
using XSpect.Configuration;
using XSpect.Extension;
using System.Reflection;

namespace XSpect.Reflection
{
    public class CodeManager
        : MarshalByRefObject,
          ICollection<CodeDomain>,
          IDisposable
    {
        private Boolean _disposed;

        public CodeDomain this[String key]
        {
            get
            {
                return this.CodeDomains[key];
            }
        }

        public HybridDictionary<String, CodeDomain> CodeDomains
        {
            get;
            private set;
        }

        public ScriptRuntime ScriptRuntime
        {
            get;
            private set;
        }

        public XmlConfiguration Configuration
        {
            get;
            set;
        }

        public ICollection<LanguageSetting> Languages
        {
            get;
            set;
        }

        public String DefaultApplicationBase
        {
            get;
            set;
        }

        public IEnumerable<String> DefaultPrivateBinPaths
        {
            get;
            set;
        }

        public IEnumerable<AssemblyName> DefaultAssemblies
        {
            get;
            set;
        }

        public IEnumerable<AssemblyName> AdditionalAssembliesForTemporary
        {
            get;
            set;
        }

        public CodeManager(FileInfo configFile)
        {
            this.Configuration = XmlConfiguration.Load(configFile);
            this.Languages = new List<LanguageSetting>();
            this.CodeDomains = new HybridDictionary<String, CodeDomain>((i, d) => d.Key);
            this.CodeDomains.ItemsRemoved += (sender, e) => e.OldElements.ForEach(_ => _.Value.Dispose());
            this.CodeDomains.ItemsReset += (sender, e) => e.OldElements.ForEach(_ => _.Value.Dispose());
            this.Setup();
        }

        ~CodeManager()
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
            this._disposed = true;
            // Clear -> ClearItems == Dispose.
            this.CodeDomains.Clear();
        }

        protected void CheckIfDisposed()
        {
            if (this._disposed)
            {
                throw new ObjectDisposedException("this");
            }
        }

        public void Add(CodeDomain item)
        {
            this.DefaultAssemblies.ForEach(ar => item.Load(ar));
            this.CodeDomains.Add(item);
        }

        public CodeDomain Add(String key)
        {
            return this.Add(key, this.DefaultPrivateBinPaths);
        }

        public CodeDomain Add(String key, IEnumerable<String> privateBinPaths)
        {
            return this.Add(key, this.DefaultApplicationBase, privateBinPaths);
        }

        public CodeDomain Add(String key, String applicationBase, IEnumerable<String> privateBinPaths)
        {
            return new CodeDomain(this, key, applicationBase, privateBinPaths)
                .Apply(d => this.DefaultAssemblies.ForEach(ar => d.Load(ar)), this.Add);
        }

        public void Clear()
        {
            this.CodeDomains.Clear();
        }

        public Boolean Contains(CodeDomain item)
        {
            return this.CodeDomains.ContainsValue(item);
        }

        public void CopyTo(CodeDomain[] array, Int32 arrayIndex)
        {
            this.CodeDomains.CopyToValues(array, arrayIndex);
        }

        public Boolean Remove(CodeDomain item)
        {
            return this.CodeDomains.RemoveValue(item);
        }

        public Int32 Count
        {
            get
            {
                return this.CodeDomains.Count;
            }
        }

        public Boolean IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public IEnumerator<CodeDomain> GetEnumerator()
        {
            return this.CodeDomains.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        protected virtual void Setup()
        {
            this.Languages.AddRange(this.Configuration.ResolveChild("languages")
                .OfValueType<LanguageSetting>()
            );
            this.ScriptRuntime = new ScriptRuntime(new ScriptRuntimeSetup().Apply(setup =>
            {
                setup.LanguageSetups.AddRange(this.Languages
                    .Where(l => l.IsDynamicLanguage)
                    .Select(l => new LanguageSetup(
                        l.Type.AssemblyQualifiedName,
                        l.Name,
                        l.Identifiers,
                        l.Extensions
                    ))
                );
                setup.DebugMode = this.Configuration.ResolveValue<Boolean>("dlr", "debug");
                setup.HostArguments = this.Configuration.ResolveValue<List<Object>>("dlr", "arguments");
                setup.Options.AddRange(
                    this.Configuration.ResolveValue<List<MutableTuple<String, Object>>>("dlr", "options")
                        .Select(s => Create.KeyValuePair(s.Item1, s.Item2))
                );
            }));
            this.DefaultApplicationBase = this.Configuration.ResolveValue<String>("default", "appbase")
                .If(String.IsNullOrEmpty, AppDomain.CurrentDomain.BaseDirectory);
            this.DefaultAssemblies = this.Configuration.ResolveValue<List<String>>("default", "assemblies")
                .Select(s => new AssemblyName(s));
            this.AdditionalAssembliesForTemporary = this.Configuration.ResolveValue<List<String>>("default", "assembliesForTemp")
                .Select(s => new AssemblyName(s));
        }

        public CodeDomain Add()
        {
            return this.Add("temp_" + Guid.NewGuid().ToString("d"))
                .Apply(d => this.AdditionalAssembliesForTemporary.ForEach(ar => d.Load(ar)));
        }

        public LanguageSetting GetLanguage(String language)
        {
            return this.Languages.Single(l =>
                l.Name == language ||
                l.Identifiers.Contains(language) ||
                l.Extensions.Contains(language)
            );
        }

        public CodeDomain Clone(String key, String keyCloning)
        {
            AppDomain domain = this.CodeDomains[keyCloning].AppDomain;
            return this.Add(key, domain.BaseDirectory, domain.SetupInformation.PrivateBinPath.Split(';'))
                .Apply(d => domain.GetAssemblies().ForEach(a => d.Load(a.GetName())));
        }

        #region Execute

        public T Execute<T>(
            LanguageSetting language,
            String source,
            IDictionary<String, Object> arguments
        )
        {
            return this.Add().Dispose(d => d.Execute<T>(language, source, arguments));
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
            return this.Execute<T>(this.GetLanguage(language), source, arguments);
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
            return this.Execute<T>(file.Extension, file.ReadAllText(), arguments);
        }

        public Object Execute(
            FileInfo file,
            IDictionary<String, Object> arguments
        )
        {
            return this.Execute<Object>(file.Extension, file.ReadAllText(), arguments);
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
    }
}