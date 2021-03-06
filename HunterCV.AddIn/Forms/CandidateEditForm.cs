﻿using System;
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
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Drawing.Imaging;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace HunterCV.AddIn
{
    public partial class CandidateEditForm : Form
    {
        private const int FEATURE_DISABLE_NAVIGATION_SOUNDS = 21;
        private const int SET_FEATURE_ON_THREAD = 0x00000001;
        private const int SET_FEATURE_ON_PROCESS = 0x00000002;
        private const int SET_FEATURE_IN_REGISTRY = 0x00000004;
        private const int SET_FEATURE_ON_THREAD_LOCALMACHINE = 0x00000008;
        private const int SET_FEATURE_ON_THREAD_INTRANET = 0x00000010;
        private const int SET_FEATURE_ON_THREAD_TRUSTED = 0x00000020;
        private const int SET_FEATURE_ON_THREAD_INTERNET = 0x00000040;
        private const int SET_FEATURE_ON_THREAD_RESTRICTED = 0x00000080;


        [DllImport("urlmon.dll")]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        static extern int CoInternetSetFeatureEnabled(
        int FeatureEntry,
        [MarshalAs(UnmanagedType.U4)] int dwFlags,
        bool fEnable);

        private const int PREVIEW_OPEN = 1200;
        private const int PREVIEW_CLOSE = 673;

        private bool m_skipEvents = false;
        private BindingList<HunterCV.Common.Resume> m_bind_documents = null;
        private Candidate m_Candidate;


        public Candidate Candidate
        {
            get { return m_Candidate; }
            set { m_Candidate = value; }
        }

        private MainRegion m_region;
        List<HunterCV.Common.Resume> m_documents = null;

        private bool m_isNew;
        private Microsoft.Office.Interop.Outlook.MailItem m_mailItem;
        private BindingSource m_positionsBindingSource = null;

        public CandidateEditForm(MainRegion region, Candidate entity)
        {
            InitializeComponent();

            cbStatus.Items.AddRange(region.CandidatesStatuses);
            cbRole.Items.AddRange(region.Roles);

            m_Candidate = entity;
            m_region = region;
            m_isNew = false;

            //btnShowHide.Enabled = false;

            SetFormValues();
            SetFormTitle();
        }

        public CandidateEditForm(bool isNew, MainRegion region, Candidate entity)
        {
            InitializeComponent();

            cbStatus.Items.AddRange(region.CandidatesStatuses);
            cbRole.Items.AddRange(region.Roles);

            m_Candidate = entity;
            m_region = region;
            m_isNew = isNew;


            //((Control)this.tabPageDocuments).Enabled = false;

            SetFormValues();
            SetFormTitle();

        }

        public CandidateEditForm(bool isNew, MainRegion region, Candidate entity, Microsoft.Office.Interop.Outlook.MailItem mailItem)
        {
            InitializeComponent();

            //tvAreas.Nodes.AddRange(region.Areas.CloneNodes());
            cbStatus.Items.AddRange(region.CandidatesStatuses);
            cbRole.Items.AddRange(region.Roles);

            m_Candidate = entity;
            m_region = region;
            m_mailItem = mailItem;
            m_isNew = isNew;

            //((Control)this.tabPageDocuments).Enabled = false;

            SetFormValues();
            SetFormTitle();

        }

        public void LoadResumes()
        {
            //load documents
            retrieveCVWorker.RunWorkerAsync(m_Candidate.CandidateID);
        }

        public void SetFormValues()
        {
            FavoritesIcons icn = (FavoritesIcons)Enum.Parse(typeof(FavoritesIcons), m_Candidate.Starred ?? "Silver", true);
            picFavorite.Image = favoritesImagesList.Images[(int)icn];

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

            tvAreas.Nodes.Clear();
            tvAreas.Nodes.AddRange(m_region.Areas.CloneNodes());
            tvAreas.ExpandAll();

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

            int feature = FEATURE_DISABLE_NAVIGATION_SOUNDS;
            CoInternetSetFeatureEnabled(feature, SET_FEATURE_ON_PROCESS, true);

            try
            {
                rtbEvents.Rtf = m_Candidate.Events;
            }
            catch { }

        }

        public void SetFormTitle()
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

        private void HandleResume()
        {

            var uploadWorker = new BackgroundWorker();

            uploadWorker.RunWorkerCompleted += (senders, es) =>
            {
                //finish saving process - close form
                CrossThreadUtility.InvokeControlAction<Form>(this, f => f.Close());

            };

            uploadWorker.DoWork += (senders, es) =>
            {
                try
                {
                    if (!es.Cancel)
                    {
                        CrossThreadUtility.InvokeControlAction<Label>(lblWaitStatus, lbl => lbl.Text = "Deleting resumes...");
                        //remove deleted resumes
                        m_documents.Where(r => r.IsDeleted).ToList().ForEach(resume =>
                        {
                            ServiceHelper.DeleteResume(resume);
                        });

                        CrossThreadUtility.InvokeControlAction<Label>(lblWaitStatus, lbl => lbl.Text = "Updating resumes...");
                        //update
                        m_documents.Where(r => r.IsDirty && r.IsCloudy && !r.IsDeleted).ToList().ForEach(resume =>
                        {
                            ServiceHelper.Update(resume);
                        });

                        CrossThreadUtility.InvokeControlAction<Label>(lblWaitStatus, lbl => lbl.Text = "Uploading resumes...");
                        // Do work - Upload all documents
                        if (m_documents.Any(r => !r.IsCloudy && !r.IsDeleted))
                        {
                            ServiceHelper.Upload(m_Candidate.CandidateID, m_documents.Where(r => !r.IsCloudy && !r.IsDeleted));
                        }
                    }
                }
                finally
                {

                }
            };

            uploadWorker.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool bFirstName = ValidateFirstName();
            bool bLastName = ValidateLastName();
            bool bEmail = ValidateEmail();

            if (!bFirstName || !bLastName || !bEmail)
            {
                return;
            }

            //reset resume path
            m_Candidate.ResumePath = null;

            RetrieveValues();
            panelWait.Visible = true;

            if (m_isNew)
            {
                insertWorker.RunWorkerAsync();
            }
            else
            {
                updateWorker.RunWorkerAsync();
            }
        }

        // This event handler is where the time-consuming work is done. 
        private void insertWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = ServiceHelper.Add(m_Candidate);
        }

        private void insertWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {

            }
            else if (e.Error != null)
            {
                if (e.Error is DuplicateCandidatesException)
                {
                    DuplicateCandidatesForm form = new DuplicateCandidatesForm(m_region, ((DuplicateCandidatesException)e.Error).Duplicates);

                    CrossThreadUtility.InvokeControlAction<Panel>(panelWait, p => p.Visible = false);

                    CrossThreadUtility.InvokeControlAction<CandidateEditForm>(this, f =>
                    {
                        if (form.ShowDialog(f) == System.Windows.Forms.DialogResult.Cancel)
                        {
                            panelWait.Invoke((MethodInvoker)delegate
                            {
                                panelWait.Visible = false;
                            });

                            return;
                        }
                        else
                        {
                            CrossThreadUtility.InvokeControlAction<Panel>(panelWait, p => p.Visible = true);

                            //mark skip
                            m_Candidate.SkipDuplicatesCheck = true;

                            //run worker again
                            insertWorker.RunWorkerAsync();
                        }
                    });
                }


            }
            else
            {
                //get new candidate number
                m_Candidate.CandidateNumber = (int)e.Result;

                if (m_mailItem != null)
                {
                    m_mailItem.Categories = string.Concat(!string.IsNullOrEmpty(m_mailItem.Categories) ? m_mailItem.Categories : string.Empty, "< < < <  HunterCV Candidate Number : " + m_Candidate.CandidateNumber.Value + " Import Date : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "   > > > > ");
                    m_mailItem.Save();
                }

                //add new candidate
                m_region.Candidates.Add(m_Candidate);
                CrossThreadUtility.InvokeControlAction<MainRegion>(m_region, f => f.DoSearch(-1));

                HandleResume();
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
                m_documents = new List<HunterCV.Common.Resume>(e.Result as IEnumerable<HunterCV.Common.Resume>);

                if (m_isNew && !string.IsNullOrEmpty(m_Candidate.ResumePath))
                {
                    m_documents.Add(new Resume
                    {
                        CandidateID = m_Candidate.CandidateID,
                        //Description = new FileInfo(m_Candidate.ResumePath).Name,
                        FileName = m_Candidate.ResumePath
                    });
                }

                // old version
                if (!m_isNew && !string.IsNullOrEmpty(m_Candidate.ResumePath))
                {
                    if (File.Exists(m_Candidate.ResumePath))
                    {
                        m_documents.Add(new Resume
                        {
                            FileName = m_Candidate.ResumePath,
                            IsCloudy = false,
                            CandidateID = m_Candidate.CandidateID,
                        });
                    }
                }

                RefreshResumeGrid();

                if (this.Width == PREVIEW_OPEN)
                {
                    ShowPreview(m_documents[0]);
                }

            }
        }

        private void RefreshResumeGrid()
        {
            m_bind_documents = new BindingList<HunterCV.Common.Resume>(m_documents.Where(s => !s.IsDeleted).ToList());

            if (m_documents != null)
            {
                CrossThreadUtility.InvokeControlAction<DataGridView>(dataGridViewCV, dg =>
                {
                    dg.DataSource = m_bind_documents;

                    dg.Columns[0].Visible = false;
                    dg.Columns[1].Visible = false;
                    dg.Columns[2].Width = 200;
                    dg.Columns[3].Visible = false;
                    dg.Columns[4].Visible = false;
                    dg.Columns[5].Visible = false;
                    dg.Columns[6].Visible = false;
                });

                if (m_isNew)
                {
                    ShowPreview(m_documents[0]);
                }
            }

        }

        // This event handler is where the time-consuming work is done. 
        private void updateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
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
            //CrossThreadUtility.InvokeControlAction<Panel>(panelWait, p => p.Visible = false);

            if (e.Cancelled == true)
            {

            }
            else if (e.Error != null)
            {
                if (e.Error is DuplicateCandidatesException)
                {
                    DuplicateCandidatesForm form = new DuplicateCandidatesForm(m_region, ((DuplicateCandidatesException)e.Error).Duplicates);

                    CrossThreadUtility.InvokeControlAction<Panel>(panelWait, p => p.Visible = false);

                    CrossThreadUtility.InvokeControlAction<CandidateEditForm>(this, f =>
                    {
                        if (form.ShowDialog(f) == System.Windows.Forms.DialogResult.Cancel)
                        {
                            panelWait.Invoke((MethodInvoker)delegate
                            {
                                panelWait.Visible = false;
                            });

                            return;
                        }
                        else
                        {
                            CrossThreadUtility.InvokeControlAction<Panel>(panelWait, p => p.Visible = true);

                            //mark skip
                            m_Candidate.SkipDuplicatesCheck = true;

                            //run worker again
                            updateWorker.RunWorkerAsync();
                        }
                    });
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

                HandleResume();
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

            LoadResumes();
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
                                            if (m_region.MailTemplates[((MenuItem)menu).Index].SetOpeningCompanyRecipient)
                                            {
                                                mail.To = GrabConnectedCompanyEmail();
                                            }
                                            mail.BodyFormat = OlBodyFormat.olFormatRichText;
                                            mail.Subject = m_region.MailTemplates[((MenuItem)menu).Index].Subject.ReplaceCandidateWildCards(m_Candidate);

                                            var body = m_region.MailTemplates[((MenuItem)menu).Index].RtfBody.ReplaceCandidateWildCards(m_Candidate, true);

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
                            if (getBytesWorker[j] != null)
                            {
                                getBytesWorker[j].RunWorkerAsync(j);
                            }
                        }

                    }
                    else
                    {
                        //no attachments
                        MailItem mail = (MailItem)m_region.Application.CreateItem(OlItemType.olMailItem);
                        if (m_region.MailTemplates[((MenuItem)menu).Index].SetOpeningCompanyRecipient)
                        {
                            mail.To = GrabConnectedCompanyEmail();
                        }
                        mail.BodyFormat = OlBodyFormat.olFormatRichText;
                        mail.Subject = m_region.MailTemplates[((MenuItem)menu).Index].Subject.ReplaceCandidateWildCards(m_Candidate);

                        var body = m_region.MailTemplates[((MenuItem)menu).Index].RtfBody.ReplaceCandidateWildCards(m_Candidate, true);

                        if (body != null)
                        {
                            mail.RTFBody = Encoding.ASCII.GetBytes(body);
                        }
                        mail.Display();
                    }
                })));
            }


        }

        private string GrabConnectedCompanyEmail()
        {
            string email = string.Empty;

            if (dgvPositions.SelectedRows.Count > 0)
            {
                Position item = dgvPositions.SelectedRows[0].DataBoundItem as Position;
                XElement element = m_region.Companies.FirstOrDefault(t => t.Attribute("title").Value == item.Company);

                if (element != null)
                {
                    var details = element.Element("details");

                    if (details != null)
                    {
                        email = details.Element("email").Value;
                    }
                }
            }

            return email;
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
            SetFormTitle();
        }

        private void tbLastName_KeyUp(object sender, KeyEventArgs e)
        {
            SetFormTitle();
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
            if (MessageBox.Show("Are You sure to permanently delete this candidate from database ?", "HunterCV", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                btnSave.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;

                try
                {
                    BackgroundWorker removeWorker = new BackgroundWorker();

                    removeWorker.RunWorkerCompleted += (senders, es) =>
                    {
                        CrossThreadUtility.InvokeControlAction<Panel>(panelWait, p => p.Visible = false);

                        CrossThreadUtility.InvokeControlAction<MainRegion>(m_region, r =>
                            {
                                m_region.Candidates.Remove(m_Candidate);
                                m_region.DoSearch(-1);
                            });

                        CrossThreadUtility.InvokeControlAction<Form>(this, f => f.Close());
                    };

                    removeWorker.DoWork += (senders, es) =>
                    {
                        CrossThreadUtility.InvokeControlAction<Panel>(panelWait, p => p.Visible = true);

                        //remove from service
                        ServiceHelper.Delete(m_Candidate);
                    };

                    removeWorker.RunWorkerAsync();
                }
                catch (HttpRequestException)
                {

                }
            }
        }

        private void CandidateEditForm_Shown(object sender, EventArgs e)
        {
            if (tbFirstName.CanFocus)
            {
                tbFirstName.Focus();
            }
        }


        private void btnShowHide_Click(object sender, EventArgs e)
        {
            if (this.Width == PREVIEW_CLOSE)
            {
                Resume item = null;

                if (dataGridViewCV.SelectedRows.Count == 0)
                {
                    if (m_documents.Count() > 0)
                    {
                        item = m_documents[0];
                    }
                    else
                    {
                        MessageBox.Show(this, "No documents exists for preview", "HunterCV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    item = dataGridViewCV.SelectedRows[0].DataBoundItem as Resume;
                }

                this.Width = PREVIEW_OPEN;
                btnShowHide.Text = "Hide Preview <<";

                ShowPreview(item);
            }
            else
            {
                this.Width = PREVIEW_CLOSE;
                btnShowHide.Text = "Show Preview >>";
            }
        }

        private void ShowPreview(Resume item)
        {
            CrossThreadUtility.InvokeControlAction<CandidateEditForm>(this, f =>
            {
                ReadingResumeForm frm = new ReadingResumeForm(m_region, item, !m_isNew);
                frm.ShowDialog(f);

                if (m_isNew)
                {
                    if (frm.ReadingResult.ContainsKey("MSWordMobile1WildCards") &&
                           !string.IsNullOrEmpty(frm.ReadingResult["MSWordMobile1WildCards"]))
                    {
                        mtbMobile.Text = frm.ReadingResult["MSWordMobile1WildCards"];
                    }
                    else
                    {
                        if (frm.ReadingResult.ContainsKey("MSWordMobile2WildCards") &&
                               !string.IsNullOrEmpty(frm.ReadingResult["MSWordMobile2WildCards"]))
                        {
                            mtbMobile.Text = frm.ReadingResult["MSWordMobile2WildCards"];
                        }
                    }

                    if (frm.ReadingResult.ContainsKey("MSWordPhone1WildCards") &&
                           !string.IsNullOrEmpty(frm.ReadingResult["MSWordPhone1WildCards"]))
                    {
                        mtbPhone.Text = frm.ReadingResult["MSWordPhone1WildCards"];
                    }
                    else
                    {
                        if (frm.ReadingResult.ContainsKey("MSWordPhone2WildCards") &&
                               !string.IsNullOrEmpty(frm.ReadingResult["MSWordPhone2WildCards"]))
                        {
                            mtbPhone.Text = frm.ReadingResult["MSWordPhone2WildCards"];
                        }
                    }
                }

                if (frm.ReadingResult.ContainsKey("HtmlPreviewFileName"))
                {
                    webBrowser1.Navigate(frm.ReadingResult["HtmlPreviewFileName"]);
                }
            });
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
            if (dataGridViewCV.SelectedRows.Count > 0 && this.Width == PREVIEW_OPEN)
            {
                ShowPreview(dataGridViewCV.SelectedRows[0].DataBoundItem as Resume);
            }
        }

        private void dataGridViewCV_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void btnSaveResume_Click(object sender, EventArgs e)
        {
            if (dataGridViewCV.SelectedRows.Count > 0)
            {
                Resume item = dataGridViewCV.SelectedRows[0].DataBoundItem as Resume;
                item.Description = tbResumeDescription.Text;
                item.IsDirty = true;

                m_bind_documents.ResetBindings();

            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (MainRegion.License == LicenseType.Free && m_bind_documents != null &&
                m_bind_documents.Count() > 0)
            {
                MessageBox.Show(this, "Sorry, but this license type does not allow more entities of those types", "HunterCV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                m_documents.Add(new Resume
                {
                    FileName = openFileDialog1.FileName,
                    IsCloudy = false,
                    CandidateID = m_Candidate.CandidateID,
                    IsDeleted = false
                });

                //m_bind_documents.ResetBindings();
                RefreshResumeGrid();
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
                    item.IsDeleted = true;
                    RefreshResumeGrid();
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
            AppointmentItem oAppointment = (AppointmentItem)m_region.Application.CreateItem(OlItemType.olAppointmentItem);

            oAppointment.Subject = string.Format("Candidate # {0} - {1} {2} is starting Work Today!", m_Candidate.CandidateNumber, m_Candidate.FirstName, m_Candidate.LastName);
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
            oAppointment.Save();

            MessageBox.Show("A New Reminder is set to candidate's work start date.", "HunterCV", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridViewCV_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCV.SelectedRows.Count > 0)
            {
                Resume item = dataGridViewCV.SelectedRows[0].DataBoundItem as Resume;

                tbResumeDescription.Text = item.Description;
                btnSaveResume.Enabled = true;
                btnRemoveResume.Enabled = true;
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ManageRolesForm form = new ManageRolesForm(m_region);
            form.ShowDialog(this);

            cbRole.Items.Clear();
            cbRole.Items.AddRange(m_region.Roles);

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ManageAreasForm form = new ManageAreasForm(m_region);
            form.ShowDialog(this);

            tvAreas.Nodes.Clear();
            tvAreas.Nodes.AddRange(m_region.Areas.CloneNodes());

            if (!string.IsNullOrEmpty(m_Candidate.Areas))
            {
                string[] areas = m_Candidate.Areas.Split(',');

                foreach (string area in areas)
                {
                    GetNodesPath(tvAreas.Nodes, area);
                }
            }

        }

        private void tbFirstName_Validating(object sender, CancelEventArgs e)
        {
            ValidateFirstName();
        }

        private bool ValidateFirstName()
        {
            bool bStatus = true;
            if (tbFirstName.Text.Trim() == "")
            {
                errorProvider1.SetError(tbFirstName, "Please enter First Name");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(tbFirstName, "");
            }
            return bStatus;
        }

        private bool ValidateLastName()
        {
            bool bStatus = true;
            if (tbLastName.Text.Trim() == "")
            {
                errorProvider1.SetError(tbLastName, "Please enter First Name");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(tbLastName, "");
            }
            return bStatus;
        }

        private bool ValidateEmail()
        {
            bool bStatus = true;

            string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
     + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";


            if (tbEMailAddress.Text.Trim() != "")
            {
                if (!Regex.IsMatch(tbEMailAddress.Text, MatchEmailPattern))
                {
                    errorProvider1.SetError(tbEMailAddress, "Please enter valid Email");
                    bStatus = false;
                }
            }
            else
            {
                errorProvider1.SetError(tbEMailAddress, "");
            }
            return bStatus;
        }

        private void tbLastName_Validating(object sender, CancelEventArgs e)
        {
            ValidateLastName();
        }

        private void tbEMailAddress_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmail();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (retrieveCVWorker.IsBusy || m_region.IsCandidatesWorkerBusy)
            {
                return;
            }

            if (m_region.DataGrid.SelectedRows.Count > 0)
            {
                Candidate item = m_region.DataGrid.SelectedRows[0].DataBoundItem as Candidate;

                if (item.CandidateID != m_Candidate.CandidateID)
                {
                    MessageBox.Show("You've lost selection on the grid, please make sure You're pointing the right row", "HunterCV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int selectedIndex = m_region.DataGrid.SelectedRows[0].Index;

                    if (selectedIndex == m_region.DataGrid.Rows.Count - 1)
                    {
                        if (m_region.GoNextPage())
                        {
                            this.Enabled = false;
                            m_region.CurrentCandidateForm = this;
                            m_region.GridRowSelectionType = GridRowSelectionTypes.First;
                        }
                    }
                    else
                    {
                        m_region.DataGrid.ClearSelection();
                        m_region.DataGrid.Rows[selectedIndex + 1].Selected = true;

                        m_Candidate = m_region.DataGrid.SelectedRows[0].DataBoundItem as Candidate;

                        SetFormValues();
                        SetFormTitle();
                        LoadResumes();
                    }
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (retrieveCVWorker.IsBusy || m_region.IsCandidatesWorkerBusy)
            {
                return;
            }

            if (m_region.DataGrid.SelectedRows.Count > 0)
            {
                Candidate item = m_region.DataGrid.SelectedRows[0].DataBoundItem as Candidate;

                if (item.CandidateID != m_Candidate.CandidateID)
                {
                    MessageBox.Show("You've lost selection on the grid, please make sure You're pointing the right row", "HunterCV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int selectedIndex = m_region.DataGrid.SelectedRows[0].Index;

                    if (selectedIndex == 0)
                    {
                        if (m_region.GoPreviousPage())
                        {
                            this.Enabled = false;
                            m_region.CurrentCandidateForm = this;
                            m_region.GridRowSelectionType = GridRowSelectionTypes.Last;
                        }
                    }
                    else
                    {
                        m_region.DataGrid.ClearSelection();
                        m_region.DataGrid.Rows[selectedIndex - 1].Selected = true;

                        m_Candidate = m_region.DataGrid.SelectedRows[0].DataBoundItem as Candidate;

                        SetFormValues();
                        SetFormTitle();
                        LoadResumes();
                    }
                }
            }
        }

        private void CandidateEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Globals.ThisAddIn.Application.ActiveExplorer().Activate();

        }

        private void picFavorite_Click(object sender, EventArgs e)
        {
            FavoritesIcons icn = (FavoritesIcons)Enum.Parse(typeof(FavoritesIcons), m_Candidate.Starred ?? "Silver", true);

            if (icn == FavoritesIcons.Red)
            {
                icn = FavoritesIcons.Silver;
            }
            else
            {
                icn = (FavoritesIcons)(((int)icn) + 1);
            }

            m_Candidate.Starred = icn.ToString();
            picFavorite.Image = favoritesImagesList.Images[(int)icn];
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (this.Width == PREVIEW_CLOSE)
            {
                this.Width = PREVIEW_OPEN;
                btnShowHide.Text = "Hide Preview <<";
            }
        }

        private void dataGridViewCV_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = null;

            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                {
                    fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                    // handle each file passed as needed
                    foreach (string fileName in fileNames)
                    {
                        // do what you are going to do with each filename
                    }
                }
                else if (e.Data.GetDataPresent("FileGroupDescriptor"))
                {
                    Stream fileStream = (Stream)e.Data.GetData("FileGroupDescriptor");
                    byte[] fileGroupDescriptor = new byte[fileStream.Length];
                    fileStream.Read(fileGroupDescriptor, 0, fileGroupDescriptor.Length);
                    fileStream.Close();
                    System.Text.StringBuilder fileName = new System.Text.StringBuilder("");
                    for (int i = 76; i < fileGroupDescriptor.Length; i++)
                    {
                        if (fileGroupDescriptor[i] != 0)
                        {
                            fileName.Append(Convert.ToChar(fileGroupDescriptor[i]));
                        }
                    }

                    fileName = fileName.Replace("?", "_");

                    string tempPath = System.IO.Path.GetTempPath();

                    // put the zip file into the temp directory
                    string theFile = Path.Combine(tempPath, "resume." + fileName.ToString().Split('.')[fileName.ToString().Split('.').Length - 1]);

                    FileInfo fi = new FileInfo(theFile);

                    int file_rescue = 1;

                    while (fi.Exists)
                    {
                        theFile = Path.Combine(tempPath, string.Format("resume({0}).", file_rescue) + fileName.ToString().Split('.')[fileName.ToString().Split('.').Length - 1]);
                        fi = new FileInfo(theFile);
                        file_rescue++;
                    }

                    // get the actual raw file into memory
                    MemoryStream ms = (MemoryStream)e.Data.GetData(
                        "FileContents", true);
                    // allocate enough bytes to hold the raw data
                    byte[] fileBytes = new byte[ms.Length];
                    // set starting position at first byte and read in the raw data
                    ms.Position = 0;
                    ms.Read(fileBytes, 0, (int)ms.Length);
                    // create a file and save the raw zip file to it
                    FileStream fs = new FileStream(theFile, FileMode.Create);
                    fs.Write(fileBytes, 0, (int)fileBytes.Length);

                    fs.Close();  // close the file

                    FileInfo tempFile = new FileInfo(theFile);

                    // always good to make sure we actually created the file
                    if (tempFile.Exists == true)
                    {
                        Resume resume = new Resume();
                        resume.CandidateID = m_Candidate.CandidateID;
                        resume.FileName = tempFile.FullName;
                        resume.IsCloudy = false;

                        m_documents.Add(resume);

                        RefreshResumeGrid();

                    }
                    else
                    { Trace.WriteLine("File was not created!"); }
                }

            }
            catch (System.Exception ex)
            {
                Trace.WriteLine("Error in DragDrop function: " + ex.Message);

                // don't use MessageBox here - Outlook or Explorer is waiting !
            }

        }

        private void dataGridViewCV_DragEnter(object sender, DragEventArgs e)
        {
            // for this program, we allow a file to be dropped from Explorer
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            { e.Effect = DragDropEffects.Copy; }
            //    or this tells us if it is an Outlook attachment drop
            else if (e.Data.GetDataPresent("FileGroupDescriptor"))
            { e.Effect = DragDropEffects.Copy; }
            //    or none of the above
            else
            { e.Effect = DragDropEffects.None; }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count > 0)
            {
                Position item = dgvPositions.SelectedRows[0].DataBoundItem as Position;

                if (item != null &&
                        MessageBox.Show("Are You sure to delete this Opening for this candidate ?", "HunterCV",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    m_positionsBindingSource.Remove(item);

                    m_Candidate.CandidatePositions.Remove(m_Candidate.CandidatePositions.Single(c => c.PositionId == item.PositionID));
                }

            }
        }

    }
}
