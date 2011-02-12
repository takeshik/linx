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

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using Achiral;
using Achiral.Extension;

namespace XSpect.Extension
{
    public static class ObjectUtil
    {
        public static Boolean If<TReceiver>(this TReceiver self, Func<TReceiver, Boolean> predicate)
        {
            return predicate(self);
        }

        public static TResult If<TReceiver, TResult>(this TReceiver self, Func<TReceiver, Boolean> predicate, TResult valueIfTrue, TResult valueIfFalse)
        {
            if (self == null)
            {
                return default(TResult);
            }
            else if (self == null || predicate(self))
            {
                return valueIfTrue;
            }
            else
            {
                return valueIfFalse;
            }
        }

        public static TReceiver If<TReceiver>(this TReceiver self, Func<TReceiver, Boolean> predicate, TReceiver valueIfTrue)
        {
            return self.If(predicate, valueIfTrue, self);
        }

        public static TResult If<TReceiver, TResult>(this TReceiver self, Func<TReceiver, Boolean> predicate, Func<TReceiver, TResult> funcIfTrue, Func<TReceiver, TResult> funcIfFalse)
        {
            if (predicate(self))
            {
                return funcIfTrue(self);
            }
            else
            {
                return funcIfFalse(self);
            }
        }

        public static TReceiver If<TReceiver>(this TReceiver self, Func<TReceiver, Boolean> predicate, Func<TReceiver, TReceiver> funcIfTrue)
        {
            return self.If(predicate, funcIfTrue, Lambda.Id<TReceiver>());
        }

        public static TReceiver If<TReceiver>(this TReceiver self, Func<TReceiver, Boolean> predicate, Action<TReceiver> actionIfTrue, Action<TReceiver> actionIfFalse)
        {
            if (predicate(self))
            {
                actionIfTrue(self);
            }
            else
            {
                actionIfFalse(self);
            }
            return self;
        }

        public static TReceiver If<TReceiver>(this TReceiver self, Func<TReceiver, Boolean> predicate, Action<TReceiver> actionIfTrue)
        {
            return self.If(predicate, actionIfTrue, Lambda.Nop<TReceiver>());
        }

        public static TResult Null<TReceiver, TResult>(this TReceiver self, Func<TReceiver, TResult> func, TResult valueIfNull)
            where TReceiver : class
        {
            if (self == null)
            {
                return valueIfNull;
            }
            else
            {
                return func(self);
            }
        }

        public static TResult Null<TReceiver, TResult>(this TReceiver self, Func<TReceiver, TResult> func)
            where TReceiver : class
        {
            return Null(self, func, default(TResult));
        }

        public static void Null<TReceiver>(this TReceiver self, Action<TReceiver> action)
        {
            if (self != null)
            {
                action(self);
            }
        }

        public static TResult Let<TReceiver, TResult>(this TReceiver self, Func<TReceiver, TResult> func)
        {
            return func(self);
        }

        public static TReceiver Apply<TReceiver>(this TReceiver self, params Action<TReceiver>[] actions)
        {
            return Apply(self, (IEnumerable<Action<TReceiver>>) actions);
        }

        public static TReceiver Apply<TReceiver>(this TReceiver self, IEnumerable<Action<TReceiver>> actions)
        {
            actions.ForEach(a => a(self));
            return self;
        }

        public static IEnumerable<TSource> ToEnumerable<TSource>(this TSource source)
        {
            yield return source;
        }

        public static TReceiver Write<TReceiver>(this TReceiver self)
        {
            return self.Write(Console.Out);
        }

        public static TReceiver WriteLine<TReceiver>(this TReceiver self)
        {
            return self.WriteLine(Console.Out);
        }

        public static TReceiver Write<TReceiver>(this TReceiver self, TextWriter writer)
        {
            return self.Apply(o => writer.Write(o));
        }

        public static TReceiver WriteLine<TReceiver>(this TReceiver self, TextWriter writer)
        {
            return self.Apply(o => writer.WriteLine(o));
        }

        public static void Void(this Object self)
        {
            return;
        }

        public static Boolean True(this Object self)
        {
            return true;
        }

        public static Boolean False(this Object self)
        {
            return false;
        }

        public static Boolean Try<TReceiver, TResult>(this TReceiver self, Func<TReceiver, TResult> func, out TResult result)
        {
            try
            {
                result = func(self);
                return true;
            }
            catch (Exception)
            {
                result = default(TResult);
                return false;
            }
        }

        public static Boolean Try<TReceiver>(this TReceiver self, Action<TReceiver> action)
        {
            try
            {
                action(self);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static TResult Scope<TReceiver, TResult>(
            this TReceiver self,
            Action<TReceiver> begin,
            Func<TReceiver, TResult> body,
            Action<TReceiver> end
        )
        {
            if (begin != null)
            {
                begin(self);
            }
            TResult ret = body(self);
            if (end != null)
            {
                end(self);
            }
            return ret;
        }

        public static void Scope<TReceiver>(
            this TReceiver self,
            Action<TReceiver> begin,
            Action<TReceiver> body,
            Action<TReceiver> end
        )
        {
            if (begin != null)
            {
                begin(self);
            }
            body(self);
            if (end != null)
            {
                end(self);
            }
        }

        public static TResult Scope<TReceiver, TResult>(
            this TReceiver self,
            Action<TReceiver> begin,
            Action<TReceiver> body,
            Func<TReceiver, TResult> end
        )
        {
            if (begin != null)
            {
                begin(self);
            }
            body(self);
            return end != null
                ? end(self)
                : default(TResult);
        }

        public static Boolean EqualsAny(this Object self, params Object[] objects)
        {
            return objects.Any(self.Equals);
        }

        public static Boolean EqualsAll(this Object self, params Object[] objects)
        {
            return objects.All(self.Equals);
        }

        public static TReturn Walk<TReturn, TParam>(this TReturn origin, Func<TReturn, TParam, TReturn> walker, IEnumerable<TParam> parameters)
        {
            if (parameters.Any())
            {
                return parameters.Select(p => origin = walker(origin, p)).Last();
            }
            else
            {
                return origin;
            }
        }

        public static TReturn Walk<TReturn, TParam>(this TReturn origin, Func<TReturn, TParam, TReturn> walker, params TParam[] parameters)
        {
            return origin.Walk(walker, (IEnumerable<TParam>) parameters);
        }

        public static IEnumerable<TSource> Walk<TSource>(this TSource origin, Func<TSource, TSource> walker, Func<TSource, Boolean> terminator)
        {
            for (TSource obj = origin; !terminator(obj); obj = walker(obj))
            {
                yield return obj;
            }
        }

        public static IEnumerable<TSource> Walk<TSource>(this TSource origin, Func<TSource, TSource> walker)
        {
            return Walk(origin, walker, s => s.Equals(default(TSource)));
        }

        public static TReceiver MemberwiseClone<TReceiver>(this TReceiver self)
        {
            return (TReceiver) self.GetType()
                .GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic)
                .Invoke(self, null);
        }

        public static TReceiver Merge<TReceiver>(this TReceiver self, TReceiver difference)
            where TReceiver : new()
        {
            TReceiver init = new TReceiver();
            TReceiver result = self.MemberwiseClone();
            Object v = null;
            typeof(TReceiver).GetFields(BindingFlags.Instance | BindingFlags.Public)
                .Where(f => f.GetValue(init) != (v = f.GetValue(difference)))
                .ForEach(f => f.SetValue(result, v));
            typeof(TReceiver).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p =>
                    p.CanRead &&
                    p.CanWrite &&
                    p.GetValue(init, null) != (v = p.GetValue(difference, null))
                )
                .ForEach(p => p.SetValue(result, v, null));
            return result;
        }

        public static IDictionary<String, Object> ToDictionary(this Object obj)
        {
            return obj.GetType().GetProperties()
                .Select(p => Create.KeyValuePair(p.Name, p.GetValue(obj, null)))
                .ToDictionary();
        }
    }
}