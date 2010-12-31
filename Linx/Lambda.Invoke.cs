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
using XSpect.Extension;
using Achiral;
using Achiral.Extension;

namespace XSpect
{
    partial class Lambda
    {
        public static void Invoke<T1, T2>(this Action<T1, T2> action, Tuple<T1, T2> args)
        {
            action.Invoke(args.Item1, args.Item2);
        }

        public static void Invoke<T1, T2, T3>(this Action<T1, T2, T3> action, Tuple<T1, T2, T3> args)
        {
            action.Invoke(args.Item1, args.Item2, args.Item3);
        }

        public static void Invoke<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, Tuple<T1, T2, T3, T4> args)
        {
            action.Invoke(args.Item1, args.Item2, args.Item3, args.Item4);
        }

        public static void Invoke<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action, Tuple<T1, T2, T3, T4, T5> args)
        {
            action.Invoke(args.Item1, args.Item2, args.Item3, args.Item4, args.Item5);
        }

        public static void Invoke<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action, Tuple<T1, T2, T3, T4, T5, T6> args)
        {
            action.Invoke(args.Item1, args.Item2, args.Item3, args.Item4, args.Item5, args.Item6);
        }

        public static void Invoke<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action, Tuple<T1, T2, T3, T4, T5, T6, T7> args)
        {
            action.Invoke(args.Item1, args.Item2, args.Item3, args.Item4, args.Item5, args.Item6, args.Item7);
        }

        public static TReturn Invoke<T1, T2, TReturn>(this Func<T1, T2, TReturn> func, Tuple<T1, T2> args)
        {
            return func.Invoke(args.Item1, args.Item2);
        }

        public static TReturn Invoke<T1, T2, T3, TReturn>(this Func<T1, T2, T3, TReturn> func, Tuple<T1, T2, T3> args)
        {
            return func.Invoke(args.Item1, args.Item2, args.Item3);
        }

        public static TReturn Invoke<T1, T2, T3, T4, TReturn>(this Func<T1, T2, T3, T4, TReturn> func, Tuple<T1, T2, T3, T4> args)
        {
            return func.Invoke(args.Item1, args.Item2, args.Item3, args.Item4);
        }

        public static TReturn Invoke<T1, T2, T3, T4, T5, TReturn>(this Func<T1, T2, T3, T4, T5, TReturn> func, Tuple<T1, T2, T3, T4, T5> args)
        {
            return func.Invoke(args.Item1, args.Item2, args.Item3, args.Item4, args.Item5);
        }

        public static TReturn Invoke<T1, T2, T3, T4, T5, T6, TReturn>(this Func<T1, T2, T3, T4, T5, T6, TReturn> func, Tuple<T1, T2, T3, T4, T5, T6> args)
        {
            return func.Invoke(args.Item1, args.Item2, args.Item3, args.Item4, args.Item5, args.Item6);
        }

        public static TReturn Invoke<T1, T2, T3, T4, T5, T6, T7, TReturn>(this Func<T1, T2, T3, T4, T5, T6, T7, TReturn> func, Tuple<T1, T2, T3, T4, T5, T6, T7> args)
        {
            return func.Invoke(args.Item1, args.Item2, args.Item3, args.Item4, args.Item5, args.Item6, args.Item7);
        }
    }
}