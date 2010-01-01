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
using System.Collections.Generic;

namespace XSpect.Hooking
{
    /// <summary>
    /// フック リストの抽象基本クラスを提供します。
    /// </summary>
    /// <typeparam name="TSelf">フックされるメソッドの <c>this</c> の型。</typeparam>
    /// <typeparam name="TMethod">フックされるメソッドのデリゲートの型。</typeparam>
    /// <typeparam name="TBeforeAfter"><see cref="Before"/> および <see cref="After"/> フックのデリゲートの型。</typeparam>
    /// <typeparam name="TSucceeded"><see cref="Succeeded"/> フックのデリゲートの型。</typeparam>
    /// <typeparam name="TFailed"><see cref="Failed"/> フックのデリゲートの型。</typeparam>
    public abstract class Hook<TSelf, TMethod, TBeforeAfter, TSucceeded, TFailed>
    {
        /// <summary>
        /// このフック リストが呼び出すメソッドの <c>this</c> の値を取得します。
        /// </summary>
        /// <value>
        /// このフック リストが呼び出すメソッドの <c>this</c> の値。
        /// </value>
        public TSelf Self
        {
            get;
            private set;
        }

        /// <summary>
        /// このフック リストが呼び出すメソッドを表すデリゲートを取得します。
        /// </summary>
        /// <value>
        /// このフック リストが呼び出すメソッドを表すデリゲート。
        /// </value>
        public TMethod Method
        {
            get;
            private set;
        }

        /// <summary>
        /// メソッドが呼び出される前に実行されるフックのリストを取得します。
        /// </summary>
        /// <value>
        /// メソッドが呼び出される前に実行されるフックのリスト。
        /// </value>
        public IList<TBeforeAfter> Before
        {
            get;
            private set;
        }

        /// <summary>
        /// メソッドの呼び出しが成功した後に実行されるフックのリストを取得します。
        /// </summary>
        /// <value>
        /// メソッドの呼び出しが成功した後に実行されるフックのリスト。
        /// </value>
        public IList<TSucceeded> Succeeded
        {
            get;
            private set;
        }

        /// <summary>
        /// メソッドの呼び出しが失敗した後に実行されるフックのリストを取得します。
        /// </summary>
        /// <value>
        /// メソッドの呼び出しが失敗した後に実行されるフックのリスト。
        /// </value>
        public IList<TFailed> Failed
        {
            get;
            private set;
        }

        /// <summary>
        /// メソッドの呼び出しが成功したかどうかに関わらず、一番最後に実行されるフックのリストを取得します。
        /// </summary>
        /// <value>
        /// メソッドの呼び出しが成功したかどうかに関わらず、一番最後に実行されるフックのリスト。
        /// </value>
        public IList<TBeforeAfter> After
        {
            get;
            private set;
        }

        /// <summary>
        /// <see cref="Hook"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="method">フックの対象とするメソッドを表すデリゲート。</param>
        protected Hook(TMethod method)
        {
            this.Method = method;
            this.Self = (TSelf) (method as Delegate).Target;
            this.Before = new List<TBeforeAfter>();
            this.Succeeded = new List<TSucceeded>();
            this.Failed = new List<TFailed>();
            this.After = new List<TBeforeAfter>();
        }
    }
}