/* Copyright (C) Przemysław Postrach - All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Przemysław Postrach <toyerek@gmail.com> July 2017
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
