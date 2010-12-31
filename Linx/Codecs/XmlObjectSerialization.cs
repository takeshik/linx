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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Achiral;
using Achiral.Extension;
using XSpect.Extension;

namespace XSpect.Codecs
{
    public static class XmlObjectSerialization
    {
        public static Byte[] XmlObjectSerialize<TReceiver>(this TReceiver self, XmlObjectSerializer serializer)
        {
            return XmlObjectSerialization<TReceiver>.Serialize(self, serializer);
        }

        public static Byte[] XmlObjectSerialize<TReceiver, TSerializer>(this TReceiver self)
            where TSerializer : XmlObjectSerializer
        {
            return XmlObjectSerialization<TReceiver>.Serialize<TSerializer>(self);
        }

        public static String XmlObjectSerializeToString<TReceiver>(this TReceiver obj, XmlObjectSerializer serializer)
        {
            return XmlObjectSerialization<TReceiver>.SerializeToString(obj, serializer);
        }

        public static String XmlObjectSerializeToString<TReceiver>(this TReceiver obj, XmlObjectSerializer serializer, Encoding encoding)
        {
            return XmlObjectSerialization<TReceiver>.SerializeToString(obj, serializer, encoding);
        }

        public static String XmlObjectSerializeToString<TReceiver, TSerializer>(this TReceiver obj, Encoding encoding)
            where TSerializer : XmlObjectSerializer
        {
            return XmlObjectSerialization<TReceiver>.SerializeToString<TSerializer>(obj, encoding);
        }

        public static String XmlObjectSerializeToString<TReceiver, TSerializer>(this TReceiver obj)
            where TSerializer : XmlObjectSerializer
        {
            return XmlObjectSerialization<TReceiver>.SerializeToString<TSerializer>(obj);
        }
    }

    public static class XmlObjectSerialization<T>
    {
        public static Byte[] Serialize(T obj, XmlObjectSerializer serializer)
        {
            return new MemoryStream().Apply(_ => _.Dispose(s =>
                serializer.WriteObject(s, obj)
            )).ToArray();
        }

        public static Byte[] Serialize<TSerializer>(T obj)
            where TSerializer : XmlObjectSerializer
        {
            return Serialize(obj, (XmlObjectSerializer) Activator.CreateInstance(typeof(TSerializer), typeof(T)));
        }

        public static String SerializeToString(T obj, XmlObjectSerializer serializer)
        {
            return SerializeToString(obj, serializer, Encoding.UTF8);
        }

        public static String SerializeToString(T obj, XmlObjectSerializer serializer, Encoding encoding)
        {
            return encoding.GetString(Serialize(obj, serializer));
        }

        public static String SerializeToString<TSerializer>(T obj, Encoding encoding)
            where TSerializer : XmlObjectSerializer
        {
            return encoding.GetString(Serialize<TSerializer>(obj));
        }

        public static String SerializeToString<TSerializer>(T obj)
            where TSerializer : XmlObjectSerializer
        {
            return SerializeToString<TSerializer>(obj, Encoding.UTF8);
        }

        public static T Deserialize(IEnumerable<Byte> data, XmlObjectSerializer serializer)
        {
            return new MemoryStream(data.ToArray()).Dispose(s =>
                (T) serializer.ReadObject(s)
            );
        }

        public static T Deserialize<TSerializer>(IEnumerable<Byte> data)
            where TSerializer : XmlObjectSerializer
        {
            return Deserialize(data, (XmlObjectSerializer) Activator.CreateInstance(typeof(TSerializer), typeof(T)));
        }

        public static T DeserializeFromString(String data, XmlObjectSerializer serializer, Encoding encoding)
        {
            return Deserialize(encoding.GetBytes(data), serializer);
        }

        public static T DeserializeFromString(String data, XmlObjectSerializer serializer)
        {
            return DeserializeFromString(data, serializer, Encoding.UTF8);
        }

        public static T DeserializeFromString<TSerializer>(String data, Encoding encoding)
            where TSerializer : XmlObjectSerializer
        {
            return Deserialize<TSerializer>(encoding.GetBytes(data));
        }

        public static T DeserializeFromString<TSerializer>(String data)
            where TSerializer : XmlObjectSerializer
        {
            return DeserializeFromString<TSerializer>(data, Encoding.UTF8);
        }
    }
}