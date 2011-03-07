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

#if LAMBDA_LIB

using System;
using System.Linq;
using System.Reflection;
using Achiral;
using Achiral.Extension;

namespace XSpect
{
    public static partial class Lambda
    {
        public static Func<T, T> Id<T>()
        {
            return New((T obj) => obj);
        }

        public static Action<T> Nop<T>()
        {
            return New((T _) =>
            {
            });
        }

        public static Action<T1, T2> Nop<T1, T2>()
        {
            return New((T1 _1, T2 _2) =>
            {
            });
        }

        public static Action<T1, T2, T3> Nop<T1, T2, T3>()
        {
            return New((T1 _1, T2 _2, T3 _3) =>
            {
            });
        }

        public static Action<T1, T2, T3, T4> Nop<T1, T2, T3, T4>()
        {
            return New((T1 _1, T2 _2, T3 _3, T4 _4) =>
            {
            });
        }

        public static Action<T1, T2, T3, T4, T5> Nop<T1, T2, T3, T4, T5>()
        {
            return New((T1 _1, T2 _2, T3 _3, T4 _4, T5 _5) =>
            {
            });
        }

        public static Action<T1, T2, T3, T4, T5, T6> Nop<T1, T2, T3, T4, T5, T6>()
        {
            return New((T1 _1, T2 _2, T3 _3, T4 _4, T5 _5, T6 _6) =>
            {
            });
        }

        public static Action<T1, T2, T3, T4, T5, T6, T7> Nop<T1, T2, T3, T4, T5, T6, T7>()
        {
            return New((T1 _1, T2 _2, T3 _3, T4 _4, T5 _5, T6 _6, T7 _7) =>
            {
            });
        }

        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Nop<T1, T2, T3, T4, T5, T6, T7, T8>()
        {
            return New((T1 _1, T2 _2, T3 _3, T4 _4, T5 _5, T6 _6, T7 _7, T8 _8) =>
            {
            });
        }
    }
}

#endif