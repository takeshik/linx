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
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using XSpect;

namespace XSpect.Windows.Forms
{
	public partial class ExceptionForm
		: Form
	{
        private readonly ExceptionHandler _handler;

        private readonly Uri _btsUri;

		public ExceptionForm(Exception ex)
			: this(ex, new Uri("https://bugs.xspect.org/"))
		{
		}

        public ExceptionForm(Exception ex, Uri uri)
        {
            InitializeComponent();

            this.exceptionTextBox.Font = new Font(
                Control.DefaultFont.FontFamily.Name,
                Control.DefaultFont.Size * 1.5f,
                Control.DefaultFont.Style | FontStyle.Bold,
                Control.DefaultFont.Unit,
                Control.DefaultFont.GdiCharSet,
                Control.DefaultFont.GdiVerticalFont
            );

            this.messageTextBox.Font = Control.DefaultFont;

            this._handler = new ExceptionHandler(ex);
            this.Initialize();
            this._btsUri = uri;
        }

		public void Initialize()
		{
            this.exceptionTextBox.Text = this._handler.Exception.GetType().FullName;
            this.messageTextBox.Text = this._handler.Exception.Message;
            this.informationTextBox.Text = this._handler.GetDiagnosticMessage();
        }

		private void ExceptionForm_FormClosed(Object sender, FormClosedEventArgs e)
		{
			this.Dispose();
		}

		private void exitButton_Click(Object sender, EventArgs e)
		{
			Environment.Exit(Int32.MaxValue);
		}

		private void debugButton_Click(Object sender, EventArgs e)
		{
			if (!Debugger.IsAttached)
			{
				Debugger.Launch();
			}
			Debugger.Break();
		}

        private void continueButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void abortButton_Click(object sender, EventArgs e)
        {
            Environment.FailFast(this._handler.Exception.Message);
        }

        private void btsLinkLabel_LinkClicked(Object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.btsLinkLabel.LinkVisited = true;
            Process.Start(this._btsUri.ToString());
        }
	}
}
