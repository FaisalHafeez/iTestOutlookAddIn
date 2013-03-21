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

namespace iTestOutlookAddIn
{
    public partial class CandidateEditForm : Form
    {
        private Candidate m_Candidate;
        private iTestDataEntities m_context;
        private MainRegion m_region;
        private Microsoft.Office.Interop.Outlook.MailItem m_mailItem;

        public CandidateEditForm(iTestDataEntities context, MainRegion region, Candidate entity)
        {
            InitializeComponent();

            tvAreas.Nodes.AddRange(Settings.Areas);
            tvSentToCompanies.Nodes.AddRange(Settings.Companies);
            cbStatus.Items.AddRange(Settings.Statuses);
            cbRole.Items.AddRange(Settings.Roles);

            m_context = context;
            m_Candidate = entity;
            m_region = region;
            
            SetValues();
            SetTitle();
        }


        public CandidateEditForm(iTestDataEntities context, MainRegion region, Candidate entity, Microsoft.Office.Interop.Outlook.MailItem mailItem)
        {
            InitializeComponent();

            tvAreas.Nodes.AddRange(Settings.Areas);
            tvSentToCompanies.Nodes.AddRange(Settings.Companies);
            cbStatus.Items.AddRange(Settings.Statuses);
            cbRole.Items.AddRange(Settings.Roles);

            m_context = context;
            m_Candidate = entity;
            m_region = region;
            m_mailItem = mailItem;

            SetValues(); 
            SetTitle();

        }

        private void SetValues()
        {

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

            if (!string.IsNullOrEmpty(m_Candidate.Areas))
            {
                string[] areas = m_Candidate.Areas.Split(',');

                foreach (string area in areas)
                {
                    GetNodesPath(tvAreas.Nodes, area);
                }
            }

            if (!string.IsNullOrEmpty(m_Candidate.SentToCompanies))
            {
                string[] companies = m_Candidate.SentToCompanies.Split(',');

                foreach (string company in companies)
                {
                    GetNodesPath(tvSentToCompanies.Nodes, company);
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
            if (m_Candidate.CandidateNumber != 0)
            {

            }
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
            this.m_Candidate.SentToCompanies = GetNodesPath(tvSentToCompanies.Nodes, null);
            this.m_Candidate.Roles = cbRole.Text;
            this.m_Candidate.EMailAddress = tbEMailAddress.Text;
            this.m_Candidate.Phone = mtbPhone.Text;
            this.m_Candidate.Mobile = mtbMobile.Text;
            this.m_Candidate.Status = cbStatus.Text;
            this.m_Candidate.Former8200 = cbFormer8200.Checked;
            this.m_Candidate.Experience = string.IsNullOrEmpty(cbExperience.Text) ? (short)0 : short.Parse(cbExperience.Text);
            this.m_Candidate.Reference = cbReference.Text;
        }


        private string GetNodesPath(TreeNodeCollection nodes, string value)
        {
            StringBuilder sb = new StringBuilder();

            foreach(TreeNode node in nodes)
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

            if (this.m_Candidate.ResumePath != null)
            {
                FileInfo file = new FileInfo(this.m_Candidate.ResumePath);

                if (file.Exists)
                {
                    string newFilePath = Settings.AppPath + m_Candidate.FirstName + "_" + m_Candidate.LastName + "_" + m_Candidate.CandidateNumber + file.Extension;

                    if ( !this.m_Candidate.ResumePath.Equals(newFilePath))
                    {
                        File.Copy(this.m_Candidate.ResumePath, newFilePath);

                        File.Delete(this.m_Candidate.ResumePath);

                        this.m_Candidate.ResumePath = newFilePath;
                    }
                }
            }

            if (m_Candidate.IsNew)
            {
                m_Candidate.IsNew = false;
                m_context.AddToCandidates(m_Candidate);
                m_context.SaveChanges();

                m_context = new iTestDataEntities();
                this.m_region.DataGrid.DataSource = null;
                this.m_region.ClearFilter();
                this.m_region.CandidateNumber = m_Candidate.CandidateNumber.Value;
                this.m_region.DoSearch(-1);
            }
            else
            {
                m_context.SaveChanges();

            }

            if (m_mailItem != null)
            {
                m_mailItem.Categories =string.Concat ( !string.IsNullOrEmpty(m_mailItem.Categories) ? m_mailItem.Categories : string.Empty,  "< < < <  iTest Candidate Number : " + m_Candidate.CandidateNumber.Value + " Import Date : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "   > > > > ");
                m_mailItem.Save();
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.m_Candidate.IsNew)
            {
                File.Delete(m_Candidate.ResumePath);
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
            button5.Enabled = !m_Candidate.IsNew;
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
        private bool updatingTreeView;

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
            MailItem mail = (MailItem) m_region.Application.CreateItem(OlItemType.olMailItem);
            mail.BodyFormat = OlBodyFormat.olFormatHTML;
            mail.Subject = "Candidate " + m_Candidate.FirstName + " " + m_Candidate.LastName;
            mail.Body = "";
            mail.Attachments.Add(m_Candidate.ResumePath, OlAttachmentType.olByValue, 1, Type.Missing);
            mail.Display();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure to remove this candidate from Your database ?", "iTest", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                m_context.DeleteObject(m_Candidate);
                m_context.SaveChanges();
                this.Close();
                //FileInfo fi = new FileInfo(m_Candidate.ResumePath)
            }
        }
    }
}