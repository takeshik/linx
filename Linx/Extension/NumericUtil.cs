// -*- mode: csharp; encoding: utf-8; tab-width: 4; c-basic-offset: 4; indent-tabs-mode: nil; -*-
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
// $Id: a7db7754a428ebb526d000b64ab4e48866a29032 $
/* Linx
 *   Library that Integrates .NET with eXtremes
 * Copyright c 2008-2009 Takeshi KIRIYA, XSpect Project <takeshik@users.sf.net>
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
using System.IO;
using Achiral.Extension;

namespace XSpect.Extension
{
    public static class NumericUtil
    {
        public static void Times(this Int32 self, Action action)
        {
            if (self < 0)
            {
                return;
            }
            for (Int32 i = 0; i < self; ++i)
            {
                action();
            }
        }

        public static void Times(this Int32 self, Action<Int32> action)
        {
            if (self < 0)
            {
                return;
            }
            for (Int32 i = 0; i < self; ++i)
            {
                action(i);
            }
        }

        public static IEnumerable<Int32> Step(this Int32 self, Int32 limit)
        {
            return Step(self, limit, 1);
        }

        public static IEnumerable<Int32> Step(this Int32 self, Int32 limit, Int32 step)
        {
            for (Int32 i = self; i <= limit; i += step)
            {
                yield return i;
            }
        }

        public static void Times(this Int64 self, Action action)
        {
            if (self < 0)
            {
                return;
            }
            for (Int64 i = 0; i < self; ++i)
            {
                action();
            }
        }

        public static void Times(this Int64 self, Action<Int64> action)
        {
            if (self < 0)
            {
                return;
            }
            for (Int64 i = 0; i < self; ++i)
            {
                action(i);
            }
        }

        public static IEnumerable<Int64> Step(this Int64 self, Int64 limit)
        {
            return Step(self, limit, 1);
        }

        public static IEnumerable<Int64> Step(this Int64 self, Int64 limit, Int64 step)
        {
            for (Int64 i = self; i <= limit; i += step)
            {
                yield return i;
            }
        }
    }
}
