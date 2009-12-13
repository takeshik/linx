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

using Achiral;

namespace XSpect
{
    partial class Lambda
    {
        public static TOut InvokeMulti<TOut>(this ActionOut1<TOut> action)
        {
            TOut value;
            action(out value);
            return value;
        }

        public static TOut InvokeMulti<T, TOut>(this ActionOut1<T, TOut> action, T arg)
        {
            TOut value;
            action(arg, out value);
            return value;
        }

        public static TOut InvokeMulti<T1, T2, TOut>(this ActionOut1<T1, T2, TOut> action, T1 arg1, T2 arg2)
        {
            TOut value;
            action(arg1, arg2, out value);
            return value;
        }

        public static TOut InvokeMulti<T1, T2, T3, TOut>(this ActionOut1<T1, T2, T3, TOut> action, T1 arg1, T2 arg2, T3 arg3)
        {
            TOut value;
            action(arg1, arg2, arg3, out value);
            return value;
        }

        public static TOut InvokeMulti<T1, T2, T3, T4, TOut>(this ActionOut1<T1, T2, T3, T4, TOut> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            TOut value;
            action(arg1, arg2, arg3, arg4, out value);
            return value;
        }

        public static TOut InvokeMulti<T1, T2, T3, T4, T5, TOut>(this ActionOut1<T1, T2, T3, T4, T5, TOut> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            TOut value;
            action(arg1, arg2, arg3, arg4, arg5, out value);
            return value;
        }

        public static TOut InvokeMulti<T1, T2, T3, T4, T5, T6, TOut>(this ActionOut1<T1, T2, T3, T4, T5, T6, TOut> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            TOut value;
            action(arg1, arg2, arg3, arg4, arg5, arg6, out value);
            return value;
        }

        public static TOut InvokeMulti<T1, T2, T3, T4, T5, T6, T7, TOut>(this ActionOut1<T1, T2, T3, T4, T5, T6, T7, TOut> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            TOut value;
            action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, out value);
            return value;
        }

        public static Tuple<TOut1, TOut2> InvokeMulti<TOut1, TOut2>(this ActionOut2<TOut1, TOut2> action)
        {
            TOut1 value1;
            TOut2 value2;
            action(out value1, out value2);
            return Make.Tuple(value1, value2);
        }

        public static Tuple<TOut1, TOut2> InvokeMulti<T, TOut1, TOut2>(this ActionOut2<T, TOut1, TOut2> action, T arg)
        {
            TOut1 value1;
            TOut2 value2;
            action(arg, out value1, out value2);
            return Make.Tuple(value1, value2);
        }

        public static Tuple<TOut1, TOut2> InvokeMulti<T1, T2, TOut1, TOut2>(this ActionOut2<T1, T2, TOut1, TOut2> action, T1 arg1, T2 arg2)
        {
            TOut1 value1;
            TOut2 value2;
            action(arg1, arg2, out value1, out value2);
            return Make.Tuple(value1, value2);
        }

        public static Tuple<TOut1, TOut2> InvokeMulti<T1, T2, T3, TOut1, TOut2>(this ActionOut2<T1, T2, T3, TOut1, TOut2> action, T1 arg1, T2 arg2, T3 arg3)
        {
            TOut1 value1;
            TOut2 value2;
            action(arg1, arg2, arg3, out value1, out value2);
            return Make.Tuple(value1, value2);
        }

        public static Tuple<TOut1, TOut2> InvokeMulti<T1, T2, T3, T4, TOut1, TOut2>(this ActionOut2<T1, T2, T3, T4, TOut1, TOut2> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            TOut1 value1;
            TOut2 value2;
            action(arg1, arg2, arg3, arg4, out value1, out value2);
            return Make.Tuple(value1, value2);
        }

        public static Tuple<TOut1, TOut2> InvokeMulti<T1, T2, T3, T4, T5, TOut1, TOut2>(this ActionOut2<T1, T2, T3, T4, T5, TOut1, TOut2> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            TOut1 value1;
            TOut2 value2;
            action(arg1, arg2, arg3, arg4, arg5, out value1, out value2);
            return Make.Tuple(value1, value2);
        }

        public static Tuple<TOut1, TOut2> InvokeMulti<T1, T2, T3, T4, T5, T6, TOut1, TOut2>(this ActionOut2<T1, T2, T3, T4, T5, T6, TOut1, TOut2> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            TOut1 value1;
            TOut2 value2;
            action(arg1, arg2, arg3, arg4, arg5, arg6, out value1, out value2);
            return Make.Tuple(value1, value2);
        }

        public static Tuple<TOut1, TOut2, TOut3> InvokeMulti<TOut1, TOut2, TOut3>(this ActionOut3<TOut1, TOut2, TOut3> action)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            action(out value1, out value2, out value3);
            return Make.Tuple(value1, value2, value3);
        }

        public static Tuple<TOut1, TOut2, TOut3> InvokeMulti<T, TOut1, TOut2, TOut3>(this ActionOut3<T, TOut1, TOut2, TOut3> action, T arg)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            action(arg, out value1, out value2, out value3);
            return Make.Tuple(value1, value2, value3);
        }

        public static Tuple<TOut1, TOut2, TOut3> InvokeMulti<T1, T2, TOut1, TOut2, TOut3>(this ActionOut3<T1, T2, TOut1, TOut2, TOut3> action, T1 arg1, T2 arg2)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            action(arg1, arg2, out value1, out value2, out value3);
            return Make.Tuple(value1, value2, value3);
        }

        public static Tuple<TOut1, TOut2, TOut3> InvokeMulti<T1, T2, T3, TOut1, TOut2, TOut3>(this ActionOut3<T1, T2, T3, TOut1, TOut2, TOut3> action, T1 arg1, T2 arg2, T3 arg3)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            action(arg1, arg2, arg3, out value1, out value2, out value3);
            return Make.Tuple(value1, value2, value3);
        }

        public static Tuple<TOut1, TOut2, TOut3> InvokeMulti<T1, T2, T3, T4, TOut1, TOut2, TOut3>(this ActionOut3<T1, T2, T3, T4, TOut1, TOut2, TOut3> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            action(arg1, arg2, arg3, arg4, out value1, out value2, out value3);
            return Make.Tuple(value1, value2, value3);
        }

        public static Tuple<TOut1, TOut2, TOut3> InvokeMulti<T1, T2, T3, T4, T5, TOut1, TOut2, TOut3>(this ActionOut3<T1, T2, T3, T4, T5, TOut1, TOut2, TOut3> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            action(arg1, arg2, arg3, arg4, arg5, out value1, out value2, out value3);
            return Make.Tuple(value1, value2, value3);
        }

        public static Tuple<TOut1, TOut2, TOut3, TOut4> InvokeMulti<TOut1, TOut2, TOut3, TOut4>(this ActionOut4<TOut1, TOut2, TOut3, TOut4> action)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            action(out value1, out value2, out value3, out value4);
            return Make.Tuple(value1, value2, value3, value4);
        }

        public static Tuple<TOut1, TOut2, TOut3, TOut4> InvokeMulti<T, TOut1, TOut2, TOut3, TOut4>(this ActionOut4<T, TOut1, TOut2, TOut3, TOut4> action, T arg)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            action(arg, out value1, out value2, out value3, out value4);
            return Make.Tuple(value1, value2, value3, value4);
        }

        public static Tuple<TOut1, TOut2, TOut3, TOut4> InvokeMulti<T1, T2, TOut1, TOut2, TOut3, TOut4>(this ActionOut4<T1, T2, TOut1, TOut2, TOut3, TOut4> action, T1 arg1, T2 arg2)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            action(arg1, arg2, out value1, out value2, out value3, out value4);
            return Make.Tuple(value1, value2, value3, value4);
        }

        public static Tuple<TOut1, TOut2, TOut3, TOut4> InvokeMulti<T1, T2, T3, TOut1, TOut2, TOut3, TOut4>(this ActionOut4<T1, T2, T3, TOut1, TOut2, TOut3, TOut4> action, T1 arg1, T2 arg2, T3 arg3)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            action(arg1, arg2, arg3, out value1, out value2, out value3, out value4);
            return Make.Tuple(value1, value2, value3, value4);
        }

        public static Tuple<TOut1, TOut2, TOut3, TOut4> InvokeMulti<T1, T2, T3, T4, TOut1, TOut2, TOut3, TOut4>(this ActionOut4<T1, T2, T3, T4, TOut1, TOut2, TOut3, TOut4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            action(arg1, arg2, arg3, arg4, out value1, out value2, out value3, out value4);
            return Make.Tuple(value1, value2, value3, value4);
        }

        public static Tuple<TOut1, TOut2, TOut3, TOut4, TOut5> InvokeMulti<TOut1, TOut2, TOut3, TOut4, TOut5>(this ActionOut5<TOut1, TOut2, TOut3, TOut4, TOut5> action)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            TOut5 value5;
            action(out value1, out value2, out value3, out value4, out value5);
            return Make.Tuple(value1, value2, value3, value4, value5);
        }

        public static Tuple<TOut1, TOut2, TOut3, TOut4, TOut5> InvokeMulti<T, TOut1, TOut2, TOut3, TOut4, TOut5>(this ActionOut5<T, TOut1, TOut2, TOut3, TOut4, TOut5> action, T arg)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            TOut5 value5;
            action(arg, out value1, out value2, out value3, out value4, out value5);
            return Make.Tuple(value1, value2, value3, value4, value5);
        }

        public static Tuple<TOut1, TOut2, TOut3, TOut4, TOut5> InvokeMulti<T1, T2, TOut1, TOut2, TOut3, TOut4, TOut5>(this ActionOut5<T1, T2, TOut1, TOut2, TOut3, TOut4, TOut5> action, T1 arg1, T2 arg2)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            TOut5 value5;
            action(arg1, arg2, out value1, out value2, out value3, out value4, out value5);
            return Make.Tuple(value1, value2, value3, value4, value5);
        }

        public static Tuple<TOut1, TOut2, TOut3, TOut4, TOut5> InvokeMulti<T1, T2, T3, TOut1, TOut2, TOut3, TOut4, TOut5>(this ActionOut5<T1, T2, T3, TOut1, TOut2, TOut3, TOut4, TOut5> action, T1 arg1, T2 arg2, T3 arg3)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            TOut5 value5;
            action(arg1, arg2, arg3, out value1, out value2, out value3, out value4, out value5);
            return Make.Tuple(value1, value2, value3, value4, value5);
        }

        public static Tuple<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6> InvokeMulti<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6>(this ActionOut6<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6> action)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            TOut5 value5;
            TOut6 value6;
            action(out value1, out value2, out value3, out value4, out value5, out value6);
            return Make.Tuple(value1, value2, value3, value4, value5, value6);
        }

        public static Tuple<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6> InvokeMulti<T, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6>(this ActionOut6<T, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6> action, T arg)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            TOut5 value5;
            TOut6 value6;
            action(arg, out value1, out value2, out value3, out value4, out value5, out value6);
            return Make.Tuple(value1, value2, value3, value4, value5, value6);
        }

        public static Tuple<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6> InvokeMulti<T1, T2, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6>(this ActionOut6<T1, T2, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6> action, T1 arg1, T2 arg2)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            TOut5 value5;
            TOut6 value6;
            action(arg1, arg2, out value1, out value2, out value3, out value4, out value5, out value6);
            return Make.Tuple(value1, value2, value3, value4, value5, value6);
        }

        public static Tuple<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7> InvokeMulti<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7>(this ActionOut7<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7> action)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            TOut5 value5;
            TOut6 value6;
            TOut7 value7;
            action(out value1, out value2, out value3, out value4, out value5, out value6, out value7);
            return Make.Tuple(value1, value2, value3, value4, value5, value6, value7);
        }

        public static Tuple<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7> InvokeMulti<T, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7>(this ActionOut7<T, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7> action, T arg)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            TOut5 value5;
            TOut6 value6;
            TOut7 value7;
            action(arg, out value1, out value2, out value3, out value4, out value5, out value6, out value7);
            return Make.Tuple(value1, value2, value3, value4, value5, value6, value7);
        }

        public static Tuple<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7, TOut8> InvokeMulti<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7, TOut8>(this ActionOut8<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7, TOut8> action)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            TOut5 value5;
            TOut6 value6;
            TOut7 value7;
            TOut8 value8;
            action(out value1, out value2, out value3, out value4, out value5, out value6, out value7, out value8);
            return Make.Tuple(value1, value2, value3, value4, value5, value6, value7, value8);
        }

        public static Tuple<TReturn, TOut> InvokeMulti<TOut, TReturn>(this FuncOut1<TOut, TReturn> func)
        {
            TOut value;
            return Make.Tuple(func(out value), value);
        }

        public static Tuple<TReturn, TOut> InvokeMulti<T, TOut, TReturn>(this FuncOut1<T, TOut, TReturn> func, T arg)
        {
            TOut value;
            return Make.Tuple(func(arg, out value), value);
        }

        public static Tuple<TReturn, TOut> InvokeMulti<T1, T2, TOut, TReturn>(this FuncOut1<T1, T2, TOut, TReturn> func, T1 arg1, T2 arg2)
        {
            TOut value;
            return Make.Tuple(func(arg1, arg2, out value), value);
        }

        public static Tuple<TReturn, TOut> InvokeMulti<T1, T2, T3, TOut, TReturn>(this FuncOut1<T1, T2, T3, TOut, TReturn> func, T1 arg1, T2 arg2, T3 arg3)
        {
            TOut value;
            return Make.Tuple(func(arg1, arg2, arg3, out value), value);
        }

        public static Tuple<TReturn, TOut> InvokeMulti<T1, T2, T3, T4, TOut, TReturn>(this FuncOut1<T1, T2, T3, T4, TOut, TReturn> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            TOut value;
            return Make.Tuple(func(arg1, arg2, arg3, arg4, out value), value);
        }

        public static Tuple<TReturn, TOut> InvokeMulti<T1, T2, T3, T4, T5, TOut, TReturn>(this FuncOut1<T1, T2, T3, T4, T5, TOut, TReturn> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            TOut value;
            return Make.Tuple(func(arg1, arg2, arg3, arg4, arg5, out value), value);
        }

        public static Tuple<TReturn, TOut> InvokeMulti<T1, T2, T3, T4, T5, T6, TOut, TReturn>(this FuncOut1<T1, T2, T3, T4, T5, T6, TOut, TReturn> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            TOut value;
            return Make.Tuple(func(arg1, arg2, arg3, arg4, arg5, arg6, out value), value);
        }

        public static Tuple<TReturn, TOut> InvokeMulti<T1, T2, T3, T4, T5, T6, T7, TOut, TReturn>(this FuncOut1<T1, T2, T3, T4, T5, T6, T7, TOut, TReturn> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            TOut value;
            return Make.Tuple(func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, out value), value);
        }

        public static Tuple<TReturn, TOut1, TOut2> InvokeMulti<TOut1, TOut2, TReturn>(this FuncOut2<TOut1, TOut2, TReturn> func)
        {
            TOut1 value1;
            TOut2 value2;
            return Make.Tuple(func(out value1, out value2), value1, value2);
        }

        public static Tuple<TReturn, TOut1, TOut2> InvokeMulti<T, TOut1, TOut2, TReturn>(this FuncOut2<T, TOut1, TOut2, TReturn> func, T arg)
        {
            TOut1 value1;
            TOut2 value2;
            return Make.Tuple(func(arg, out value1, out value2), value1, value2);
        }

        public static Tuple<TReturn, TOut1, TOut2> InvokeMulti<T1, T2, TOut1, TOut2, TReturn>(this FuncOut2<T1, T2, TOut1, TOut2, TReturn> func, T1 arg1, T2 arg2)
        {
            TOut1 value1;
            TOut2 value2;
            return Make.Tuple(func(arg1, arg2, out value1, out value2), value1, value2);
        }

        public static Tuple<TReturn, TOut1, TOut2> InvokeMulti<T1, T2, T3, TOut1, TOut2, TReturn>(this FuncOut2<T1, T2, T3, TOut1, TOut2, TReturn> func, T1 arg1, T2 arg2, T3 arg3)
        {
            TOut1 value1;
            TOut2 value2;
            return Make.Tuple(func(arg1, arg2, arg3, out value1, out value2), value1, value2);
        }

        public static Tuple<TReturn, TOut1, TOut2> InvokeMulti<T1, T2, T3, T4, TOut1, TOut2, TReturn>(this FuncOut2<T1, T2, T3, T4, TOut1, TOut2, TReturn> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            TOut1 value1;
            TOut2 value2;
            return Make.Tuple(func(arg1, arg2, arg3, arg4, out value1, out value2), value1, value2);
        }

        public static Tuple<TReturn, TOut1, TOut2> InvokeMulti<T1, T2, T3, T4, T5, TOut1, TOut2, TReturn>(this FuncOut2<T1, T2, T3, T4, T5, TOut1, TOut2, TReturn> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            TOut1 value1;
            TOut2 value2;
            return Make.Tuple(func(arg1, arg2, arg3, arg4, arg5, out value1, out value2), value1, value2);
        }

        public static Tuple<TReturn, TOut1, TOut2> InvokeMulti<T1, T2, T3, T4, T5, T6, TOut1, TOut2, TReturn>(this FuncOut2<T1, T2, T3, T4, T5, T6, TOut1, TOut2, TReturn> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            TOut1 value1;
            TOut2 value2;
            return Make.Tuple(func(arg1, arg2, arg3, arg4, arg5, arg6, out value1, out value2), value1, value2);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3> InvokeMulti<TOut1, TOut2, TOut3, TReturn>(this FuncOut3<TOut1, TOut2, TOut3, TReturn> func)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            return Make.Tuple(func(out value1, out value2, out value3), value1, value2, value3);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3> InvokeMulti<T, TOut1, TOut2, TOut3, TReturn>(this FuncOut3<T, TOut1, TOut2, TOut3, TReturn> func, T arg)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            return Make.Tuple(func(arg, out value1, out value2, out value3), value1, value2, value3);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3> InvokeMulti<T1, T2, TOut1, TOut2, TOut3, TReturn>(this FuncOut3<T1, T2, TOut1, TOut2, TOut3, TReturn> func, T1 arg1, T2 arg2)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            return Make.Tuple(func(arg1, arg2, out value1, out value2, out value3), value1, value2, value3);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3> InvokeMulti<T1, T2, T3, TOut1, TOut2, TOut3, TReturn>(this FuncOut3<T1, T2, T3, TOut1, TOut2, TOut3, TReturn> func, T1 arg1, T2 arg2, T3 arg3)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            return Make.Tuple(func(arg1, arg2, arg3, out value1, out value2, out value3), value1, value2, value3);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3> InvokeMulti<T1, T2, T3, T4, TOut1, TOut2, TOut3, TReturn>(this FuncOut3<T1, T2, T3, T4, TOut1, TOut2, TOut3, TReturn> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            return Make.Tuple(func(arg1, arg2, arg3, arg4, out value1, out value2, out value3), value1, value2, value3);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3> InvokeMulti<T1, T2, T3, T4, T5, TOut1, TOut2, TOut3, TReturn>(this FuncOut3<T1, T2, T3, T4, T5, TOut1, TOut2, TOut3, TReturn> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            return Make.Tuple(func(arg1, arg2, arg3, arg4, arg5, out value1, out value2, out value3), value1, value2, value3);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3, TOut4> InvokeMulti<TOut1, TOut2, TOut3, TOut4, TReturn>(this FuncOut4<TOut1, TOut2, TOut3, TOut4, TReturn> func)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            return Make.Tuple(func(out value1, out value2, out value3, out value4), value1, value2, value3, value4);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3, TOut4> InvokeMulti<T, TOut1, TOut2, TOut3, TOut4, TReturn>(this FuncOut4<T, TOut1, TOut2, TOut3, TOut4, TReturn> func, T arg)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            return Make.Tuple(func(arg, out value1, out value2, out value3, out value4), value1, value2, value3, value4);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3, TOut4> InvokeMulti<T1, T2, TOut1, TOut2, TOut3, TOut4, TReturn>(this FuncOut4<T1, T2, TOut1, TOut2, TOut3, TOut4, TReturn> func, T1 arg1, T2 arg2)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            return Make.Tuple(func(arg1, arg2, out value1, out value2, out value3, out value4), value1, value2, value3, value4);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3, TOut4> InvokeMulti<T1, T2, T3, TOut1, TOut2, TOut3, TOut4, TReturn>(this FuncOut4<T1, T2, T3, TOut1, TOut2, TOut3, TOut4, TReturn> func, T1 arg1, T2 arg2, T3 arg3)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            return Make.Tuple(func(arg1, arg2, arg3, out value1, out value2, out value3, out value4), value1, value2, value3, value4);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3, TOut4> InvokeMulti<T1, T2, T3, T4, TOut1, TOut2, TOut3, TOut4, TReturn>(this FuncOut4<T1, T2, T3, T4, TOut1, TOut2, TOut3, TOut4, TReturn> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            return Make.Tuple(func(arg1, arg2, arg3, arg4, out value1, out value2, out value3, out value4), value1, value2, value3, value4);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3, TOut4, TOut5> InvokeMulti<TOut1, TOut2, TOut3, TOut4, TOut5, TReturn>(this FuncOut5<TOut1, TOut2, TOut3, TOut4, TOut5, TReturn> func)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            TOut5 value5;
            return Make.Tuple(func(out value1, out value2, out value3, out value4, out value5), value1, value2, value3, value4, value5);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3, TOut4, TOut5> InvokeMulti<T, TOut1, TOut2, TOut3, TOut4, TOut5, TReturn>(this FuncOut5<T, TOut1, TOut2, TOut3, TOut4, TOut5, TReturn> func, T arg)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            TOut5 value5;
            return Make.Tuple(func(arg, out value1, out value2, out value3, out value4, out value5), value1, value2, value3, value4, value5);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3, TOut4, TOut5> InvokeMulti<T1, T2, TOut1, TOut2, TOut3, TOut4, TOut5, TReturn>(this FuncOut5<T1, T2, TOut1, TOut2, TOut3, TOut4, TOut5, TReturn> func, T1 arg1, T2 arg2)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            TOut5 value5;
            return Make.Tuple(func(arg1, arg2, out value1, out value2, out value3, out value4, out value5), value1, value2, value3, value4, value5);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3, TOut4, TOut5> InvokeMulti<T1, T2, T3, TOut1, TOut2, TOut3, TOut4, TOut5, TReturn>(this FuncOut5<T1, T2, T3, TOut1, TOut2, TOut3, TOut4, TOut5, TReturn> func, T1 arg1, T2 arg2, T3 arg3)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            TOut5 value5;
            return Make.Tuple(func(arg1, arg2, arg3, out value1, out value2, out value3, out value4, out value5), value1, value2, value3, value4, value5);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6> InvokeMulti<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TReturn>(this FuncOut6<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TReturn> func)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            TOut5 value5;
            TOut6 value6;
            return Make.Tuple(func(out value1, out value2, out value3, out value4, out value5, out value6), value1, value2, value3, value4, value5, value6);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6> InvokeMulti<T, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TReturn>(this FuncOut6<T, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TReturn> func, T arg)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            TOut5 value5;
            TOut6 value6;
            return Make.Tuple(func(arg, out value1, out value2, out value3, out value4, out value5, out value6), value1, value2, value3, value4, value5, value6);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6> InvokeMulti<T1, T2, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TReturn>(this FuncOut6<T1, T2, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TReturn> func, T1 arg1, T2 arg2)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            TOut5 value5;
            TOut6 value6;
            return Make.Tuple(func(arg1, arg2, out value1, out value2, out value3, out value4, out value5, out value6), value1, value2, value3, value4, value5, value6);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7> InvokeMulti<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7, TReturn>(this FuncOut7<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7, TReturn> func)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            TOut5 value5;
            TOut6 value6;
            TOut7 value7;
            return Make.Tuple(func(out value1, out value2, out value3, out value4, out value5, out value6, out value7), value1, value2, value3, value4, value5, value6, value7);
        }

        public static Tuple<TReturn, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7> InvokeMulti<T, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7, TReturn>(this FuncOut7<T, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7, TReturn> func, T arg)
        {
            TOut1 value1;
            TOut2 value2;
            TOut3 value3;
            TOut4 value4;
            TOut5 value5;
            TOut6 value6;
            TOut7 value7;
            return Make.Tuple(func(arg, out value1, out value2, out value3, out value4, out value5, out value6, out value7), value1, value2, value3, value4, value5, value6, value7);
        }
    }
}