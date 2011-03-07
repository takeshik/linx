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
        public static Action Uncurry(this Func<Action> func)
        {
            return New(() => func()());
        }

        public static Action<TB1> Uncurry<TB1>(this Func<Action<TB1>> func)
        {
            return New((TB1 valueB1) => func()(valueB1));
        }

        public static Action<TB1, TB2> Uncurry<TB1, TB2>(this Func<Action<TB1, TB2>> func)
        {
            return New((TB1 valueB1, TB2 valueB2) => func()(valueB1, valueB2));
        }

        public static Action<TB1, TB2, TB3> Uncurry<TB1, TB2, TB3>(this Func<Action<TB1, TB2, TB3>> func)
        {
            return New((TB1 valueB1, TB2 valueB2, TB3 valueB3) => func()(valueB1, valueB2, valueB3));
        }

        public static Action<TB1, TB2, TB3, TB4> Uncurry<TB1, TB2, TB3, TB4>(this Func<Action<TB1, TB2, TB3, TB4>> func)
        {
            return New((TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4) => func()(valueB1, valueB2, valueB3, valueB4));
        }

        public static Action<TB1, TB2, TB3, TB4, TB5> Uncurry<TB1, TB2, TB3, TB4, TB5>(this Func<Action<TB1, TB2, TB3, TB4, TB5>> func)
        {
            return New((TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5) => func()(valueB1, valueB2, valueB3, valueB4, valueB5));
        }

        public static Action<TB1, TB2, TB3, TB4, TB5, TB6> Uncurry<TB1, TB2, TB3, TB4, TB5, TB6>(this Func<Action<TB1, TB2, TB3, TB4, TB5, TB6>> func)
        {
            return New((TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5, TB6 valueB6) => func()(valueB1, valueB2, valueB3, valueB4, valueB5, valueB6));
        }

        public static Action<TB1, TB2, TB3, TB4, TB5, TB6, TB7> Uncurry<TB1, TB2, TB3, TB4, TB5, TB6, TB7>(this Func<Action<TB1, TB2, TB3, TB4, TB5, TB6, TB7>> func)
        {
            return New((TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5, TB6 valueB6, TB7 valueB7) => func()(valueB1, valueB2, valueB3, valueB4, valueB5, valueB6, valueB7));
        }

        public static Action<TB1, TB2, TB3, TB4, TB5, TB6, TB7, TB8> Uncurry<TB1, TB2, TB3, TB4, TB5, TB6, TB7, TB8>(this Func<Action<TB1, TB2, TB3, TB4, TB5, TB6, TB7, TB8>> func)
        {
            return New((TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5, TB6 valueB6, TB7 valueB7, TB8 valueB8) => func()(valueB1, valueB2, valueB3, valueB4, valueB5, valueB6, valueB7, valueB8));
        }

        public static Action<TA1> Uncurry<TA1>(this Func<TA1, Action> func)
        {
            return New((TA1 valueA1) => func(valueA1)());
        }

        public static Action<TA1, TB1> Uncurry<TA1, TB1>(this Func<TA1, Action<TB1>> func)
        {
            return New((TA1 valueA1, TB1 valueB1) => func(valueA1)(valueB1));
        }

        public static Action<TA1, TB1, TB2> Uncurry<TA1, TB1, TB2>(this Func<TA1, Action<TB1, TB2>> func)
        {
            return New((TA1 valueA1, TB1 valueB1, TB2 valueB2) => func(valueA1)(valueB1, valueB2));
        }

        public static Action<TA1, TB1, TB2, TB3> Uncurry<TA1, TB1, TB2, TB3>(this Func<TA1, Action<TB1, TB2, TB3>> func)
        {
            return New((TA1 valueA1, TB1 valueB1, TB2 valueB2, TB3 valueB3) => func(valueA1)(valueB1, valueB2, valueB3));
        }

        public static Action<TA1, TB1, TB2, TB3, TB4> Uncurry<TA1, TB1, TB2, TB3, TB4>(this Func<TA1, Action<TB1, TB2, TB3, TB4>> func)
        {
            return New((TA1 valueA1, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4) => func(valueA1)(valueB1, valueB2, valueB3, valueB4));
        }

        public static Action<TA1, TB1, TB2, TB3, TB4, TB5> Uncurry<TA1, TB1, TB2, TB3, TB4, TB5>(this Func<TA1, Action<TB1, TB2, TB3, TB4, TB5>> func)
        {
            return New((TA1 valueA1, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5) => func(valueA1)(valueB1, valueB2, valueB3, valueB4, valueB5));
        }

        public static Action<TA1, TB1, TB2, TB3, TB4, TB5, TB6> Uncurry<TA1, TB1, TB2, TB3, TB4, TB5, TB6>(this Func<TA1, Action<TB1, TB2, TB3, TB4, TB5, TB6>> func)
        {
            return New((TA1 valueA1, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5, TB6 valueB6) => func(valueA1)(valueB1, valueB2, valueB3, valueB4, valueB5, valueB6));
        }

        public static Action<TA1, TB1, TB2, TB3, TB4, TB5, TB6, TB7> Uncurry<TA1, TB1, TB2, TB3, TB4, TB5, TB6, TB7>(this Func<TA1, Action<TB1, TB2, TB3, TB4, TB5, TB6, TB7>> func)
        {
            return New((TA1 valueA1, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5, TB6 valueB6, TB7 valueB7) => func(valueA1)(valueB1, valueB2, valueB3, valueB4, valueB5, valueB6, valueB7));
        }

        public static Action<TA1, TA2> Uncurry<TA1, TA2>(this Func<TA1, TA2, Action> func)
        {
            return New((TA1 valueA1, TA2 valueA2) => func(valueA1, valueA2)());
        }

        public static Action<TA1, TA2, TB1> Uncurry<TA1, TA2, TB1>(this Func<TA1, TA2, Action<TB1>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TB1 valueB1) => func(valueA1, valueA2)(valueB1));
        }

        public static Action<TA1, TA2, TB1, TB2> Uncurry<TA1, TA2, TB1, TB2>(this Func<TA1, TA2, Action<TB1, TB2>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TB1 valueB1, TB2 valueB2) => func(valueA1, valueA2)(valueB1, valueB2));
        }

        public static Action<TA1, TA2, TB1, TB2, TB3> Uncurry<TA1, TA2, TB1, TB2, TB3>(this Func<TA1, TA2, Action<TB1, TB2, TB3>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TB1 valueB1, TB2 valueB2, TB3 valueB3) => func(valueA1, valueA2)(valueB1, valueB2, valueB3));
        }

        public static Action<TA1, TA2, TB1, TB2, TB3, TB4> Uncurry<TA1, TA2, TB1, TB2, TB3, TB4>(this Func<TA1, TA2, Action<TB1, TB2, TB3, TB4>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4) => func(valueA1, valueA2)(valueB1, valueB2, valueB3, valueB4));
        }

        public static Action<TA1, TA2, TB1, TB2, TB3, TB4, TB5> Uncurry<TA1, TA2, TB1, TB2, TB3, TB4, TB5>(this Func<TA1, TA2, Action<TB1, TB2, TB3, TB4, TB5>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5) => func(valueA1, valueA2)(valueB1, valueB2, valueB3, valueB4, valueB5));
        }

        public static Action<TA1, TA2, TB1, TB2, TB3, TB4, TB5, TB6> Uncurry<TA1, TA2, TB1, TB2, TB3, TB4, TB5, TB6>(this Func<TA1, TA2, Action<TB1, TB2, TB3, TB4, TB5, TB6>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5, TB6 valueB6) => func(valueA1, valueA2)(valueB1, valueB2, valueB3, valueB4, valueB5, valueB6));
        }

        public static Action<TA1, TA2, TA3> Uncurry<TA1, TA2, TA3>(this Func<TA1, TA2, TA3, Action> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3) => func(valueA1, valueA2, valueA3)());
        }

        public static Action<TA1, TA2, TA3, TB1> Uncurry<TA1, TA2, TA3, TB1>(this Func<TA1, TA2, TA3, Action<TB1>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TB1 valueB1) => func(valueA1, valueA2, valueA3)(valueB1));
        }

        public static Action<TA1, TA2, TA3, TB1, TB2> Uncurry<TA1, TA2, TA3, TB1, TB2>(this Func<TA1, TA2, TA3, Action<TB1, TB2>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TB1 valueB1, TB2 valueB2) => func(valueA1, valueA2, valueA3)(valueB1, valueB2));
        }

        public static Action<TA1, TA2, TA3, TB1, TB2, TB3> Uncurry<TA1, TA2, TA3, TB1, TB2, TB3>(this Func<TA1, TA2, TA3, Action<TB1, TB2, TB3>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TB1 valueB1, TB2 valueB2, TB3 valueB3) => func(valueA1, valueA2, valueA3)(valueB1, valueB2, valueB3));
        }

        public static Action<TA1, TA2, TA3, TB1, TB2, TB3, TB4> Uncurry<TA1, TA2, TA3, TB1, TB2, TB3, TB4>(this Func<TA1, TA2, TA3, Action<TB1, TB2, TB3, TB4>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4) => func(valueA1, valueA2, valueA3)(valueB1, valueB2, valueB3, valueB4));
        }

        public static Action<TA1, TA2, TA3, TB1, TB2, TB3, TB4, TB5> Uncurry<TA1, TA2, TA3, TB1, TB2, TB3, TB4, TB5>(this Func<TA1, TA2, TA3, Action<TB1, TB2, TB3, TB4, TB5>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5) => func(valueA1, valueA2, valueA3)(valueB1, valueB2, valueB3, valueB4, valueB5));
        }

        public static Action<TA1, TA2, TA3, TA4> Uncurry<TA1, TA2, TA3, TA4>(this Func<TA1, TA2, TA3, TA4, Action> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4) => func(valueA1, valueA2, valueA3, valueA4)());
        }

        public static Action<TA1, TA2, TA3, TA4, TB1> Uncurry<TA1, TA2, TA3, TA4, TB1>(this Func<TA1, TA2, TA3, TA4, Action<TB1>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TB1 valueB1) => func(valueA1, valueA2, valueA3, valueA4)(valueB1));
        }

        public static Action<TA1, TA2, TA3, TA4, TB1, TB2> Uncurry<TA1, TA2, TA3, TA4, TB1, TB2>(this Func<TA1, TA2, TA3, TA4, Action<TB1, TB2>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TB1 valueB1, TB2 valueB2) => func(valueA1, valueA2, valueA3, valueA4)(valueB1, valueB2));
        }

        public static Action<TA1, TA2, TA3, TA4, TB1, TB2, TB3> Uncurry<TA1, TA2, TA3, TA4, TB1, TB2, TB3>(this Func<TA1, TA2, TA3, TA4, Action<TB1, TB2, TB3>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TB1 valueB1, TB2 valueB2, TB3 valueB3) => func(valueA1, valueA2, valueA3, valueA4)(valueB1, valueB2, valueB3));
        }

        public static Action<TA1, TA2, TA3, TA4, TB1, TB2, TB3, TB4> Uncurry<TA1, TA2, TA3, TA4, TB1, TB2, TB3, TB4>(this Func<TA1, TA2, TA3, TA4, Action<TB1, TB2, TB3, TB4>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4) => func(valueA1, valueA2, valueA3, valueA4)(valueB1, valueB2, valueB3, valueB4));
        }

        public static Action<TA1, TA2, TA3, TA4, TA5> Uncurry<TA1, TA2, TA3, TA4, TA5>(this Func<TA1, TA2, TA3, TA4, TA5, Action> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5) => func(valueA1, valueA2, valueA3, valueA4, valueA5)());
        }

        public static Action<TA1, TA2, TA3, TA4, TA5, TB1> Uncurry<TA1, TA2, TA3, TA4, TA5, TB1>(this Func<TA1, TA2, TA3, TA4, TA5, Action<TB1>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5, TB1 valueB1) => func(valueA1, valueA2, valueA3, valueA4, valueA5)(valueB1));
        }

        public static Action<TA1, TA2, TA3, TA4, TA5, TB1, TB2> Uncurry<TA1, TA2, TA3, TA4, TA5, TB1, TB2>(this Func<TA1, TA2, TA3, TA4, TA5, Action<TB1, TB2>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5, TB1 valueB1, TB2 valueB2) => func(valueA1, valueA2, valueA3, valueA4, valueA5)(valueB1, valueB2));
        }

        public static Action<TA1, TA2, TA3, TA4, TA5, TB1, TB2, TB3> Uncurry<TA1, TA2, TA3, TA4, TA5, TB1, TB2, TB3>(this Func<TA1, TA2, TA3, TA4, TA5, Action<TB1, TB2, TB3>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5, TB1 valueB1, TB2 valueB2, TB3 valueB3) => func(valueA1, valueA2, valueA3, valueA4, valueA5)(valueB1, valueB2, valueB3));
        }

        public static Action<TA1, TA2, TA3, TA4, TA5, TA6> Uncurry<TA1, TA2, TA3, TA4, TA5, TA6>(this Func<TA1, TA2, TA3, TA4, TA5, TA6, Action> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5, TA6 valueA6) => func(valueA1, valueA2, valueA3, valueA4, valueA5, valueA6)());
        }

        public static Action<TA1, TA2, TA3, TA4, TA5, TA6, TB1> Uncurry<TA1, TA2, TA3, TA4, TA5, TA6, TB1>(this Func<TA1, TA2, TA3, TA4, TA5, TA6, Action<TB1>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5, TA6 valueA6, TB1 valueB1) => func(valueA1, valueA2, valueA3, valueA4, valueA5, valueA6)(valueB1));
        }

        public static Action<TA1, TA2, TA3, TA4, TA5, TA6, TB1, TB2> Uncurry<TA1, TA2, TA3, TA4, TA5, TA6, TB1, TB2>(this Func<TA1, TA2, TA3, TA4, TA5, TA6, Action<TB1, TB2>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5, TA6 valueA6, TB1 valueB1, TB2 valueB2) => func(valueA1, valueA2, valueA3, valueA4, valueA5, valueA6)(valueB1, valueB2));
        }

        public static Action<TA1, TA2, TA3, TA4, TA5, TA6, TA7> Uncurry<TA1, TA2, TA3, TA4, TA5, TA6, TA7>(this Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, Action> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5, TA6 valueA6, TA7 valueA7) => func(valueA1, valueA2, valueA3, valueA4, valueA5, valueA6, valueA7)());
        }

        public static Action<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TB1> Uncurry<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TB1>(this Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, Action<TB1>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5, TA6 valueA6, TA7 valueA7, TB1 valueB1) => func(valueA1, valueA2, valueA3, valueA4, valueA5, valueA6, valueA7)(valueB1));
        }

        public static Action<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8> Uncurry<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8>(this Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, Action> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5, TA6 valueA6, TA7 valueA7, TA8 valueA8) => func(valueA1, valueA2, valueA3, valueA4, valueA5, valueA6, valueA7, valueA8)());
        }

        public static Func<TResult> Uncurry<TResult>(this Func<Func<TResult>> func)
        {
            return New(() => func()());
        }

        public static Func<TB1, TResult> Uncurry<TB1, TResult>(this Func<Func<TB1, TResult>> func)
        {
            return New((TB1 valueB1) => func()(valueB1));
        }

        public static Func<TB1, TB2, TResult> Uncurry<TB1, TB2, TResult>(this Func<Func<TB1, TB2, TResult>> func)
        {
            return New((TB1 valueB1, TB2 valueB2) => func()(valueB1, valueB2));
        }

        public static Func<TB1, TB2, TB3, TResult> Uncurry<TB1, TB2, TB3, TResult>(this Func<Func<TB1, TB2, TB3, TResult>> func)
        {
            return New((TB1 valueB1, TB2 valueB2, TB3 valueB3) => func()(valueB1, valueB2, valueB3));
        }

        public static Func<TB1, TB2, TB3, TB4, TResult> Uncurry<TB1, TB2, TB3, TB4, TResult>(this Func<Func<TB1, TB2, TB3, TB4, TResult>> func)
        {
            return New((TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4) => func()(valueB1, valueB2, valueB3, valueB4));
        }

        public static Func<TB1, TB2, TB3, TB4, TB5, TResult> Uncurry<TB1, TB2, TB3, TB4, TB5, TResult>(this Func<Func<TB1, TB2, TB3, TB4, TB5, TResult>> func)
        {
            return New((TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5) => func()(valueB1, valueB2, valueB3, valueB4, valueB5));
        }

        public static Func<TB1, TB2, TB3, TB4, TB5, TB6, TResult> Uncurry<TB1, TB2, TB3, TB4, TB5, TB6, TResult>(this Func<Func<TB1, TB2, TB3, TB4, TB5, TB6, TResult>> func)
        {
            return New((TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5, TB6 valueB6) => func()(valueB1, valueB2, valueB3, valueB4, valueB5, valueB6));
        }

        public static Func<TB1, TB2, TB3, TB4, TB5, TB6, TB7, TResult> Uncurry<TB1, TB2, TB3, TB4, TB5, TB6, TB7, TResult>(this Func<Func<TB1, TB2, TB3, TB4, TB5, TB6, TB7, TResult>> func)
        {
            return New((TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5, TB6 valueB6, TB7 valueB7) => func()(valueB1, valueB2, valueB3, valueB4, valueB5, valueB6, valueB7));
        }

        public static Func<TB1, TB2, TB3, TB4, TB5, TB6, TB7, TB8, TResult> Uncurry<TB1, TB2, TB3, TB4, TB5, TB6, TB7, TB8, TResult>(this Func<Func<TB1, TB2, TB3, TB4, TB5, TB6, TB7, TB8, TResult>> func)
        {
            return New((TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5, TB6 valueB6, TB7 valueB7, TB8 valueB8) => func()(valueB1, valueB2, valueB3, valueB4, valueB5, valueB6, valueB7, valueB8));
        }

        public static Func<TA1, TResult> Uncurry<TA1, TResult>(this Func<TA1, Func<TResult>> func)
        {
            return New((TA1 valueA1) => func(valueA1)());
        }

        public static Func<TA1, TB1, TResult> Uncurry<TA1, TB1, TResult>(this Func<TA1, Func<TB1, TResult>> func)
        {
            return New((TA1 valueA1, TB1 valueB1) => func(valueA1)(valueB1));
        }

        public static Func<TA1, TB1, TB2, TResult> Uncurry<TA1, TB1, TB2, TResult>(this Func<TA1, Func<TB1, TB2, TResult>> func)
        {
            return New((TA1 valueA1, TB1 valueB1, TB2 valueB2) => func(valueA1)(valueB1, valueB2));
        }

        public static Func<TA1, TB1, TB2, TB3, TResult> Uncurry<TA1, TB1, TB2, TB3, TResult>(this Func<TA1, Func<TB1, TB2, TB3, TResult>> func)
        {
            return New((TA1 valueA1, TB1 valueB1, TB2 valueB2, TB3 valueB3) => func(valueA1)(valueB1, valueB2, valueB3));
        }

        public static Func<TA1, TB1, TB2, TB3, TB4, TResult> Uncurry<TA1, TB1, TB2, TB3, TB4, TResult>(this Func<TA1, Func<TB1, TB2, TB3, TB4, TResult>> func)
        {
            return New((TA1 valueA1, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4) => func(valueA1)(valueB1, valueB2, valueB3, valueB4));
        }

        public static Func<TA1, TB1, TB2, TB3, TB4, TB5, TResult> Uncurry<TA1, TB1, TB2, TB3, TB4, TB5, TResult>(this Func<TA1, Func<TB1, TB2, TB3, TB4, TB5, TResult>> func)
        {
            return New((TA1 valueA1, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5) => func(valueA1)(valueB1, valueB2, valueB3, valueB4, valueB5));
        }

        public static Func<TA1, TB1, TB2, TB3, TB4, TB5, TB6, TResult> Uncurry<TA1, TB1, TB2, TB3, TB4, TB5, TB6, TResult>(this Func<TA1, Func<TB1, TB2, TB3, TB4, TB5, TB6, TResult>> func)
        {
            return New((TA1 valueA1, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5, TB6 valueB6) => func(valueA1)(valueB1, valueB2, valueB3, valueB4, valueB5, valueB6));
        }

        public static Func<TA1, TB1, TB2, TB3, TB4, TB5, TB6, TB7, TResult> Uncurry<TA1, TB1, TB2, TB3, TB4, TB5, TB6, TB7, TResult>(this Func<TA1, Func<TB1, TB2, TB3, TB4, TB5, TB6, TB7, TResult>> func)
        {
            return New((TA1 valueA1, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5, TB6 valueB6, TB7 valueB7) => func(valueA1)(valueB1, valueB2, valueB3, valueB4, valueB5, valueB6, valueB7));
        }

        public static Func<TA1, TA2, TResult> Uncurry<TA1, TA2, TResult>(this Func<TA1, TA2, Func<TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2) => func(valueA1, valueA2)());
        }

        public static Func<TA1, TA2, TB1, TResult> Uncurry<TA1, TA2, TB1, TResult>(this Func<TA1, TA2, Func<TB1, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TB1 valueB1) => func(valueA1, valueA2)(valueB1));
        }

        public static Func<TA1, TA2, TB1, TB2, TResult> Uncurry<TA1, TA2, TB1, TB2, TResult>(this Func<TA1, TA2, Func<TB1, TB2, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TB1 valueB1, TB2 valueB2) => func(valueA1, valueA2)(valueB1, valueB2));
        }

        public static Func<TA1, TA2, TB1, TB2, TB3, TResult> Uncurry<TA1, TA2, TB1, TB2, TB3, TResult>(this Func<TA1, TA2, Func<TB1, TB2, TB3, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TB1 valueB1, TB2 valueB2, TB3 valueB3) => func(valueA1, valueA2)(valueB1, valueB2, valueB3));
        }

        public static Func<TA1, TA2, TB1, TB2, TB3, TB4, TResult> Uncurry<TA1, TA2, TB1, TB2, TB3, TB4, TResult>(this Func<TA1, TA2, Func<TB1, TB2, TB3, TB4, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4) => func(valueA1, valueA2)(valueB1, valueB2, valueB3, valueB4));
        }

        public static Func<TA1, TA2, TB1, TB2, TB3, TB4, TB5, TResult> Uncurry<TA1, TA2, TB1, TB2, TB3, TB4, TB5, TResult>(this Func<TA1, TA2, Func<TB1, TB2, TB3, TB4, TB5, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5) => func(valueA1, valueA2)(valueB1, valueB2, valueB3, valueB4, valueB5));
        }

        public static Func<TA1, TA2, TB1, TB2, TB3, TB4, TB5, TB6, TResult> Uncurry<TA1, TA2, TB1, TB2, TB3, TB4, TB5, TB6, TResult>(this Func<TA1, TA2, Func<TB1, TB2, TB3, TB4, TB5, TB6, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5, TB6 valueB6) => func(valueA1, valueA2)(valueB1, valueB2, valueB3, valueB4, valueB5, valueB6));
        }

        public static Func<TA1, TA2, TA3, TResult> Uncurry<TA1, TA2, TA3, TResult>(this Func<TA1, TA2, TA3, Func<TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3) => func(valueA1, valueA2, valueA3)());
        }

        public static Func<TA1, TA2, TA3, TB1, TResult> Uncurry<TA1, TA2, TA3, TB1, TResult>(this Func<TA1, TA2, TA3, Func<TB1, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TB1 valueB1) => func(valueA1, valueA2, valueA3)(valueB1));
        }

        public static Func<TA1, TA2, TA3, TB1, TB2, TResult> Uncurry<TA1, TA2, TA3, TB1, TB2, TResult>(this Func<TA1, TA2, TA3, Func<TB1, TB2, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TB1 valueB1, TB2 valueB2) => func(valueA1, valueA2, valueA3)(valueB1, valueB2));
        }

        public static Func<TA1, TA2, TA3, TB1, TB2, TB3, TResult> Uncurry<TA1, TA2, TA3, TB1, TB2, TB3, TResult>(this Func<TA1, TA2, TA3, Func<TB1, TB2, TB3, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TB1 valueB1, TB2 valueB2, TB3 valueB3) => func(valueA1, valueA2, valueA3)(valueB1, valueB2, valueB3));
        }

        public static Func<TA1, TA2, TA3, TB1, TB2, TB3, TB4, TResult> Uncurry<TA1, TA2, TA3, TB1, TB2, TB3, TB4, TResult>(this Func<TA1, TA2, TA3, Func<TB1, TB2, TB3, TB4, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4) => func(valueA1, valueA2, valueA3)(valueB1, valueB2, valueB3, valueB4));
        }

        public static Func<TA1, TA2, TA3, TB1, TB2, TB3, TB4, TB5, TResult> Uncurry<TA1, TA2, TA3, TB1, TB2, TB3, TB4, TB5, TResult>(this Func<TA1, TA2, TA3, Func<TB1, TB2, TB3, TB4, TB5, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4, TB5 valueB5) => func(valueA1, valueA2, valueA3)(valueB1, valueB2, valueB3, valueB4, valueB5));
        }

        public static Func<TA1, TA2, TA3, TA4, TResult> Uncurry<TA1, TA2, TA3, TA4, TResult>(this Func<TA1, TA2, TA3, TA4, Func<TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4) => func(valueA1, valueA2, valueA3, valueA4)());
        }

        public static Func<TA1, TA2, TA3, TA4, TB1, TResult> Uncurry<TA1, TA2, TA3, TA4, TB1, TResult>(this Func<TA1, TA2, TA3, TA4, Func<TB1, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TB1 valueB1) => func(valueA1, valueA2, valueA3, valueA4)(valueB1));
        }

        public static Func<TA1, TA2, TA3, TA4, TB1, TB2, TResult> Uncurry<TA1, TA2, TA3, TA4, TB1, TB2, TResult>(this Func<TA1, TA2, TA3, TA4, Func<TB1, TB2, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TB1 valueB1, TB2 valueB2) => func(valueA1, valueA2, valueA3, valueA4)(valueB1, valueB2));
        }

        public static Func<TA1, TA2, TA3, TA4, TB1, TB2, TB3, TResult> Uncurry<TA1, TA2, TA3, TA4, TB1, TB2, TB3, TResult>(this Func<TA1, TA2, TA3, TA4, Func<TB1, TB2, TB3, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TB1 valueB1, TB2 valueB2, TB3 valueB3) => func(valueA1, valueA2, valueA3, valueA4)(valueB1, valueB2, valueB3));
        }

        public static Func<TA1, TA2, TA3, TA4, TB1, TB2, TB3, TB4, TResult> Uncurry<TA1, TA2, TA3, TA4, TB1, TB2, TB3, TB4, TResult>(this Func<TA1, TA2, TA3, TA4, Func<TB1, TB2, TB3, TB4, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TB1 valueB1, TB2 valueB2, TB3 valueB3, TB4 valueB4) => func(valueA1, valueA2, valueA3, valueA4)(valueB1, valueB2, valueB3, valueB4));
        }

        public static Func<TA1, TA2, TA3, TA4, TA5, TResult> Uncurry<TA1, TA2, TA3, TA4, TA5, TResult>(this Func<TA1, TA2, TA3, TA4, TA5, Func<TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5) => func(valueA1, valueA2, valueA3, valueA4, valueA5)());
        }

        public static Func<TA1, TA2, TA3, TA4, TA5, TB1, TResult> Uncurry<TA1, TA2, TA3, TA4, TA5, TB1, TResult>(this Func<TA1, TA2, TA3, TA4, TA5, Func<TB1, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5, TB1 valueB1) => func(valueA1, valueA2, valueA3, valueA4, valueA5)(valueB1));
        }

        public static Func<TA1, TA2, TA3, TA4, TA5, TB1, TB2, TResult> Uncurry<TA1, TA2, TA3, TA4, TA5, TB1, TB2, TResult>(this Func<TA1, TA2, TA3, TA4, TA5, Func<TB1, TB2, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5, TB1 valueB1, TB2 valueB2) => func(valueA1, valueA2, valueA3, valueA4, valueA5)(valueB1, valueB2));
        }

        public static Func<TA1, TA2, TA3, TA4, TA5, TB1, TB2, TB3, TResult> Uncurry<TA1, TA2, TA3, TA4, TA5, TB1, TB2, TB3, TResult>(this Func<TA1, TA2, TA3, TA4, TA5, Func<TB1, TB2, TB3, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5, TB1 valueB1, TB2 valueB2, TB3 valueB3) => func(valueA1, valueA2, valueA3, valueA4, valueA5)(valueB1, valueB2, valueB3));
        }

        public static Func<TA1, TA2, TA3, TA4, TA5, TA6, TResult> Uncurry<TA1, TA2, TA3, TA4, TA5, TA6, TResult>(this Func<TA1, TA2, TA3, TA4, TA5, TA6, Func<TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5, TA6 valueA6) => func(valueA1, valueA2, valueA3, valueA4, valueA5, valueA6)());
        }

        public static Func<TA1, TA2, TA3, TA4, TA5, TA6, TB1, TResult> Uncurry<TA1, TA2, TA3, TA4, TA5, TA6, TB1, TResult>(this Func<TA1, TA2, TA3, TA4, TA5, TA6, Func<TB1, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5, TA6 valueA6, TB1 valueB1) => func(valueA1, valueA2, valueA3, valueA4, valueA5, valueA6)(valueB1));
        }

        public static Func<TA1, TA2, TA3, TA4, TA5, TA6, TB1, TB2, TResult> Uncurry<TA1, TA2, TA3, TA4, TA5, TA6, TB1, TB2, TResult>(this Func<TA1, TA2, TA3, TA4, TA5, TA6, Func<TB1, TB2, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5, TA6 valueA6, TB1 valueB1, TB2 valueB2) => func(valueA1, valueA2, valueA3, valueA4, valueA5, valueA6)(valueB1, valueB2));
        }

        public static Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TResult> Uncurry<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TResult>(this Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, Func<TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5, TA6 valueA6, TA7 valueA7) => func(valueA1, valueA2, valueA3, valueA4, valueA5, valueA6, valueA7)());
        }

        public static Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TB1, TResult> Uncurry<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TB1, TResult>(this Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, Func<TB1, TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5, TA6 valueA6, TA7 valueA7, TB1 valueB1) => func(valueA1, valueA2, valueA3, valueA4, valueA5, valueA6, valueA7)(valueB1));
        }

        public static Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TResult> Uncurry<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, TResult>(this Func<TA1, TA2, TA3, TA4, TA5, TA6, TA7, TA8, Func<TResult>> func)
        {
            return New((TA1 valueA1, TA2 valueA2, TA3 valueA3, TA4 valueA4, TA5 valueA5, TA6 valueA6, TA7 valueA7, TA8 valueA8) => func(valueA1, valueA2, valueA3, valueA4, valueA5, valueA6, valueA7, valueA8)());
        }
    }
}

#endif