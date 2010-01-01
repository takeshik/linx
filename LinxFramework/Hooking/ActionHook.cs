// -*- mode: csharp; encoding: utf-8; tab-width: 4; c-basic-offset: 4; indent-tabs-mode: nil; -*-
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
// $Id: a7db7754a428ebb526d000b64ab4e48866a29032 $
/* LinxFramework
 *   Practical class library based on Linx Core Library
 *   Part of Linx
 * Linx
 *   Library that Integrates .NET with eXtremes
 * Copyright © 2008-2010 Takeshi KIRIYA (aka takeshik) <takeshik@users.sf.net>
 * All rights reserved.
 * 
 * This file is part of LinxFramework.
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
using Achiral;
using Achiral.Extension;

namespace XSpect.Hooking
{
    /// <summary>
    /// 引数を持たず、値を返さないメソッドのフック リストを表します。
    /// </summary>
    /// <typeparam name="TSelf">フックされるメソッドの <c>this</c> の型。</typeparam>
    public sealed class ActionHook<TSelf>
        : Hook<TSelf, Action, Action<TSelf>, Action<TSelf>, Action<TSelf, Exception>>
    {
        /// <summary>
        /// <see cref="ActionHook{TSelf}"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="action">フックの対象とするメソッドを表すデリゲート。</param>
        public ActionHook(Action action)
            : base(action)
        {
        }

        /// <summary>
        /// フックを適用して、メソッドを実行します。
        /// </summary>
        public void Execute()
        {
            this.Before.ForEach(f => f(this.Self));
            try
            {
                this.Method();
                this.Succeeded.ForEach(f => f(this.Self));
            }
            catch (Exception ex)
            {
                this.Failed.ForEach(f => f(this.Self, ex));
            }
            finally
            {
                this.After.ForEach(f => f(this.Self));
            }
        }
    }

    /// <summary>
    /// 1 個の引数を持ち、値を返さないメソッドのフック リストを表します。
    /// </summary>
    /// <typeparam name="TSelf">フックされるメソッドの <c>this</c> の型。</typeparam>
    /// <typeparam name="T1">フックされるメソッドの第 1 引数の型。</typeparam>
    public sealed class ActionHook<TSelf, T1>
        : Hook<TSelf, Action<T1>, Action<TSelf, T1>, Action<TSelf, T1>, Action<TSelf, T1, Exception>>
    {
        /// <summary>
        /// <see cref="ActionHook{TSelf, T1}"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="action">フックの対象とするメソッドを表すデリゲート。</param>
        public ActionHook(Action<T1> action)
            : base(action)
        {
        }

        /// <summary>
        /// フックを適用して、メソッドを実行します。
        /// </summary>
        /// <param name="arg1">メソッドの第 1 引数。</param>
        public void Execute(T1 arg1)
        {
            this.Before.ForEach(f => f(this.Self, arg1));
            try
            {
                this.Method(arg1);
                this.Succeeded.ForEach(f => f(this.Self, arg1));
            }
            catch (Exception ex)
            {
                this.Failed.ForEach(f => f(this.Self, arg1, ex));
            }
            finally
            {
                this.After.ForEach(f => f(this.Self, arg1));
            }
        }
    }

    /// <summary>
    /// 2 個の引数を持ち、値を返さないメソッドのフック リストを表します。
    /// </summary>
    /// <typeparam name="TSelf">フックされるメソッドの <c>this</c> の型。</typeparam>
    /// <typeparam name="T1">フックされるメソッドの第 1 引数の型。</typeparam>
    /// <typeparam name="T2">フックされるメソッドの第 2 引数の型。</typeparam>
    public sealed class ActionHook<TSelf, T1, T2>
        : Hook<TSelf, Action<T1, T2>, Action<TSelf, T1, T2>, Action<TSelf, T1, T2>, Action<TSelf, T1, T2, Exception>>
    {
        /// <summary>
        /// <see cref="ActionHook{TSelf, T1, T2}"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="action">フックの対象とするメソッドを表すデリゲート。</param>
        public ActionHook(Action<T1, T2> action)
            : base(action)
        {
        }

        /// <summary>
        /// フックを適用して、メソッドを実行します。
        /// </summary>
        /// <param name="arg1">メソッドの第 1 引数。</param>
        /// <param name="arg2">メソッドの第 2 引数。</param>
        public void Execute(T1 arg1, T2 arg2)
        {
            this.Before.ForEach(f => f(this.Self, arg1, arg2));
            try
            {
                this.Method(arg1, arg2);
                this.Succeeded.ForEach(f => f(this.Self, arg1, arg2));
            }
            catch (Exception ex)
            {
                this.Failed.ForEach(f => f(this.Self, arg1, arg2, ex));
            }
            finally
            {
                this.After.ForEach(f => f(this.Self, arg1, arg2));
            }
        }
    }

    /// <summary>
    /// 3 個の引数を持ち、値を返さないメソッドのフック リストを表します。
    /// </summary>
    /// <typeparam name="TSelf">フックされるメソッドの <c>this</c> の型。</typeparam>
    /// <typeparam name="T1">フックされるメソッドの第 1 引数の型。</typeparam>
    /// <typeparam name="T2">フックされるメソッドの第 2 引数の型。</typeparam>
    /// <typeparam name="T3">フックされるメソッドの第 3 引数の型。</typeparam>
    public sealed class ActionHook<TSelf, T1, T2, T3>
        : Hook<TSelf, Action<T1, T2, T3>, Action<TSelf, T1, T2, T3>, Action<TSelf, T1, T2, T3>, Action<TSelf, T1, T2, T3, Exception>>
    {
        /// <summary>
        /// <see cref="ActionHook{TSelf, T1, T2, T3}"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="action">フックの対象とするメソッドを表すデリゲート。</param>
        public ActionHook(Action<T1, T2, T3> action)
            : base(action)
        {
        }

        /// <summary>
        /// フックを適用して、メソッドを実行します。
        /// </summary>
        /// <param name="arg1">メソッドの第 1 引数。</param>
        /// <param name="arg2">メソッドの第 2 引数。</param>
        /// <param name="arg3">メソッドの第 3 引数。</param>
        public void Execute(T1 arg1, T2 arg2, T3 arg3)
        {
            this.Before.ForEach(f => f(this.Self, arg1, arg2, arg3));
            try
            {
                this.Method(arg1, arg2, arg3);
                this.Succeeded.ForEach(f => f(this.Self, arg1, arg2, arg3));
            }
            catch (Exception ex)
            {
                this.Failed.ForEach(f => f(this.Self, arg1, arg2, arg3, ex));
            }
            finally
            {
                this.After.ForEach(f => f(this.Self, arg1, arg2, arg3));
            }
        }
    }

    /// <summary>
    /// 4 個の引数を持ち、値を返さないメソッドのフック リストを表します。
    /// </summary>
    /// <typeparam name="TSelf">フックされるメソッドの <c>this</c> の型。</typeparam>
    /// <typeparam name="T1">フックされるメソッドの第 1 引数の型。</typeparam>
    /// <typeparam name="T2">フックされるメソッドの第 2 引数の型。</typeparam>
    /// <typeparam name="T3">フックされるメソッドの第 3 引数の型。</typeparam>
    /// <typeparam name="T4">フックされるメソッドの第 4 引数の型。</typeparam>
    public sealed class ActionHook<TSelf, T1, T2, T3, T4>
        : Hook<TSelf, Action<T1, T2, T3, T4>, Action<TSelf, T1, T2, T3, T4>, Action<TSelf, T1, T2, T3, T4>, Action<TSelf, T1, T2, T3, T4, Exception>>
    {
        /// <summary>
        /// <see cref="ActionHook{TSelf, T1, T2, T3, T4}"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="action">フックの対象とするメソッドを表すデリゲート。</param>
        public ActionHook(Action<T1, T2, T3, T4> action)
            : base(action)
        {
        }

        /// <summary>
        /// フックを適用して、メソッドを実行します。
        /// </summary>
        /// <param name="arg1">メソッドの第 1 引数。</param>
        /// <param name="arg2">メソッドの第 2 引数。</param>
        /// <param name="arg3">メソッドの第 3 引数。</param>
        /// <param name="arg4">メソッドの第 4 引数。</param>
        public void Execute(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            this.Before.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4));
            try
            {
                this.Method(arg1, arg2, arg3, arg4);
                this.Succeeded.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4));
            }
            catch (Exception ex)
            {
                this.Failed.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, ex));
            }
            finally
            {
                this.After.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4));
            }
        }
    }

    /// <summary>
    /// 5 個の引数を持ち、値を返さないメソッドのフック リストを表します。
    /// </summary>
    /// <typeparam name="TSelf">フックされるメソッドの <c>this</c> の型。</typeparam>
    /// <typeparam name="T1">フックされるメソッドの第 1 引数の型。</typeparam>
    /// <typeparam name="T2">フックされるメソッドの第 2 引数の型。</typeparam>
    /// <typeparam name="T3">フックされるメソッドの第 3 引数の型。</typeparam>
    /// <typeparam name="T4">フックされるメソッドの第 4 引数の型。</typeparam>
    /// <typeparam name="T5">フックされるメソッドの第 5 引数の型。</typeparam>
    public sealed class ActionHook<TSelf, T1, T2, T3, T4, T5>
        : Hook<TSelf, Action<T1, T2, T3, T4, T5>, Action<TSelf, T1, T2, T3, T4, T5>, Action<TSelf, T1, T2, T3, T4, T5>, Action<TSelf, T1, T2, T3, T4, T5, Exception>>
    {
        /// <summary>
        /// <see cref="ActionHook{TSelf, T1, T2, T3, T4, T5}"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="action">フックの対象とするメソッドを表すデリゲート。</param>
        public ActionHook(Action<T1, T2, T3, T4, T5> action)
            : base(action)
        {
        }

        /// <summary>
        /// フックを適用して、メソッドを実行します。
        /// </summary>
        /// <param name="arg1">メソッドの第 1 引数。</param>
        /// <param name="arg2">メソッドの第 2 引数。</param>
        /// <param name="arg3">メソッドの第 3 引数。</param>
        /// <param name="arg4">メソッドの第 4 引数。</param>
        /// <param name="arg5">メソッドの第 5 引数。</param>
        public void Execute(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            this.Before.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5));
            try
            {
                this.Method(arg1, arg2, arg3, arg4, arg5);
                this.Succeeded.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5));
            }
            catch (Exception ex)
            {
                this.Failed.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, ex));
            }
            finally
            {
                this.After.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5));
            }
        }
    }

    /// <summary>
    /// 6 個の引数を持ち、値を返さないメソッドのフック リストを表します。
    /// </summary>
    /// <typeparam name="TSelf">フックされるメソッドの <c>this</c> の型。</typeparam>
    /// <typeparam name="T1">フックされるメソッドの第 1 引数の型。</typeparam>
    /// <typeparam name="T2">フックされるメソッドの第 2 引数の型。</typeparam>
    /// <typeparam name="T3">フックされるメソッドの第 3 引数の型。</typeparam>
    /// <typeparam name="T4">フックされるメソッドの第 4 引数の型。</typeparam>
    /// <typeparam name="T5">フックされるメソッドの第 5 引数の型。</typeparam>
    /// <typeparam name="T6">フックされるメソッドの第 6 引数の型。</typeparam>
    public sealed class ActionHook<TSelf, T1, T2, T3, T4, T5, T6>
        : Hook<TSelf, Action<T1, T2, T3, T4, T5, T6>, Action<TSelf, T1, T2, T3, T4, T5, T6>, Action<TSelf, T1, T2, T3, T4, T5, T6>, Action<TSelf, T1, T2, T3, T4, T5, T6, Exception>>
    {
        /// <summary>
        /// <see cref="ActionHook{TSelf, T1, T2, T3, T4, T5, T6}"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="action">フックの対象とするメソッドを表すデリゲート。</param>
        public ActionHook(Action<T1, T2, T3, T4, T5, T6> action)
            : base(action)
        {
        }

        /// <summary>
        /// フックを適用して、メソッドを実行します。
        /// </summary>
        /// <param name="arg1">メソッドの第 1 引数。</param>
        /// <param name="arg2">メソッドの第 2 引数。</param>
        /// <param name="arg3">メソッドの第 3 引数。</param>
        /// <param name="arg4">メソッドの第 4 引数。</param>
        /// <param name="arg5">メソッドの第 5 引数。</param>
        /// <param name="arg6">メソッドの第 6 引数。</param>
        public void Execute(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            this.Before.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6));
            try
            {
                this.Method(arg1, arg2, arg3, arg4, arg5, arg6);
                this.Succeeded.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6));
            }
            catch (Exception ex)
            {
                this.Failed.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, ex));
            }
            finally
            {
                this.After.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6));
            }
        }
    }

    /// <summary>
    /// 7 個の引数を持ち、値を返さないメソッドのフック リストを表します。
    /// </summary>
    /// <typeparam name="TSelf">フックされるメソッドの <c>this</c> の型。</typeparam>
    /// <typeparam name="T1">フックされるメソッドの第 1 引数の型。</typeparam>
    /// <typeparam name="T2">フックされるメソッドの第 2 引数の型。</typeparam>
    /// <typeparam name="T3">フックされるメソッドの第 3 引数の型。</typeparam>
    /// <typeparam name="T4">フックされるメソッドの第 4 引数の型。</typeparam>
    /// <typeparam name="T5">フックされるメソッドの第 5 引数の型。</typeparam>
    /// <typeparam name="T6">フックされるメソッドの第 6 引数の型。</typeparam>
    /// <typeparam name="T7">フックされるメソッドの第 7 引数の型。</typeparam>
    public sealed class ActionHook<TSelf, T1, T2, T3, T4, T5, T6, T7>
        : Hook<TSelf, Action<T1, T2, T3, T4, T5, T6, T7>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, Exception>>
    {
        /// <summary>
        /// <see cref="ActionHook{TSelf, T1, T2, T3, T4, T5, T6, T7}"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="action">フックの対象とするメソッドを表すデリゲート。</param>
        public ActionHook(Action<T1, T2, T3, T4, T5, T6, T7> action)
            : base(action)
        {
        }

        /// <summary>
        /// フックを適用して、メソッドを実行します。
        /// </summary>
        /// <param name="arg1">メソッドの第 1 引数。</param>
        /// <param name="arg2">メソッドの第 2 引数。</param>
        /// <param name="arg3">メソッドの第 3 引数。</param>
        /// <param name="arg4">メソッドの第 4 引数。</param>
        /// <param name="arg5">メソッドの第 5 引数。</param>
        /// <param name="arg6">メソッドの第 6 引数。</param>
        /// <param name="arg7">メソッドの第 7 引数。</param>
        public void Execute(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            this.Before.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7));
            try
            {
                this.Method(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                this.Succeeded.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7));
            }
            catch (Exception ex)
            {
                this.Failed.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, ex));
            }
            finally
            {
                this.After.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7));
            }
        }
    }

    /// <summary>
    /// 8 個の引数を持ち、値を返さないメソッドのフック リストを表します。
    /// </summary>
    /// <typeparam name="TSelf">フックされるメソッドの <c>this</c> の型。</typeparam>
    /// <typeparam name="T1">フックされるメソッドの第 1 引数の型。</typeparam>
    /// <typeparam name="T2">フックされるメソッドの第 2 引数の型。</typeparam>
    /// <typeparam name="T3">フックされるメソッドの第 3 引数の型。</typeparam>
    /// <typeparam name="T4">フックされるメソッドの第 4 引数の型。</typeparam>
    /// <typeparam name="T5">フックされるメソッドの第 5 引数の型。</typeparam>
    /// <typeparam name="T6">フックされるメソッドの第 6 引数の型。</typeparam>
    /// <typeparam name="T7">フックされるメソッドの第 7 引数の型。</typeparam>
    /// <typeparam name="T8">フックされるメソッドの第 8 引数の型。</typeparam>
    public sealed class ActionHook<TSelf, T1, T2, T3, T4, T5, T6, T7, T8>
        : Hook<TSelf, Action<T1, T2, T3, T4, T5, T6, T7, T8>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, Exception>>
    {
        /// <summary>
        /// <see cref="ActionHook{TSelf, T1, T2, T3, T4, T5, T6, T7, T8}"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="action">フックの対象とするメソッドを表すデリゲート。</param>
        public ActionHook(Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
            : base(action)
        {
        }

        /// <summary>
        /// フックを適用して、メソッドを実行します。
        /// </summary>
        /// <param name="arg1">メソッドの第 1 引数。</param>
        /// <param name="arg2">メソッドの第 2 引数。</param>
        /// <param name="arg3">メソッドの第 3 引数。</param>
        /// <param name="arg4">メソッドの第 4 引数。</param>
        /// <param name="arg5">メソッドの第 5 引数。</param>
        /// <param name="arg6">メソッドの第 6 引数。</param>
        /// <param name="arg7">メソッドの第 7 引数。</param>
        /// <param name="arg8">メソッドの第 8 引数。</param>
        public void Execute(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            this.Before.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
            try
            {
                this.Method(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                this.Succeeded.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
            }
            catch (Exception ex)
            {
                this.Failed.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, ex));
            }
            finally
            {
                this.After.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
            }
        }
    }

    /// <summary>
    /// 9 個の引数を持ち、値を返さないメソッドのフック リストを表します。
    /// </summary>
    /// <typeparam name="TSelf">フックされるメソッドの <c>this</c> の型。</typeparam>
    /// <typeparam name="T1">フックされるメソッドの第 1 引数の型。</typeparam>
    /// <typeparam name="T2">フックされるメソッドの第 2 引数の型。</typeparam>
    /// <typeparam name="T3">フックされるメソッドの第 3 引数の型。</typeparam>
    /// <typeparam name="T4">フックされるメソッドの第 4 引数の型。</typeparam>
    /// <typeparam name="T5">フックされるメソッドの第 5 引数の型。</typeparam>
    /// <typeparam name="T6">フックされるメソッドの第 6 引数の型。</typeparam>
    /// <typeparam name="T7">フックされるメソッドの第 7 引数の型。</typeparam>
    /// <typeparam name="T8">フックされるメソッドの第 8 引数の型。</typeparam>
    /// <typeparam name="T9">フックされるメソッドの第 9 引数の型。</typeparam>
    public sealed class ActionHook<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9>
        : Hook<TSelf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, Exception>>
    {
        /// <summary>
        /// <see cref="ActionHook{TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9}"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="action">フックの対象とするメソッドを表すデリゲート。</param>
        public ActionHook(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
            : base(action)
        {
        }

        /// <summary>
        /// フックを適用して、メソッドを実行します。
        /// </summary>
        /// <param name="arg1">メソッドの第 1 引数。</param>
        /// <param name="arg2">メソッドの第 2 引数。</param>
        /// <param name="arg3">メソッドの第 3 引数。</param>
        /// <param name="arg4">メソッドの第 4 引数。</param>
        /// <param name="arg5">メソッドの第 5 引数。</param>
        /// <param name="arg6">メソッドの第 6 引数。</param>
        /// <param name="arg7">メソッドの第 7 引数。</param>
        /// <param name="arg8">メソッドの第 8 引数。</param>
        /// <param name="arg9">メソッドの第 9 引数。</param>
        public void Execute(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            this.Before.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
            try
            {
                this.Method(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                this.Succeeded.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
            }
            catch (Exception ex)
            {
                this.Failed.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, ex));
            }
            finally
            {
                this.After.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
            }
        }
    }

    /// <summary>
    /// 10 個の引数を持ち、値を返さないメソッドのフック リストを表します。
    /// </summary>
    /// <typeparam name="TSelf">フックされるメソッドの <c>this</c> の型。</typeparam>
    /// <typeparam name="T1">フックされるメソッドの第 1 引数の型。</typeparam>
    /// <typeparam name="T2">フックされるメソッドの第 2 引数の型。</typeparam>
    /// <typeparam name="T3">フックされるメソッドの第 3 引数の型。</typeparam>
    /// <typeparam name="T4">フックされるメソッドの第 4 引数の型。</typeparam>
    /// <typeparam name="T5">フックされるメソッドの第 5 引数の型。</typeparam>
    /// <typeparam name="T6">フックされるメソッドの第 6 引数の型。</typeparam>
    /// <typeparam name="T7">フックされるメソッドの第 7 引数の型。</typeparam>
    /// <typeparam name="T8">フックされるメソッドの第 8 引数の型。</typeparam>
    /// <typeparam name="T9">フックされるメソッドの第 9 引数の型。</typeparam>
    /// <typeparam name="T10">フックされるメソッドの第 10 引数の型。</typeparam>
    public sealed class ActionHook<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
        : Hook<TSelf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Exception>>
    {
        /// <summary>
        /// <see cref="ActionHook{TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="action">フックの対象とするメソッドを表すデリゲート。</param>
        public ActionHook(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
            : base(action)
        {
        }

        /// <summary>
        /// フックを適用して、メソッドを実行します。
        /// </summary>
        /// <param name="arg1">メソッドの第 1 引数。</param>
        /// <param name="arg2">メソッドの第 2 引数。</param>
        /// <param name="arg3">メソッドの第 3 引数。</param>
        /// <param name="arg4">メソッドの第 4 引数。</param>
        /// <param name="arg5">メソッドの第 5 引数。</param>
        /// <param name="arg6">メソッドの第 6 引数。</param>
        /// <param name="arg7">メソッドの第 7 引数。</param>
        /// <param name="arg8">メソッドの第 8 引数。</param>
        /// <param name="arg9">メソッドの第 9 引数。</param>
        /// <param name="arg10">メソッドの第 10 引数。</param>
        public void Execute(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            this.Before.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));
            try
            {
                this.Method(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                this.Succeeded.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));
            }
            catch (Exception ex)
            {
                this.Failed.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, ex));
            }
            finally
            {
                this.After.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));
            }
        }
    }

    /// <summary>
    /// 11 個の引数を持ち、値を返さないメソッドのフック リストを表します。
    /// </summary>
    /// <typeparam name="TSelf">フックされるメソッドの <c>this</c> の型。</typeparam>
    /// <typeparam name="T1">フックされるメソッドの第 1 引数の型。</typeparam>
    /// <typeparam name="T2">フックされるメソッドの第 2 引数の型。</typeparam>
    /// <typeparam name="T3">フックされるメソッドの第 3 引数の型。</typeparam>
    /// <typeparam name="T4">フックされるメソッドの第 4 引数の型。</typeparam>
    /// <typeparam name="T5">フックされるメソッドの第 5 引数の型。</typeparam>
    /// <typeparam name="T6">フックされるメソッドの第 6 引数の型。</typeparam>
    /// <typeparam name="T7">フックされるメソッドの第 7 引数の型。</typeparam>
    /// <typeparam name="T8">フックされるメソッドの第 8 引数の型。</typeparam>
    /// <typeparam name="T9">フックされるメソッドの第 9 引数の型。</typeparam>
    /// <typeparam name="T10">フックされるメソッドの第 10 引数の型。</typeparam>
    /// <typeparam name="T11">フックされるメソッドの第 11 引数の型。</typeparam>
    public sealed class ActionHook<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
        : Hook<TSelf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Exception>>
    {
        /// <summary>
        /// <see cref="ActionHook{TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="action">フックの対象とするメソッドを表すデリゲート。</param>
        public ActionHook(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
            : base(action)
        {
        }

        /// <summary>
        /// フックを適用して、メソッドを実行します。
        /// </summary>
        /// <param name="arg1">メソッドの第 1 引数。</param>
        /// <param name="arg2">メソッドの第 2 引数。</param>
        /// <param name="arg3">メソッドの第 3 引数。</param>
        /// <param name="arg4">メソッドの第 4 引数。</param>
        /// <param name="arg5">メソッドの第 5 引数。</param>
        /// <param name="arg6">メソッドの第 6 引数。</param>
        /// <param name="arg7">メソッドの第 7 引数。</param>
        /// <param name="arg8">メソッドの第 8 引数。</param>
        /// <param name="arg9">メソッドの第 9 引数。</param>
        /// <param name="arg10">メソッドの第 10 引数。</param>
        /// <param name="arg11">メソッドの第 11 引数。</param>
        public void Execute(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            this.Before.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));
            try
            {
                this.Method(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                this.Succeeded.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));
            }
            catch (Exception ex)
            {
                this.Failed.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, ex));
            }
            finally
            {
                this.After.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));
            }
        }
    }

    /// <summary>
    /// 12 個の引数を持ち、値を返さないメソッドのフック リストを表します。
    /// </summary>
    /// <typeparam name="TSelf">フックされるメソッドの <c>this</c> の型。</typeparam>
    /// <typeparam name="T1">フックされるメソッドの第 1 引数の型。</typeparam>
    /// <typeparam name="T2">フックされるメソッドの第 2 引数の型。</typeparam>
    /// <typeparam name="T3">フックされるメソッドの第 3 引数の型。</typeparam>
    /// <typeparam name="T4">フックされるメソッドの第 4 引数の型。</typeparam>
    /// <typeparam name="T5">フックされるメソッドの第 5 引数の型。</typeparam>
    /// <typeparam name="T6">フックされるメソッドの第 6 引数の型。</typeparam>
    /// <typeparam name="T7">フックされるメソッドの第 7 引数の型。</typeparam>
    /// <typeparam name="T8">フックされるメソッドの第 8 引数の型。</typeparam>
    /// <typeparam name="T9">フックされるメソッドの第 9 引数の型。</typeparam>
    /// <typeparam name="T10">フックされるメソッドの第 10 引数の型。</typeparam>
    /// <typeparam name="T11">フックされるメソッドの第 11 引数の型。</typeparam>
    /// <typeparam name="T12">フックされるメソッドの第 12 引数の型。</typeparam>
    public sealed class ActionHook<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
        : Hook<TSelf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Exception>>
    {
        /// <summary>
        /// <see cref="ActionHook{TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="action">フックの対象とするメソッドを表すデリゲート。</param>
        public ActionHook(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
            : base(action)
        {
        }

        /// <summary>
        /// フックを適用して、メソッドを実行します。
        /// </summary>
        /// <param name="arg1">メソッドの第 1 引数。</param>
        /// <param name="arg2">メソッドの第 2 引数。</param>
        /// <param name="arg3">メソッドの第 3 引数。</param>
        /// <param name="arg4">メソッドの第 4 引数。</param>
        /// <param name="arg5">メソッドの第 5 引数。</param>
        /// <param name="arg6">メソッドの第 6 引数。</param>
        /// <param name="arg7">メソッドの第 7 引数。</param>
        /// <param name="arg8">メソッドの第 8 引数。</param>
        /// <param name="arg9">メソッドの第 9 引数。</param>
        /// <param name="arg10">メソッドの第 10 引数。</param>
        /// <param name="arg11">メソッドの第 11 引数。</param>
        /// <param name="arg12">メソッドの第 12 引数。</param>
        public void Execute(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            this.Before.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12));
            try
            {
                this.Method(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                this.Succeeded.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12));
            }
            catch (Exception ex)
            {
                this.Failed.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, ex));
            }
            finally
            {
                this.After.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12));
            }
        }
    }

    /// <summary>
    /// 13 個の引数を持ち、値を返さないメソッドのフック リストを表します。
    /// </summary>
    /// <typeparam name="TSelf">フックされるメソッドの <c>this</c> の型。</typeparam>
    /// <typeparam name="T1">フックされるメソッドの第 1 引数の型。</typeparam>
    /// <typeparam name="T2">フックされるメソッドの第 2 引数の型。</typeparam>
    /// <typeparam name="T3">フックされるメソッドの第 3 引数の型。</typeparam>
    /// <typeparam name="T4">フックされるメソッドの第 4 引数の型。</typeparam>
    /// <typeparam name="T5">フックされるメソッドの第 5 引数の型。</typeparam>
    /// <typeparam name="T6">フックされるメソッドの第 6 引数の型。</typeparam>
    /// <typeparam name="T7">フックされるメソッドの第 7 引数の型。</typeparam>
    /// <typeparam name="T8">フックされるメソッドの第 8 引数の型。</typeparam>
    /// <typeparam name="T9">フックされるメソッドの第 9 引数の型。</typeparam>
    /// <typeparam name="T10">フックされるメソッドの第 10 引数の型。</typeparam>
    /// <typeparam name="T11">フックされるメソッドの第 11 引数の型。</typeparam>
    /// <typeparam name="T12">フックされるメソッドの第 12 引数の型。</typeparam>
    /// <typeparam name="T13">フックされるメソッドの第 13 引数の型。</typeparam>
    public sealed class ActionHook<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
        : Hook<TSelf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Exception>>
    {
        /// <summary>
        /// <see cref="ActionHook{TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="action">フックの対象とするメソッドを表すデリゲート。</param>
        public ActionHook(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
            : base(action)
        {
        }

        /// <summary>
        /// フックを適用して、メソッドを実行します。
        /// </summary>
        /// <param name="arg1">メソッドの第 1 引数。</param>
        /// <param name="arg2">メソッドの第 2 引数。</param>
        /// <param name="arg3">メソッドの第 3 引数。</param>
        /// <param name="arg4">メソッドの第 4 引数。</param>
        /// <param name="arg5">メソッドの第 5 引数。</param>
        /// <param name="arg6">メソッドの第 6 引数。</param>
        /// <param name="arg7">メソッドの第 7 引数。</param>
        /// <param name="arg8">メソッドの第 8 引数。</param>
        /// <param name="arg9">メソッドの第 9 引数。</param>
        /// <param name="arg10">メソッドの第 10 引数。</param>
        /// <param name="arg11">メソッドの第 11 引数。</param>
        /// <param name="arg12">メソッドの第 12 引数。</param>
        /// <param name="arg13">メソッドの第 13 引数。</param>
        public void Execute(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            this.Before.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));
            try
            {
                this.Method(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                this.Succeeded.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));
            }
            catch (Exception ex)
            {
                this.Failed.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, ex));
            }
            finally
            {
                this.After.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));
            }
        }
    }

    /// <summary>
    /// 14 個の引数を持ち、値を返さないメソッドのフック リストを表します。
    /// </summary>
    /// <typeparam name="TSelf">フックされるメソッドの <c>this</c> の型。</typeparam>
    /// <typeparam name="T1">フックされるメソッドの第 1 引数の型。</typeparam>
    /// <typeparam name="T2">フックされるメソッドの第 2 引数の型。</typeparam>
    /// <typeparam name="T3">フックされるメソッドの第 3 引数の型。</typeparam>
    /// <typeparam name="T4">フックされるメソッドの第 4 引数の型。</typeparam>
    /// <typeparam name="T5">フックされるメソッドの第 5 引数の型。</typeparam>
    /// <typeparam name="T6">フックされるメソッドの第 6 引数の型。</typeparam>
    /// <typeparam name="T7">フックされるメソッドの第 7 引数の型。</typeparam>
    /// <typeparam name="T8">フックされるメソッドの第 8 引数の型。</typeparam>
    /// <typeparam name="T9">フックされるメソッドの第 9 引数の型。</typeparam>
    /// <typeparam name="T10">フックされるメソッドの第 10 引数の型。</typeparam>
    /// <typeparam name="T11">フックされるメソッドの第 11 引数の型。</typeparam>
    /// <typeparam name="T12">フックされるメソッドの第 12 引数の型。</typeparam>
    /// <typeparam name="T13">フックされるメソッドの第 13 引数の型。</typeparam>
    /// <typeparam name="T14">フックされるメソッドの第 14 引数の型。</typeparam>
    public sealed class ActionHook<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
        : Hook<TSelf, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Action<TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Exception>>
    {
        /// <summary>
        /// <see cref="ActionHook{TSelf, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="action">フックの対象とするメソッドを表すデリゲート。</param>
        public ActionHook(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
            : base(action)
        {
        }

        /// <summary>
        /// フックを適用して、メソッドを実行します。
        /// </summary>
        /// <param name="arg1">メソッドの第 1 引数。</param>
        /// <param name="arg2">メソッドの第 2 引数。</param>
        /// <param name="arg3">メソッドの第 3 引数。</param>
        /// <param name="arg4">メソッドの第 4 引数。</param>
        /// <param name="arg5">メソッドの第 5 引数。</param>
        /// <param name="arg6">メソッドの第 6 引数。</param>
        /// <param name="arg7">メソッドの第 7 引数。</param>
        /// <param name="arg8">メソッドの第 8 引数。</param>
        /// <param name="arg9">メソッドの第 9 引数。</param>
        /// <param name="arg10">メソッドの第 10 引数。</param>
        /// <param name="arg11">メソッドの第 11 引数。</param>
        /// <param name="arg12">メソッドの第 12 引数。</param>
        /// <param name="arg13">メソッドの第 13 引数。</param>
        /// <param name="arg14">メソッドの第 14 引数。</param>
        public void Execute(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            this.Before.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14));
            try
            {
                this.Method(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                this.Succeeded.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14));
            }
            catch (Exception ex)
            {
                this.Failed.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, ex));
            }
            finally
            {
                this.After.ForEach(f => f(this.Self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14));
            }
        }
    }
}