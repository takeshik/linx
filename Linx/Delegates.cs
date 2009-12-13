// -*- mode: csharp; encoding: utf-8; tab-width: 4; c-basic-offset: 4; indent-tabs-mode: nil; -*-
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
// $Id: d6b10c5725bb43e99e47189bd0cabe1c595119b8 $
/* Linx
 *   Library that Integrates .NET with eXtremes
 * Copyright c 2008-2009 Takeshi KIRIYA, XSpect Project <takeshik@users.sf.net>
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

namespace XSpect
{
    public delegate void ActionRef1<TRef>(ref TRef argRef);

    public delegate void ActionRef1<T, TRef>(T arg1, ref TRef argRef);

    public delegate void ActionRef2<TRef1, TRef2>(ref TRef1 argRef1, ref TRef2 argRef2);

    public delegate void ActionRef1<T1, T2, TRef>(T1 arg1, T2 arg2, ref TRef argRef);

    public delegate void ActionRef2<T, TRef1, TRef2>(T arg1, ref TRef1 argRef1, ref TRef2 argRef2);

    public delegate void ActionRef3<TRef1, TRef2, TRef3>(ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3);

    public delegate void ActionRef1<T1, T2, T3, TRef>(T1 arg1, T2 arg2, T3 arg3, ref TRef argRef);

    public delegate void ActionRef2<T1, T2, TRef1, TRef2>(T1 arg1, T2 arg2, ref TRef1 argRef1, ref TRef2 argRef2);

    public delegate void ActionRef3<T, TRef1, TRef2, TRef3>(T arg1, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3);

    public delegate void ActionRef4<TRef1, TRef2, TRef3, TRef4>(ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4);

    public delegate void ActionRef1<T1, T2, T3, T4, TRef>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, ref TRef argRef);

    public delegate void ActionRef2<T1, T2, T3, TRef1, TRef2>(T1 arg1, T2 arg2, T3 arg3, ref TRef1 argRef1, ref TRef2 argRef2);

    public delegate void ActionRef3<T1, T2, TRef1, TRef2, TRef3>(T1 arg1, T2 arg2, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3);

    public delegate void ActionRef4<T, TRef1, TRef2, TRef3, TRef4>(T arg1, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4);

    public delegate void ActionRef5<TRef1, TRef2, TRef3, TRef4, TRef5>(ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5);

    public delegate void ActionRef1<T1, T2, T3, T4, T5, TRef>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, ref TRef argRef);

    public delegate void ActionRef2<T1, T2, T3, T4, TRef1, TRef2>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, ref TRef1 argRef1, ref TRef2 argRef2);

    public delegate void ActionRef3<T1, T2, T3, TRef1, TRef2, TRef3>(T1 arg1, T2 arg2, T3 arg3, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3);

    public delegate void ActionRef4<T1, T2, TRef1, TRef2, TRef3, TRef4>(T1 arg1, T2 arg2, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4);

    public delegate void ActionRef5<T, TRef1, TRef2, TRef3, TRef4, TRef5>(T arg1, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5);

    public delegate void ActionRef6<TRef1, TRef2, TRef3, TRef4, TRef5, TRef6>(ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5, ref TRef6 argRef6);

    public delegate void ActionRef1<T1, T2, T3, T4, T5, T6, TRef>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, ref TRef argRef);

    public delegate void ActionRef2<T1, T2, T3, T4, T5, TRef1, TRef2>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, ref TRef1 argRef1, ref TRef2 argRef2);

    public delegate void ActionRef3<T1, T2, T3, T4, TRef1, TRef2, TRef3>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3);

    public delegate void ActionRef4<T1, T2, T3, TRef1, TRef2, TRef3, TRef4>(T1 arg1, T2 arg2, T3 arg3, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4);

    public delegate void ActionRef5<T1, T2, TRef1, TRef2, TRef3, TRef4, TRef5>(T1 arg1, T2 arg2, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5);

    public delegate void ActionRef6<T, TRef1, TRef2, TRef3, TRef4, TRef5, TRef6>(T arg1, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5, ref TRef6 argRef6);

    public delegate void ActionRef7<TRef1, TRef2, TRef3, TRef4, TRef5, TRef6, TRef7>(ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5, ref TRef6 argRef6, ref TRef7 argRef7);

    public delegate void ActionRef1<T1, T2, T3, T4, T5, T6, T7, TRef>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, ref TRef argRef);

    public delegate void ActionRef2<T1, T2, T3, T4, T5, T6, TRef1, TRef2>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, ref TRef1 argRef1, ref TRef2 argRef2);

    public delegate void ActionRef3<T1, T2, T3, T4, T5, TRef1, TRef2, TRef3>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3);

    public delegate void ActionRef4<T1, T2, T3, T4, TRef1, TRef2, TRef3, TRef4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4);

    public delegate void ActionRef5<T1, T2, T3, TRef1, TRef2, TRef3, TRef4, TRef5>(T1 arg1, T2 arg2, T3 arg3, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5);

    public delegate void ActionRef6<T1, T2, TRef1, TRef2, TRef3, TRef4, TRef5, TRef6>(T1 arg1, T2 arg2, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5, ref TRef6 argRef6);

    public delegate void ActionRef7<T, TRef1, TRef2, TRef3, TRef4, TRef5, TRef6, TRef7>(T arg1, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5, ref TRef6 argRef6, ref TRef7 argRef7);

    public delegate void ActionRef8<TRef1, TRef2, TRef3, TRef4, TRef5, TRef6, TRef7, TRef8>(ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5, ref TRef6 argRef6, ref TRef7 argRef7, ref TRef8 argRef8);

    public delegate void ActionOut1<TOut>(out TOut argRef);

    public delegate void ActionOut1<T, TOut>(T arg1, out TOut argRef);

    public delegate void ActionOut2<TOut1, TOut2>(out TOut1 argOut1, out TOut2 argOut2);

    public delegate void ActionOut1<T1, T2, TOut>(T1 arg1, T2 arg2, out TOut argRef);

    public delegate void ActionOut2<T, TOut1, TOut2>(T arg1, out TOut1 argOut1, out TOut2 argOut2);

    public delegate void ActionOut3<TOut1, TOut2, TOut3>(out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3);

    public delegate void ActionOut1<T1, T2, T3, TOut>(T1 arg1, T2 arg2, T3 arg3, out TOut argRef);

    public delegate void ActionOut2<T1, T2, TOut1, TOut2>(T1 arg1, T2 arg2, out TOut1 argOut1, out TOut2 argOut2);

    public delegate void ActionOut3<T, TOut1, TOut2, TOut3>(T arg1, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3);

    public delegate void ActionOut4<TOut1, TOut2, TOut3, TOut4>(out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4);

    public delegate void ActionOut1<T1, T2, T3, T4, TOut>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, out TOut argRef);

    public delegate void ActionOut2<T1, T2, T3, TOut1, TOut2>(T1 arg1, T2 arg2, T3 arg3, out TOut1 argOut1, out TOut2 argOut2);

    public delegate void ActionOut3<T1, T2, TOut1, TOut2, TOut3>(T1 arg1, T2 arg2, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3);

    public delegate void ActionOut4<T, TOut1, TOut2, TOut3, TOut4>(T arg1, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4);

    public delegate void ActionOut5<TOut1, TOut2, TOut3, TOut4, TOut5>(out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5);

    public delegate void ActionOut1<T1, T2, T3, T4, T5, TOut>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, out TOut argRef);

    public delegate void ActionOut2<T1, T2, T3, T4, TOut1, TOut2>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, out TOut1 argOut1, out TOut2 argOut2);

    public delegate void ActionOut3<T1, T2, T3, TOut1, TOut2, TOut3>(T1 arg1, T2 arg2, T3 arg3, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3);

    public delegate void ActionOut4<T1, T2, TOut1, TOut2, TOut3, TOut4>(T1 arg1, T2 arg2, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4);

    public delegate void ActionOut5<T, TOut1, TOut2, TOut3, TOut4, TOut5>(T arg1, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5);

    public delegate void ActionOut6<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6>(out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5, out TOut6 argOut6);

    public delegate void ActionOut1<T1, T2, T3, T4, T5, T6, TOut>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, out TOut argRef);

    public delegate void ActionOut2<T1, T2, T3, T4, T5, TOut1, TOut2>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, out TOut1 argOut1, out TOut2 argOut2);

    public delegate void ActionOut3<T1, T2, T3, T4, TOut1, TOut2, TOut3>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3);

    public delegate void ActionOut4<T1, T2, T3, TOut1, TOut2, TOut3, TOut4>(T1 arg1, T2 arg2, T3 arg3, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4);

    public delegate void ActionOut5<T1, T2, TOut1, TOut2, TOut3, TOut4, TOut5>(T1 arg1, T2 arg2, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5);

    public delegate void ActionOut6<T, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6>(T arg1, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5, out TOut6 argOut6);

    public delegate void ActionOut7<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7>(out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5, out TOut6 argOut6, out TOut7 argOut7);

    public delegate void ActionOut1<T1, T2, T3, T4, T5, T6, T7, TOut>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, out TOut argRef);

    public delegate void ActionOut2<T1, T2, T3, T4, T5, T6, TOut1, TOut2>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, out TOut1 argOut1, out TOut2 argOut2);

    public delegate void ActionOut3<T1, T2, T3, T4, T5, TOut1, TOut2, TOut3>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3);

    public delegate void ActionOut4<T1, T2, T3, T4, TOut1, TOut2, TOut3, TOut4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4);

    public delegate void ActionOut5<T1, T2, T3, TOut1, TOut2, TOut3, TOut4, TOut5>(T1 arg1, T2 arg2, T3 arg3, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5);

    public delegate void ActionOut6<T1, T2, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6>(T1 arg1, T2 arg2, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5, out TOut6 argOut6);

    public delegate void ActionOut7<T, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7>(T arg1, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5, out TOut6 argOut6, out TOut7 argOut7);

    public delegate void ActionOut8<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7, TOut8>(out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5, out TOut6 argOut6, out TOut7 argOut7, out TOut8 argOut8);

    public delegate TReturn FuncRef1<TRef, TReturn>(ref TRef argRef);

    public delegate TReturn FuncRef1<T, TRef, TReturn>(T arg1, ref TRef argRef);

    public delegate TReturn FuncRef2<TRef1, TRef2, TReturn>(ref TRef1 argRef1, ref TRef2 argRef2);

    public delegate TReturn FuncRef1<T1, T2, TRef, TReturn>(T1 arg1, T2 arg2, ref TRef argRef);

    public delegate TReturn FuncRef2<T, TRef1, TRef2, TReturn>(T arg1, ref TRef1 argRef1, ref TRef2 argRef2);

    public delegate TReturn FuncRef3<TRef1, TRef2, TRef3, TReturn>(ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3);

    public delegate TReturn FuncRef1<T1, T2, T3, TRef, TReturn>(T1 arg1, T2 arg2, T3 arg3, ref TRef argRef);

    public delegate TReturn FuncRef2<T1, T2, TRef1, TRef2, TReturn>(T1 arg1, T2 arg2, ref TRef1 argRef1, ref TRef2 argRef2);

    public delegate TReturn FuncRef3<T, TRef1, TRef2, TRef3, TReturn>(T arg1, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3);

    public delegate TReturn FuncRef4<TRef1, TRef2, TRef3, TRef4, TReturn>(ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4);

    public delegate TReturn FuncRef1<T1, T2, T3, T4, TRef, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, ref TRef argRef);

    public delegate TReturn FuncRef2<T1, T2, T3, TRef1, TRef2, TReturn>(T1 arg1, T2 arg2, T3 arg3, ref TRef1 argRef1, ref TRef2 argRef2);

    public delegate TReturn FuncRef3<T1, T2, TRef1, TRef2, TRef3, TReturn>(T1 arg1, T2 arg2, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3);

    public delegate TReturn FuncRef4<T, TRef1, TRef2, TRef3, TRef4, TReturn>(T arg1, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4);

    public delegate TReturn FuncRef5<TRef1, TRef2, TRef3, TRef4, TRef5, TReturn>(ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5);

    public delegate TReturn FuncRef1<T1, T2, T3, T4, T5, TRef, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, ref TRef argRef);

    public delegate TReturn FuncRef2<T1, T2, T3, T4, TRef1, TRef2, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, ref TRef1 argRef1, ref TRef2 argRef2);

    public delegate TReturn FuncRef3<T1, T2, T3, TRef1, TRef2, TRef3, TReturn>(T1 arg1, T2 arg2, T3 arg3, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3);

    public delegate TReturn FuncRef4<T1, T2, TRef1, TRef2, TRef3, TRef4, TReturn>(T1 arg1, T2 arg2, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4);

    public delegate TReturn FuncRef5<T, TRef1, TRef2, TRef3, TRef4, TRef5, TReturn>(T arg1, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5);

    public delegate TReturn FuncRef6<TRef1, TRef2, TRef3, TRef4, TRef5, TRef6, TReturn>(ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5, ref TRef6 argRef6);

    public delegate TReturn FuncRef1<T1, T2, T3, T4, T5, T6, TRef, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, ref TRef argRef);

    public delegate TReturn FuncRef2<T1, T2, T3, T4, T5, TRef1, TRef2, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, ref TRef1 argRef1, ref TRef2 argRef2);

    public delegate TReturn FuncRef3<T1, T2, T3, T4, TRef1, TRef2, TRef3, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3);

    public delegate TReturn FuncRef4<T1, T2, T3, TRef1, TRef2, TRef3, TRef4, TReturn>(T1 arg1, T2 arg2, T3 arg3, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4);

    public delegate TReturn FuncRef5<T1, T2, TRef1, TRef2, TRef3, TRef4, TRef5, TReturn>(T1 arg1, T2 arg2, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5);

    public delegate TReturn FuncRef6<T, TRef1, TRef2, TRef3, TRef4, TRef5, TRef6, TReturn>(T arg1, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5, ref TRef6 argRef6);

    public delegate TReturn FuncRef7<TRef1, TRef2, TRef3, TRef4, TRef5, TRef6, TRef7, TReturn>(ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5, ref TRef6 argRef6, ref TRef7 argRef7);

    public delegate TReturn FuncRef1<T1, T2, T3, T4, T5, T6, T7, TRef, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, ref TRef argRef);

    public delegate TReturn FuncRef2<T1, T2, T3, T4, T5, T6, TRef1, TRef2, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, ref TRef1 argRef1, ref TRef2 argRef2);

    public delegate TReturn FuncRef3<T1, T2, T3, T4, T5, TRef1, TRef2, TRef3, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3);

    public delegate TReturn FuncRef4<T1, T2, T3, T4, TRef1, TRef2, TRef3, TRef4, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4);

    public delegate TReturn FuncRef5<T1, T2, T3, TRef1, TRef2, TRef3, TRef4, TRef5, TReturn>(T1 arg1, T2 arg2, T3 arg3, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5);

    public delegate TReturn FuncRef6<T1, T2, TRef1, TRef2, TRef3, TRef4, TRef5, TRef6, TReturn>(T1 arg1, T2 arg2, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5, ref TRef6 argRef6);

    public delegate TReturn FuncRef7<T, TRef1, TRef2, TRef3, TRef4, TRef5, TRef6, TRef7, TReturn>(T arg1, ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5, ref TRef6 argRef6, ref TRef7 argRef7);

    public delegate TReturn FuncRef8<TRef1, TRef2, TRef3, TRef4, TRef5, TRef6, TRef7, TRef8, TReturn>(ref TRef1 argRef1, ref TRef2 argRef2, ref TRef3 argRef3, ref TRef4 argRef4, ref TRef5 argRef5, ref TRef6 argRef6, ref TRef7 argRef7, ref TRef8 argRef8);

    public delegate TReturn FuncOut1<TOut, TReturn>(out TOut argRef);

    public delegate TReturn FuncOut1<T, TOut, TReturn>(T arg1, out TOut argRef);

    public delegate TReturn FuncOut2<TOut1, TOut2, TReturn>(out TOut1 argOut1, out TOut2 argOut2);

    public delegate TReturn FuncOut1<T1, T2, TOut, TReturn>(T1 arg1, T2 arg2, out TOut argRef);

    public delegate TReturn FuncOut2<T, TOut1, TOut2, TReturn>(T arg1, out TOut1 argOut1, out TOut2 argOut2);

    public delegate TReturn FuncOut3<TOut1, TOut2, TOut3, TReturn>(out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3);

    public delegate TReturn FuncOut1<T1, T2, T3, TOut, TReturn>(T1 arg1, T2 arg2, T3 arg3, out TOut argRef);

    public delegate TReturn FuncOut2<T1, T2, TOut1, TOut2, TReturn>(T1 arg1, T2 arg2, out TOut1 argOut1, out TOut2 argOut2);

    public delegate TReturn FuncOut3<T, TOut1, TOut2, TOut3, TReturn>(T arg1, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3);

    public delegate TReturn FuncOut4<TOut1, TOut2, TOut3, TOut4, TReturn>(out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4);

    public delegate TReturn FuncOut1<T1, T2, T3, T4, TOut, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, out TOut argRef);

    public delegate TReturn FuncOut2<T1, T2, T3, TOut1, TOut2, TReturn>(T1 arg1, T2 arg2, T3 arg3, out TOut1 argOut1, out TOut2 argOut2);

    public delegate TReturn FuncOut3<T1, T2, TOut1, TOut2, TOut3, TReturn>(T1 arg1, T2 arg2, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3);

    public delegate TReturn FuncOut4<T, TOut1, TOut2, TOut3, TOut4, TReturn>(T arg1, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4);

    public delegate TReturn FuncOut5<TOut1, TOut2, TOut3, TOut4, TOut5, TReturn>(out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5);

    public delegate TReturn FuncOut1<T1, T2, T3, T4, T5, TOut, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, out TOut argRef);

    public delegate TReturn FuncOut2<T1, T2, T3, T4, TOut1, TOut2, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, out TOut1 argOut1, out TOut2 argOut2);

    public delegate TReturn FuncOut3<T1, T2, T3, TOut1, TOut2, TOut3, TReturn>(T1 arg1, T2 arg2, T3 arg3, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3);

    public delegate TReturn FuncOut4<T1, T2, TOut1, TOut2, TOut3, TOut4, TReturn>(T1 arg1, T2 arg2, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4);

    public delegate TReturn FuncOut5<T, TOut1, TOut2, TOut3, TOut4, TOut5, TReturn>(T arg1, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5);

    public delegate TReturn FuncOut6<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TReturn>(out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5, out TOut6 argOut6);

    public delegate TReturn FuncOut1<T1, T2, T3, T4, T5, T6, TOut, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, out TOut argRef);

    public delegate TReturn FuncOut2<T1, T2, T3, T4, T5, TOut1, TOut2, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, out TOut1 argOut1, out TOut2 argOut2);

    public delegate TReturn FuncOut3<T1, T2, T3, T4, TOut1, TOut2, TOut3, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3);

    public delegate TReturn FuncOut4<T1, T2, T3, TOut1, TOut2, TOut3, TOut4, TReturn>(T1 arg1, T2 arg2, T3 arg3, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4);

    public delegate TReturn FuncOut5<T1, T2, TOut1, TOut2, TOut3, TOut4, TOut5, TReturn>(T1 arg1, T2 arg2, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5);

    public delegate TReturn FuncOut6<T, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TReturn>(T arg1, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5, out TOut6 argOut6);

    public delegate TReturn FuncOut7<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7, TReturn>(out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5, out TOut6 argOut6, out TOut7 argOut7);

    public delegate TReturn FuncOut1<T1, T2, T3, T4, T5, T6, T7, TOut, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, out TOut argRef);

    public delegate TReturn FuncOut2<T1, T2, T3, T4, T5, T6, TOut1, TOut2, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, out TOut1 argOut1, out TOut2 argOut2);

    public delegate TReturn FuncOut3<T1, T2, T3, T4, T5, TOut1, TOut2, TOut3, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3);

    public delegate TReturn FuncOut4<T1, T2, T3, T4, TOut1, TOut2, TOut3, TOut4, TReturn>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4);

    public delegate TReturn FuncOut5<T1, T2, T3, TOut1, TOut2, TOut3, TOut4, TOut5, TReturn>(T1 arg1, T2 arg2, T3 arg3, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5);

    public delegate TReturn FuncOut6<T1, T2, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TReturn>(T1 arg1, T2 arg2, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5, out TOut6 argOut6);

    public delegate TReturn FuncOut7<T, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7, TReturn>(T arg1, out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5, out TOut6 argOut6, out TOut7 argOut7);

    public delegate TReturn FuncOut8<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7, TOut8, TReturn>(out TOut1 argOut1, out TOut2 argOut2, out TOut3 argOut3, out TOut4 argOut4, out TOut5 argOut5, out TOut6 argOut6, out TOut7 argOut7, out TOut8 argOut8);
}