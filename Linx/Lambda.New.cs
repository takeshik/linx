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
using XSpect.Extension;
using Achiral;
using Achiral.Extension;

namespace XSpect
{
    partial class Lambda
    {
        public static Action New(Action action)
        {
            return action;
        }

        public static Action<T1> New<T1>(Action<T1> action)
        {
            return action;
        }

        public static Action<T1, T2> New<T1, T2>(Action<T1, T2> action)
        {
            return action;
        }

        public static Action<T1, T2, T3> New<T1, T2, T3>(Action<T1, T2, T3> action)
        {
            return action;
        }

        public static Action<T1, T2, T3, T4> New<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action)
        {
            return action;
        }

        public static Action<T1, T2, T3, T4, T5> New<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action)
        {
            return action;
        }

        public static Action<T1, T2, T3, T4, T5, T6> New<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action)
        {
            return action;
        }

        public static Action<T1, T2, T3, T4, T5, T6, T7> New<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action)
        {
            return action;
        }

        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> New<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
        {
            return action;
        }

        public static Func<TResult> New<TResult>(Func<TResult> func)
        {
            return func;
        }

        public static Func<T1, TResult> New<T1, TResult>(Func<T1, TResult> func)
        {
            return func;
        }

        public static Func<T1, T2, TResult> New<T1, T2, TResult>(Func<T1, T2, TResult> func)
        {
            return func;
        }

        public static Func<T1, T2, T3, TResult> New<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func)
        {
            return func;
        }

        public static Func<T1, T2, T3, T4, TResult> New<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> func)
        {
            return func;
        }

        public static Func<T1, T2, T3, T4, T5, TResult> New<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> func)
        {
            return func;
        }

        public static Func<T1, T2, T3, T4, T5, T6, TResult> New<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> func)
        {
            return func;
        }

        public static Func<T1, T2, T3, T4, T5, T6, T7, TResult> New<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> func)
        {
            return func;
        }

        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> New<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func)
        {
            return func;
        }
    }
}

#endif