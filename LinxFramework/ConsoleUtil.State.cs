// -*- mode: csharp; encoding: utf-8; tab-width: 4; c-basic-offset: 4; indent-tabs-mode: nil; -*-
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
// $Id: a7db7754a428ebb526d000b64ab4e48866a29032 $
/* LinxFramework
 *   Practical class library based on Linx Core Library
 *   Part of Linx
 * Linx
 *   Library that Integrates .NET with eXtremes
 * Copyright c 2008-2009 Takeshi KIRIYA, XSpect Project <takeshik@users.sf.net>
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

namespace XSpect
{
    partial class ConsoleUtil
    {
        private struct State
        {
            private ConsoleColor _foregroundColor;
            private ConsoleColor _backgroundColor;
            private Int32 _cursorLeft;
            private Int32 _cursorTop;
            private Boolean _cursorVisible;
            private String _title;
            private Int32 _bufferWidth;
            private Int32 _bufferHeight;
            private Int32 _windowWidth;
            private Int32 _windowHeight;
            private Int32 _windowLeft;
            private Int32 _windowTop;

            public static State Capture()
            {
                State state;
                state._foregroundColor = Console.ForegroundColor;
                state._backgroundColor = Console.BackgroundColor;
                state._cursorLeft = Console.CursorLeft;
                state._cursorTop = Console.CursorTop;
                state._cursorVisible = Console.CursorVisible;
                state._title = Console.Title;
                state._bufferWidth = Console.BufferWidth;
                state._bufferHeight = Console.BufferHeight;
                state._windowWidth = Console.WindowWidth;
                state._windowHeight = Console.WindowHeight;
                state._windowLeft = Console.WindowLeft;
                state._windowTop = Console.WindowTop;
                return state;
            }

            public void Restore(Boolean restoreCursorPosition)
            {
                Console.ForegroundColor = this._foregroundColor;
                Console.BackgroundColor = this._backgroundColor;

                if (restoreCursorPosition)
                {
                    Console.CursorLeft = this._cursorLeft;
                    Console.CursorTop = this._cursorTop;
                }

                try
                {
                    Console.CursorVisible = this._cursorVisible;
                    Console.Title = this._title;
                    Console.BufferWidth = this._bufferWidth;
                    Console.BufferHeight = this._bufferHeight;
                    Console.WindowWidth = this._windowWidth;
                    Console.WindowHeight = this._windowHeight;
                    Console.WindowLeft = this._windowLeft;
                    Console.WindowTop = this._windowTop;
                }
                catch (Exception)
                {
                    // STUB
                    // TODO: Think what he have to do.
                }
            }
        }
    }
}