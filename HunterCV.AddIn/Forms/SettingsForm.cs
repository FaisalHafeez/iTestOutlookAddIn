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
                    if ( ctls[0].GetType() == typeof(TextBox))
                    {
                        ctls[0].Text = pair.Value;
                    }
                }
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        public string populateSettingsXml()
        {
            m_region.Settings = new List<KeyValuePair<string, string>>();

            StringBuilder sr = new StringBuilder();
            //Write the header
            sr = sr.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            //Write our root node
            sr = sr.Append("<settings>");

            var ctls = GetAll(this, typeof(TextBox));

            foreach (Control ctl in ctls)
            {
                sr = sr.Append("<setting title=\"" + ctl.Name + "\" value=\"" + ctl.Text + "\" />");
                m_region.Settings.Add(new KeyValuePair<string, string>(ctl.Name, ctl.Text));
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
    }
}
