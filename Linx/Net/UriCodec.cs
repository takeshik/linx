// -*- mode: csharp; encoding: utf-8; tab-width: 4; c-basic-offset: 4; indent-tabs-mode: nil; -*-
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
// $Id: Create.cs 34861 2009-08-12 16:14:56Z takeshik $
/* Linx
 *   Library that Integrates .NET with eXtremes
 * Copyright © 2008-2009 Takeshi KIRIYA, XSpect Project <takeshik@users.sf.net>
 * All rights reserved.
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
using System.Text;
using System.Text.RegularExpressions;
using Achiral;
using Achiral.Extension;

namespace XSpect.Net
{
    public static class UriCodec
    {
        public const String UnreservedChars = "-.0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz~";

        private static Boolean IsReservedChar(Char c)
        {
            return UnreservedChars.IndexOf(c) < 0;
        }

        public static String Encode(String str, Encoding encoding)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Byte b in encoding.GetBytes(str))
            {
                if (IsReservedChar((Char) b))
                {
                    sb.AppendFormat("%{0:X2}", b);
                }
                else
                {
                    sb.Append((Char) b);
                }
            }
            return sb.ToString();
        }

        public static String Encode(String str)
        {
            return Encode(str, Encoding.UTF8);
        }

        public static String Decode(String str, Encoding encoding)
        {
            return encoding.GetString(
                Regex.Matches(str, @"%([0-9A-Fa-f]{2})|.")
                    .Select(m => m.Groups[1].Success
                        ? Convert.ToByte(m.Groups[1].Value, 16)
                        : (Byte) m.Value[0]
                    )
                    .ToArray()
            );
        }

        public static String Decode(String str)
        {
            return Decode(str, Encoding.UTF8);
        }
    }
}