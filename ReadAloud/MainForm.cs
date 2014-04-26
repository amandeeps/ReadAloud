﻿// Copyright (c) 2014 Amandeep Singh

//  The MIT License (MIT)
//  Permission is hereby granted, free of charge, to any person obtaining a
//  copy of this software and associated documentation files (the "Software"),
//  to deal in the Software without restriction, including without limitation
//  the rights to use, copy, modify, merge, publish, distribute, sublicense,
//  and/or sell copies of the Software, and to permit persons to whom the
//  Software is furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included
//  in all copies or substantial portions of the Software.

//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
//  OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//  FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//  DEALINGS IN THE SOFTWARE.

using System;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Text.RegularExpressions;
using System.Threading;

namespace Read_Aloud
{
    partial class MainForm : Form
    {
        HookManager.HookManager hookManager = new HookManager.HookManager();

        public MainForm()
        {
            InitializeComponent();

            hookManager.KeyDown += hookManager_KeyDown;
        }

        private void hookManager_KeyDown(object sender, HookManager.KeyArgs e)
        {
            if (e.KeyData == Keys.Space && e.Ctrl)
            {
                Enqueue();
                e.Handled = true;
            }
            else if(e.KeyData == Keys.P && e.Ctrl && e.Alt)
            {
                PauseResume();
                e.Handled = true;
            }
            else if(e.KeyData == Keys.X && e.Ctrl && e.Alt)
            {
                Stop();
                e.Handled = true;
            }
            else if(e.KeyData == Keys.C && e.Ctrl && e.Alt)
            {
                Clear();
                e.Handled = true;
            }
        }

        private void PauseResume()
        { }

        private void Stop()
        { }

        private void Enqueue()
        {
            ClipboardManager.Instance.GetHighlightedText();
        }

        private void Clear()
        { }
    }
}