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

namespace HunterCV.AddIn
{
    public partial class PositionsForm : Form
    {
        private MainRegion m_region = null;
        private BindingSource m_mainGridBindingSource = null;
        private int m_oldSortingIndex = -1;
        private bool m_oldSortingAscending = false;
        private bool m_ignoreCheckedEvent = false;
        private FormOpenMode m_openMode = FormOpenMode.Normal;
        private IEnumerable<Guid> m_selectedPositionsIds = null;
        private IEnumerable<Position> m_filteredPositions;

        private static int m_TotalRecords;
        private static int m_TotalPages;
        private static int m_CurrentPage;

        public IEnumerable<Guid> SelectedPositionsIds
        {
            get { return m_selectedPositionsIds; }
            set { m_selectedPositionsIds = value; }
        }

        public PositionsForm(MainRegion region, FormOpenMode mode)
        {
            InitializeComponent();

            m_region = region;

            tvAreas.Nodes.AddRange(region.Areas.CloneNodes());
            cbStatus.Items.AddRange(region.PositionsStatuses);
            cbRole.Items.AddRange(region.Roles);
            cbCompany.Items.AddRange(region.Companies.Select(t => t.Attribute("title").Value).ToArray());

            m_openMode = mode;

            if (m_openMode == FormOpenMode.SearchAndSelect)
            {
                cbStatus.Enabled = false;
            }

            DoSearch(-1);
        }

        public void DoSearch(int columnIndex)
        {
            if (m_region.Positions == null)
            {
                return;
            }

            m_filteredPositions = (from l in m_region.Positions select l);

            List<String> areas = GetCheckedAreas(tvAreas.Nodes, false);

            if (areas.Count() > 0)
            {
                foreach (var area in areas)
                {
                    m_filteredPositions = m_filteredPositions.Where(p => p.PositionAreas != null && p.PositionAreas.Contains(area));
                }
            }

            if (m_openMode == FormOpenMode.SearchAndSelect)
            {
                m_filteredPositions = m_filteredPositions.Where(a => a.Status != "Manned");
            }
            else
            {
                if (!string.IsNullOrEmpty(cbStatus.Text))
                {
                    m_filteredPositions = m_filteredPositions.Where(a => a.Status == cbStatus.Text);
                }
            }

            if (!string.IsNullOrEmpty(cbCompany.Text))
            {
                m_filteredPositions = m_filteredPositions.Where(a => a.Company == cbCompany.Text);
            }

            CrossThreadUtility.InvokeControlAction<TextBox>(tbNumber, tb =>
            {
                if (!string.IsNullOrEmpty(tb.Text))
                {
                    bool parse;
                    int result;

                    parse = int.TryParse(tb.Text, out result);

                    if (parse)
                    {
                        m_filteredPositions = m_filteredPositions.Where(a => a.PositionNumber.Value == result);
                    }
                }

            });

            if (checkBox1.Checked)
            {
                DateTime start = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 0, 0, 0);
                DateTime end = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day, 23, 59, 59);

                m_filteredPositions = m_filteredPositions.Where(a => a.PublishedAt.Value >= start && a.PublishedAt.Value <= end);
            }

            m_TotalRecords = m_filteredPositions.Count();
            m_TotalPages = m_TotalRecords / Properties.Settings.Default.PageSize + (m_TotalRecords % Properties.Settings.Default.PageSize > 0 ? 1 : 0);
            m_CurrentPage = 0;

            if (columnIndex > 0 && dg.Columns[columnIndex].Name == "PositionNumber")
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    m_filteredPositions = m_filteredPositions.OrderByDescending(p => p.PositionNumber);
                    m_oldSortingAscending = false;
                }
                else
                {
                    m_filteredPositions = m_filteredPositions.OrderBy(p => p.PositionNumber);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }

            if (columnIndex > 0 && dg.Columns[columnIndex].Name == "PublishedAt")
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    m_filteredPositions = m_filteredPositions.OrderByDescending(p => p.PublishedAt);
                    m_oldSortingAscending = false;
                }
                else
                {
                    m_filteredPositions = m_filteredPositions.OrderBy(p => p.PublishedAt);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }

            if (columnIndex > 0 && dg.Columns[columnIndex].Name == "PositionTitle")
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    m_filteredPositions = m_filteredPositions.OrderByDescending(p => p.PositionTitle);
                    m_oldSortingAscending = false;
                }
                else
                {
                    m_filteredPositions = m_filteredPositions.OrderBy(p => p.PositionTitle);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }

            if (columnIndex > 0 && dg.Columns[columnIndex].Name == "PositionDescription")
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    m_filteredPositions = m_filteredPositions.OrderByDescending(p => p.PositionDescription);
                    m_oldSortingAscending = false;
                }
                else
                {
                    m_filteredPositions = m_filteredPositions.OrderBy(p => p.PositionDescription);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }

            if (columnIndex > 0 && dg.Columns[columnIndex].Name == "PositionAreas")
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    m_filteredPositions = m_filteredPositions.OrderByDescending(p => p.PositionAreas);
                    m_oldSortingAscending = false;
                }
                else
                {
                    m_filteredPositions = m_filteredPositions.OrderBy(p => p.PositionAreas);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }

            if (columnIndex > 0 && dg.Columns[columnIndex].Name == "PositionRole")
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    m_filteredPositions = m_filteredPositions.OrderByDescending(p => p.PositionRole);
                    m_oldSortingAscending = false;
                }
                else
                {
                    m_filteredPositions = m_filteredPositions.OrderBy(p => p.PositionRole);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }

            if (columnIndex > 0 && dg.Columns[columnIndex].Name == "Company")
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    m_filteredPositions = m_filteredPositions.OrderByDescending(p => p.Company);
                    m_oldSortingAscending = false;
                }
                else
                {
                    m_filteredPositions = m_filteredPositions.OrderBy(p => p.Company);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }

            if (columnIndex > 0 && dg.Columns[columnIndex].Name == "Status")
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    m_filteredPositions = m_filteredPositions.OrderByDescending(p => p.Status);
                    m_oldSortingAscending = false;
                }
                else
                {
                    m_filteredPositions = m_filteredPositions.OrderBy(p => p.Status);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }

            //m_mainGridBindingSource = new BindingSource();
            //m_mainGridBindingSource.DataSource = new List<Position>(m_filteredPositions);

            //dg.Columns.Clear();
            //dg.DataSource = m_mainGridBindingSource;

            //if (m_filteredPositions.Count() > 0)
            //{
            //    dg.Columns[0].Visible = false;
            //    dg.Columns[10].Visible = false;
            //    dg.Columns[11].Visible = false;
            //}
            if (m_openMode == FormOpenMode.SearchAndSelect)
            {
                btnContinue.Enabled = true;
            }

            loadPage();
        }

        private void loadPage()
        {
            CrossThreadUtility.InvokeControlAction<DataGridView>(dg, dataGrid =>
            {
                var m_pagedCandidates = m_filteredPositions.Skip(m_CurrentPage * Properties.Settings.Default.PageSize)
                    .Take(Properties.Settings.Default.PageSize);

                m_mainGridBindingSource = new BindingSource();
                m_mainGridBindingSource.DataSource = new List<Position>(m_pagedCandidates);
                
                dataGrid.Columns.Clear();
                dataGrid.DataSource = m_mainGridBindingSource;
                if (m_filteredPositions.Count() > 0 && dataGrid.Columns.Count > 0)
                {
                    dataGrid.Columns[0].Visible = false;
                    dataGrid.Columns[10].Visible = false;
                    dataGrid.Columns[11].Visible = false;
                }

                if (m_openMode == FormOpenMode.SearchAndSelect)
                {
                    dataGrid.ReadOnly = false;

                    for (int i = 0; i < dataGrid.ColumnCount; i++)
                    {
                        dataGrid.Columns[i].ReadOnly = true;
                    }

                    var col = new System.Windows.Forms.DataGridViewCheckBoxColumn();
                    col.Width = 30;
                    col.Frozen = true;
                    col.DividerWidth = 3;
                    col.MinimumWidth = 30;
                    col.ReadOnly = false;

                    dataGrid.Columns.Insert(0, col);
                }
                else
                {
                    dataGrid.ReadOnly = true;
                }

            });

            // Show Status
            CrossThreadUtility.InvokeControlAction<Label>(lblStatus, label => label.Text = (m_CurrentPage + (m_TotalRecords > 0 ? 1 : 0)).ToString() + " / " + m_TotalPages.ToString());
            CrossThreadUtility.InvokeControlAction<Panel>(panelWait, panel => panel.Visible = false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoSearch(-1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearFilter();
            DoSearch(-1);
        }

        private void ClearFilter()
        {
            CrossThreadUtility.InvokeControlAction<ComboBox>(cbRole, cb => cb.Text = "");
            CrossThreadUtility.InvokeControlAction<CheckBox>(checkBox1, cb => cb.Checked = false);
            CrossThreadUtility.InvokeControlAction<ComboBox>(cbStatus, cb => cb.SelectedIndex = -1);
            CrossThreadUtility.InvokeControlAction<TextBox>(tbNumber, cb =>
            {
                cb.Text = "";

                m_ignoreCheckedEvent = true;
                GetCheckedAreas(tvAreas.Nodes, true);
                m_ignoreCheckedEvent = false;

            });

        }

        private List<string> GetCheckedAreas(TreeNodeCollection nodes, bool reset)
        {
            List<String> areas = new List<string>();

            foreach (TreeNode node in nodes)
            {
                if (reset)
                {
                    node.Checked = false;
                }
                else
                {
                    if (node.Checked)
                    {
                        areas.Add(node.Text);
                    }
                }
                CheckChildren(node, areas, reset);
            }

            return areas;
        }

        private void CheckChildren(TreeNode rootNode, List<String> areas, bool reset)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (reset)
                {
                    node.Checked = false;
                }
                else
                {
                    if (node.Checked)
                    {
                        areas.Add(node.Text);
                    }
                    CheckChildren(node, areas, reset);
                }
            }
        }

        private void tvAreas_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (m_ignoreCheckedEvent)
                return;

            DoSearch(-1);
        }

        private void dg_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DoSearch(e.ColumnIndex);
        }

        private void dg_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dg.SelectedRows.Count > 0)
            {
                Position item = dg.SelectedRows[0].DataBoundItem as Position;
                PositionEditForm form = new PositionEditForm(m_region, item);
                form.Show(this);
            }

        }



        private void btnContinue_Click(object sender, EventArgs e)
        {
            List<Guid> selectedIds = new List<Guid>();
            DataGridViewRowCollection rows = dg.Rows ;

            foreach (DataGridViewRow row in rows)
            {
                bool selected = (bool)row.Cells[0].FormattedValue;

                if (selected)
                {
                    Position item = row.DataBoundItem as Position;
                    selectedIds.Add(item.PositionID);
                }
            }

            this.SelectedPositionsIds = selectedIds;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int number = int.Parse(m_region.Settings.Where(p => p.Key == "PositionsStartIndex").Single().Value);

            Guid guid = Guid.NewGuid();

            if (m_region.Positions.Count() > 0)
            {
                var max = (from p in m_region.Positions
                           select (p.PositionNumber)).Max();

                if (max.HasValue)
                {
                    number = max.Value + 1;
                }
            }

            var position = new Position
            {
                PositionNumber = number,
                PositionID = guid,
                Username = ServiceHelper.LastLogin.Username,
                IsNew = true,
                PublishedAt = DateTime.Today,
                Status = "Open"
            };

            PositionEditForm frm = new PositionEditForm(m_region, position);
            frm.Show();

        }


        private void goFirst()
        {
            if (m_filteredPositions == null)
            {
                return;
            }

            m_CurrentPage = 0;

            loadPage();
        }

        private void goPrevious()
        {
            if (m_filteredPositions == null)
            {
                return;
            }

            m_CurrentPage--;

            if (m_CurrentPage < 1)
                m_CurrentPage = 0;

            loadPage();
        }

        private void goNext()
        {
            if (m_filteredPositions == null)
            {
                return;
            }

            m_CurrentPage++;

            if (m_CurrentPage > (m_TotalPages - 1))
                m_CurrentPage = m_TotalPages - 1;

            loadPage();
        }

        private void goLast()
        {
            if (m_filteredPositions == null)
            {
                return;
            }

            m_CurrentPage = m_TotalPages - 1;

            loadPage();
        }

        private void PositionsForm_Activated(object sender, EventArgs e)
        {
            m_mainGridBindingSource.ResetBindings(true);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            goFirst();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            goPrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            goNext();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            goLast();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = checkBox1.Checked;
            dateTimePicker2.Enabled = checkBox1.Checked;
        }
    }
}
