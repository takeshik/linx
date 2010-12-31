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

// Original: MutableTuples.cs from Mono Project
//
// Authors:
//  Zoltan Varga (vargaz@gmail.com)
//  Marek Safar (marek.safar@gmail.com)
//
// Copyright (C) 2009 Novell
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections;
using System.Collections.Generic;

namespace XSpect
{
    public partial class MutableTuple<T1, T2, T3, T4, T5, T6, T7, TRest>
    {
        public MutableTuple (T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, TRest rest)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
            this.item4 = item4;
            this.item5 = item5;
            this.item6 = item6;
            this.item7 = item7;
            this.rest = rest;

            bool ok = true;
            if (!typeof (TRest).IsGenericType)
               ok = false;
            if (ok) {
               Type t = typeof (TRest).GetGenericTypeDefinition ();
               if (!(t == typeof (MutableTuple<>) || t == typeof (MutableTuple<,>) || t == typeof (MutableTuple<,,>) || t == typeof (MutableTuple<,,,>) || t == typeof (MutableTuple<,,,,>) || t == typeof (MutableTuple <,,,,,>) || t == typeof (MutableTuple<,,,,,,>) || t == typeof (MutableTuple<,,,,,,,>)))
                   ok = false;
            }
            if (!ok)
               throw new ArgumentException ("The last element of an eight element tuple must be a MutableTuple.");
        }
    }

    public static class MutableTuple
    {
        public static MutableTuple<T1, T2, T3, T4, T5, T6, T7, MutableTuple<T8>> Create<T1, T2, T3, T4, T5, T6, T7, T8>
            (
             T1 item1,
             T2 item2,
             T3 item3,
             T4 item4,
             T5 item5,
             T6 item6,
             T7 item7,
             T8 item8)
        {
            return new MutableTuple<T1, T2, T3, T4, T5, T6, T7, MutableTuple<T8>>(item1, item2, item3, item4, item5, item6, item7, new MutableTuple<T8>(item8));
        }

        public static MutableTuple<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>
            (
             T1 item1,
             T2 item2,
             T3 item3,
             T4 item4,
             T5 item5,
             T6 item6,
             T7 item7)
        {
            return new MutableTuple<T1, T2, T3, T4, T5, T6, T7>(item1, item2, item3, item4, item5, item6, item7);
        }

        public static MutableTuple<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>
            (
             T1 item1,
             T2 item2,
             T3 item3,
             T4 item4,
             T5 item5,
             T6 item6)
        {
            return new MutableTuple<T1, T2, T3, T4, T5, T6>(item1, item2, item3, item4, item5, item6);
        }

        public static MutableTuple<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>
            (
             T1 item1,
             T2 item2,
             T3 item3,
             T4 item4,
             T5 item5)
        {
            return new MutableTuple<T1, T2, T3, T4, T5>(item1, item2, item3, item4, item5);
        }

        public static MutableTuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>
            (
             T1 item1,
             T2 item2,
             T3 item3,
             T4 item4)
        {
            return new MutableTuple<T1, T2, T3, T4>(item1, item2, item3, item4);
        }

        public static MutableTuple<T1, T2, T3> Create<T1, T2, T3>
            (
             T1 item1,
             T2 item2,
             T3 item3)
        {
            return new MutableTuple<T1, T2, T3>(item1, item2, item3);
        }

        public static MutableTuple<T1, T2> Create<T1, T2>
            (
             T1 item1,
             T2 item2)
        {
            return new MutableTuple<T1, T2>(item1, item2);
        }

        public static MutableTuple<T1> Create<T1>
            (
             T1 item1)
        {
            return new MutableTuple<T1>(item1);
        }
    }		

    [Serializable]
    public class MutableTuple<T1> : IStructuralEquatable, IStructuralComparable, IComparable
    {
        T1 item1;

        public MutableTuple()
        {
        }

        public MutableTuple (T1 item1)
        {
            this.item1 = item1;
        }

        public T1 Item1 {
            get { return item1; }
            set { item1 = value; }
        }

        int IComparable.CompareTo (object obj)
        {
            return ((IStructuralComparable) this).CompareTo (obj, Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo (object other, IComparer comparer)
        {
            var t = other as MutableTuple<T1>;
            if (t == null) {
               if (other == null) return 1;
               throw new ArgumentException ();
            }

            return comparer.Compare (item1, t.item1);
        }

        public override bool Equals (object obj)
        {
            return ((IStructuralEquatable) this).Equals (obj, EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals (object other, IEqualityComparer comparer)
        {
            var t = other as MutableTuple<T1>;
            if (t == null) {
               if (other == null) return false;
               throw new ArgumentException ();
            }

            return comparer.Equals (item1, t.item1);
        }

        public override int GetHashCode ()
        {
            return ((IStructuralEquatable) this).GetHashCode (EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode (IEqualityComparer comparer)
        {
            return comparer.GetHashCode (item1);
        }

        public override string ToString ()
        {
            return String.Format ("({0})", item1);
        }
    }

    [Serializable]
    public class MutableTuple<T1, T2> : IStructuralEquatable, IStructuralComparable, IComparable
    {
        T1 item1;
        T2 item2;

        public MutableTuple()
        {
        }

        public MutableTuple (T1 item1, T2 item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public T1 Item1 {
            get { return item1; }
            set { item1 = value; }
        }

        public T2 Item2 {
            get { return item2; }
            set { item2 = value; }
        }

        int IComparable.CompareTo (object obj)
        {
            return ((IStructuralComparable) this).CompareTo (obj, Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo (object other, IComparer comparer)
        {
            var t = other as MutableTuple<T1, T2>;
            if (t == null) {
               if (other == null) return 1;
               throw new ArgumentException ();
            }

            int res = comparer.Compare (item1, t.item1);
            if (res != 0) return res;
            return comparer.Compare (item2, t.item2);
        }

        public override bool Equals (object obj)
        {
            return ((IStructuralEquatable) this).Equals (obj, EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals (object other, IEqualityComparer comparer)
        {
            var t = other as MutableTuple<T1, T2>;
            if (t == null) {
               if (other == null) return false;
               throw new ArgumentException ();
            }

            return comparer.Equals (item1, t.item1) &&
               comparer.Equals (item2, t.item2);
        }

        public override int GetHashCode ()
        {
            return ((IStructuralEquatable) this).GetHashCode (EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode (IEqualityComparer comparer)
        {
            unchecked
            {
                int h = comparer.GetHashCode(item1);
                h = (h << 5) - h + comparer.GetHashCode(item2);
                return h;
            }
        }

        public override string ToString ()
        {
            return String.Format ("({0}, {1})", item1, item2);
        }
    }

    [Serializable]
    public class MutableTuple<T1, T2, T3> : IStructuralEquatable, IStructuralComparable, IComparable
    {
        T1 item1;
        T2 item2;
        T3 item3;

        public MutableTuple()
        {
        }

        public MutableTuple (T1 item1, T2 item2, T3 item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }

        public T1 Item1 {
            get { return item1; }
            set { item1 = value; }
        }

        public T2 Item2 {
            get { return item2; }
            set { item2 = value; }
        }

        public T3 Item3 {
            get { return item3; }
            set { item3 = value; }
        }

        int IComparable.CompareTo (object obj)
        {
            return ((IStructuralComparable) this).CompareTo (obj, Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo (object other, IComparer comparer)
        {
            var t = other as MutableTuple<T1, T2, T3>;
            if (t == null) {
               if (other == null) return 1;
               throw new ArgumentException ();
            }

            int res = comparer.Compare (item1, t.item1);
            if (res != 0) return res;
            res = comparer.Compare (item2, t.item2);
            if (res != 0) return res;
            return comparer.Compare (item3, t.item3);
        }

        public override bool Equals (object obj)
        {
            return ((IStructuralEquatable) this).Equals (obj, EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals (object other, IEqualityComparer comparer)
        {
            var t = other as MutableTuple<T1, T2, T3>;
            if (t == null) {
               if (other == null) return false;
               throw new ArgumentException ();
            }

            return comparer.Equals (item1, t.item1) &&
               comparer.Equals (item2, t.item2) &&
               comparer.Equals (item3, t.item3);
        }

        public override int GetHashCode ()
        {
            return ((IStructuralEquatable) this).GetHashCode (EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            unchecked
            {
                int h = comparer.GetHashCode(item1);
                h = (h << 5) - h + comparer.GetHashCode(item2);
                h = (h << 5) - h + comparer.GetHashCode(item3);
                return h;
            }
        }

        public override string ToString ()
        {
            return String.Format ("({0}, {1}, {2})", item1, item2, item3);
        }
    }

    [Serializable]
    public class MutableTuple<T1, T2, T3, T4> : IStructuralEquatable, IStructuralComparable, IComparable
    {
        T1 item1;
        T2 item2;
        T3 item3;
        T4 item4;

        public MutableTuple()
        {
        }

        public MutableTuple (T1 item1, T2 item2, T3 item3, T4 item4)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
            this.item4 = item4;
        }

        public T1 Item1 {
            get { return item1; }
            set { item1 = value; }
        }

        public T2 Item2 {
            get { return item2; }
            set { item2 = value; }
        }

        public T3 Item3 {
            get { return item3; }
            set { item3 = value; }
        }

        public T4 Item4 {
            get { return item4; }
            set { item4 = value; }
        }

        int IComparable.CompareTo (object obj)
        {
            return ((IStructuralComparable) this).CompareTo (obj, Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo (object other, IComparer comparer)
        {
            var t = other as MutableTuple<T1, T2, T3, T4>;
            if (t == null) {
               if (other == null) return 1;
               throw new ArgumentException ();
            }

            int res = comparer.Compare (item1, t.item1);
            if (res != 0) return res;
            res = comparer.Compare (item2, t.item2);
            if (res != 0) return res;
            res = comparer.Compare (item3, t.item3);
            if (res != 0) return res;
            return comparer.Compare (item4, t.item4);
        }

        public override bool Equals (object obj)
        {
            return ((IStructuralEquatable) this).Equals (obj, EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals (object other, IEqualityComparer comparer)
        {
            var t = other as MutableTuple<T1, T2, T3, T4>;
            if (t == null) {
               if (other == null) return false;
               throw new ArgumentException ();
            }

            return comparer.Equals (item1, t.item1) &&
               comparer.Equals (item2, t.item2) &&
               comparer.Equals (item3, t.item3) &&
               comparer.Equals (item4, t.item4);
        }

        public override int GetHashCode ()
        {
            return ((IStructuralEquatable) this).GetHashCode (EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            unchecked
            {
                int h = comparer.GetHashCode(item1);
                h = (h << 5) - h + comparer.GetHashCode(item2);
                h = (h << 5) - h + comparer.GetHashCode(item3);
                h = (h << 5) - h + comparer.GetHashCode(item4);
                return h;
            }
        }

        public override string ToString ()
        {
            return String.Format ("({0}, {1}, {2}, {3})", item1, item2, item3, item4);
        }
    }

    [Serializable]
    public class MutableTuple<T1, T2, T3, T4, T5> : IStructuralEquatable, IStructuralComparable, IComparable
    {
        T1 item1;
        T2 item2;
        T3 item3;
        T4 item4;
        T5 item5;

        public MutableTuple()
        {
        }

        public MutableTuple (T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
            this.item4 = item4;
            this.item5 = item5;
        }

        public T1 Item1 {
            get { return item1; }
            set { item1 = value; }
        }

        public T2 Item2 {
            get { return item2; }
            set { item2 = value; }
        }

        public T3 Item3 {
            get { return item3; }
            set { item3 = value; }
        }

        public T4 Item4 {
            get { return item4; }
            set { item4 = value; }
        }

        public T5 Item5 {
            get { return item5; }
            set { item5 = value; }
        }

        int IComparable.CompareTo (object obj)
        {
            return ((IStructuralComparable) this).CompareTo (obj, Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo (object other, IComparer comparer)
        {
            var t = other as MutableTuple<T1, T2, T3, T4, T5>;
            if (t == null) {
               if (other == null) return 1;
               throw new ArgumentException ();
            }

            int res = comparer.Compare (item1, t.item1);
            if (res != 0) return res;
            res = comparer.Compare (item2, t.item2);
            if (res != 0) return res;
            res = comparer.Compare (item3, t.item3);
            if (res != 0) return res;
            res = comparer.Compare (item4, t.item4);
            if (res != 0) return res;
            return comparer.Compare (item5, t.item5);
        }

        public override bool Equals (object obj)
        {
            return ((IStructuralEquatable) this).Equals (obj, EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals (object other, IEqualityComparer comparer)
        {
            var t = other as MutableTuple<T1, T2, T3, T4, T5>;
            if (t == null) {
               if (other == null) return false;
               throw new ArgumentException ();
            }

            return comparer.Equals (item1, t.item1) &&
               comparer.Equals (item2, t.item2) &&
               comparer.Equals (item3, t.item3) &&
               comparer.Equals (item4, t.item4) &&
               comparer.Equals (item5, t.item5);
        }

        public override int GetHashCode ()
        {
            return ((IStructuralEquatable) this).GetHashCode (EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            unchecked
            {
                int h = comparer.GetHashCode(item1);
                h = (h << 5) - h + comparer.GetHashCode(item2);
                h = (h << 5) - h + comparer.GetHashCode(item3);
                h = (h << 5) - h + comparer.GetHashCode(item4);
                h = (h << 5) - h + comparer.GetHashCode(item5);
                return h;
            }
        }

        public override string ToString ()
        {
            return String.Format ("({0}, {1}, {2}, {3}, {4})", item1, item2, item3, item4, item5);
        }
    }

    [Serializable]
    public class MutableTuple<T1, T2, T3, T4, T5, T6> : IStructuralEquatable, IStructuralComparable, IComparable
    {
        T1 item1;
        T2 item2;
        T3 item3;
        T4 item4;
        T5 item5;
        T6 item6;

        public MutableTuple()
        {
        }

        public MutableTuple (T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
            this.item4 = item4;
            this.item5 = item5;
            this.item6 = item6;
        }

        public T1 Item1 {
            get { return item1; }
            set { item1 = value; }
        }

        public T2 Item2 {
            get { return item2; }
            set { item2 = value; }
        }

        public T3 Item3 {
            get { return item3; }
            set { item3 = value; }
        }

        public T4 Item4 {
            get { return item4; }
            set { item4 = value; }
        }

        public T5 Item5 {
            get { return item5; }
            set { item5 = value; }
        }

        public T6 Item6 {
            get { return item6; }
            set { item6 = value; }
        }

        int IComparable.CompareTo (object obj)
        {
            return ((IStructuralComparable) this).CompareTo (obj, Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo (object other, IComparer comparer)
        {
            var t = other as MutableTuple<T1, T2, T3, T4, T5, T6>;
            if (t == null) {
               if (other == null) return 1;
               throw new ArgumentException ();
            }

            int res = comparer.Compare (item1, t.item1);
            if (res != 0) return res;
            res = comparer.Compare (item2, t.item2);
            if (res != 0) return res;
            res = comparer.Compare (item3, t.item3);
            if (res != 0) return res;
            res = comparer.Compare (item4, t.item4);
            if (res != 0) return res;
            res = comparer.Compare (item5, t.item5);
            if (res != 0) return res;
            return comparer.Compare (item6, t.item6);
        }

        public override bool Equals (object obj)
        {
            return ((IStructuralEquatable) this).Equals (obj, EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals (object other, IEqualityComparer comparer)
        {
            var t = other as MutableTuple<T1, T2, T3, T4, T5, T6>;
            if (t == null) {
               if (other == null) return false;
               throw new ArgumentException ();
            }

            return comparer.Equals (item1, t.item1) &&
               comparer.Equals (item2, t.item2) &&
               comparer.Equals (item3, t.item3) &&
               comparer.Equals (item4, t.item4) &&
               comparer.Equals (item5, t.item5) &&
               comparer.Equals (item6, t.item6);
        }

        public override int GetHashCode ()
        {
            return ((IStructuralEquatable) this).GetHashCode (EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            unchecked
            {
                int h = comparer.GetHashCode(item1);
                h = (h << 5) - h + comparer.GetHashCode(item2);
                h = (h << 5) - h + comparer.GetHashCode(item3);
                h = (h << 5) - h + comparer.GetHashCode(item4);
                h = (h << 5) - h + comparer.GetHashCode(item5);
                h = (h << 5) - h + comparer.GetHashCode(item6);
                return h;
            }
        }

        public override string ToString ()
        {
            return String.Format ("({0}, {1}, {2}, {3}, {4}, {5})", item1, item2, item3, item4, item5, item6);
        }
    }

    [Serializable]
    public class MutableTuple<T1, T2, T3, T4, T5, T6, T7> : IStructuralEquatable, IStructuralComparable, IComparable
    {
        T1 item1;
        T2 item2;
        T3 item3;
        T4 item4;
        T5 item5;
        T6 item6;
        T7 item7;

        public MutableTuple()
        {
        }

        public MutableTuple (T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
            this.item4 = item4;
            this.item5 = item5;
            this.item6 = item6;
            this.item7 = item7;
        }

        public T1 Item1 {
            get { return item1; }
            set { item1 = value; }
        }

        public T2 Item2 {
            get { return item2; }
            set { item2 = value; }
        }

        public T3 Item3 {
            get { return item3; }
            set { item3 = value; }
        }

        public T4 Item4 {
            get { return item4; }
            set { item4 = value; }
        }

        public T5 Item5 {
            get { return item5; }
            set { item5 = value; }
        }

        public T6 Item6 {
            get { return item6; }
            set { item6 = value; }
        }

        public T7 Item7 {
            get { return item7; }
            set { item7 = value; }
        }

        int IComparable.CompareTo (object obj)
        {
            return ((IStructuralComparable) this).CompareTo (obj, Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo (object other, IComparer comparer)
        {
            var t = other as MutableTuple<T1, T2, T3, T4, T5, T6, T7>;
            if (t == null) {
               if (other == null) return 1;
               throw new ArgumentException ();
            }

            int res = comparer.Compare (item1, t.item1);
            if (res != 0) return res;
            res = comparer.Compare (item2, t.item2);
            if (res != 0) return res;
            res = comparer.Compare (item3, t.item3);
            if (res != 0) return res;
            res = comparer.Compare (item4, t.item4);
            if (res != 0) return res;
            res = comparer.Compare (item5, t.item5);
            if (res != 0) return res;
            res = comparer.Compare (item6, t.item6);
            if (res != 0) return res;
            return comparer.Compare (item7, t.item7);
        }

        public override bool Equals (object obj)
        {
            return ((IStructuralEquatable) this).Equals (obj, EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals (object other, IEqualityComparer comparer)
        {
            var t = other as MutableTuple<T1, T2, T3, T4, T5, T6, T7>;
            if (t == null) {
               if (other == null) return false;
               throw new ArgumentException ();
            }

            return comparer.Equals (item1, t.item1) &&
               comparer.Equals (item2, t.item2) &&
               comparer.Equals (item3, t.item3) &&
               comparer.Equals (item4, t.item4) &&
               comparer.Equals (item5, t.item5) &&
               comparer.Equals (item6, t.item6) &&
               comparer.Equals (item7, t.item7);
        }

        public override int GetHashCode ()
        {
            return ((IStructuralEquatable) this).GetHashCode (EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            unchecked
            {
                int h = comparer.GetHashCode(item1);
                h = (h << 5) - h + comparer.GetHashCode(item2);
                h = (h << 5) - h + comparer.GetHashCode(item3);
                h = (h << 5) - h + comparer.GetHashCode(item4);
                h = (h << 5) - h + comparer.GetHashCode(item5);
                h = (h << 5) - h + comparer.GetHashCode(item6);
                h = (h << 5) - h + comparer.GetHashCode(item7);
                return h;
            }
        }

        public override string ToString ()
        {
            return String.Format ("({0}, {1}, {2}, {3}, {4}, {5}, {6})", item1, item2, item3, item4, item5, item6, item7);
        }
    }

    [Serializable]
    public partial class MutableTuple<T1, T2, T3, T4, T5, T6, T7, TRest> : IStructuralEquatable, IStructuralComparable, IComparable
    {
        T1 item1;
        T2 item2;
        T3 item3;
        T4 item4;
        T5 item5;
        T6 item6;
        T7 item7;
        TRest rest;

        public MutableTuple()
        {
        }

        public T1 Item1 {
            get { return item1; }
            set { item1 = value; }
        }

        public T2 Item2 {
            get { return item2; }
            set { item2 = value; }
        }

        public T3 Item3 {
            get { return item3; }
            set { item3 = value; }
        }

        public T4 Item4 {
            get { return item4; }
            set { item4 = value; }
        }

        public T5 Item5 {
            get { return item5; }
            set { item5 = value; }
        }

        public T6 Item6 {
            get { return item6; }
            set { item6 = value; }
        }

        public T7 Item7 {
            get { return item7; }
            set { item7 = value; }
        }

        public TRest Rest {
            get { return rest; }
            set { rest = value; }
        }

        int IComparable.CompareTo (object obj)
        {
            return ((IStructuralComparable) this).CompareTo (obj, Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo (object other, IComparer comparer)
        {
            var t = other as MutableTuple<T1, T2, T3, T4, T5, T6, T7, TRest>;
            if (t == null) {
               if (other == null) return 1;
               throw new ArgumentException ();
            }

            int res = comparer.Compare (item1, t.item1);
            if (res != 0) return res;
            res = comparer.Compare (item2, t.item2);
            if (res != 0) return res;
            res = comparer.Compare (item3, t.item3);
            if (res != 0) return res;
            res = comparer.Compare (item4, t.item4);
            if (res != 0) return res;
            res = comparer.Compare (item5, t.item5);
            if (res != 0) return res;
            res = comparer.Compare (item6, t.item6);
            if (res != 0) return res;
            res = comparer.Compare (item7, t.item7);
            if (res != 0) return res;
            return comparer.Compare (rest, t.rest);
        }

        public override bool Equals (object obj)
        {
            return ((IStructuralEquatable) this).Equals (obj, EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals (object other, IEqualityComparer comparer)
        {
            var t = other as MutableTuple<T1, T2, T3, T4, T5, T6, T7, TRest>;
            if (t == null) {
               if (other == null) return false;
               throw new ArgumentException ();
            }

            return comparer.Equals (item1, t.item1) &&
               comparer.Equals (item2, t.item2) &&
               comparer.Equals (item3, t.item3) &&
               comparer.Equals (item4, t.item4) &&
               comparer.Equals (item5, t.item5) &&
               comparer.Equals (item6, t.item6) &&
               comparer.Equals (item7, t.item7) &&
               comparer.Equals (rest, t.rest);
        }

        public override int GetHashCode ()
        {
            return ((IStructuralEquatable) this).GetHashCode (EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            unchecked
            {
                int h = comparer.GetHashCode(item1);
                h = (h << 5) - h + comparer.GetHashCode(item2);
                h = (h << 5) - h + comparer.GetHashCode(item3);
                h = (h << 5) - h + comparer.GetHashCode(item4);
                h = (h << 5) - h + comparer.GetHashCode(item5);
                h = (h << 5) - h + comparer.GetHashCode(item6);
                h = (h << 5) - h + comparer.GetHashCode(item7);
                h = (h << 5) - h + comparer.GetHashCode(rest);
                return h;
            }
        }

        public override string ToString ()
        {
            return String.Format ("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})", item1, item2, item3, item4, item5, item6, item7, rest);
        }
    }
}
