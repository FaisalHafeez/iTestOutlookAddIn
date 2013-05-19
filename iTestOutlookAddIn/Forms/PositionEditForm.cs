using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTestOutlookAddIn.ExtensionMethods;
using HunterCV.Common;

namespace iTestOutlookAddIn
{
    public partial class PositionEditForm : Form
    {
        private MainRegion m_region = null;
        private Position m_position = null;

        public PositionEditForm(MainRegion region, Position position)
        {
            InitializeComponent();

            m_position = position;
            m_region = region;

            tvAreas.Nodes.AddRange(region.Areas.CloneNodes());
            cbStatus.Items.AddRange(region.PositionsStatuses);
            cbRole.Items.AddRange(region.Roles);
            cbCompany.Items.AddRange(region.Companies.Select( t => t.Text).ToArray());

            this.tbTitle.DataBindings.Add("Text", m_position, "PositionTitle", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbDescription.DataBindings.Add("Text", m_position, "PositionDescription", false, DataSourceUpdateMode.OnPropertyChanged);
            this.dtpPublishedAt.DataBindings.Add("Value", m_position, "PublishedAt", false, DataSourceUpdateMode.OnPropertyChanged);
            this.cbRole.DataBindings.Add("Text", m_position, "PositionRole", false, DataSourceUpdateMode.OnPropertyChanged);
            this.cbStatus.DataBindings.Add("Text", m_position, "Status", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbUsername.DataBindings.Add("Text", m_position, "Username", false, DataSourceUpdateMode.OnPropertyChanged);
            this.cbCompany.DataBindings.Add("Text", m_position, "Company", false, DataSourceUpdateMode.OnPropertyChanged);
            this.rtbEvents.DataBindings.Add("Rtf", m_position, "Events", false, DataSourceUpdateMode.OnPropertyChanged);

            if (!string.IsNullOrEmpty(m_position.PositionAreas))
            {
                string[] areas = m_position.PositionAreas.Split(',');

                foreach (string area in areas)
                {
                    GetNodesPath(tvAreas.Nodes, area);
                }
            }

            SetTitle();
        }

        private void PositionEditForm_Shown(object sender, EventArgs e)
        {
            
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
            panelWait.Visible = true;
            button1.Enabled = false;

            this.m_position.PositionAreas = GetNodesPath(tvAreas.Nodes, null);

            //exists
            if (!m_position.IsNew)
            {

                var saveWorker = new BackgroundWorker();

                saveWorker.RunWorkerCompleted += (senders, es) =>
                {
                    CrossThreadUtility.InvokeControlAction<MainRegion>(m_region, m => m.Positions.Add(m_position));

                    CrossThreadUtility.InvokeControlAction<Form>(this, f => f.Close());

                };

                saveWorker.DoWork += (senders, es) =>
                {
                    try
                    {
                        if (!es.Cancel)
                        {
                            ServiceHelper.Update(m_position);
                        }
                    }
                    finally
                    {

                    }
                };

                saveWorker.RunWorkerAsync();


            }
            else
            {
                //new

                var saveWorker = new BackgroundWorker();

                saveWorker.RunWorkerCompleted += (senders, es) =>
                {
                    CrossThreadUtility.InvokeControlAction<MainRegion>(m_region, m => m.Positions.Add(m_position));

                    CrossThreadUtility.InvokeControlAction<Form>(this, f => f.Close());

                };

                saveWorker.DoWork += (senders, es) =>
                {
                    try
                    {
                        if (!es.Cancel)
                        {
                            ServiceHelper.Add(m_position);
                        }
                    }
                    finally
                    {

                    }
                };

                saveWorker.RunWorkerAsync();

            }
        }

        private void SetTitle()
        {
            lblTitle.Text = m_position.PositionNumber + " - " + m_position.PositionTitle;
            this.Text = lblTitle.Text;

        }

        private void tbTitle_KeyUp(object sender, KeyEventArgs e)
        {
            SetTitle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
