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
    public partial class PositionsForm : Form
    {
        private MainRegion m_region = null;
        private BindingSource m_mainGridBindingSource = null;
        private int m_oldSortingIndex = -1;
        private bool m_oldSortingAscending = false;
        private bool m_ignoreCheckedEvent = false;
        private FormOpenMode m_openMode = FormOpenMode.Normal;
        private IEnumerable<Guid> m_selectedPositionsIds = null;

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
            cbCompany.Items.AddRange(region.Companies.Select(t => t.Text).ToArray());

            m_openMode = mode;

            if (m_openMode == FormOpenMode.SearchAndSelect)
            {

            }

            DoSearch(-1);
        }

        private void DoSearch(int columnIndex)
        {
            if (m_region.Positions == null)
            {
                return;
            }

            var loc = (from l in m_region.Positions select l);

            List<String> areas = GetCheckedAreas(tvAreas.Nodes, false);

            if (areas.Count() > 0)
            {
                foreach (var area in areas)
                {
                    loc = loc.Where(p => p.PositionAreas != null && p.PositionAreas.Contains(area));
                }
            }

            if (!string.IsNullOrEmpty(cbStatus.Text))
            {
                loc = loc.Where(a => a.Status == cbStatus.Text);
            }

            if (!string.IsNullOrEmpty(cbCompany.Text))
            {
                loc = loc.Where(a => a.Company == cbCompany.Text);
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
                        loc = loc.Where(a => a.PositionNumber.Value == result);
                    }
                }

            });

            if (checkBox1.Checked)
            {
                DateTime start = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 0, 0, 0);
                DateTime end = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day, 23, 59, 59);

                loc = loc.Where(a => a.PublishedAt.Value >= start && a.PublishedAt.Value <= end);
            }

            if (columnIndex > 0 && dg.Columns[columnIndex].Name == "PositionNumber")
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    loc = loc.OrderByDescending(p => p.PositionNumber);
                    m_oldSortingAscending = false;
                }
                else
                {
                    loc = loc.OrderBy(p => p.PositionNumber);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }

            if (columnIndex > 0 && dg.Columns[columnIndex].Name == "PublishedAt")
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    loc = loc.OrderByDescending(p => p.PublishedAt);
                    m_oldSortingAscending = false;
                }
                else
                {
                    loc = loc.OrderBy(p => p.PublishedAt);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }

            if (columnIndex > 0 && dg.Columns[columnIndex].Name == "PositionTitle")
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    loc = loc.OrderByDescending(p => p.PositionTitle);
                    m_oldSortingAscending = false;
                }
                else
                {
                    loc = loc.OrderBy(p => p.PositionTitle);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }

            if (columnIndex > 0 && dg.Columns[columnIndex].Name == "PositionDescription")
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    loc = loc.OrderByDescending(p => p.PositionDescription);
                    m_oldSortingAscending = false;
                }
                else
                {
                    loc = loc.OrderBy(p => p.PositionDescription);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }

            if (columnIndex > 0 && dg.Columns[columnIndex].Name == "PositionAreas")
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    loc = loc.OrderByDescending(p => p.PositionAreas);
                    m_oldSortingAscending = false;
                }
                else
                {
                    loc = loc.OrderBy(p => p.PositionAreas);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }

            if (columnIndex > 0 && dg.Columns[columnIndex].Name == "PositionRole")
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    loc = loc.OrderByDescending(p => p.PositionRole);
                    m_oldSortingAscending = false;
                }
                else
                {
                    loc = loc.OrderBy(p => p.PositionRole);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }

            if (columnIndex > 0 && dg.Columns[columnIndex].Name == "Company")
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    loc = loc.OrderByDescending(p => p.Company);
                    m_oldSortingAscending = false;
                }
                else
                {
                    loc = loc.OrderBy(p => p.Company);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }

            if (columnIndex > 0 && dg.Columns[columnIndex].Name == "Status")
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    loc = loc.OrderByDescending(p => p.Status);
                    m_oldSortingAscending = false;
                }
                else
                {
                    loc = loc.OrderBy(p => p.Status);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }


            m_mainGridBindingSource = new BindingSource();
            m_mainGridBindingSource.DataSource = new List<Position>(loc);

            dg.DataSource = m_mainGridBindingSource;

            if (loc.Count() > 0)
            {
                dg.Columns[0].Visible = false;
                dg.Columns[10].Visible = false;
                dg.Columns[11].Visible = false;
            }

            if (m_openMode == FormOpenMode.SearchAndSelect)
            {
                btnContinue.Enabled = true;
                dg.ReadOnly = false;

                for(int i =0;i<dg.ColumnCount;i++)
                {
                    dg.Columns[i].ReadOnly = true;
                }

                var col = new System.Windows.Forms.DataGridViewCheckBoxColumn();
                col.Width = 30;
                col.Frozen = true;
                col.DividerWidth = 3;
                col.MinimumWidth = 30;
                col.ReadOnly = false;

                dg.Columns.Insert(0, col);
            }
            else
            {
                dg.ReadOnly = true;
            }
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
            CrossThreadUtility.InvokeControlAction<ComboBox>(cbStatus, cb => cb.Text = "");
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
    }
}
