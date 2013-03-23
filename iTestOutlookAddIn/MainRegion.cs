using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;
using System.ComponentModel;
using iTest.Common;
using System.Net.Http;

namespace iTestOutlookAddIn
{
    public partial class MainRegion
    {
        #region Form Region Factory

        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Note)]
        [Microsoft.Office.Tools.Outlook.FormRegionName("iTestOutlookAddIn.MainRegion")]
        public partial class MainRegionFactory
        {
            // Occurs before the form region is initialized.
            // To prevent the form region from appearing, set e.Cancel to true.
            // Use e.OutlookItem to get a reference to the current Outlook item.
            private void MainRegionFactory_FormRegionInitializing(object sender, Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs e)
            {
                if (!CandidatesServiceHelper.IsLoggedIn && !CandidatesServiceHelper.CanceledLogin)
                {
                    LoginForm form = new LoginForm();
                    form.ShowDialog();

                    if (CandidatesServiceHelper.IsLoggedIn)
                    {
                        m_candidates = CandidatesServiceHelper.GetCandidates();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else if (CandidatesServiceHelper.CanceledLogin)
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        // Occurs before the form region is displayed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void MainRegion_FormRegionShowing(object sender, System.EventArgs e)
        {
            //DoSearch(-1);
            tvAreas.Nodes.AddRange(Settings.Areas);
            cbStatus.Items.AddRange(Settings.Statuses);
            cbRole.Items.AddRange(Settings.Roles);

            Outlook.MailItem mailItem = (this.OutlookItem as Outlook.MailItem);

            if (mailItem != null && m_candidates != null)
            {
                var row = m_candidates.Where(p => p.MailEntryID == mailItem.EntryID).FirstOrDefault();

                if (row != null)
                {
                    tbNumber.Text = row.CandidateNumber.Value.ToString();
                    DoSearch(-1);
                }
            }

        }

        public Outlook.Application Application
        {
            get
            {
                return this.OutlookFormRegion.Application;
            }
        }

        public DataGridView DataGrid
        {
            set
            {
                dataGridView1 = value;
            }
            get
            {
                return dataGridView1;
            }
        }

        public List<iTest.Common.Candidate> Candidates
        {
            get
            {
                return m_candidates;
            }
        }

        private static List<iTest.Common.Candidate> m_candidates;
        private bool m_ignoreCheckedEvent = false;

        // Occurs when the form region is closed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void MainRegion_FormRegionClosed(object sender, System.EventArgs e)
        {
            
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
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

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = null;
            int number = 1000;

            Guid guid = Guid.NewGuid();

            if (m_candidates.Count() > 0)
            {
                var max = (from p in m_candidates
                           where p.CandidateNumber != null
                           select (p.CandidateNumber)).Max();

                if (max.HasValue)
                {
                    number = max.Value + 1;
                }
            }

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
                    //
                    // the first step here is to get the filename
                    // of the attachment and
                    // build a full-path name so we can store it 
                    // in the temporary folder
                    //

                    // set up to obtain the FileGroupDescriptor 
                    // and extract the file name
                    Stream theStream = (Stream)e.Data.GetData("FileGroupDescriptor");
                    byte[] fileGroupDescriptor = new byte[512];
                    theStream.Read(fileGroupDescriptor, 0, 512);
                    // used to build the filename from the FileGroupDescriptor block
                    StringBuilder fileName = new StringBuilder("");
                    // this trick gets the filename of the passed attached file
                    for (int i = 76; fileGroupDescriptor[i] != 0; i++)
                    { fileName.Append(Convert.ToChar(fileGroupDescriptor[i])); }
                    theStream.Close();
                    string path = Settings.AppPath;

                    // put the zip file into the temp directory
                    string theFile = path + number.ToString() + "." + fileName.ToString().Split('.').Last();

                    FileInfo fi = new FileInfo(theFile);

                    while (fi.Exists)
                    {
                        number++;
                        theFile = path + number.ToString() + "." + fileName.ToString().Split('.').Last();
                        fi = new FileInfo(theFile);
                    }

                    // create the full-path name

                    //
                    // Second step:  we have the file name.  
                    // Now we need to get the actual raw
                    // data for the attached file and copy it to disk so we work on it.
                    //

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
                        Outlook.MailItem mailItem =
                    (this.OutlookItem as Outlook.MailItem);

                        Candidate newCandidate = new Candidate();
                        newCandidate.CandidateNumber = number;
                        newCandidate.RegistrationDate = mailItem.SentOn;
                        newCandidate.MailEntryID = mailItem.EntryID;
                        newCandidate.CandidateID = guid;
                        newCandidate.ResumePath = tempFile.FullName;
                        newCandidate.EMailAddress = mailItem.SenderEmailAddress;
                        newCandidate.FirstName = mailItem.SenderName;
                        newCandidate.Status = "Classification";

                        CandidateEditForm form = new CandidateEditForm(true, this, newCandidate, mailItem);
                        form.Show(this);
                    }
                    else
                    { Trace.WriteLine("File was not created!"); }
                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error in DragDrop function: " + ex.Message);

                // don't use MessageBox here - Outlook or Explorer is waiting !
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Candidate item = dataGridView1.SelectedRows[0].DataBoundItem as Candidate;
                CandidateEditForm form = new CandidateEditForm( this, item);
                form.Show(this);
            }
        }

        private int m_oldSortingIndex = -1;
        private bool m_oldSortingAscending = false;

        public void DoSearch(int columnIndex)
        {
            DoSearch(columnIndex, false);
        }

        public void DoSearch(int columnIndex, bool reload)
        {
            if (reload)
            {
                try
                {
                    m_candidates = CandidatesServiceHelper.GetCandidates();
                }
                catch (HttpRequestException)
                {
                    LoginForm form = new LoginForm();
                    form.ShowDialog(this);

                    if (CandidatesServiceHelper.IsLoggedIn)
                    {
                        m_candidates = CandidatesServiceHelper.GetCandidates();
                    }
                    else
                    {
                        return;
                    }
                }

            }

            var loc = (from l in m_candidates select l);

            if (!string.IsNullOrEmpty(tbName.Text))
            {
                string[] segments = tbName.Text.Split(' ');

                foreach (string s in segments)
                {
                    loc = loc.Where(a => a.FirstName.Contains(tbName.Text) || a.LastName.Contains(tbName.Text));
                }

            }

            List<String> areas = GetCheckedAreas(tvAreas.Nodes, false);

            if(areas.Count() > 0 )
            {
                loc = loc.Where(p => areas.Contains(p.Areas));
            }

            if (!string.IsNullOrEmpty(cbRole.Text))
                loc = loc.Where(a => a.Roles == cbRole.Text);

            if (!string.IsNullOrEmpty(cbStatus.Text))
                loc = loc.Where(a => a.Status == cbStatus.Text);

            if (!string.IsNullOrEmpty(tbNumber.Text))
            {
                bool parse;
                int result;

                parse = int.TryParse(tbNumber.Text,out result);

                if (parse)
                {
                    loc = loc.Where(a => a.CandidateNumber.Value == result);
                }
            }

            if (checkBox1.Checked)
            {
                DateTime start = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 0, 0, 0);
                DateTime end = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day, 23, 59, 59);

                loc = loc.Where(a => a.RegistrationDate.Value >= start && a.RegistrationDate.Value <= end);
            }

            if (columnIndex == 1)
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    loc = loc.OrderByDescending(p => p.RegistrationDate);
                    m_oldSortingAscending = false;
                }
                else
                {
                    loc = loc.OrderBy(p => p.RegistrationDate);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }

            if (columnIndex == 3)
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    loc = loc.OrderByDescending(p => p.FirstName);
                    m_oldSortingAscending = false;
                }
                else
                {
                    loc = loc.OrderBy(p => p.FirstName);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }

            if (columnIndex == 4)
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    loc = loc.OrderByDescending(p => p.LastName);
                    m_oldSortingAscending = false;
                }
                else
                {
                    loc = loc.OrderBy(p => p.LastName);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }

            if (columnIndex == 9)
            {
                if (m_oldSortingIndex == columnIndex && m_oldSortingAscending)
                {
                    loc = loc.OrderByDescending(p => p.Experience);
                    m_oldSortingAscending = false;
                }
                else
                {
                    loc = loc.OrderBy(p => p.Experience);
                    m_oldSortingAscending = true;
                }

                m_oldSortingIndex = columnIndex;
            }


            this.dataGridView1.DataSource = new List<Candidate>( loc);
            if (loc.Count() > 0)
            {
                this.dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Columns[2].Visible = false;
                this.dataGridView1.Columns[5].Visible = false;
                this.dataGridView1.Columns[6].Visible = false;
                this.dataGridView1.Columns[7].Visible = false;
                this.dataGridView1.Columns[8].Visible = false;
                this.dataGridView1.Columns[12].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoSearch(-1);
        }

        private void tvAreas_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (m_ignoreCheckedEvent)
                return;

            DoSearch(-1);
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

        public int CandidateNumber
        {
            set
            {
                tbNumber.Text = value.ToString();
            }
        }

        public void ClearFilter()
        {
            cbRole.Text = "";
            tbName.Text = "";
            checkBox1.Checked = false;
            cbStatus.Text = "";
            tbNumber.Text = "";

            m_ignoreCheckedEvent = true;
            GetCheckedAreas(tvAreas.Nodes, true);
            m_ignoreCheckedEvent = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearFilter();
            DoSearch(-1);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = checkBox1.Checked;
            dateTimePicker2.Enabled = checkBox1.Checked;
        }

        private void tvAreas_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            DoSearch(e.ColumnIndex);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DoSearch(-1, true);
        }

    }
}
