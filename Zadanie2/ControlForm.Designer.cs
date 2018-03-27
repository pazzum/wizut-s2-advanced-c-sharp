namespace Zadanie2
{
    partial class ControlForm
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
            this.PortTextbox = new System.Windows.Forms.TextBox();
            this.HostingFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.HostingDirectoryBrowse = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Stop = new System.Windows.Forms.Button();
            this.SelectedPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PortTextbox
            // 
            this.PortTextbox.Location = new System.Drawing.Point(31, 40);
            this.PortTextbox.Name = "PortTextbox";
            this.PortTextbox.Size = new System.Drawing.Size(100, 20);
            this.PortTextbox.TabIndex = 0;
            this.PortTextbox.Text = "8003";
            this.PortTextbox.TextChanged += new System.EventHandler(this.PortTextbox_TextChanged);
            this.PortTextbox.HandleCreated += new System.EventHandler(this.PortTextbox_HandleCreated);
            // 
            // HostingDirectoryBrowse
            // 
            this.HostingDirectoryBrowse.Location = new System.Drawing.Point(178, 49);
            this.HostingDirectoryBrowse.Name = "HostingDirectoryBrowse";
            this.HostingDirectoryBrowse.Size = new System.Drawing.Size(146, 23);
            this.HostingDirectoryBrowse.TabIndex = 1;
            this.HostingDirectoryBrowse.Text = "Select hosting directory";
            this.HostingDirectoryBrowse.UseVisualStyleBackColor = true;
            this.HostingDirectoryBrowse.Click += new System.EventHandler(this.HostingDirectoryBrowse_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(31, 88);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 2;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(193, 93);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(37, 13);
            this.Status.TabIndex = 3;
            this.Status.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(112, 88);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(75, 23);
            this.Stop.TabIndex = 5;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // SelectedPath
            // 
            this.SelectedPath.AutoSize = true;
            this.SelectedPath.Location = new System.Drawing.Point(178, 30);
            this.SelectedPath.Name = "SelectedPath";
            this.SelectedPath.Size = new System.Drawing.Size(74, 13);
            this.SelectedPath.TabIndex = 6;
            this.SelectedPath.Text = "Selected Path";
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 155);
            this.Controls.Add(this.SelectedPath);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.HostingDirectoryBrowse);
            this.Controls.Add(this.PortTextbox);
            this.Name = "Server Control Panel";
            this.Text = "Server Control Panel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PortTextbox;
        private System.Windows.Forms.FolderBrowserDialog HostingFolderBrowserDialog;
        private System.Windows.Forms.Button HostingDirectoryBrowse;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Label SelectedPath;
    }
}