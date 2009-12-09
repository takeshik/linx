﻿// -*- mode: csharp; encoding: utf-8; tab-width: 4; c-basic-offset: 4; indent-tabs-mode: nil; -*-
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
// $Id: BooleanUtil.cs 34861 2009-08-12 16:14:56Z takeshik $
/* Linx
 *   Library that Integrates .NET with eXtremes
 * Copyright © 2008-2009 Takeshi KIRIYA, XSpect Project <takeshik@users.sf.net>
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Achiral.Extension;

namespace XSpect.Extension
{
    public static class BooleanUtil
    {
        public static void Then(this Boolean condition, Action action)
        {
            if (condition)
            {
                action();
            }
        }

        public static void Else(this Boolean condition, Action action)
        {
            if (!condition)
            {
                action();
            }
        }

        public static void ThenElse(this Boolean condition, Action actionIfTrue, Action actionIfFalse)
        {
            if (condition)
            {
                actionIfTrue();
            }
            else
            {
                actionIfFalse();
            }
        }

        public static TResult ThenElse<TResult>(this Boolean condition, Func<TResult> funcIfTrue, Func<TResult> funcIfFalse)
        {
            if (condition)
            {
                return funcIfTrue();
            }
            else
            {
                return funcIfFalse();
            }
        }
    }
}