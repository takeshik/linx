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
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Achiral;
using Achiral.Extension;
using XSpect;
using XSpect.Collections;
using XSpect.Extension;
using XSpect.Codecs;

namespace XSpect.Configuration
{
    [Serializable()]
    [XmlRoot("configuration", Namespace = "urn:XSpect.Configuration.XmlConfiguration")]
    public partial class XmlConfiguration
        : HybridDictionary<String, XmlConfiguration.Entry>,
          IXmlSerializable
    {
        public const Int32 Version = 2;

        public new Entry this[String key]
        {
            get
            {
                return this.Resolve(key);
            }
        }

        public FileInfo ConfigurationFile
        {
            get;
            set;
        }

        public ICollection<XmlConfiguration> BaseConfigurations
        {
            get;
            set;
        }

        public IEnumerable<XmlConfiguration> Hierarchy
        {
            get
            {
                return Make.Array(this)
                    .Concat(this.BaseConfigurations
                        .CascadeBreadthFirst(c => c.BaseConfigurations)
                    );
            }
        }

        public Boolean IsExterned
        {
            get;
            set;
        }

        public XmlConfiguration()
            : base((i, v) => v.Key)
        {
            this.BaseConfigurations = new List<XmlConfiguration>();
        }

        public XmlConfiguration(FileInfo file)
            : this()
        {
            this.ConfigurationFile = file;
        }

        public XmlConfiguration(String path)
            : this(new FileInfo(path))
        {
        }

        public static XmlConfiguration Load(FileInfo file)
        {
            XmlConfiguration config = new XmlConfiguration(file);
            if (file.Exists)
            {
                config.Import(file);
            }
            return config;
        }

        public static XmlConfiguration Load(String path)
        {
            return Load(new FileInfo(path));
        }

        protected override void InsertItems(IEnumerable<Int32> indexes, IEnumerable<String> keys, IEnumerable<Entry> values, Boolean ensureKeysCompliant)
        {
            values
                .OfType<Entry<XmlConfiguration>>()
                .ForEach(entry => entry.Value.BaseConfigurations.AddRange(
                    this.BaseConfigurations
                        .Select(c => c.TryResolve<XmlConfiguration>(entry.Key))
                        .Where(e => e != null)
                        .Select(e => e.Value)
                ));
            base.InsertItems(indexes, keys, values, ensureKeysCompliant);
        }

        #region Implementation of IXmlSerializable

        public new XmlSchema GetSchema()
        {
            return null;
        }

        public new void ReadXml(XmlReader reader)
        {
            // HACK: Measure for XML Serializing, calls .ctor(), so ConfigurationFile is null.
            if (this.ConfigurationFile == null && !reader.BaseURI.IsNullOrEmpty())
            {
                this.ConfigurationFile = new FileInfo(new Uri(reader.BaseURI).LocalPath);
            }
            XDocument.Load(reader).Root.Elements().ForEach(xe =>
            {
                switch (xe.Name.LocalName)
                {
                    case "metadata":
                        if (xe.Attribute("version").Value != Version.ToString())
                        {
                            throw new InvalidDataException(String.Format(
                                "Invalid version: expected v{0} but this is v{1}",
                                Version,
                                xe.Attribute("version").Value
                            ));
                        }
                        break;
                    case "refer":
                        this.Clear();
                        FileInfo file = new FileInfo(new Uri(
                            new Uri(this.ConfigurationFile.FullName),
                            xe.Attribute("path").Value).LocalPath
                        );
                        this.ReadXml(XmlReader.Create(file.FullName));
                        this.ConfigurationFile = file;
                        this.IsExterned = true;
                        return;
                    case "base":
                        this.BaseConfigurations
                            .Add(Load(new Uri(
                                new Uri(this.ConfigurationFile.FullName),
                                xe.Attribute("path").Value).LocalPath)
                            );
                        break;
                    case "entry":
                        XComment xcname = xe.Nodes().OfType<XComment>()
                            .SingleOrDefault(xc => xc.Value.StartsWith("NAME: "));
                        XComment xcdescription = xe.Nodes().OfType<XComment>()
                            .SingleOrDefault(xc => xc.Value.StartsWith("DESC: "));
                        XElement xvalue = xe.Elements().FirstOrDefault();
                        Type type = Type.GetType(xe.Attribute("type").Value);
                        this.Update(xvalue != null
                            ? Entry.Create(
                                  this,
                                  type,
                                  xe.Attribute("key").Value,
                                  type == typeof(XmlConfiguration)
                                      ? new XmlConfiguration(this.ConfigurationFile)
                                            .Let(c => xvalue.CreateReader().Dispose(c.ReadXml))
                                      : xvalue.CreateReader().Dispose(r => new XmlSerializer(type).Deserialize(r)),
                                  xcname.Null(xc => xcname.Value.Substring(6)), // "NAME: "
                                  xcdescription.Null(xc => xcdescription.Value.Substring(6)) // "DESC: "
                              )
                            : Entry.Create(
                                  this,
                                  type,
                                  xe.Attribute("key").Value,
                                  xcname.Null(xc => xcname.Value.Substring(6)), // "NAME: "
                                  xcdescription.Null(xc => xcdescription.Value.Substring(6)) // "DESC: "
                              )
                        );
                        break;
                    default:
                        break;
                }
            });
        }

        public new void WriteXml(XmlWriter writer)
        {
            new XNode[]
            {
                new XComment(
                    " Generated by XmlConfiguration class in Linx Framework "
                ),
                new XElement("metadata",
                    new XAttribute("version", Version)
                ),
            }
                .Concat(this.BaseConfigurations
                    .Where(x => x.ConfigurationFile != null)
                    .Select(config =>
                        (XNode) new XElement("base",
                            new XAttribute(
                                "path",
                                new Uri(this.ConfigurationFile.FullName)
                                    .MakeRelativeUri(new Uri(config.ConfigurationFile.FullName))
                            )
                        )
                    )
                )
                .Concat(this.Values.Select(entry =>
                {
                    XmlConfiguration config;
                    XElement xvalue;

                    if (!entry.IsValueDefined)
                    {
                        xvalue = null;
                    }
                    else if (entry is Entry<XmlConfiguration>
                        && (config = ((Entry<XmlConfiguration>) entry).Value).IsExterned)
                    {
                        config.Save();
                        xvalue = new XElement("refer",
                            new XAttribute(
                                "path",
                                new Uri(this.ConfigurationFile.FullName)
                                    .MakeRelativeUri(new Uri(config.ConfigurationFile.FullName))
                            )
                        );
                    }
                    else
                    {
                        xvalue = entry.UntypedValue.XmlSerialize(entry.Type);
                    }

                    return (XNode) new XElement("entry",
                        new XAttribute("key", entry.Key),
                        new XAttribute("type", entry.Type.AssemblyQualifiedName),
                        entry.IsNameDefined ? new XComment("NAME: " + entry.Name) : null,
                        entry.IsDescriptionDefined ? new XComment("DESC: " + entry.Description) : null,
                        xvalue
                    );
                }))
                .ForEach(xn => xn.WriteTo(writer));
        }

        #endregion

        public void Add<T>(String key, T value, String name, String description)
        {
            this.Add(new Entry<T>(this)
            {
                Key = key,
                Name = name,
                Description = description,
                Value = value,
            });
        }

        public void Add<T>(String key, String name, String description)
        {
            this.Add(new Entry<T>(this)
            {
                Key = key,
                Name = name,
                Description = description,
                IsValueDefined = false,
            });
        }

        public void Add<T>(String key, T value)
        {
            this.Add(key, value, null, null);
        }

        public void Add<T>(String key)
        {
            this.Add<T>(key, null, null);
        }

        public Boolean Update<T>(String key, T value, String name, String description)
        {
            if (this.ContainsKey(key))
            {
                Entry<T> entry = this.Get<T>(key);
                entry.Value = value;
                entry.Name = name;
                entry.Description = description;
                return false;
            }
            else
            {
                this.Add(key, value, name, description);
                return true;
            }
        }

        public Boolean Update<T>(String key, String name, String description)
        {
            if (this.ContainsKey(key))
            {
                Entry<T> entry = this.Get<T>(key);
                entry.IsValueDefined = false;
                entry.Name = name;
                entry.Description = description;
                return false;
            }
            else
            {
                this.Add<T>(key, name, description);
                return true;
            }
        }

        public Boolean Update<T>(String key, T value)
        {
            if (this.ContainsKey(key))
            {
                this.Get<T>(key).Value = value;
                return false;
            }
            else
            {
                this.Add(key, value);
                return true;
            }
        }

        public Boolean Update<T>(String key)
        {
            if (this.ContainsKey(key))
            {
                this.Get<T>(key).IsValueDefined = false;
                return false;
            }
            else
            {
                this.Add<T>(key);
                return true;
            }
        }

        public Boolean Update(Entry entry)
        {
            Boolean contained = this.ContainsValue(entry);
            if (contained)
            {
                this.RemoveValue(entry);
            }
            this.Add(entry);
            return contained;
        }

        public Boolean Exists(String key)
        {
            return this.Hierarchy.Any(c => c.ContainsKey(key));
        }

        public Entry Get(String key)
        {
            return base[key];
        }

        public Entry Get(params String[] keys)
        {
            return this.Walk((c, k) => c.ResolveChild(k), keys.Take(keys.Count() - 1))[keys.Last()];
        }

        public Entry TryGet(params String[] keys)
        {
            XmlConfiguration config = this.Walk((c, k) => c.ResolveChild(k), keys.Take(keys.Count() - 1));
            String key = keys.Last();
            return config.ContainsKey(key) ? config.Get(key) : null;
        }

        public Boolean TryGet(String key, out Entry value)
        {
            return this.ContainsKey(key)
                ? (value = this.Get(key)).True()
                : (value = null).False();
        }

        public Entry<T> Get<T>(params String[] keys)
        {
            return (Entry<T>) this.Get(keys);
        }

        public Entry<T> TryGet<T>(params String[] keys)
        {
            return (Entry<T>) this.TryGet(keys);
        }

        public Boolean TryGet<T>(String key, out Entry<T> value)
        {
            return this.ContainsKey(key)
                ? (value = this.Get<T>(key)).True()
                : (value = null).False();
        }

        public T GetValue<T>(params String[] keys)
        {
            return ((Entry<T>) this.Get(keys)).Value;
        }

        public Boolean TryGetValue<T>(String key, out T value)
        {
            return this.ContainsKey(key)
                ? (value = this.GetValue<T>(key)).True()
                : (value = default(T)).False();
        }

        public XmlConfiguration GetChild(String key)
        {
            return this.GetValue<XmlConfiguration>(key);
        }

        public Entry Resolve(String key)
        {
            foreach (XmlConfiguration config in this.Hierarchy)
            {
                if (config.ContainsKey(key))
                {
                    return config.Get(key);
                }
            }
            throw new KeyNotFoundException();
        }

        public Entry Resolve(params String[] keys)
        {
            foreach (XmlConfiguration config in this
                .Walk((c, k) => c.ResolveChild(k), keys.Take(keys.Count() - 1))
                .Hierarchy
            )
            {
                String key = keys.Last();
                if (config.ContainsKey(key))
                {
                    return config.Get(key);
                }
            }
            throw new KeyNotFoundException();
        }

        public Entry TryResolve(params String[] keys)
        {
            XmlConfiguration config = this.Walk((c, k) => c.ResolveChild(k), keys.Take(keys.Count() - 1));
            String key = keys.Last();
            return config.Exists(key) ? config.Resolve(key) : null;
        }

        public Boolean TryResolve(String key, out Entry value)
        {
            return this.Exists(key)
                ? (value = this.Resolve(key)).True()
                : (value = null).False();
        }

        public Entry<T> Resolve<T>(params String[] keys)
        {
            return (Entry<T>) this.Resolve(keys);
        }

        public Entry<T> TryResolve<T>(params String[] keys)
        {
            return (Entry<T>) this.Resolve(keys);
        }

        public Boolean TryResolve<T>(String key, out Entry<T> value)
        {
            return this.Exists(key)
                ? (value = this.Resolve<T>(key)).True()
                : (value = null).False();
        }

        public T ResolveValue<T>(params String[] keys)
        {
            return ((Entry<T>) this.Resolve(keys)).Value;
        }

        public Boolean TryResolveValue<T>(String key, out T value)
        {
            return this.Exists(key)
                ? (value = this.ResolveValue<T>(key)).True()
                : (value = default(T)).False();
        }

        public IEnumerable<Entry> GetHierarchy(params String[] keys)
        {
            return this.Walk((c, k) => c.ResolveChild(k), keys.Take(keys.Count() - 1)).Hierarchy.Select(x => x.TryGet(keys.Last())).Where(e => e != null);
        }

        public IEnumerable<Entry<T>> GetHierarchy<T>(params String[] keys)
        {
            return this.Walk((c, k) => c.ResolveChild(k), keys.Take(keys.Count() - 1)).Hierarchy.Select(x => x.TryGet<T>(keys.Last())).Where(e => e != null);
        }

        public XmlConfiguration ResolveChild(String key)
        {
            return this.ResolveValue<XmlConfiguration>(key);
        }

        public IEnumerable<Entry<T>> OfEntryType<T>()
        {
            return this.Values.OfType<Entry<T>>();
        }

        public IEnumerable<T> OfValueType<T>()
        {
            return this.OfEntryType<T>().Select(e => (T) e);
        }

        public IDictionary<String, Object> ToDictionary()
        {
            return this.Values.ToDictionary(e => e.Key, e => e.UntypedValue);
        }

        public IDictionary<String, T> ToDictionary<T>()
        {
            return this.OfEntryType<T>().ToDictionary(e => e.Key, e => e.Value);
        }

        public void Import(FileInfo file)
        {
            if (this.ConfigurationFile == null)
            {
                this.ConfigurationFile = file;
            }
            this.ReadXml(XmlReader.Create(file.FullName));
        }

        public void Import(String path)
        {
            this.Import(new FileInfo(path));
        }

        public void Save()
        {
            this.Save(this.ConfigurationFile);
        }

        public void Save(FileInfo file)
        {
            FileInfo previous = this.ConfigurationFile;
            this.ConfigurationFile = file;
            try
            {
                new MemoryStream().Dispose(stream =>
                    XmlWriter.Create(
                        stream, new XmlWriterSettings()
                        {
                            Encoding = Encoding.UTF8,
                            Indent = true,
                            IndentChars = new String(' ', 4),
                            OmitXmlDeclaration = false,
                        }
                    ).Dispose(writer =>
                    {
                        new XmlSerializer(typeof(XmlConfiguration)).Serialize(writer, this);
                        stream.Seek(0, SeekOrigin.Begin);
                        XDocument xdoc = XmlReader.Create(stream).Dispose(reader => XDocument.Load(reader));
                        xdoc.Save(file.FullName, SaveOptions.None);
                    })
                );
            }
            catch (Exception)
            {
                // Restore path to configuration file if failed
                this.ConfigurationFile = previous;
                throw;
            }
        }

        public void Save(String path)
        {
            this.Save(new FileInfo(path));
        }
    }
}