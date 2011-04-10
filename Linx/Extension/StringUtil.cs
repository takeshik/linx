﻿// -*- mode: csharp; encoding: utf-8; tab-width: 4; c-basic-offset: 4; indent-tabs-mode: nil; -*-
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
using System.Linq;
using System.Text.RegularExpressions;
using Achiral.Extension;
using Achiral;

namespace XSpect.Extension
{
    public static class StringUtil
    {
        public static IEnumerable<String> Lines(this String str)
        {
            return str.Split(Make.Array(Environment.NewLine), StringSplitOptions.None);
        }

        public static String ForEachLine(this String str, Func<String, String> selector)
        {
            return str.Lines().Select(selector).Join(Environment.NewLine);
        }

        public static String Indent(this String str, Int32 columnCount)
        {
            return str.ForEachLine(s => new String(' ', columnCount) + s);
        }

        public static String Unindent(this String str, Int32 columnCount)
        {
            if (!str.Lines().All(s => s.StartsWith(new String(' ', columnCount))))
            {
                throw new ArgumentException("Source string has not indented line.", "str");
            }
            return str.ForEachLine(s => s.Substring(columnCount));
        }

        public static String Quote(this String str, String head, String tail)
        {
            return head + str + tail;
        }

        public static String Replace(this String str, IDictionary<String, String> replaceTable)
        {
            return Regex.Replace(str, replaceTable.Keys.Select(Regex.Escape).Join("|").Quote("(", ")"), m => replaceTable[m.Groups[1].Value]);
        }

        public static Boolean StartsWithAny(this String str, params String[] values)
        {
            return values.Any(str.StartsWith);
        }

        public static Boolean EndsWithAny(this String str, params String[] values)
        {
            return values.Any(str.EndsWith);
        }
    }
}