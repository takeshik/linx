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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Achiral;
using Achiral.Extension;
using XSpect;
using XSpect.Extension;

namespace XSpect
{
    public class Shell
        : Object
    {
        public Dictionary<String, String> Variables
        {
            get;
            set;
        }

        public String Prompt
        {
            get
            {
                if (!this.Variables.ContainsKey(".prompt"))
                {
                    this.Variables[".prompt"] = "> ";
                }
                return this.Variables[".prompt"];
            }
        }

        public String InputHeader
        {
            get
            {
                if (!this.Variables.ContainsKey(".hdr_input"))
                {
                    this.Variables[".hdr_input"] = " : ";
                }
                return this.Variables[".hdr_input"];
            }
        }

        public String OutputHeader
        {
            get
            {
                if (!this.Variables.ContainsKey(".hdr_output"))
                {
                    this.Variables[".hdr_output"] = " | ";
                }
                return this.Variables[".hdr_output"];
            }
        }

        public String ErrorHeader
        {
            get
            {
                if (!this.Variables.ContainsKey(".hdr_error"))
                {
                    this.Variables[".hdr_error"] = " * ";
                }
                return this.Variables[".hdr_error"];
            }
        }

        public Shell()
        {
            this.Variables = new Dictionary<String, String>();
        }

        public static IDictionary<String, String> GetArguments(String[] args, String baseFile)
        {
            Dictionary<String, String> arguments = new Dictionary<String, String>();
            if (!baseFile.IsNullOrEmpty() && new FileInfo(Assembly.GetCallingAssembly().Location).Directory.File(baseFile).Exists)
            {
                args = File.ReadAllLines("MetaTweet.args")
                    .Where(l => !(l.StartsWith("#") || String.IsNullOrEmpty(l)))
                    .Concat(args)
                    .ToArray();
            }
            foreach (Match match in args
                .Select(s => Regex.Match(s, "(-(?<key>[a-zA-Z0-9_]*)(=(?<value>(\"[^\"]*\")|('[^']*')|(.*)))?)*"))
                .Where(m => m.Success)
            )
            {
                arguments[match.Groups["key"].Value] = match.Groups["value"].Success
                    ? match.Groups["value"].Value
                    : "true";
            }
            return arguments;
        }

        public IList<String> Input(String terminator)
        {
            return Make.Repeat(() => Lambda.New(() =>
            {
                Console.Write(this.InputHeader);
                Console.ForegroundColor = ConsoleColor.White;
                String l = Console.ReadLine();
                Console.ResetColor();
                return l;
            }))
                .Select(f => f())
                .TakeWhile(s => s != terminator)
                .ToArray();
        }

        public String Read()
        {
            Console.Write(this.Prompt);
            Console.ForegroundColor = ConsoleColor.White;
            String l = Console.ReadLine();
            Console.ResetColor();
            return l;
        }

        public void Output(String str, params Object[] args)
        {
            str.Split(Make.Array(Environment.NewLine), StringSplitOptions.None)
                .ForEach(l =>
                {
                    Console.Write(this.OutputHeader);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(l, args);
                    Console.ResetColor();
                });
        }

        public void Fatal(String str, params Object[] args)
        {
            str.Split(Make.Array(Environment.NewLine), StringSplitOptions.None)
                .ForEach(l =>
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(this.ErrorHeader);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(l, args);
                    Console.ResetColor();
                });
        }

        public void Warn(String str, params Object[] args)
        {
            str.Split(Make.Array(Environment.NewLine), StringSplitOptions.None)
                .ForEach(l =>
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(this.ErrorHeader);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(l, args);
                    Console.ResetColor();
                });
        }

        public void Info(String str, params Object[] args)
        {
            str.Split(Make.Array(Environment.NewLine), StringSplitOptions.None)
                .ForEach(l =>
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(this.ErrorHeader);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(l, args);
                    Console.ResetColor();
                });
        }

    }
}