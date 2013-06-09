using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HunterCV.AddIn.ExtensionMethods;
using HunterCV.Common;
using System.Net.Http;

namespace HunterCV.AddIn
{
    public partial class PositionEditForm : Form
    {
        private MainRegion m_region = null;
        private Position m_position = null;
        private BindingSource m_candidatesBindingSource = null;

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

            if (m_position.IsNew)
            {
                btnDelete.Enabled = false;
            }
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
            bool blValidTitle = ValidateTitle();

            if (!blValidTitle)
            {
                return;
            }

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
                    if (es.Error != null)
                    {
                        if (es.Error is LicenseException)
                        {
                            CrossThreadUtility.InvokeControlAction<Form>(this, f =>
                            {
                                MessageBox.Show(this, "Sorry, but this license type does not allow more entities of those types", "HunterCV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                f.Close();
                                
                            });
                        }
                    }
                    else
                    {
                        m_position.IsNew = false;

                        CrossThreadUtility.InvokeControlAction<MainRegion>(m_region, m => m.Positions.Add(m_position));

                        Form form = MainRegion.GetForm(typeof(PositionsForm));

                        if (form is PositionsForm)
                        {
                            CrossThreadUtility.InvokeControlAction<PositionsForm>(((PositionsForm)form), f => f.DoSearch(-1));
                        }


                        CrossThreadUtility.InvokeControlAction<Form>(this, f => f.Close());
                    }
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


        private void BindCandidatesGrid()
        {
            var candidates = m_region.Candidates.SelectMany(p => p.CandidatePositions).Where(c => c.PositionId == m_position.PositionID).Select( c => c.CandidateId);// .CandidatePositions.Select(c => c.PositionId).Contains((p.PositionID))));

            m_candidatesBindingSource = new BindingSource();
            m_candidatesBindingSource.DataSource = new List<Candidate>(m_region.Candidates.Where(c => candidates.Contains(c.CandidateID)));
            
            dgvCandidates.DataSource = m_candidatesBindingSource;

            if (m_candidatesBindingSource != null )
            {
                dgvCandidates.Columns[0].Visible = false;
                dgvCandidates.Columns[7].Visible = false;
                dgvCandidates.Columns[8].Visible = false;
                dgvCandidates.Columns[9].Visible = false;
                dgvCandidates.Columns[10].Visible = false;
                dgvCandidates.Columns[11].Visible = false;
                dgvCandidates.Columns[12].Visible = false;
                dgvCandidates.Columns[18].Visible = false;
                dgvCandidates.Columns[19].Visible = false;
                dgvCandidates.Columns[20].Visible = false;
                dgvCandidates.Columns[21].Visible = false;
                dgvCandidates.Columns[22].Visible = false;
                dgvCandidates.Columns[23].Visible = false;
                dgvCandidates.Columns[24].Visible = false;
                dgvCandidates.Columns[25].Visible = false;
            }

        }

        private void PositionEditForm_Load(object sender, EventArgs e)
        {
            BindCandidatesGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (m_candidatesBindingSource.Count > 0)
            {
                MessageBox.Show("You can not delete this opening till You remove all candidates connected to this position", "HunterCV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are You sure to permanently delete this opening from database ?", "HunterCV", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                btnDelete.Enabled = false;

                try
                {
                    BackgroundWorker worker = new BackgroundWorker();

                    worker.RunWorkerCompleted += (senders, es) =>
                    {
                        CrossThreadUtility.InvokeControlAction<Panel>(panelWait, p => p.Visible = false);

                        CrossThreadUtility.InvokeControlAction<MainRegion>(m_region, r =>
                        {
                            m_region.Positions.Remove(m_position);
                        });

                        Form form = MainRegion.GetForm(typeof(PositionsForm));

                        if (form is PositionsForm)
                        {
                            CrossThreadUtility.InvokeControlAction<PositionsForm>(((PositionsForm)form), f => f.DoSearch(-1));
                        }

                        CrossThreadUtility.InvokeControlAction<Form>(this, f => f.Close());
                    };

                    worker.DoWork += (senders, es) =>
                    {
                        CrossThreadUtility.InvokeControlAction<Panel>(panelWait, p => p.Visible = true);

                        //remove from service
                        ServiceHelper.Delete(m_position);
                    };

                    worker.RunWorkerAsync();
                }
                catch (HttpRequestException)
                {

                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ManageCompaniesForm form = new ManageCompaniesForm(m_region);
            form.ShowDialog(this);

            cbCompany.Items.Clear();
            cbCompany.Items.AddRange(m_region.Companies.Select(t => t.Text).ToArray());

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

            if (!string.IsNullOrEmpty(m_position.PositionAreas))
            {
                string[] areas = m_position.PositionAreas.Split(',');

                foreach (string area in areas)
                {
                    GetNodesPath(tvAreas.Nodes, area);
                }
            }

        }

        private void tbTitle_Validating(object sender, CancelEventArgs e)
        {
            ValidateTitle();
        }

        private bool ValidateTitle()
        {
            bool bStatus = true;
            if (tbTitle.Text.Trim() == "")
            {
                errorProvider1.SetError(tbTitle, "Please enter Title");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(tbTitle, "");
            }
            return bStatus;
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
    }
}
