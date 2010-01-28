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
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using Achiral.Extension;
using XSpect.Extension;
using System.Collections.Generic;

namespace XSpect.Net
{
    public class HttpClient
        : Object
    {
        private static readonly Func<HttpWebResponse, Byte[]> _byteArrayConverter
            = res => res.GetResponseStream().Dispose(s => s.ReadAll());

        private static readonly Func<HttpWebResponse, Encoding, String> _stringConverterBase
            = (res, enc) => enc.GetString(_byteArrayConverter(res));

        public Action<HttpWebRequest> RequestInitializer
        {
            get;
            set;
        }

        public Action<HttpWebResponse> ResponseHandler
        {
            get;
            set;
        }

        public CookieContainer Cookies
        {
            get;
            set;
        }

        public ICredentials Credentials
        {
            get;
            set;
        }

        public IWebProxy Proxy
        {
            get;
            set;
        }

        public HttpClient()
        {
            this.RequestInitializer += req =>
            {
                req.Accept = @"text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                req.AllowAutoRedirect = false;
                req.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                req.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                req.CookieContainer = this.Cookies;
                req.Credentials = this.Credentials;
                req.KeepAlive = true;
                req.Pipelined = true;
                req.Proxy = this.Proxy;
            };
            this.ResponseHandler += res => res.Cookies
                .OfType<Cookie>()
                .ForEach(c =>
                {
                    c.Domain = c.Domain.StartsWith(".") ? c.Domain.Substring(1) : c.Domain;
                    this.Cookies.Add(c);
                });
        }

        public HttpClient(String userAgent)
            : this()
        {
            this.RequestInitializer += req => req.UserAgent = userAgent;
        }

        protected virtual HttpWebRequest CreateRequest(Uri uri, String method)
        {
            HttpWebRequest request = HttpWebRequest.Create(uri) as HttpWebRequest;
            this.RequestInitializer(request);
            request.Method = method;
            return request;
        }

        public virtual T Get<T>(Uri uri, Func<HttpWebResponse, T> converter)
        {
            return converter(this.CreateRequest(uri, "GET").GetResponse() as HttpWebResponse);
        }

        public Byte[] Get(Uri uri)
        {
            return this.Get(uri, _byteArrayConverter);
        }

        public String Get(Uri uri, Encoding encoding)
        {
            return this.Get(uri, _stringConverterBase.Bind2nd(encoding));
        }

        public virtual T Post<T>(Uri uri, Byte[] data, Func<HttpWebResponse, T> converter)
        {
            return converter(this.CreateRequest(uri, "POST")
                .Let(r => r.GetRequestStream().Dispose(s => s.Write(data, 0, data.Length)))
                .GetResponse()
            as HttpWebResponse);
        }

        public Byte[] Post(Uri uri, Byte[] data)
        {
            return this.Post(uri, data, _byteArrayConverter);
        }

        public String Post(Uri uri, Byte[] data, Encoding encoding)
        {
            return this.Post(uri, data, _stringConverterBase.Bind2nd(encoding));
        }

        public virtual T Put<T>(Uri uri, Func<HttpWebResponse, T> converter)
        {
            return converter(this.CreateRequest(uri, "PUT").GetResponse() as HttpWebResponse);
        }

        public Byte[] Put(Uri uri)
        {
            return this.Put(uri, _byteArrayConverter);
        }

        public String Put(Uri uri, Encoding encoding)
        {
            return this.Put(uri, _stringConverterBase.Bind2nd(encoding));
        }

        public virtual T Delete<T>(Uri uri, Func<HttpWebResponse, T> converter)
        {
            return converter(this.CreateRequest(uri, "DELETE").GetResponse() as HttpWebResponse);
        }

        public Byte[] Delete(Uri uri)
        {
            return this.Delete(uri, _byteArrayConverter);
        }

        public String Delete(Uri uri, Encoding encoding)
        {
            return this.Delete(uri, _stringConverterBase.Bind2nd(encoding));
        }
    }
}
