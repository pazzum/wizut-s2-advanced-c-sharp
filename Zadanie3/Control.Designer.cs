namespace Zadanie3
{
    partial class ProjectZipper
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
            this.SelectedPath = new System.Windows.Forms.Label();
            this.ProjectDirectoryBrowse = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.ProjectDirectoryBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.Status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SelectedPath
            // 
            this.SelectedPath.AutoSize = true;
            this.SelectedPath.Location = new System.Drawing.Point(145, 9);
            this.SelectedPath.Name = "SelectedPath";
            this.SelectedPath.Size = new System.Drawing.Size(74, 13);
            this.SelectedPath.TabIndex = 7;
            this.SelectedPath.Text = "Selected Path";
            this.SelectedPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProjectDirectoryBrowse
            // 
            this.ProjectDirectoryBrowse.Location = new System.Drawing.Point(111, 39);
            this.ProjectDirectoryBrowse.Name = "ProjectDirectoryBrowse";
            this.ProjectDirectoryBrowse.Size = new System.Drawing.Size(146, 23);
            this.ProjectDirectoryBrowse.TabIndex = 8;
            this.ProjectDirectoryBrowse.Text = "Select project directory";
            this.ProjectDirectoryBrowse.UseVisualStyleBackColor = true;
            this.ProjectDirectoryBrowse.Click += new System.EventHandler(this.ProjectDirectoryBrowse_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(144, 94);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 9;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(182, 72);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 13);
            this.Status.TabIndex = 10;
            this.Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProjectZipper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 129);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.ProjectDirectoryBrowse);
            this.Controls.Add(this.SelectedPath);
            this.Name = "ProjectZipper";
            this.Text = "Project Zipper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SelectedPath;
        private System.Windows.Forms.Button ProjectDirectoryBrowse;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.FolderBrowserDialog ProjectDirectoryBrowserDialog;
        private System.Windows.Forms.Label Status;
    }
}

