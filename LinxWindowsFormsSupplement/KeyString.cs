// -*- mode: csharp; encoding: utf-8; tab-width: 4; c-basic-offset: 4; indent-tabs-mode: nil; -*-
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
// $Id: a7db7754a428ebb526d000b64ab4e48866a29032 $
/* LinxWindowsFormsSupplement
 *   Supplemental library for Windows Forms based on Linx Core Library
 *   Part of Linx
 * Linx
 *   Library that Integrates .NET with eXtremes
 * Copyright © 2008-2010 Takeshi KIRIYA (aka takeshik) <takeshik@users.sf.net>
 * All rights reserved.
 * 
 * This file is part of LinxWindowsFormsSupplement.
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
using System.Linq;
using System.Windows.Forms;
using Achiral.Extension;
using XSpect.Extension;

namespace XSpect.Windows.Forms
{
    public static class KeyString
    {
        public const String Control = "C-";

        public const String Meta = "M-";

        public const String Shift = "S-";

        public static Keys[] GetKeysArray(String keyString)
        {
            return keyString.Split(' ').Select(s =>
            {
                Keys keys = (Keys) Enum.Parse(typeof(Keys), s.Substring(s.LastIndexOf('-') + 1), true);
                if (s.Contains(Control))
                {
                    keys |= Keys.Control;
                }
                if (s.Contains(Meta))
                {
                    keys |= Keys.Alt;
                }
                if (s.Contains(Shift))
                {
                    keys |= Keys.Shift;
                }
                return keys;
            }).ToArray();
        }

        public static String ToKeyString(this Keys keys)
        {
            if (
                (keys & Keys.KeyCode) == Keys.ControlKey ||
                (keys & Keys.KeyCode) == Keys.Menu ||
                (keys & Keys.KeyCode) == Keys.ShiftKey
            )
            {
                return null;
            }
            return
                ((keys & Keys.Control) == Keys.Control ? Control : String.Empty) +
                ((keys & Keys.Alt) == Keys.Alt ? Meta : String.Empty) +
                ((keys & Keys.Shift) == Keys.Shift ? Shift : String.Empty) +
                (keys & Keys.KeyCode).ToString().If(s => s.Length == 1, s => s.ToLower());
        }
    }
}
