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
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Achiral;
using Achiral.Extension;

namespace XSpect.Codecs
{
    public static class XmlSerialization
    {
        public static XElement XmlSerialize<TReceiver>(this TReceiver self, Type type)
        {
            return XmlSerialization<TReceiver>.Serialize(self, type);
        }

        public static XElement XmlSerialize<TReceiver>(this TReceiver self)
        {
            return XmlSerialize(self, typeof(TReceiver));
        }
    }

    public static class XmlSerialization<T>
    {
        public static XElement Serialize(T obj, Type type)
        {
            return new MemoryStream().Dispose(s =>
            {
                new XmlSerializer(type).Serialize(s, obj);
                s.Seek(0, SeekOrigin.Begin);
                return XmlReader.Create(s).Dispose<XmlReader, XElement>(XElement.Load);
            });
        }

        public static XElement Serialize(T obj)
        {
            return Serialize(obj, typeof(T));
        }

        public static T Deserialize(XElement xelem)
        {
            return xelem.CreateReader().Dispose(xr => (T) new XmlSerializer(typeof(T)).Deserialize(xr));
        }
    }
}