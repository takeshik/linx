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

#if LAMBDA_LIB

using System;
using XSpect.Extension;
using Achiral;
using Achiral.Extension;

namespace XSpect
{
    partial class Lambda
    {
        public static Action Bind<T1>(this Action<T1> action, T1 value1)
        {
            return New(() => action(value1));
        }

        public static Action<T2> Bind1st<T1, T2>(this Action<T1, T2> action, T1 value1)
        {
            return New((T2 value2) => action(value1, value2));
        }

        public static Action<T1> Bind2nd<T1, T2>(this Action<T1, T2> action, T2 value2)
        {
            return New((T1 value1) => action(value1, value2));
        }

        public static Action<T2, T3> Bind1st<T1, T2, T3>(this Action<T1, T2, T3> action, T1 value1)
        {
            return New((T2 value2, T3 value3) => action(value1, value2, value3));
        }

        public static Action<T1, T3> Bind2nd<T1, T2, T3>(this Action<T1, T2, T3> action, T2 value2)
        {
            return New((T1 value1, T3 value3) => action(value1, value2, value3));
        }

        public static Action<T1, T2> Bind3rd<T1, T2, T3>(this Action<T1, T2, T3> action, T3 value3)
        {
            return New((T1 value1, T2 value2) => action(value1, value2, value3));
        }

        public static Action<T2, T3, T4> Bind1st<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 value1)
        {
            return New((T2 value2, T3 value3, T4 value4) => action(value1, value2, value3, value4));
        }

        public static Action<T1, T3, T4> Bind2nd<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T2 value2)
        {
            return New((T1 value1, T3 value3, T4 value4) => action(value1, value2, value3, value4));
        }

        public static Action<T1, T2, T4> Bind3rd<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T3 value3)
        {
            return New((T1 value1, T2 value2, T4 value4) => action(value1, value2, value3, value4));
        }

        public static Action<T1, T2, T3> Bind4th<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T4 value4)
        {
            return New((T1 value1, T2 value2, T3 value3) => action(value1, value2, value3, value4));
        }

        public static Action<T2, T3, T4, T5> Bind1st<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action, T1 value1)
        {
            return New((T2 value2, T3 value3, T4 value4, T5 value5) => action(value1, value2, value3, value4, value5));
        }

        public static Action<T1, T3, T4, T5> Bind2nd<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action, T2 value2)
        {
            return New((T1 value1, T3 value3, T4 value4, T5 value5) => action(value1, value2, value3, value4, value5));
        }

        public static Action<T1, T2, T4, T5> Bind3rd<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action, T3 value3)
        {
            return New((T1 value1, T2 value2, T4 value4, T5 value5) => action(value1, value2, value3, value4, value5));
        }

        public static Action<T1, T2, T3, T5> Bind4th<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action, T4 value4)
        {
            return New((T1 value1, T2 value2, T3 value3, T5 value5) => action(value1, value2, value3, value4, value5));
        }

        public static Action<T1, T2, T3, T4> Bind5th<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action, T5 value5)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4) => action(value1, value2, value3, value4, value5));
        }

        public static Action<T2, T3, T4, T5, T6> Bind1st<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action, T1 value1)
        {
            return New((T2 value2, T3 value3, T4 value4, T5 value5, T6 value6) => action(value1, value2, value3, value4, value5, value6));
        }

        public static Action<T1, T3, T4, T5, T6> Bind2nd<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action, T2 value2)
        {
            return New((T1 value1, T3 value3, T4 value4, T5 value5, T6 value6) => action(value1, value2, value3, value4, value5, value6));
        }

        public static Action<T1, T2, T4, T5, T6> Bind3rd<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action, T3 value3)
        {
            return New((T1 value1, T2 value2, T4 value4, T5 value5, T6 value6) => action(value1, value2, value3, value4, value5, value6));
        }

        public static Action<T1, T2, T3, T5, T6> Bind4th<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action, T4 value4)
        {
            return New((T1 value1, T2 value2, T3 value3, T5 value5, T6 value6) => action(value1, value2, value3, value4, value5, value6));
        }

        public static Action<T1, T2, T3, T4, T6> Bind5th<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action, T5 value5)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4, T6 value6) => action(value1, value2, value3, value4, value5, value6));
        }

        public static Action<T1, T2, T3, T4, T5> Bind6th<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action, T6 value6)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4, T5 value5) => action(value1, value2, value3, value4, value5, value6));
        }

        public static Action<T2, T3, T4, T5, T6, T7> Bind1st<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action, T1 value1)
        {
            return New((T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7) => action(value1, value2, value3, value4, value5, value6, value7));
        }

        public static Action<T1, T3, T4, T5, T6, T7> Bind2nd<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action, T2 value2)
        {
            return New((T1 value1, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7) => action(value1, value2, value3, value4, value5, value6, value7));
        }

        public static Action<T1, T2, T4, T5, T6, T7> Bind3rd<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action, T3 value3)
        {
            return New((T1 value1, T2 value2, T4 value4, T5 value5, T6 value6, T7 value7) => action(value1, value2, value3, value4, value5, value6, value7));
        }

        public static Action<T1, T2, T3, T5, T6, T7> Bind4th<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action, T4 value4)
        {
            return New((T1 value1, T2 value2, T3 value3, T5 value5, T6 value6, T7 value7) => action(value1, value2, value3, value4, value5, value6, value7));
        }

        public static Action<T1, T2, T3, T4, T6, T7> Bind5th<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action, T5 value5)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4, T6 value6, T7 value7) => action(value1, value2, value3, value4, value5, value6, value7));
        }

        public static Action<T1, T2, T3, T4, T5, T7> Bind6th<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action, T6 value6)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T7 value7) => action(value1, value2, value3, value4, value5, value6, value7));
        }

        public static Action<T1, T2, T3, T4, T5, T6> Bind7th<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action, T7 value7)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6) => action(value1, value2, value3, value4, value5, value6, value7));
        }

        public static Action<T2, T3, T4, T5, T6, T7, T8> Bind1st<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action, T1 value1)
        {
            return New((T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8) => action(value1, value2, value3, value4, value5, value6, value7, value8));
        }

        public static Action<T1, T3, T4, T5, T6, T7, T8> Bind2nd<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action, T2 value2)
        {
            return New((T1 value1, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8) => action(value1, value2, value3, value4, value5, value6, value7, value8));
        }

        public static Action<T1, T2, T4, T5, T6, T7, T8> Bind3rd<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action, T3 value3)
        {
            return New((T1 value1, T2 value2, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8) => action(value1, value2, value3, value4, value5, value6, value7, value8));
        }

        public static Action<T1, T2, T3, T5, T6, T7, T8> Bind4th<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action, T4 value4)
        {
            return New((T1 value1, T2 value2, T3 value3, T5 value5, T6 value6, T7 value7, T8 value8) => action(value1, value2, value3, value4, value5, value6, value7, value8));
        }

        public static Action<T1, T2, T3, T4, T6, T7, T8> Bind5th<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action, T5 value5)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4, T6 value6, T7 value7, T8 value8) => action(value1, value2, value3, value4, value5, value6, value7, value8));
        }

        public static Action<T1, T2, T3, T4, T5, T7, T8> Bind6th<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action, T6 value6)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T7 value7, T8 value8) => action(value1, value2, value3, value4, value5, value6, value7, value8));
        }

        public static Action<T1, T2, T3, T4, T5, T6, T8> Bind7th<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action, T7 value7)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T8 value8) => action(value1, value2, value3, value4, value5, value6, value7, value8));
        }

        public static Action<T1, T2, T3, T4, T5, T6, T7> Bind8th<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action, T8 value8)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7) => action(value1, value2, value3, value4, value5, value6, value7, value8));
        }

        public static Func<T2, TResult> Bind1st<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 value1)
        {
            return New((T2 value2) => func(value1, value2));
        }

        public static Func<T1, TResult> Bind2nd<T1, T2, TResult>(this Func<T1, T2, TResult> func, T2 value2)
        {
            return New((T1 value1) => func(value1, value2));
        }

        public static Func<T2, T3, TResult> Bind1st<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 value1)
        {
            return New((T2 value2, T3 value3) => func(value1, value2, value3));
        }

        public static Func<T1, T3, TResult> Bind2nd<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T2 value2)
        {
            return New((T1 value1, T3 value3) => func(value1, value2, value3));
        }

        public static Func<T1, T2, TResult> Bind3rd<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T3 value3)
        {
            return New((T1 value1, T2 value2) => func(value1, value2, value3));
        }

        public static Func<T2, T3, T4, TResult> Bind1st<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T1 value1)
        {
            return New((T2 value2, T3 value3, T4 value4) => func(value1, value2, value3, value4));
        }

        public static Func<T1, T3, T4, TResult> Bind2nd<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T2 value2)
        {
            return New((T1 value1, T3 value3, T4 value4) => func(value1, value2, value3, value4));
        }

        public static Func<T1, T2, T4, TResult> Bind3rd<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T3 value3)
        {
            return New((T1 value1, T2 value2, T4 value4) => func(value1, value2, value3, value4));
        }

        public static Func<T1, T2, T3, TResult> Bind4th<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T4 value4)
        {
            return New((T1 value1, T2 value2, T3 value3) => func(value1, value2, value3, value4));
        }

        public static Func<T2, T3, T4, T5, TResult> Bind1st<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> func, T1 value1)
        {
            return New((T2 value2, T3 value3, T4 value4, T5 value5) => func(value1, value2, value3, value4, value5));
        }

        public static Func<T1, T3, T4, T5, TResult> Bind2nd<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> func, T2 value2)
        {
            return New((T1 value1, T3 value3, T4 value4, T5 value5) => func(value1, value2, value3, value4, value5));
        }

        public static Func<T1, T2, T4, T5, TResult> Bind3rd<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> func, T3 value3)
        {
            return New((T1 value1, T2 value2, T4 value4, T5 value5) => func(value1, value2, value3, value4, value5));
        }

        public static Func<T1, T2, T3, T5, TResult> Bind4th<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> func, T4 value4)
        {
            return New((T1 value1, T2 value2, T3 value3, T5 value5) => func(value1, value2, value3, value4, value5));
        }

        public static Func<T1, T2, T3, T4, TResult> Bind5th<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> func, T5 value5)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4) => func(value1, value2, value3, value4, value5));
        }

        public static Func<T2, T3, T4, T5, T6, TResult> Bind1st<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> func, T1 value1)
        {
            return New((T2 value2, T3 value3, T4 value4, T5 value5, T6 value6) => func(value1, value2, value3, value4, value5, value6));
        }

        public static Func<T1, T3, T4, T5, T6, TResult> Bind2nd<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> func, T2 value2)
        {
            return New((T1 value1, T3 value3, T4 value4, T5 value5, T6 value6) => func(value1, value2, value3, value4, value5, value6));
        }

        public static Func<T1, T2, T4, T5, T6, TResult> Bind3rd<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> func, T3 value3)
        {
            return New((T1 value1, T2 value2, T4 value4, T5 value5, T6 value6) => func(value1, value2, value3, value4, value5, value6));
        }

        public static Func<T1, T2, T3, T5, T6, TResult> Bind4th<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> func, T4 value4)
        {
            return New((T1 value1, T2 value2, T3 value3, T5 value5, T6 value6) => func(value1, value2, value3, value4, value5, value6));
        }

        public static Func<T1, T2, T3, T4, T6, TResult> Bind5th<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> func, T5 value5)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4, T6 value6) => func(value1, value2, value3, value4, value5, value6));
        }

        public static Func<T1, T2, T3, T4, T5, TResult> Bind6th<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> func, T6 value6)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4, T5 value5) => func(value1, value2, value3, value4, value5, value6));
        }

        public static Func<T2, T3, T4, T5, T6, T7, TResult> Bind1st<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func, T1 value1)
        {
            return New((T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7) => func(value1, value2, value3, value4, value5, value6, value7));
        }

        public static Func<T1, T3, T4, T5, T6, T7, TResult> Bind2nd<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func, T2 value2)
        {
            return New((T1 value1, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7) => func(value1, value2, value3, value4, value5, value6, value7));
        }

        public static Func<T1, T2, T4, T5, T6, T7, TResult> Bind3rd<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func, T3 value3)
        {
            return New((T1 value1, T2 value2, T4 value4, T5 value5, T6 value6, T7 value7) => func(value1, value2, value3, value4, value5, value6, value7));
        }

        public static Func<T1, T2, T3, T5, T6, T7, TResult> Bind4th<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func, T4 value4)
        {
            return New((T1 value1, T2 value2, T3 value3, T5 value5, T6 value6, T7 value7) => func(value1, value2, value3, value4, value5, value6, value7));
        }

        public static Func<T1, T2, T3, T4, T6, T7, TResult> Bind5th<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func, T5 value5)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4, T6 value6, T7 value7) => func(value1, value2, value3, value4, value5, value6, value7));
        }

        public static Func<T1, T2, T3, T4, T5, T7, TResult> Bind6th<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func, T6 value6)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T7 value7) => func(value1, value2, value3, value4, value5, value6, value7));
        }

        public static Func<T1, T2, T3, T4, T5, T6, TResult> Bind7th<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func, T7 value7)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6) => func(value1, value2, value3, value4, value5, value6, value7));
        }

        public static Func<T2, T3, T4, T5, T6, T7, T8, TResult> Bind1st<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func, T1 value1)
        {
            return New((T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8) => func(value1, value2, value3, value4, value5, value6, value7, value8));
        }

        public static Func<T1, T3, T4, T5, T6, T7, T8, TResult> Bind2nd<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func, T2 value2)
        {
            return New((T1 value1, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8) => func(value1, value2, value3, value4, value5, value6, value7, value8));
        }

        public static Func<T1, T2, T4, T5, T6, T7, T8, TResult> Bind3rd<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func, T3 value3)
        {
            return New((T1 value1, T2 value2, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8) => func(value1, value2, value3, value4, value5, value6, value7, value8));
        }

        public static Func<T1, T2, T3, T5, T6, T7, T8, TResult> Bind4th<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func, T4 value4)
        {
            return New((T1 value1, T2 value2, T3 value3, T5 value5, T6 value6, T7 value7, T8 value8) => func(value1, value2, value3, value4, value5, value6, value7, value8));
        }

        public static Func<T1, T2, T3, T4, T6, T7, T8, TResult> Bind5th<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func, T5 value5)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4, T6 value6, T7 value7, T8 value8) => func(value1, value2, value3, value4, value5, value6, value7, value8));
        }

        public static Func<T1, T2, T3, T4, T5, T7, T8, TResult> Bind6th<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func, T6 value6)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T7 value7, T8 value8) => func(value1, value2, value3, value4, value5, value6, value7, value8));
        }

        public static Func<T1, T2, T3, T4, T5, T6, T8, TResult> Bind7th<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func, T7 value7)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T8 value8) => func(value1, value2, value3, value4, value5, value6, value7, value8));
        }

        public static Func<T1, T2, T3, T4, T5, T6, T7, TResult> Bind8th<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func, T8 value8)
        {
            return New((T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7) => func(value1, value2, value3, value4, value5, value6, value7, value8));
        }
    }
}

#endif