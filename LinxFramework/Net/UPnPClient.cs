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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Achiral.Extension;
using XSpect.Extension;

namespace XSpect.Net
{
    public class UPnPClient
        : Object,
          IDisposable
    {
        private readonly IPAddress _clientAddr;

        private readonly IPAddress _igdAddr;

        private readonly List<Int32> _openedPorts;

        public UPnPClient()
            : this(NetworkInterface.GetAllNetworkInterfaces()
                .Single(nif => nif.NetworkInterfaceType != NetworkInterfaceType.Loopback)
            )
        {
        }

        public UPnPClient(NetworkInterface networkInterface)
            : this(networkInterface, networkInterface.GetIPProperties().UnicastAddresses.Single().Address)
        {
        }

        public UPnPClient(NetworkInterface networkInterface, IPAddress clientAddr)
            : this(networkInterface, clientAddr, networkInterface.GetIPProperties().GatewayAddresses.Single().Address)
        {
        }

        public UPnPClient(NetworkInterface networkInterface, IPAddress clientAddr, IPAddress igdAddr)
        {
            this._openedPorts = new List<Int32>();

            if (networkInterface.GetIPProperties().UnicastAddresses
                .Select(addrInfo => addrInfo.Address)
                .Contains(clientAddr)
            )
            {
                this._clientAddr = clientAddr;
            }
            else
            {
                throw new ArgumentException("Invalid IP address", "clientAddr");
            }

            if (networkInterface.GetIPProperties().GatewayAddresses
                .Select(addrInfo => addrInfo.Address)
                .Contains(igdAddr)
            )
            {
                this._igdAddr = igdAddr;
            }
            else
            {
                throw new ArgumentException("Invalid IGD address", "igdAddr");
            }
        }

        public virtual void Open(Int32 port)
        {
            Int32 remotePort = -1;
            XDocument services = this.Discover(out remotePort);
            if (remotePort < 0)
            {
                throw new InvalidOperationException();
            }
            try
            {
                this.AddPortMapping(services, "urn:schemas-upnp-org:service:WANIPConnection:1", ProtocolType.Tcp, port);
            }
            catch (InvalidOperationException)
            {
                this.AddPortMapping(services, "urn:schemas-upnp-org:service:WANPPPConnection:1", ProtocolType.Tcp, port);
            }
        }

        public virtual void Close(Int32 port)
        {
            Int32 remotePort = -1;
            XDocument services = this.Discover(out remotePort);
            if (remotePort < 0)
            {
                throw new InvalidOperationException();
            }
            try
            {
                this.DeletePortMapping(services, "urn:schemas-upnp-org:service:WANIPConnection:1", ProtocolType.Tcp, port);
            }
            catch (InvalidOperationException)
            {
                this.DeletePortMapping(services, "urn:schemas-upnp-org:service:WANPPPConnection:1", ProtocolType.Tcp, port);
            }
        }

        public virtual IPAddress GetIPAddress()
        {
            Int32 remotePort = -1;
            XDocument services = this.Discover(out remotePort);
            if (remotePort < 0)
            {
                throw new InvalidOperationException();
            }
            try
            {
                return this.GetExternalIPAddress(services, "urn:schemas-upnp-org:service:WANIPConnection:1");
            }
            catch (InvalidOperationException)
            {
                return this.GetExternalIPAddress(services, "urn:schemas-upnp-org:service:WANPPPConnection:1");
            }
        }

        protected virtual XDocument Discover(out Int32 responsePort)
        {
            Socket socketClient = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Dgram,
                ProtocolType.Udp
            );
            socketClient.SetSocketOption(
                SocketOptionLevel.Socket,
                SocketOptionName.ReceiveTimeout,
                5000
            );
            Byte[] query = Encoding.ASCII.GetBytes(
                "M-SEARCH * HTTP/1.1\r\n" +
                "HOST: " + this._igdAddr + ":1900\r\n" +
                "ST: upnp:rootdevice\r\n" +
                "MAN: \"ssdp:discover\"\r\n" +
                "MX:3\r\n" +
                "\r\n" +
                "\r\n"
            );
            socketClient.SendTo(
                query,
                query.Length,
                SocketFlags.None,
                new IPEndPoint(this._igdAddr, 1900)
            );
            Byte[] data = new Byte[1024];
            EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            socketClient.ReceiveFrom(data, ref endPoint);
            socketClient.Close();

            String locationLine = Encoding.ASCII.GetString(data)
                .Lines()
                .Single(l => l.ToUpper().StartsWith("LOCATION"));

            HttpClient httpClient = new HttpClient(null);
            Uri uri = new Uri(locationLine.Substring(locationLine.IndexOf(':') + 1));
            responsePort = uri.Port;
            return httpClient.Get(uri, response =>
                response.GetResponseStream().Dispose(stream =>
                    XDocument.Load(XmlReader.Create(stream))
                )
            );
        }

        protected virtual void AddPortMapping(XDocument services, String serviceType, ProtocolType protocol, Int32 port)
        {
            Byte[] body = UTF8Encoding.ASCII.GetBytes(String.Format(
                #region SOAP body
@"<?xml version='1.0'?>
<s:Envelope
    xmlns:s='http://schemas.xmlsoap.org/soap/envelope/'
    s:encodingStyle='http://schemas.xmlsoap.org/soap/encoding/'
>
    <s:Body>
        <m:AddPortMapping
            xmlns:m='{0}'
        >
            <NewRemoteHost></NewRemoteHost>
            <NewExternalPort>{1}</NewExternalPort>
            <NewProtocol>{2}</NewProtocol>
            <NewInternalPort>{1}</NewInternalPort>
            <NewInternalClient>{3}</NewInternalClient>
            <NewEnabled>1</NewEnabled>
            <NewPortMappingDescription>Set by {4}</NewPortMappingDescription>
            <NewLeaseDuration>0</NewLeaseDuration>
        </m:AddPortMapping>
    </s:Body>
</s:Envelope>"
                #endregion
                , serviceType, port, protocol, this._clientAddr, "XSpect.Net.UPnPClient"
            ));
            HttpClient client = new HttpClient("UPnPClient");
            client.RequestInitializer += req => req.Headers.Add("SOAPAction", String.Format("\"{0}#GetExternalIPAddress\"", serviceType));
            client.Post(new Uri(
                services
                    .Element("{urn:schemas-upnp-org:device-1-0}root")
                    .Element("{urn:schemas-upnp-org:device-1-0}URLBase")
                    .Value
                + services.Descendants()
                    .Where(e => e.Name == "{urn:schemas-upnp-org:device-1-0}serviceType")
                    .Single(e => e.Value == serviceType)
                    .Parent
                    .Element("{urn:schemas-upnp-org:device-1-0}controlURL")
                    .Value
            ), body);
            // webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            this._openedPorts.Remove(port);
        }

        protected virtual void DeletePortMapping(XDocument services, String serviceType, ProtocolType protocol, Int32 port)
        {
            Byte[] body = UTF8Encoding.ASCII.GetBytes(String.Format(
                #region SOAP body
@"<?xml version='1.0'?>
<s:Envelope
    xmlns:s='http://schemas.xmlsoap.org/soap/envelope/'
    s:encodingStyle='http://schemas.xmlsoap.org/soap/encoding/'
>
    <s:Body>
        <m:DeletePortMapping
            xmlns:m='{0}'
        >
            <NewRemoteHost></NewRemoteHost>
            <NewExternalPort>{1}</NewExternalPort>
            <NewProtocol>{2}</NewProtocol>
            <NewInternalPort>{1}</NewInternalPort>
            <NewInternalClient>{3}</NewInternalClient>
        </m:AddPortMapping>
    </s:Body>
</s:Envelope>"
                #endregion
                , serviceType, port, protocol, this._clientAddr
            ));
            HttpClient client = new HttpClient("UPnPClient");
            client.RequestInitializer += req => req.Headers.Add("SOAPAction", String.Format("\"{0}#GetExternalIPAddress\"", serviceType));
            client.Post(new Uri(
                services
                    .Element("{urn:schemas-upnp-org:device-1-0}root")
                    .Element("{urn:schemas-upnp-org:device-1-0}URLBase")
                    .Value
                + services.Descendants()
                    .Where(e => e.Name == "{urn:schemas-upnp-org:device-1-0}serviceType")
                    .Single(e => e.Value == serviceType)
                    .Parent
                    .Element("{urn:schemas-upnp-org:device-1-0}controlURL")
                    .Value
            ), body);
            this._openedPorts.Add(port);
        }

        protected virtual IPAddress GetExternalIPAddress(XDocument services, String serviceType)
        {
            Byte[] body = UTF8Encoding.ASCII.GetBytes(String.Format(
                #region SOAP body
@"<?xml version='1.0'?>
<s:Envelope
    xmlns:s='http://schemas.xmlsoap.org/soap/envelope/'
    s:encodingStyle='http://schemas.xmlsoap.org/soap/encoding/'>
    <s:Body>
    <m:GetExternalIPAddress
        xmlns:m='{0}'>
    </m:GetExternalIPAddress>
    </s:Body>
</s:Envelope>"
                #endregion
                , serviceType
            ));
            HttpClient client = new HttpClient("UPnPClient");
            client.RequestInitializer += req => req.Headers.Add("SOAPAction", String.Format("\"{0}#GetExternalIPAddress\"", serviceType));
            return client.Post(new Uri(
                services
                    .Element("{urn:schemas-upnp-org:device-1-0}root")
                    .Element("{urn:schemas-upnp-org:device-1-0}URLBase")
                    .Value
                + services.Descendants()
                    .Where(e => e.Name == "{urn:schemas-upnp-org:device-1-0}serviceType")
                    .Single(e => e.Value == serviceType)
                    .Parent
                    .Element("{urn:schemas-upnp-org:device-1-0}controlURL")
                    .Value
            ), body, response => response.GetResponseStream().Dispose(stream =>
                IPAddress.Parse(XDocument.Load(XmlReader.Create(stream)).Elements().Single().Value)
            ));
        }

        public virtual void Dispose()
        {
            foreach (Int32 port in this._openedPorts)
            {
                this.Close(port);
            }
        }
    }
}
