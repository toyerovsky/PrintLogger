/* 
 * Copyright (C) <2017> <Przemysław Postrach>
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Atom8.Monitors;
using System.Linq;
using System.IO;

namespace PrintLogger
{
    public partial class MainForm : Form
    {
        public static PrintQueueMonitor PrintMonitor { get; set; }

        public List<string> Printers
        {
            get
            {
                List<string> printers = new List<string>();
                foreach (var printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    printers.Add(printer.ToString());
                }
                return printers;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            if (!Printers.Any())
            {
                MessageBox.Show("Whoops! We can't find any printer installed in OS.");
                Dispose();
            }

            printersList.DataSource = Printers;
            PrintMonitor = new PrintQueueMonitor(printersList.SelectedItem.ToString());
        }

        private void pathButton_Click(object sender, EventArgs e)
        {
            outputSaveDialog.ShowDialog();
        }

        private void outputSaveDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (sender is SaveFileDialog dialog)
            {
                using (File.Create(dialog.FileName))
                    outputTextBox.Text = dialog.FileName;
            }
        }

        private void printersList_Click(object sender, EventArgs e)
        {
            if (printersList.SelectedItem is string printerName)
                PrintMonitor = new PrintQueueMonitor(printerName);
            else
                MessageBox.Show("Whoops! We can't read printer name from printer device.");
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(outputSaveDialog?.FileName))
            {
                MessageBox.Show("You have to specify the output file before you can start.");
                return;
            }

            WindowState = FormWindowState.Minimized;
            PrintMonitor.Start();
            PrintMonitor.OnJobStatusChange += PrintMonitor_OnJobStatusChange;
        }

        private void PrintMonitor_OnJobStatusChange(object Sender, PrintJobChangeEventArgs e)
        {
            using (StreamWriter sw = File.AppendText(outputSaveDialog.FileName))
                sw.WriteLine($"[{DateTime.Now}] Id:{e.JobID} Info:{e.JobInfo} Nazwa:{e.JobName} Status:{e.JobStatus}");
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            PrintMonitor.Stop();
            PrintMonitor.OnJobStatusChange -= PrintMonitor_OnJobStatusChange;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                systemTrayIcon.Visible = true;
                systemTrayIcon.ShowBalloonTip(500, "PrintLogger", "Click to maximalize window.", ToolTipIcon.Info);
                Hide();
            }
        }

        private void systemTrayIcon_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                systemTrayIcon.Visible = false;
                Show();
            }
        }
    }
}
