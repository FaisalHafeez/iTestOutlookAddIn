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
    public partial class DuplicateCandidatesForm : Form
    {
        private MainRegion m_region = null;
        private BindingSource m_candidatesBindingSource = null;
        private IEnumerable<Candidate> m_candidates = null;

        public DuplicateCandidatesForm(MainRegion region, IEnumerable<Candidate> candidates)
        {
            InitializeComponent();

            m_candidates = candidates;

            BindCandidatesGrid();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BindCandidatesGrid()
        {
            m_candidatesBindingSource = new BindingSource();
            m_candidatesBindingSource.DataSource = new List<Candidate>(m_candidates);

            dgvCandidates.DataSource = m_candidatesBindingSource;

            if (m_candidatesBindingSource.Count > 0)
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
            }

        }
    }
}
