using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace iTestOutlookAddIn
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool result = CandidatesServiceHelper.Login(tbUsername.Text, tbPassword.Text);

            if (result)
            {
                if (cbRemember.Checked)
                {
                    //save credentials if checkbox is on
                    Properties.Settings.Default.Username = tbUsername.Text;
                    Properties.Settings.Default.Password = tbPassword.Text;
                    Properties.Settings.Default.Save();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed, please try again", "iTest");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CandidatesServiceHelper.CanceledLogin = true;
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            tbUsername.Text = Properties.Settings.Default.Username;
            tbPassword.Text = Properties.Settings.Default.Password;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(ConfigurationManager.AppSettings["iTest.Site.ForgotPasswordUrl"]);
        }
    }
}
