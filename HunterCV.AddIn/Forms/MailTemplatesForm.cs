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
    public partial class MailTemplatesForm : Form
    {
        private MailTemplate m_mailTemplate = null;
        private MainRegion m_mainRegion = null;
        private BindingList<MailTemplate> m_bindingList = null;
        private IList<MailTemplate> m_templates = null;

        public MailTemplatesForm(MainRegion region)
        {
            InitializeComponent();
            m_mainRegion = region;
        }

        private void tbrUnderline_Click(object sender, EventArgs e)
        {
            if (m_mailTemplate == null)
            {
                return;
            }

            try
            {
                if (!(rtbDoc.SelectionFont == null))
                {
                    System.Drawing.Font currentFont = rtbDoc.SelectionFont;
                    System.Drawing.FontStyle newFontStyle;

                    newFontStyle = rtbDoc.SelectionFont.Style ^ FontStyle.Underline;

                    rtbDoc.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void tbrItalic_Click(object sender, EventArgs e)
        {
            if (m_mailTemplate == null)
            {
                return;
            }

            try
            {
                if (!(rtbDoc.SelectionFont == null))
                {
                    System.Drawing.Font currentFont = rtbDoc.SelectionFont;
                    System.Drawing.FontStyle newFontStyle;

                    newFontStyle = rtbDoc.SelectionFont.Style ^ FontStyle.Italic;

                    rtbDoc.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }

        }

        private void tbrBold_Click(object sender, EventArgs e)
        {
            if (m_mailTemplate == null)
            {
                return;
            }

            try
            {
                if (!(rtbDoc.SelectionFont == null))
                {
                    System.Drawing.Font currentFont = rtbDoc.SelectionFont;
                    System.Drawing.FontStyle newFontStyle;

                    newFontStyle = rtbDoc.SelectionFont.Style ^ FontStyle.Bold;

                    rtbDoc.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }

        }

        private void tbrRight_Click(object sender, EventArgs e)
        {
            if (m_mailTemplate == null)
            {
                return;
            }

            rtbDoc.SelectAll();
            rtbDoc.SelectionAlignment = HorizontalAlignment.Right;
            rtbDoc.SelectionLength = 0;

        }

        private void tbrCenter_Click(object sender, EventArgs e)
        {
            if (m_mailTemplate == null)
            {
                return;
            }

            rtbDoc.SelectionAlignment = HorizontalAlignment.Center;

        }

        private void tbrLeft_Click(object sender, EventArgs e)
        {
            if (m_mailTemplate == null)
            {
                return;
            }

            rtbDoc.SelectAll();
            rtbDoc.SelectionAlignment = HorizontalAlignment.Left;
            rtbDoc.SelectionLength = 0;

        }

        private void tspColor_Click(object sender, EventArgs e)
        {
            if (m_mailTemplate == null)
            {
                return;
            }

            try
            {
                colorDialog1.Color = rtbDoc.ForeColor;
                if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    rtbDoc.SelectionColor = colorDialog1.Color;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }

        }

        private void tbrFont_Click(object sender, EventArgs e)
        {
            if (m_mailTemplate == null)
            {
                return;
            }

            try
            {
                if (!(rtbDoc.Font == null))
                {
                    FontDialog1.Font = rtbDoc.SelectionFont;
                }
                else
                {
                    FontDialog1.Font = null;
                }
                FontDialog1.ShowApply = true;
                
                if (FontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    rtbDoc.SelectionFont = FontDialog1.Font;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }

        }

        private void MailTemplate_Load(object sender, EventArgs e)
        {
            if (m_mainRegion.MailTemplates != null && m_mainRegion.MailTemplates.Any())
            {
                m_templates = new List<MailTemplate>(m_mainRegion.MailTemplates);
            }
            else
            {
                m_templates = new List<MailTemplate>();

                rtbDoc.Enabled = false;
                tbSubject.Enabled = false;
                tbTitle.Enabled = false;
                cbIncludeAttachments.Enabled = false;

            }

            m_bindingList = new BindingList<MailTemplate>(m_templates);
            listBox1.DisplayMember = "Title";
            listBox1.DataSource = m_bindingList;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelWait.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;

            var insertWorker = new BackgroundWorker();

            short index = 0;

            //fix index
            foreach (MailTemplate tmpl in m_bindingList)
            {
                index++;
                tmpl.TemplateIndex = index;
            }

            insertWorker.RunWorkerCompleted += (senders, es) =>
            {
                CrossThreadUtility.InvokeControlAction<Panel>(panelWait, panel => panel.Visible = false);
            };

            insertWorker.DoWork += (senders, es) =>
            {
                try
                {
                    if (!es.Cancel)
                    {
                        ServiceHelper.Add(listBox1.DataSource as IEnumerable<MailTemplate>);

                        CrossThreadUtility.InvokeControlAction<Form>(this, f => f.Close());

                        //add new template
                        m_mainRegion.MailTemplates = new List<MailTemplate>(listBox1.DataSource as IEnumerable<MailTemplate>);
                    }
                }
                finally
                {

                }
            };

            insertWorker.RunWorkerAsync();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_mailTemplate = listBox1.SelectedItem as MailTemplate;

            if (m_mailTemplate != null)
            {
                btnDelete.Enabled = true;
                tbTitle.Text = m_mailTemplate.Title;
                tbSubject.Text = m_mailTemplate.Subject;
                rtbDoc.Rtf = m_mailTemplate.RtfBody;
                cbIncludeAttachments.Checked = m_mailTemplate.IncludeAttachments;

                rtbDoc.Enabled = true;
                tbSubject.Enabled = true;
                tbTitle.Enabled = true;
                cbIncludeAttachments.Enabled = true;

            }
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            if (m_mailTemplate != null)
            {
                m_mailTemplate.Title = tbTitle.Text;
                m_bindingList.ResetBindings();
            }
        }

        private void tbSubject_TextChanged(object sender, EventArgs e)
        {
            if (m_mailTemplate != null)
            {
                m_mailTemplate.Subject = tbSubject.Text;
            }

        }

        private void rtbDoc_TextChanged(object sender, EventArgs e)
        {
            if (m_mailTemplate != null)
            {
                m_mailTemplate.RtfBody = rtbDoc.Rtf;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MainRegion.License == LicenseType.Free && m_bindingList != null &&
                m_bindingList.Count() > 1)
            {
                MessageBox.Show(this, "Sorry, but this license type does not allow more entities of those types", "HunterCV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            m_mailTemplate = null;

            rtbDoc.Clear();
            tbSubject.Clear();
            tbTitle.Text = "Mail Template " + (listBox1.Items.Count + 1);

            m_mailTemplate = new MailTemplate
            {
                RoleId = m_mainRegion.RoleId,
                Title = tbTitle.Text,
                RtfBody = rtbDoc.Rtf,
                Subject = string.Empty,
                TemplateIndex = (short)(listBox1.Items.Count + 1)
            };

            m_bindingList.Add(m_mailTemplate);

            listBox1.SelectedIndex = listBox1.Items.Count - 1;

            rtbDoc.Enabled = true;
            tbSubject.Enabled = true;
            tbTitle.Enabled = true;
            cbIncludeAttachments.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (m_mailTemplate != null)
            {
                m_bindingList.Remove(m_mailTemplate);
                m_mailTemplate = null;

                listBox1.ClearSelected();

                rtbDoc.Clear();
                tbSubject.Clear();
                tbTitle.Clear();

                rtbDoc.Enabled = false;
                tbSubject.Enabled = false;
                tbTitle.Enabled = false;
                cbIncludeAttachments.Enabled = false;

            }
        }

        private void cbIncludeAttachments_CheckedChanged(object sender, EventArgs e)
        {
            if (m_mailTemplate != null)
            {
                m_mailTemplate.IncludeAttachments = cbIncludeAttachments.Checked;
            }
        }
    }
}
