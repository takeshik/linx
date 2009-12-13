// -*- mode: csharp; encoding: utf-8; tab-width: 4; c-basic-offset: 4; indent-tabs-mode: nil; -*-
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
// $Id: a7db7754a428ebb526d000b64ab4e48866a29032 $
/* LinxFramework
 *   Practical class library based on Linx Core Library
 *   Part of Linx
 * Linx
 *   Library that Integrates .NET with eXtremes
 * Copyright c 2008-2009 Takeshi KIRIYA, XSpect Project <takeshik@users.sf.net>
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
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Achiral;
using Achiral.Extension;
using Microsoft.Scripting.Runtime;
using XSpect;
using XSpect.Extension;

namespace XSpect.Reflection
{

    [XmlRoot("language")]
    public sealed class LanguageSetting
        : IXmlSerializable
    {
        public String Name
        {
            get;
            set;
        }

        public ICollection<String> Identifiers
        {
            get;
            set;
        }

        public ICollection<String> Extensions
        {
            get;
            set;
        }

        public Type Type
        {
            get;
            set;
        }

        public IDictionary<String, String> Options
        {
            get;
            set;
        }

        public Boolean IsDynamicLanguage
        {
            get
            {
                return this.Type.IsSubclassOf(typeof(LanguageContext));
            }
        }

        public LanguageSetting()
        {
            this.Identifiers = new List<String>();
            this.Extensions = new List<String>();
            this.Options = new Dictionary<String, String>();
        }

        #region Implementation of IXmlSerializable

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            XElement xlanguage = XDocument.Load(reader).Element("language");
            this.Name = xlanguage.Element("name").Value;
            this.Type = Type.GetType(xlanguage.Element("type").Value);
            this.Identifiers.AddRange(xlanguage
                .Element("ids")
                .Elements("id")
                .Select(xe => xe.Value)
            );
            this.Extensions.AddRange(xlanguage
                .Element("extensions")
                .Elements("extension")
                .Select(xe => xe.Value)
            );
            this.Options.AddRange(xlanguage
                .Element("options")
                .Elements("option")
                .Select(xe => Create.KeyValuePair(xe.Attribute("key").Value, xe.Value))
            );
        }

        public void WriteXml(XmlWriter writer)
        {
            Make.Array(
                new XElement("name", this.Name),
                new XElement("type", this.Type.AssemblyQualifiedName),
                new XElement("ids",
                    this.Identifiers.Select(l => new XElement("id", l))
                ),
                new XElement("extensions",
                    this.Extensions.Select(e => new XElement("extension", e))
                ),
                new XElement("options",
                    this.Options.Select(o => new XElement("option",
                        new XAttribute("key", o.Key),
                        o.Value
                    ))
                )
            ).ForEach(xe => xe.WriteTo(writer));
        }

        #endregion
    }
}