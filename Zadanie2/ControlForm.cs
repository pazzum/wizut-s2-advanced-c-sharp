using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zadanie2
{
    public partial class ControlForm: Form
    {
        private string _portTextBoxValue;
        private Server _server;

        public ControlForm()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            try
            {
                _server = new Server(Int32.Parse(_portTextBoxValue));
            }
            catch(Exception exception)
            {
                this.Status.Text = exception.Message;
                this.Status.ForeColor = Color.Red;
            }

            this.Status.Text = "Uruchomiono";
            this.Status.ForeColor = Color.Green;

            button.Enabled = false;
            this.Stop.Enabled = true;
        }

        private void PortTextbox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            _portTextBoxValue = textBox.Text;
        }

        private void PortTextbox_HandleCreated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            _portTextBoxValue = textBox.Text;
        }

        private void HostingDirectoryBrowse_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if(this.HostingFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if(_server != null)
                {
                    _server._servingPath = this.HostingFolderBrowserDialog.SelectedPath;
                }
                this.SelectedPath.Text = this.HostingFolderBrowserDialog.SelectedPath;
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            _server.Stop();

            this.Status.Text = "Zatrzymano";
            this.Status.ForeColor = Color.Red;

            button.Enabled = false;
            this.Start.Enabled = true;
        }

        private void ControlForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _server.Stop();
        }
    }
}
