// -*- mode: csharp; encoding: utf-8; tab-width: 4; c-basic-offset: 4; indent-tabs-mode: nil; -*-
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
// $Id: a7db7754a428ebb526d000b64ab4e48866a29032 $
/* Linx
 *   Library that Integrates .NET with eXtremes
 * Copyright © 2008-2010 Takeshi KIRIYA (aka takeshik) <takeshik@users.sf.net>
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
using Achiral;
using Achiral.Extension;
using XSpect.Extension;

namespace XSpect.Codecs
{
    [CLSCompliant(false)]
    public static class FormatterSerialization
    {
        public static Byte[] Serialize<TReceiver>(this TReceiver self, IFormatter formatter)
        {
            return FormatterSerialization<TReceiver>.Serialize(self, formatter);
        }

        public static Byte[] Serialize<TReceiver, TFormatter>(this TReceiver self)
            where TFormatter : IFormatter, new()
        {
            return FormatterSerialization<TReceiver>.Serialize<TFormatter>(self);
        }
    }

    [CLSCompliant(false)]
    public static class FormatterSerialization<T>
    {
        public static Byte[] Serialize(T obj, IFormatter formatter)
        {
            return new MemoryStream().Dispose(s =>
                s.Let(_ => formatter.Serialize(_, obj)).ToArray()
            );
        }

        public static Byte[] Serialize<TFormatter>(T obj)
            where TFormatter : IFormatter, new()
        {
            return new MemoryStream().Dispose<MemoryStream, Byte[]>(s =>
                s.Let(_ => new TFormatter().Serialize(_, obj)).ToArray()
            );
        }

        public static T Deserialize(IEnumerable<Byte> data, IFormatter formatter)
        {
            return new MemoryStream(data.ToArray()).Dispose(s =>
                (T) formatter.Deserialize(s)
            );
        }

        public static T Deserialize<TFormatter>(IEnumerable<Byte> data)
            where TFormatter : IFormatter, new()
        {
            return new MemoryStream(data.ToArray()).Dispose<MemoryStream, T>(s =>
                (T) new TFormatter().Deserialize(s)
            );
        }
    }
}