namespace PrintLogger
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pathButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.dataSourceLabel = new System.Windows.Forms.Label();
            this.pathLabel = new System.Windows.Forms.Label();
            this.outputSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.printersList = new System.Windows.Forms.ListBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.systemTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // pathButton
            // 
            this.pathButton.Location = new System.Drawing.Point(316, 173);
            this.pathButton.Name = "pathButton";
            this.pathButton.Size = new System.Drawing.Size(38, 21);
            this.pathButton.TabIndex = 0;
            this.pathButton.Text = "...";
            this.pathButton.UseVisualStyleBackColor = true;
            this.pathButton.Click += new System.EventHandler(this.pathButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(277, 200);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(77, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start logging";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Enabled = false;
            this.outputTextBox.Location = new System.Drawing.Point(15, 174);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(295, 20);
            this.outputTextBox.TabIndex = 2;
            // 
            // dataSourceLabel
            // 
            this.dataSourceLabel.AutoSize = true;
            this.dataSourceLabel.Location = new System.Drawing.Point(12, 9);
            this.dataSourceLabel.Name = "dataSourceLabel";
            this.dataSourceLabel.Size = new System.Drawing.Size(68, 13);
            this.dataSourceLabel.TabIndex = 3;
            this.dataSourceLabel.Text = "Data source:";
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(14, 158);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(66, 13);
            this.pathLabel.TabIndex = 4;
            this.pathLabel.Text = "Output path:";
            // 
            // outputSaveDialog
            // 
            this.outputSaveDialog.FileName = "printlog.txt";
            this.outputSaveDialog.Title = "Choose print log file path...";
            this.outputSaveDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.outputSaveDialog_FileOk);
            // 
            // printersList
            // 
            this.printersList.FormattingEnabled = true;
            this.printersList.Location = new System.Drawing.Point(15, 25);
            this.printersList.Name = "printersList";
            this.printersList.Size = new System.Drawing.Size(339, 121);
            this.printersList.TabIndex = 6;
            this.printersList.Click += new System.EventHandler(this.printersList_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(194, 200);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(77, 23);
            this.stopButton.TabIndex = 7;
            this.stopButton.Text = "Stop logging";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // systemTrayIcon
            // 
            this.systemTrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.systemTrayIcon.BalloonTipText = "Click to restore PrintLogger window";
            this.systemTrayIcon.BalloonTipTitle = "PrintLogger";
            this.systemTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("systemTrayIcon.Icon")));
            this.systemTrayIcon.Text = "PrintLogger";
            this.systemTrayIcon.Click += new System.EventHandler(this.systemTrayIcon_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 234);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.printersList);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.dataSourceLabel);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.pathButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "PrintLogger";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pathButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label dataSourceLabel;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.SaveFileDialog outputSaveDialog;
        private System.Windows.Forms.ListBox printersList;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.NotifyIcon systemTrayIcon;
    }
}

