using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Threading.Tasks;

namespace HunterCV.AddIn
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // This event handler is where the time-consuming work is done. 
        private void loginWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = ServiceHelper.Login(tbUsername.Text, tbPassword.Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool blValidUsername = ValidateUserName();
            bool blValidPassword = ValidatePassword();

            if (!blValidPassword || !blValidUsername)
            {
                return;
            }

            btnOK.Enabled = false;

            if (loginWorker.IsBusy != true)
            {
                panelWait.Visible = true;
                loginWorker.RunWorkerAsync();
            }
        }

        // This event handler deals with the results of the background operation. 
        private void loginWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panelWait.Visible = false;
            btnOK.Enabled = true;

            if (e.Cancelled == true)
            {
                this.Close();
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Login failed, please try again\n\nError:" + e.Error.Message , "HunterCV");
            }
            else
            {
                bool result = (bool)e.Result;

                if (result)
                {
                    ServiceHelper.LastLogin = new LoginDetails
                        {
                            Username = tbUsername.Text,
                            Password = tbPassword.Text
                        };

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
                    MessageBox.Show("Login failed, please try again", "HunterCV");
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (loginWorker.IsBusy)
            {
                loginWorker.CancelAsync();
            }

            ServiceHelper.CanceledLogin = true;
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

        private void tbUsername_Validating(object sender, CancelEventArgs e)
        {
            ValidateUserName();
        }

        private bool ValidateUserName()
        {
            bool bStatus = true;
            if (tbUsername.Text.Trim() == "")
            {
                errorProvider1.SetError(tbUsername, "Please enter Username");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(tbUsername, "");
            }
            return bStatus;
        }

        private bool ValidatePassword()
        {
            bool bStatus = true;
            if (tbPassword.Text.Trim() == "")
            {
                errorProvider1.SetError(tbPassword, "Please enter Password");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(tbPassword, "");
            }
            return bStatus;
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            ValidatePassword();
        }

    }
}
