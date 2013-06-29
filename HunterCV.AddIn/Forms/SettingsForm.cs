using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HunterCV.Common;

namespace HunterCV.AddIn.Forms
{
    public partial class SettingsForm : Form
    {
        private MainRegion m_region = null;

        public SettingsForm(MainRegion region)
        {
            InitializeComponent();

            m_region = region;

            foreach (KeyValuePair<string, string> pair in region.Settings)
            {
                Control[] ctls = this.Controls.Find(pair.Key, true);

                if (ctls != null && ctls.Length > 0)
                {
                    if (ctls[0].GetType() == typeof(TextBox) || ctls[0].GetType() == typeof(MaskedTextBox))
                    {
                        ctls[0].Text = pair.Value;
                    }
                    else if (ctls[0].GetType() == typeof(NumericUpDown))
                    {
                        ((NumericUpDown)ctls[0]).Value = Convert.ToDecimal( pair.Value );
                    }
                }
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            udPageSize.Value = Properties.Settings.Default.PageSize;
            cbUseProxy.Checked = Properties.Settings.Default.UseProxy;
            cbAddMSCompanyLogo.Checked = Properties.Settings.Default.AddMSCompanyLogo;
            tbMSLogoFilePath.Text = Properties.Settings.Default.MSLogoFilePath;

            tbProxyAddress.Text = Properties.Settings.Default.ProxyAddress;
            tbProxyPort.Text = Properties.Settings.Default.ProxyPort.ToString();

            tbProxyAddress.Enabled = cbUseProxy.Checked;
            tbProxyPort.Enabled = cbUseProxy.Checked;
        }

        public IEnumerable<Control> GetAll(Control control, Type[] type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => type.Contains( c.GetType() ));
        }

        public string populateSettingsXml()
        {
            m_region.Settings = new List<KeyValuePair<string, string>>();

            StringBuilder sr = new StringBuilder();
            //Write the header
            sr = sr.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            //Write our root node
            sr = sr.Append("<settings>");

            var ctls = GetAll(this, new Type[] { typeof(TextBox), typeof(MaskedTextBox), typeof(NumericUpDown) });

            foreach (Control ctl in ctls)
            {
                if (ctl.Tag != null && ctl.Tag.ToString() == "cloud")
                {
                    sr = sr.Append("<setting title=\"" + ctl.Name + "\" value=\"" + ctl.Text + "\" />");
                    m_region.Settings.Add(new KeyValuePair<string, string>(ctl.Name, ctl.Text));
                }
            }
            //Close the root node

            sr = sr.Append("</settings>");

            return sr.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            panelWait.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;

            Properties.Settings.Default.PageSize = Convert.ToInt32( udPageSize.Value );
            Properties.Settings.Default.UseProxy = cbUseProxy.Checked;
            Properties.Settings.Default.ProxyAddress = tbProxyAddress.Text;
            Properties.Settings.Default.ProxyPort = int.Parse(tbProxyPort.Text);
            Properties.Settings.Default.AddMSCompanyLogo = cbAddMSCompanyLogo.Checked;
            Properties.Settings.Default.MSLogoFilePath = tbMSLogoFilePath.Text;

            Properties.Settings.Default.Save();

            string xml = populateSettingsXml();

            var saveWorker = new BackgroundWorker();

            saveWorker.RunWorkerCompleted += (senders, es) =>
            {
                CrossThreadUtility.InvokeControlAction<Form>(this, f => f.Close());
            };

            saveWorker.DoWork += (senders, es) =>
            {
                try
                {
                    if (!es.Cancel)
                    {
                        ServiceHelper.Update(new Settings
                        {
                            Xml = xml
                        });
                    }
                }
                finally
                {

                }
            };

            saveWorker.RunWorkerAsync();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbUseProxy_CheckedChanged(object sender, EventArgs e)
        {
            tbProxyAddress.Enabled = cbUseProxy.Checked;
            tbProxyPort.Enabled = cbUseProxy.Checked;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "All files (*.*)|*.*|Bitmap Files (*.bmp)|*.bmp|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            if (openFileDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                tbMSLogoFilePath.Text = openFileDialog1.FileName;
            }
        }
    }
}
