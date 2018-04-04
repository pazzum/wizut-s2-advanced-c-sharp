using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie3
{
    public partial class ProjectZipper : Form
    {
        private string _selectedPath;

        public ProjectZipper()
        {
            InitializeComponent();
        }

        private void ProjectDirectoryBrowse_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (this.ProjectDirectoryBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                _selectedPath = this.ProjectDirectoryBrowserDialog.SelectedPath;
                this.SelectedPath.Text = this.ProjectDirectoryBrowserDialog.SelectedPath;
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            var solutionFinder = new SolutionFinder(_selectedPath);
            try
            {
                var solutionFile = solutionFinder.Find();
                var projectFinder = new ProjectFinder(solutionFile.First());
                var projectsFiles = projectFinder.Find();
                foreach(var projectFile in projectsFiles)
                {
                    var projectFilesFinder = new ProjectFilesFinder(_selectedPath, projectFile);
                    var filesToCopy = projectFilesFinder.Find();
                    var projectCopier = new ProjectCopier(filesToCopy, projectFilesFinder.GetProjectDirectory(), _selectedPath);
                    projectCopier.Copy();
                }

                var solutionFileCopier = new SolutionFileCopier(solutionFile.First(), _selectedPath);
                solutionFileCopier.Copy();

                var copyDirectoryZipper = new CopyDirectoryZipper(_selectedPath);
                copyDirectoryZipper.Zip();
            }
            catch(Exception exception)
            {
                this.Status.Text = exception.Message;
                this.Status.ForeColor = Color.Red;
                return;
            }

            this.Status.Text = "Solution archived successfully.";
            this.Status.ForeColor = Color.Green;
        }
    }
}
