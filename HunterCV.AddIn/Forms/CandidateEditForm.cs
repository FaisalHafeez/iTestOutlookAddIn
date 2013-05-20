using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Office.Interop.Outlook;
using HunterCV.Common;
using System.Net.Http;
using HunterCV.AddIn.ExtensionMethods;
using System.Threading;
using System.Threading.Tasks;

namespace HunterCV.AddIn
{
    public partial class CandidateEditForm : Form
    {
        private bool m_skipEvents = false;
        private BindingList<HunterCV.Common.Resume> m_bind_documents = null;
        private Candidate m_Candidate;
        private MainRegion m_region;
        private bool m_isNew;
        private Microsoft.Office.Interop.Outlook.MailItem m_mailItem;
        private BindingSource m_positionsBindingSource = null;

        public CandidateEditForm(MainRegion region, Candidate entity)
        {
            InitializeComponent();

            tvAreas.Nodes.AddRange(region.Areas.CloneNodes());
            cbStatus.Items.AddRange(region.CandidatesStatuses);
            cbRole.Items.AddRange(region.Roles);

            m_Candidate = entity;
            m_region = region;
            m_isNew = false;

            btnShowHide.Enabled = false;

            SetValues();
            SetTitle();
        }


        public CandidateEditForm(bool isNew, MainRegion region, Candidate entity, Microsoft.Office.Interop.Outlook.MailItem mailItem)
        {
            InitializeComponent();

            tvAreas.Nodes.AddRange(region.Areas.CloneNodes());
            cbStatus.Items.AddRange(region.CandidatesStatuses);
            cbRole.Items.AddRange(region.Roles);

            m_Candidate = entity;
            m_region = region;
            m_mailItem = mailItem;
            m_isNew = isNew;

            //((Control)this.tabPageDocuments).Enabled = false;

            SetValues();
            SetTitle();

        }

        private void SetValues()
        {
            tbUsername.Text = m_Candidate.Username;
            tbFirstName.Text = m_Candidate.FirstName;
            tbLastName.Text = m_Candidate.LastName;
            dtpDOB.Value = m_Candidate.DateOfBirth.HasValue ? m_Candidate.DateOfBirth.Value : dtpDOB.MinDate;
            cbRole.Text = m_Candidate.Roles;
            cbIsActive.Checked = m_Candidate.IsActive.HasValue ? m_Candidate.IsActive.Value : true;
            tbJoiningDate.Text = m_Candidate.RegistrationDate.HasValue ? m_Candidate.RegistrationDate.Value.ToString("dd/MM/yyyy") : "";
            mtbMobile.Text = m_Candidate.Mobile;
            mtbPhone.Text = m_Candidate.Phone;
            tbEMailAddress.Text = m_Candidate.EMailAddress;
            cbFormer8200.Checked = m_Candidate.Former8200.HasValue ? m_Candidate.Former8200.Value : false;
            cbStatus.Text = m_Candidate.Status;
            cbExperience.Text = m_Candidate.Experience.HasValue ? m_Candidate.Experience.Value.ToString() : "0";
            cbReference.Text = m_Candidate.Reference;

            if (m_Candidate.Status.ToLower() == "signed")
            {
                dtpSigningDate.Enabled = true;
                dtpWorkStartDate.Enabled = true;
                linkLabel1.Enabled = true;

                dtpSigningDate.Value = m_Candidate.SigningDate ?? DateTime.Today;
                dtpWorkStartDate.Value = m_Candidate.WorkStartDate ?? DateTime.Today;
            }

            if (!string.IsNullOrEmpty(m_Candidate.Areas))
            {
                string[] areas = m_Candidate.Areas.Split(',');

                foreach (string area in areas)
                {
                    GetNodesPath(tvAreas.Nodes, area);
                }
            }



            try
            {
                rtbEvents.Rtf = m_Candidate.Events;
            }
            catch { }

        }

        private void SetTitle()
        {
            lblTitle.Text = tbFirstName.Text + " " + tbLastName.Text + (m_Candidate.CandidateNumber.HasValue ? " -" + m_Candidate.CandidateNumber.Value.ToString("0000") : string.Empty);
            this.Text = lblTitle.Text;

        }

        private void RetrieveValues()
        {
            this.m_Candidate.FirstName = tbFirstName.Text;
            this.m_Candidate.LastName = tbLastName.Text;
            this.m_Candidate.IdentityNumber = tbIdentity.Text;
            this.m_Candidate.DateOfBirth = dtpDOB.Value;
            this.m_Candidate.Events = rtbEvents.Rtf;
            this.m_Candidate.Areas = GetNodesPath(tvAreas.Nodes, null);
            this.m_Candidate.Roles = cbRole.Text;
            this.m_Candidate.EMailAddress = tbEMailAddress.Text;
            this.m_Candidate.Phone = mtbPhone.Text;
            this.m_Candidate.Mobile = mtbMobile.Text;
            this.m_Candidate.Status = cbStatus.Text;
            this.m_Candidate.Former8200 = cbFormer8200.Checked;
            this.m_Candidate.Experience = string.IsNullOrEmpty(cbExperience.Text) ? (short)0 : short.Parse(cbExperience.Text);
            this.m_Candidate.Reference = cbReference.Text;

            if (dtpSigningDate.Enabled)
            {
                this.m_Candidate.SigningDate = dtpSigningDate.Value;
                this.m_Candidate.WorkStartDate = dtpWorkStartDate.Value;
            }
            else
            {
                this.m_Candidate.SigningDate = null;
                this.m_Candidate.WorkStartDate = null;
            }
        }


        private string GetNodesPath(TreeNodeCollection nodes, string value)
        {
            StringBuilder sb = new StringBuilder();

            foreach (TreeNode node in nodes)
            {
                if (value != null)
                {
                    if (node.Text == value)
                    {
                        node.Checked = true;
                    }
                }
                else
                {
                    if (node.Checked)
                    {
                        sb.Append(!string.IsNullOrEmpty(sb.ToString()) ? "," + node.Text : node.Text);
                    }
                }
                CheckChildren(node, sb, value);
            }

            return sb.ToString();
        }

        private void CheckChildren(TreeNode rootNode, StringBuilder sb, string value)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (value != null)
                {
                    if (node.Text == value)
                    {
                        node.Checked = true;
                    }
                }
                else
                {
                    if (node.Checked)
                    {
                        sb.Append(!string.IsNullOrEmpty(sb.ToString()) ? "," + node.Text : node.Text);
                    }
                    CheckChildren(node, sb, value);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RetrieveValues();

            lblWaitStatus.Text = "Uploading...Please wait...";
            panelWait.Visible = true;

            var uploadWorker = new BackgroundWorker();

            uploadWorker.RunWorkerCompleted += (senders, es) =>
            {
                CrossThreadUtility.InvokeControlAction<Label>(lblWaitStatus, lbl => lbl.Text = "Saving...");

                if (m_isNew)
                {
                    insertWorker.RunWorkerAsync();
                }
                else
                {
                    updateWorker.RunWorkerAsync();
                }
            };

            uploadWorker.DoWork += (senders, es) =>
            {
                try
                {
                    if (!es.Cancel)
                    {
                        // Do work - Upload all documents
                        if (m_bind_documents.ToList<Resume>().Any(r => !r.IsCloudy))
                        {
                            ServiceHelper.Upload(m_Candidate.CandidateID, m_bind_documents);
                        }
                    }
                }
                finally
                {

                }
            };

            uploadWorker.RunWorkerAsync();

        }

        // This event handler is where the time-consuming work is done. 
        private void insertWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            panelWait.Invoke((MethodInvoker)delegate
            {
                panelWait.Visible = true;
            });

            ServiceHelper.Add(m_Candidate);
        }

        private void insertWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panelWait.Invoke((MethodInvoker)delegate
            {
                panelWait.Visible = false;
            });

            if (e.Cancelled == true)
            {

            }
            else if (e.Error != null)
            {
                LoginForm form = new LoginForm();
                form.ShowDialog(this);

                if (ServiceHelper.IsLoggedIn)
                {
                    updateWorker.RunWorkerAsync();
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (m_mailItem != null)
                {
                    m_mailItem.Categories = string.Concat(!string.IsNullOrEmpty(m_mailItem.Categories) ? m_mailItem.Categories : string.Empty, "< < < <  HunterCV Candidate Number : " + m_Candidate.CandidateNumber.Value + " Import Date : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "   > > > > ");
                    m_mailItem.Save();
                }

                //add new candidate
                m_region.Candidates.Add(m_Candidate);
                CrossThreadUtility.InvokeControlAction<MainRegion>(m_region, f => f.Candidates.ResetBindings());

                // set filter
                //this.m_region.ClearFilter();
                //this.m_region.CandidateNumber = m_Candidate.CandidateNumber.Value;
                //this.m_region.DoSearch(-1);

                CrossThreadUtility.InvokeControlAction<Form>(this, f => f.Close());
            }
        }

        // This event handler is where the time-consuming work is done. 
        private void retrieveCVWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = ServiceHelper.GetResumes((Guid)e.Argument);
        }

        private void retrieveCVWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panelCVWait.Invoke((MethodInvoker)delegate
            {
                panelCVWait.Visible = false;
            });

            if (e.Cancelled == true)
            {

            }
            else if (e.Error != null)
            {
                LoginForm form = new LoginForm();
                form.ShowDialog(this);

                if (ServiceHelper.IsLoggedIn)
                {
                    updateWorker.RunWorkerAsync();
                }
                else
                {
                    return;
                }
            }
            else
            {
                List<HunterCV.Common.Resume> documents = new List<HunterCV.Common.Resume>(e.Result as IEnumerable<HunterCV.Common.Resume>);

                if (m_isNew)
                {
                    documents.Add(new Resume
                    {
                        CandidateID = m_Candidate.CandidateID,
                        Description = new FileInfo(m_Candidate.ResumePath).Name,
                        FileName = m_Candidate.ResumePath
                    });
                }

                // old version
                if (!m_isNew && !string.IsNullOrEmpty(m_Candidate.ResumePath))
                {
                    if (File.Exists(m_Candidate.ResumePath))
                    {
                        documents.Add(new Resume
                        {
                            FileName = m_Candidate.ResumePath,
                            IsCloudy = false,
                            CandidateID = m_Candidate.CandidateID,
                        });
                    }
                }

                //reset resume path
                m_Candidate.ResumePath = null;

                m_bind_documents = new BindingList<HunterCV.Common.Resume>(documents);

                if (documents != null)
                {
                    dataGridViewCV.Invoke((MethodInvoker)delegate
                    {
                        dataGridViewCV.DataSource = m_bind_documents;

                        dataGridViewCV.Columns[0].Visible = false;
                        dataGridViewCV.Columns[1].Visible = false;
                    });
                }

                //m_retrieveDocuments = true;
            }
        }


        // This event handler is where the time-consuming work is done. 
        private void updateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CrossThreadUtility.InvokeControlAction<Panel>(panelWait, p => p.Visible = true);

            ServiceHelper.Update(m_Candidate);
        }


        // This event handler is where the time-consuming work is done. 
        private void updateResumeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CrossThreadUtility.InvokeControlAction<Panel>(panelCVWait, p => p.Visible = true);

            ServiceHelper.Update((Resume)e.Argument);
        }

        private void updateResumeWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CrossThreadUtility.InvokeControlAction<Panel>(panelCVWait, p => p.Visible = false);

            if (e.Cancelled == true)
            {

            }
            else if (e.Error != null)
            {
                LoginForm form = new LoginForm();
                form.ShowDialog(this);

                if (ServiceHelper.IsLoggedIn)
                {
                    updateWorker.RunWorkerAsync();
                }
                else
                {
                    return;
                }
            }
            else
            {
                CrossThreadUtility.InvokeControlAction<DataGridView>(dataGridViewCV, grid =>
                {
                    m_bind_documents.ResetBindings();
                });
            }
        }


        private void updateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CrossThreadUtility.InvokeControlAction<Panel>(panelWait, p => p.Visible = false);

            if (e.Cancelled == true)
            {

            }
            else if (e.Error != null)
            {
                LoginForm form = new LoginForm();
                form.ShowDialog(this);

                if (ServiceHelper.IsLoggedIn)
                {
                    updateWorker.RunWorkerAsync();
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (m_mailItem != null)
                {
                    m_mailItem.Categories = string.Concat(!string.IsNullOrEmpty(m_mailItem.Categories) ? m_mailItem.Categories : string.Empty, "< < < <  HunterCV Candidate Number : " + m_Candidate.CandidateNumber.Value + " Import Date : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "   > > > > ");
                    m_mailItem.Save();
                }

                CrossThreadUtility.InvokeControlAction<MainRegion>(m_region, f => f.MainGridBindingSource.ResetBindings(true));

                CrossThreadUtility.InvokeControlAction<Form>(this, f => f.Close());
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (m_isNew)
            {
                try
                {
                    File.Delete(m_Candidate.ResumePath);
                }
                catch
                {

                }
            }

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rtbEvents.Focus();
            rtbEvents.Select(0, 0);

            Font font = new Font("Tahoma", 8, FontStyle.Regular);
            rtbEvents.SelectionFont = font;
            rtbEvents.SelectionColor = Color.Red;
            rtbEvents.SelectedText = Environment.NewLine + Environment.NewLine + DateTime.Now.ToLongDateString() + " : " + Environment.NewLine;
            rtbEvents.SelectionColor = Color.Black;
        }

        private void CandidateEditForm_Load(object sender, EventArgs e)
        {
            button5.Enabled = !m_isNew;

            //load documents
            retrieveCVWorker.RunWorkerAsync(m_Candidate.CandidateID);

            RefreshMailTemplatesContextMenu();

            mtbMobile.Mask = m_region.Settings.Where(p => p.Key == "MobileFormat").Single().Value;
            mtbPhone.Mask = m_region.Settings.Where(p => p.Key == "PhoneFormat").Single().Value;

            BindPositionsGrid();
        }

        private void BindPositionsGrid()
        {

            m_positionsBindingSource = new BindingSource();
            m_positionsBindingSource.DataSource = new List<Position>(m_region.Positions.Where(p => m_Candidate.CandidatePositions.Select(c => c.PositionId).Contains((p.PositionID))));

            dgvPositions.DataSource = m_positionsBindingSource;

            if (m_positionsBindingSource.Count > 0)
            {
                dgvPositions.Columns[0].Visible = false;
                dgvPositions.Columns[10].Visible = false;
                dgvPositions.Columns[11].Visible = false;
            }

        }

        public void RefreshMailTemplatesContextMenu()
        {
            foreach (MailTemplate item in m_region.MailTemplates)
            {
                contextMenu1.MenuItems.Add(new MenuItem(item.Title, new EventHandler((menu, se) =>
                {
                    if (m_region.MailTemplates[((MenuItem)menu).Index].IncludeAttachments && m_bind_documents != null
                        && m_bind_documents.Count > 0)
                    {
                        CrossThreadUtility.InvokeControlAction<Panel>(panelWait, panel => panel.Visible = true);

                        int numberOfAttachments = m_bind_documents.Count;
                        var getBytesWorker = new BackgroundWorker[numberOfAttachments];

                        string[] attachments = new string[numberOfAttachments];
                        var manualEvents = new ManualResetEvent(false);

                        for (int i = 0; i < numberOfAttachments; i++)
                        {
                            Resume resume = m_bind_documents[i];
                            FileInfo fi = null;

                            //cloudy document
                            if (resume.IsCloudy)
                            {
                                getBytesWorker[i] = new BackgroundWorker();

                                getBytesWorker[i].RunWorkerCompleted += (senders, es) =>
                                {
                                    try
                                    {
                                        attachments[((DownloadResult)es.Result).Index] = Path.Combine(System.IO.Path.GetTempPath(), resume.FileName);
                                        System.IO.File.WriteAllBytes(attachments[((DownloadResult)es.Result).Index], ((DownloadResult)es.Result).Bytes);
                                    }
                                    finally
                                    {
                                        if (!attachments.ToList().Exists(s => s == null))
                                        {
                                            //show message
                                            MailItem mail = (MailItem)m_region.Application.CreateItem(OlItemType.olMailItem);
                                            mail.BodyFormat = OlBodyFormat.olFormatRichText;
                                            mail.Subject = m_region.MailTemplates[((MenuItem)menu).Index].Subject.ReplaceCandidateWildCards(m_Candidate);

                                            var body = m_region.MailTemplates[((MenuItem)menu).Index].RtfBody.ReplaceCandidateWildCards(m_Candidate);

                                            if (body != null)
                                            {
                                                mail.RTFBody = Encoding.ASCII.GetBytes(body);
                                            }

                                            foreach (var att in attachments)
                                            {
                                                mail.Attachments.Add(att, OlAttachmentType.olByValue, body.Length, Type.Missing);
                                            }
                                            mail.Display();

                                            CrossThreadUtility.InvokeControlAction<Panel>(panelWait, panel => panel.Visible = false);
                                        }
                                    }
                                };

                                getBytesWorker[i].DoWork += (senders, es) =>
                                {
                                    var index = (int)es.Argument;
                                    try
                                    {
                                        if (!es.Cancel)
                                        {
                                            es.Result = new DownloadResult
                                            {
                                                Bytes = ServiceHelper.GetResumeContent(resume.ResumeID),
                                                Index = index
                                            };
                                        }
                                    }
                                    finally
                                    {

                                    }
                                };

                            }
                            else
                            {
                                var k = i;

                                // open exists documents
                                fi = new FileInfo(resume.FileName);

                                if (fi.Exists)
                                {
                                    attachments[k] = fi.FullName;
                                }
                            }
                        }

                        for (int j = 0; j < numberOfAttachments; j++)
                        {
                            getBytesWorker[j].RunWorkerAsync(j);
                        }

                    }
                    else
                    {
                        //no attachments
                        MailItem mail = (MailItem)m_region.Application.CreateItem(OlItemType.olMailItem);
                        mail.BodyFormat = OlBodyFormat.olFormatRichText;
                        mail.Subject = m_region.MailTemplates[((MenuItem)menu).Index].Subject.ReplaceCandidateWildCards(m_Candidate);

                        var body = m_region.MailTemplates[((MenuItem)menu).Index].RtfBody.ReplaceCandidateWildCards(m_Candidate);

                        if (body != null)
                        {
                            mail.RTFBody = Encoding.ASCII.GetBytes(body);
                        }
                        mail.Display();
                    }
                })));
            }


        }

        private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            int counter = 0;
            TreeNode ChildNode;
            XmlNodeList nodeList;
            XmlAttributeCollection attributes;


            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;

                foreach (XmlNode item in nodeList)
                {
                    if (item.NodeType == XmlNodeType.Element)
                    {
                        attributes = item.Attributes;

                        foreach (XmlAttribute x in attributes)
                        {
                            if (x.Name == "attribute")
                            {
                                inTreeNode.Nodes.Add(new TreeNode(x.Value));
                                ChildNode = inTreeNode.Nodes[counter];
                                counter++;
                                AddNode(item, ChildNode);
                            }
                        }
                    }
                }
            }
        }

        private void tbFirstName_KeyUp(object sender, KeyEventArgs e)
        {
            SetTitle();
        }

        private void tbLastName_KeyUp(object sender, KeyEventArgs e)
        {
            SetTitle();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(m_Candidate.ResumePath);
            }
            catch
            {

            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //if (updatingTreeView) return;
            //updatingTreeView = true;
            //CheckChildren_ParentSelected(e.Node, e.Node.Checked);
            //SelectParents(e.Node, e.Node.Checked);
            //updatingTreeView = false;
        }

        private void CheckChildren_ParentSelected(TreeNode node, Boolean isChecked)
        {
            foreach (TreeNode item in node.Nodes)
            {
                item.Checked = isChecked;

                if (item.Nodes.Count > 0)
                {
                    this.CheckChildren_ParentSelected(item, isChecked);
                }
            }
        }

        private void SelectParents(TreeNode node, Boolean isChecked)
        {
            //MessageBox.Show(node.Parent.ToString());
            if (node.Parent != null)
            {
                node.Parent.Checked = isChecked;
                SelectParents(node.Parent, isChecked);
            }
        }

        private void tvAreas_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            contextMenu1.Show(button4, new Point(button4.Width, 0));
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure to remove this candidate from Your database ?", "HunterCV", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    //remove from service
                    ServiceHelper.Delete(m_Candidate);
                }
                catch (HttpRequestException)
                {
                    LoginForm form = new LoginForm();
                    form.ShowDialog(this);

                    if (ServiceHelper.IsLoggedIn)
                    {
                        ServiceHelper.Delete(m_Candidate);
                    }
                    else
                    {
                        return;
                    }
                }

                //remove from list
                m_region.Candidates.Remove(m_Candidate);
                m_region.DataGrid.DataSource = m_region.Candidates;

                this.Close();
            }
        }

        private void CandidateEditForm_Shown(object sender, EventArgs e)
        {
            readingResumeTimer.Enabled = true;

        }

        private void readingResumeTimer_Tick(object sender, EventArgs e)
        {
            readingResumeTimer.Enabled = false;

            if (m_isNew && m_Candidate.ResumePath != null)
            {
                ReadingResumeForm frm = new ReadingResumeForm(m_Candidate.ResumePath);
                frm.ShowDialog(this);

                if (frm.ReadingResult.ContainsKey("Content"))
                {
                    btnShowHide.Enabled = true;
                    btnShowHide.Text = "Hide Preview <<";
                    this.Width = 898;
                    rtbPreview.AppendText(frm.ReadingResult["Content"]);
                }


                if (frm.ReadingResult.ContainsKey("Mobile1") &&
                       !string.IsNullOrEmpty(frm.ReadingResult["Mobile1"]))
                {
                    mtbMobile.Text = frm.ReadingResult["Mobile1"];
                }
                else
                {
                    if (frm.ReadingResult.ContainsKey("Mobile2") &&
                           !string.IsNullOrEmpty(frm.ReadingResult["Mobile2"]))
                    {
                        mtbMobile.Text = frm.ReadingResult["Mobile2"];
                    }
                }
            }

        }

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            if (this.Width == 618)
            {
                this.Width = 898;
                btnShowHide.Text = "Hide Preview <<";
            }
            else
            {
                this.Width = 618;
                btnShowHide.Text = "Show Preview >>";
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tabControl1.SelectedIndex == 2)
            //{
            //    if (!retrieveCVWorker.IsBusy && !m_retrieveDocuments)
            //    {
            //        retrieveCVWorker.RunWorkerAsync(m_Candidate.CandidateID);
            //    }
            //}
        }

        private void dataGridViewCV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridViewCV.SelectedRows.Count > 0)
            {
                dataGridViewCV.Enabled = false;
                panelCVWait.Visible = true;

                Resume item = dataGridViewCV.SelectedRows[0].DataBoundItem as Resume;

                FileInfo fi = null;

                //cloudy document
                if (item.IsCloudy)
                {
                    var getBytesWorker = new BackgroundWorker();

                    getBytesWorker.RunWorkerCompleted += (senders, es) =>
                    {
                        string path = Path.Combine(System.IO.Path.GetTempPath(), item.FileName);
                        System.IO.File.WriteAllBytes(path, (byte[])es.Result);
                        try
                        {
                            System.Diagnostics.Process.Start(path);
                        }
                        finally
                        {
                            CrossThreadUtility.InvokeControlAction<DataGridView>(dataGridViewCV, dv => dv.Enabled = true);
                            CrossThreadUtility.InvokeControlAction<Panel>(panelCVWait, panel => panel.Visible = false);
                        }
                    };

                    getBytesWorker.DoWork += (senders, es) =>
                    {
                        try
                        {
                            if (!es.Cancel)
                            {
                                es.Result = ServiceHelper.GetResumeContent(item.ResumeID);
                            }
                        }
                        finally
                        {

                        }
                    };

                    getBytesWorker.RunWorkerAsync();
                }
                else
                {
                    // open exists documents
                    fi = new FileInfo(item.FileName);

                    if (fi.Exists)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(fi.FullName);
                        }
                        finally
                        {
                            dataGridViewCV.Enabled = true;
                            panelCVWait.Visible = false;
                        }
                    }
                }


            }
        }

        private void dataGridViewCV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridViewCV_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridViewCV.SelectedRows.Count > 0)
            {
                Resume item = dataGridViewCV.SelectedRows[0].DataBoundItem as Resume;

                tbResumeDescription.Text = item.Description;
                btnSaveResume.Enabled = true;
                btnRemoveResume.Enabled = true;
            }
        }

        private void btnSaveResume_Click(object sender, EventArgs e)
        {
            if (dataGridViewCV.SelectedRows.Count > 0)
            {
                Resume item = dataGridViewCV.SelectedRows[0].DataBoundItem as Resume;
                item.Description = tbResumeDescription.Text;

                if (item.IsCloudy)
                {
                    updateResumeWorker.RunWorkerAsync(item);
                }
                else
                {
                    m_bind_documents.ResetBindings();
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                m_bind_documents.Add(new Resume
                {
                    FileName = openFileDialog1.FileName,
                    IsCloudy = false,
                    CandidateID = m_Candidate.CandidateID,
                });

            }
        }

        private void btnRemoveResume_Click(object sender, EventArgs e)
        {
            if (dataGridViewCV.SelectedRows.Count > 0)
            {
                Resume item = dataGridViewCV.SelectedRows[0].DataBoundItem as Resume;

                btnRemoveResume.Enabled = false;
                btnSaveResume.Enabled = false;
                tbResumeDescription.Text = "";

                if (item.IsCloudy)
                {
                    var removeResumeWorker = new BackgroundWorker();

                    removeResumeWorker.RunWorkerCompleted += (senders, es) =>
                    {
                        CrossThreadUtility.InvokeControlAction<Panel>(panelCVWait, panel => panel.Visible = false);
                        CrossThreadUtility.InvokeControlAction<DataGridView>(dataGridViewCV, dg =>
                        {
                            m_bind_documents.Remove(item);
                            m_bind_documents.ResetBindings();
                        });
                    };

                    removeResumeWorker.DoWork += (senders, es) =>
                    {
                        try
                        {
                            if (!es.Cancel)
                            {
                                ServiceHelper.DeleteResume(item);
                            }
                        }
                        finally
                        {

                        }
                    };

                    CrossThreadUtility.InvokeControlAction<Panel>(panelCVWait, panel => panel.Visible = true);

                    removeResumeWorker.RunWorkerAsync();
                }
                else
                {
                    m_bind_documents.Remove(item);
                    m_bind_documents.ResetBindings();
                }
            }
        }

        private void CandidateEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (retrieveCVWorker.IsBusy)
            {
                retrieveCVWorker.CancelAsync();
            }
        }

        private void dgvPositions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvPositions.SelectedRows.Count > 0)
            {
                Position item = dgvPositions.SelectedRows[0].DataBoundItem as Position;
                PositionEditForm form = new PositionEditForm(m_region, item);
                form.Show(this);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (PositionsForm frm = new PositionsForm(m_region, FormOpenMode.SearchAndSelect))
            {
                frm.ShowDialog(this);

                if (frm.SelectedPositionsIds != null && frm.SelectedPositionsIds.Any())
                {
                    var positions = m_region.Positions.Where(p => frm.SelectedPositionsIds.Contains(p.PositionID));

                    foreach (Position position in positions)
                    {
                        if (!m_Candidate.CandidatePositions.Any(p => p.PositionId == position.PositionID))
                        {
                            m_Candidate.CandidatePositions.Add(new CandidatePosition
                            {
                                PositionId = position.PositionID,
                                CandidateId = m_Candidate.CandidateID,
                                CandidatePositionDate = DateTime.Today,
                                CandidatePositionStatus = "In Process"
                            });
                        }
                    }
                }
            }

            BindPositionsGrid();
        }

        private void dgvPositions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count > 0)
            {
                Position position = dgvPositions.SelectedRows[0].DataBoundItem as Position;

                if (position != null)
                {
                    dtpPositionDate.Enabled = true;
                    cbPositionStatus.Enabled = true;

                    CandidatePosition cPosition = m_Candidate.CandidatePositions.Where(p => p.PositionId == position.PositionID).Single();

                    m_skipEvents = true;
                    cbPositionStatus.Text = cPosition.CandidatePositionStatus;
                    dtpPositionDate.Value = cPosition.CandidatePositionDate ?? DateTime.Today;
                    m_skipEvents = false;
                }
            }
        }

        private void cbPositionStatus_TextChanged(object sender, EventArgs e)
        {
            if (m_skipEvents)
                return;

            Position position = dgvPositions.SelectedRows[0].DataBoundItem as Position;

            if (position != null)
            {
                CandidatePosition cPosition = m_Candidate.CandidatePositions.Where(p => p.PositionId == position.PositionID).Single();

                if (cbPositionStatus.Text.ToLower() == "signed")
                {
                    //clear previous
                    var signed = m_Candidate.CandidatePositions.Where(p => p.CandidatePositionStatus == "Signed");

                    foreach (CandidatePosition cp in signed)
                    {
                        cp.CandidatePositionStatus = "Rejected";
                    }

                    cPosition.CandidatePositionStatus = cbPositionStatus.Text;

                    dtpSigningDate.Enabled = true;
                    dtpWorkStartDate.Enabled = true;
                    linkLabel1.Enabled = true;

                    cbStatus.Text = "Signed";
                    position.Status = "Manned";
                }
                else
                {
                    cPosition.CandidatePositionStatus = cbPositionStatus.Text;

                }

                m_positionsBindingSource.ResetBindings(true);
            }

        }

        private void dtpPositionDate_ValueChanged(object sender, EventArgs e)
        {
            Position position = dgvPositions.SelectedRows[0].DataBoundItem as Position;

            if (position != null)
            {
                CandidatePosition cPosition = m_Candidate.CandidatePositions.Where(p => p.PositionId == position.PositionID).Single();

                cPosition.CandidatePositionDate = dtpPositionDate.Value;
            }
        }

        private void dgvPositions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dataGridView = sender as DataGridView;

            var position = dataGridView.Rows[e.RowIndex].DataBoundItem as Position;

            if (position != null)
            {
                var cpos = m_Candidate.CandidatePositions.Where(p => p.PositionId == position.PositionID).Single();

                if (cpos.CandidatePositionStatus.ToLower() == "signed")
                {
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                    // edit: to change the background color:
                    e.CellStyle.BackColor = Color.Coral;
                }
            }
        }

        private void cbPositionStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AppointmentItem oAppointment = (AppointmentItem) m_region.Application.CreateItem (OlItemType.olAppointmentItem);
 
            oAppointment.Subject = string.Format("Candidate # {0} - {1} {2} is starting Work Today!", m_Candidate.CandidateNumber, m_Candidate.FirstName , m_Candidate.LastName);
            //oAppointment.Body = "This is the body text for my appointment"; 
            //oAppointment.Location = m_po
            TimeSpan ts = new TimeSpan(8, 30, 0);
            DateTime dtStart = dtpWorkStartDate.Value.Date + ts;

            // Set the start date
            oAppointment.Start = dtStart;
            // End date 
            oAppointment.End = dtStart.AddMinutes(15);
            // Set the reminder 15 minutes before start
            oAppointment.ReminderSet = true; 
            oAppointment.ReminderMinutesBeforeStart = 15; 
 
            //Setting the sound file for a reminder: 
            oAppointment.ReminderPlaySound = true;
 
            //Setting the importance: 
            //use OlImportance enum to set the importance to low, medium or high

            oAppointment.Importance = OlImportance.olImportanceLow; 
 
            /* OlBusyStatus is enum with following values:
            olBusy
            olFree
            olOutOfOffice
            olTentative
            */
            oAppointment.BusyStatus = OlBusyStatus.olFree; 
 
            //Finally, save the appointment: 
 
            // Save the appointment
            oAppointment.Save ();

            MessageBox.Show("A New Reminder is set to candidate's work start date.", "HunterCV", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }
}
