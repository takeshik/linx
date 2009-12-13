// -*- mode: csharp; encoding: utf-8; tab-width: 4; c-basic-offset: 4; indent-tabs-mode: nil; -*-
// vim:set ft=cs fenc=utf-8 ts=4 sw=4 sts=4 et:
// $Id: bcc0c291d83411d36be4f03a0c2db231930cb478 $
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using Achiral.Extension;
using Achiral;

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
            if (self == null)
            {
                return default(TResult);
            }
            else if (self == null || predicate(self))
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

        public static Nullable<TResult> Nullable<TReceiver, TResult>(this TReceiver self, Func<TReceiver, TResult> func)
            where TResult : struct
        {
            if (self == null)
            {
                return null;
            }
            else
            {
                return func(self);
            }
        }

        public static Nullable<TReceiver> NullIf<TReceiver>(this TReceiver self, Func<TReceiver, Boolean> predicate)
            where TReceiver : struct
        {
            if (predicate(self))
            {
                return null;
            }
            else
            {
                return self;
            }
        }

        public static Boolean IsDefault<TReceiver>(this TReceiver self)
        {
            return self.Equals(default(TReceiver));
        }

        public static TResult Do<TReceiver, TResult>(this TReceiver self, Func<TReceiver, TResult> func)
        {
            return func(self);
        }

        public static TResult[] Do<TReceiver, TResult>(this TReceiver self, params Func<TReceiver, TResult>[] funcs)
        {
            return funcs.Select(f => f(self)).ToArray();
        }

        public static TReceiver Do<TReceiver>(this TReceiver self, params Action<TReceiver>[] actions)
        {
            actions.ForEach(a => a(self));
            return self;
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
            return self.Do(o => writer.Write(o));
        }

        public static TReceiver WriteLine<TReceiver>(this TReceiver self, TextWriter writer)
        {
            return self.Do(o => writer.WriteLine(o));
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
            if (begin != null)
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
            if (begin != null)
            {
                end(self);
            }
        }

        public static Boolean EqualsAny(this Object self, params Object[] objects)
        {
            return objects.Any(self.Equals);
        }

        public static Boolean EqualsAll(this Object self, params Object[] objects)
        {
            return objects.All(self.Equals);
        }

        public static TResult MemberOf<TResult>(this Object self, String name)
        {
            MemberInfo member = self.GetType()
                .GetMember(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Single();
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    return (TResult) (member as FieldInfo).GetValue(self);
                case MemberTypes.Property:
                    return (TResult) (member as PropertyInfo).GetValue(self, null);
                case MemberTypes.Method:
                    return (TResult) ((Object) (member as MethodInfo).CreateDelegateFromType(typeof(TResult), self));
                default:
                    throw new NotSupportedException();
            }
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
            return origin.Walk(walker, parameters as IEnumerable<TParam>);
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

        public static IEnumerable<TSource> Next<TSource>(this TSource source, Func<IEnumerable<TSource>, TSource> generator)
        {
            return Make.Sequence(source).Next(generator);
        }

        public static IDictionary<String, Object> ToDictionary(this Object obj)
        {
            return obj.GetType().GetProperties()
                .Select(p => Create.KeyValuePair(p.Name, p.GetValue(obj, null)))
                .ToDictionary();
        }

    }
}