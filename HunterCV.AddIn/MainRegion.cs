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
using HunterCV.Common;
using System.Net.Http;
using HunterCV.AddIn.ExtensionMethods;
using System.Threading;
using log4net;
using log4net.Config;

namespace HunterCV.AddIn
{
    public partial class MainRegion
    {
        #region Form Region Factory

        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Note)]
        [Microsoft.Office.Tools.Outlook.FormRegionName("HunterCV.AddIn.MainRegion")]
        public partial class MainRegionFactory
        {
            // Occurs before the form region is initialized.
            // To prevent the form region from appearing, set e.Cancel to true.
            // Use e.OutlookItem to get a reference to the current Outlook item.
            private void MainRegionFactory_FormRegionInitializing(object sender, Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs e)
            {
                if (!ServiceHelper.IsLoggedIn && !ServiceHelper.CanceledLogin)
                {
                    LoginForm form = new LoginForm();
                    form.ShowDialog();

                    if (!ServiceHelper.IsLoggedIn)
                    {
                        e.Cancel = true;
                    }
                }
                else if (ServiceHelper.CanceledLogin)
                {
                    e.Cancel = true;
                }
            }

        }

        #endregion

        public static readonly ILog Logger =
                        LogManager.GetLogger(typeof(MainRegion));

        static MainRegion() 
        { 
            XmlConfigurator.Configure();

            Logger.InfoFormat("Starts logger...");
        } 

        public void RefreshRoles()
        {
            CrossThreadUtility.InvokeControlAction<ComboBox>(cbRole, cb =>
            {
                cb.Items.Clear();
                cb.Items.AddRange(m_roles);
            });
        }

        public void RefreshCandidatesStatuses()
        {

            CrossThreadUtility.InvokeControlAction<ComboBox>(cbStatus, cb =>
            {
                cb.Items.Clear();
                cb.Items.AddRange(m_candidatesStatuses);
            });
        }

        public void RefreshAreas()
        {
            CrossThreadUtility.InvokeControlAction<TreeView>(tvAreas, tv =>
            {
                tv.Nodes.Clear();
                tv.Nodes.AddRange(m_areas.CloneNodes());
            });
        }

        // Occurs before the form region is displayed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void MainRegion_FormRegionShowing(object sender, System.EventArgs e)
        {
            pictureBox1.AllowDrop = true;

            var worker = new BackgroundWorker();

            worker.RunWorkerCompleted += (senders, es) =>
            {
                //CrossThreadUtility.InvokeControlAction<Panel>(panelWait, p => p.Visible = false);
            };

            worker.DoWork += (senders, es) =>
            {
                if (m_candidates == null && !roleWorker.IsBusy)
                {
                    CrossThreadUtility.InvokeControlAction<Panel>(panelWait, p => p.Visible = true);
                    roleWorker.RunWorkerAsync();
                }
                else if (!roleWorker.IsBusy)
                {
                    RefreshAreas();
                    RefreshRoles();
                    RefreshCandidatesStatuses();

                    Outlook.MailItem mailItem = (this.OutlookItem as Outlook.MailItem);

                    if (mailItem != null && m_candidates != null)
                    {
                        var row = m_candidates.Where(p => p.MailEntryID == mailItem.EntryID).FirstOrDefault();

                        if (row != null)
                        {
                            CrossThreadUtility.InvokeControlAction<TextBox>(tbNumber, t => t.Text = row.CandidateNumber.Value.ToString());
                            DoSearch(-1);
                        }
                    }
                }
                else
                {
                    CrossThreadUtility.InvokeControlAction<Panel>(panelWait, p => p.Visible = true);
                }

            };

            worker.RunWorkerAsync();
        }

        public Outlook.Application Application
        {
            get
            {
                return this.OutlookFormRegion.Application;
            }
        }

        public GridRowSelectionTypes GridRowSelectionType { get; set; }

        public bool FilterFavorites { get; set; }

        public CandidateEditForm CurrentCandidateForm
        {
            get
            {
                return m_CurrentCandidateForm;
            }
            set
            {
                m_CurrentCandidateForm = value;
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

        public BindingList<HunterCV.Common.Candidate> Candidates
        {
            get
            {
                return m_candidates;
            }
        }

        public BindingList<HunterCV.Common.Position> Positions
        {
            get
            {
                return m_positions;
            }
        }

        public TreeNode[] Areas
        {
            get
            {
                return m_areas;
            }
            set
            {
                m_areas = value;
            }
        }

        public string[] Roles
        {
            get
            {
                return m_roles;
            }
            set
            {
                m_roles = value;
            }
        }

        public string[] CandidatesStatuses
        {
            get
            {
                return m_candidatesStatuses;
            }
            set
            {
                m_candidatesStatuses = value;
            }
        }

        public string[] PositionsStatuses
        {
            get
            {
                return m_positionsStatuses;
            }
            set
            {
                m_positionsStatuses = value;
            }
        }

        public List<KeyValuePair<string, string>> Settings
        {
            get
            {
                return m_Settings;
            }
            set
            {
                m_Settings = value;
            }
        }

        public List<MailTemplate> MailTemplates
        {
            get
            {
                return m_templates;
            }
            set
            {
                m_templates = value;
            }
        }

        public Guid RoleId
        {
            get
            {
                return m_roleId;
            }
        }

        public TreeNode[] Companies
        {
            get
            {
                return m_companies;
            }
            set
            {
                m_companies = value;
            }
        }

        public BindingSource MainGridBindingSource
        {
            get
            {
                return m_mainGridBindingSource;
            }
            set
            {
                m_mainGridBindingSource = value;
            }
        }

        #region Private static fields

        private CandidateEditForm m_CurrentCandidateForm;
        private static BindingList<HunterCV.Common.Candidate> m_candidates;
        private static BindingList<HunterCV.Common.Position> m_positions;
        private static List<MailTemplate> m_templates;
        private static TreeNode[] m_areas;
        private static string[] m_roles;
        private static string[] m_candidatesStatuses;
        private static string[] m_positionsStatuses;
        private static TreeNode[] m_companies;
        private static Guid m_roleId;
        private static BindingSource m_mainGridBindingSource;
        private static List<KeyValuePair<string, string>> m_Settings = null;
        private static LicenseType m_license;

        public static LicenseType License
        {
            get { return MainRegion.m_license; }
            set { MainRegion.m_license = value; }
        }

        public bool IsRoleWorkerBusy
        {
            get
            {
                return roleWorker.IsBusy;
            }
        }

        private int m_TotalRecords;

        public int TotalRecords
        {
            get { return m_TotalRecords; }
            set { m_TotalRecords = value; }
        }
        private int m_TotalPages;

        public int TotalPages
        {
            get { return m_TotalPages; }
            set { m_TotalPages = value; }
        }
        private int m_CurrentPage;

        public int CurrentPage
        {
            get { return m_CurrentPage; }
            set { m_CurrentPage = value; }
        }

        #endregion

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

            Guid guid = Guid.NewGuid();

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
                        theFile = Path.Combine(tempPath, string.Format("resume({0}).",file_rescue) + fileName.ToString().Split('.')[fileName.ToString().Split('.').Length - 1]);
                        fi = new FileInfo(theFile );
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
                        Outlook.MailItem mailItem =
                    (this.OutlookItem as Outlook.MailItem);

                        Candidate newCandidate = new Candidate();
                        newCandidate.Username = ServiceHelper.LastLogin.Username;
                        newCandidate.RegistrationDate = mailItem.SentOn;
                        newCandidate.MailEntryID = mailItem.EntryID;
                        newCandidate.CandidateID = guid;
                        newCandidate.ResumePath = tempFile.FullName;
                        newCandidate.EMailAddress = mailItem.SenderEmailAddress;
                        newCandidate.CandidatePositions = new List<CandidatePosition>();

                        string[] senderarr = mailItem.SenderName.Split(' ');

                        if (senderarr.Length > 1)
                        {
                            newCandidate.FirstName = senderarr[0];
                            newCandidate.LastName = senderarr.Skip(1).Aggregate((i, j) => i + " " + j);
                        }
                        else
                        {
                            newCandidate.FirstName = senderarr[0];
                        }

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

        public static Form GetForm(Type type)
        {
            FormCollection forms = System.Windows.Forms.Application.OpenForms;

            for (int i = forms.Count - 1; i >= 0; i--)
            {
                if (forms[i].GetType() == type)
                    return forms[i];
            }

            return null;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Candidate item = dataGridView1.SelectedRows[0].DataBoundItem as Candidate;
                CandidateEditForm form = new CandidateEditForm(this, item);
                form.Show(this);
            }
        }

        private int m_oldSortingIndex = -1;
        private bool m_oldSortingAscending = false;

        public void DoSearch(int columnIndex)
        {
            DoSearch(columnIndex, false);
        }

        // This event handler is where the time-consuming work is done. 
        private void m_retrieveWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = ServiceHelper.GetUserData();
        }

        // This event handler deals with the results of the background operation. 
        private void m_retrieveWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //panelWait.Visible = false;

            if (e.Cancelled == true)
            {

            }
            else if (e.Error != null)
            {
                MessageBox.Show("Login failed, please try again\n\nError:" + e.Error.Message, "HunterCV");
            }
            else
            {
                m_roleId = ((UserData)e.Result).roleId;

                var license = ((UserData)e.Result).license;

                if (license == Role.FreeLicenseGuid)
                {
                    m_license = LicenseType.Free;
                }
                else if (license == Role.StandardLicenseGuid)
                {
                    m_license = LicenseType.Standard;
                }
                else if (license == Role.PremiumLicenseGuid)
                {
                    m_license = LicenseType.Premium;
                }
                else
                {
                    m_license = LicenseType.Free;
                }


                m_positions = new BindingList<Position>(((UserData)e.Result).positions.ToList());


                //parse areas
                var docAreas = XDocument.Parse(((UserData)e.Result).areas);
                var elementsAreas = docAreas.Root.Elements();
                List<TreeNode> xAreas = new List<TreeNode>();

                foreach (XElement root in elementsAreas)
                {
                    xAreas.AddRange(GetNodes(new TreeNode((string)root.Attribute("title")), root));
                }

                m_areas = xAreas.ToArray();

                //parse companies
                var docCompanies = XDocument.Parse(((UserData)e.Result).companies);
                var elementsCompanies = docCompanies.Root.Elements();
                List<TreeNode> xCompany = new List<TreeNode>();

                foreach (XElement root in elementsCompanies)
                {
                    xCompany.AddRange(GetNodes(new TreeNode((string)root.Attribute("title")), root));
                }

                m_companies = xCompany.ToArray();

                //parse roles
                var docRoles = XDocument.Parse(((UserData)e.Result).roles);
                var elementsRoles = docRoles.Root.Elements();
                List<string> xRole = new List<string>();

                foreach (XElement root in elementsRoles)
                {
                    xRole.Add((string)root.Attribute("title"));
                }

                m_roles = xRole.ToArray();


                //parse candidates statuses
                var docCandidatesStatuses = XDocument.Parse(((UserData)e.Result).candidatesStatuses);
                var elementsCandidatesStatuses = docCandidatesStatuses.Root.Elements();
                List<string> xCandidatesStatus = new List<string>();

                foreach (XElement root in elementsCandidatesStatuses)
                {
                    xCandidatesStatus.Add((string)root.Attribute("title"));
                }

                m_candidatesStatuses = xCandidatesStatus.ToArray();

                //parse positions statuses
                var docPositionsStatuses = XDocument.Parse(((UserData)e.Result).positionsStatuses);
                var elementsPositionsStatuses = docPositionsStatuses.Root.Elements();
                List<string> xPositionsStatus = new List<string>();

                foreach (XElement root in elementsPositionsStatuses)
                {
                    xPositionsStatus.Add((string)root.Attribute("title"));
                }

                m_positionsStatuses = xPositionsStatus.ToArray();

                //parse settings
                var docSettings = XDocument.Parse(((UserData)e.Result).settings);
                var elementsSettings = docSettings.Root.Elements();
                m_Settings = new List<KeyValuePair<string, string>>();

                foreach (XElement root in elementsSettings)
                {
                    m_Settings.Add(new KeyValuePair<string, string>((string)root.Attribute("title"), (string)root.Attribute("value")));
                }

                //parse mail templates
                m_templates = new List<MailTemplate>(((UserData)e.Result).templates);

                foreach (Microsoft.Office.Tools.Outlook.IFormRegion formRegion
                    in Globals.FormRegions)
                {
                    if (formRegion is MainRegion)
                    {
                        MainRegion region = (MainRegion)formRegion;
                        region.RefreshAreas();
                        region.RefreshRoles();
                        region.RefreshCandidatesStatuses();
                        region.DoSearch(-1, false);

                        CrossThreadUtility.InvokeControlAction<Panel>(region.panelWait, panel =>
                        {
                            panel.Visible = false;
                        });
                    }
                }

            }
        }




        private static IEnumerable<TreeNode> GetNodes(TreeNode node, XElement element)
        {
            return element.HasElements ?
                node.AddRange(
                                from item in element.Elements()
                                let tree = new TreeNode((string)item.Attribute("title"))
                                from newNode
                                in GetNodes(tree, item)
                                where item.HasAttributes
                                select newNode
                              )
                              :
                new[] { node };
        }


        public void DoSearch(int columnIndex, bool reload)
        {
            m_CurrentPage = 0;

            if (m_oldSortingIndex == columnIndex && columnIndex != -1)
            {
                m_oldSortingAscending = !m_oldSortingAscending;
            }
            else
            {
                if (m_oldSortingIndex == -1)
                {
                    m_oldSortingAscending = false;
                }

                m_oldSortingIndex = columnIndex;
            }

            if (reload)
            {
                if (candidatesWorker.IsBusy != true)
                {
                    panelWait.Visible = true;
                    candidatesWorker.RunWorkerAsync();
                }
                return;
            }

            FilterCandidates(columnIndex);
        }

        private void FilterCandidates()
        {
            FilterCandidates(-1);
        }

        private void FilterCandidates(int columnIndex)
        {
            if (!candidatesWorker.IsBusy)
            {
                candidatesWorker.RunWorkerAsync();
            }
        }

        private void SetCandidatesInGridView()
        {
            CrossThreadUtility.InvokeControlAction<DataGridView>(dataGridView1, dg =>
            {
                m_mainGridBindingSource = new BindingSource();
                m_mainGridBindingSource.DataSource = new List<Candidate>(m_candidates);
                dg.Columns.Clear();
                dg.DataSource = m_mainGridBindingSource;
                if (m_candidates.Count() > 0 && dg.Columns.Count > 0)
                {
                    dg.Columns[0].Visible = false;
                    dg.Columns[7].Visible = false;
                    dg.Columns[8].Visible = false;
                    dg.Columns[9].Visible = false;
                    dg.Columns[10].Visible = false;
                    dg.Columns[11].Visible = false;
                    dg.Columns[12].Visible = false;
                    dg.Columns[18].Visible = false;
                    dg.Columns[19].Visible = false;
                    dg.Columns[20].Visible = false;
                    dg.Columns[21].Visible = false;
                    dg.Columns[22].Visible = false;
                    dg.Columns[23].Visible = false;
                    dg.Columns[24].Visible = false;
                    dg.Columns[25].Visible = false;
                    dg.Columns[26].Visible = false;

                    DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
                    iconColumn.Name = "FavoriteIcon";
                    iconColumn.HeaderText = "";
                    iconColumn.Width = 35;
                    dg.Columns.Insert(0, iconColumn);
                }
            });

            // Show Status
            CrossThreadUtility.InvokeControlAction<Label>(lblStatus, label => label.Text = (m_CurrentPage + (m_TotalRecords > 0 ? 1 : 0)).ToString() + " / " + m_TotalPages.ToString());
            CrossThreadUtility.InvokeControlAction<Panel>(panelWait, panel => panel.Visible = false);
        }

        public void GoFirstPage()
        {
            if (m_candidates == null)
            {
                return;
            }

            m_CurrentPage = 0;

            FilterCandidates();
        }

        public bool GoPreviousPage()
        {
            if (m_candidates == null)
            {
                return false;
            }

            m_CurrentPage--;

            if (m_CurrentPage < 0)
            {
                m_CurrentPage = 0;
                return false;
            }

            FilterCandidates();

            return true;
        }

        public bool GoNextPage()
        {
            if (m_candidates == null)
            {
                return false;
            }

            m_CurrentPage++;

            if (m_CurrentPage > (m_TotalPages - 1))
            {
                m_CurrentPage = m_TotalPages - 1;
                return false;
            }

            FilterCandidates();

            return true;
        }

        public void GoLastPage()
        {
            if (m_candidates == null)
            {
                return;
            }

            m_CurrentPage = m_TotalPages - 1;

            FilterCandidates();
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
                CrossThreadUtility.InvokeControlAction<TextBox>(tbNumber, cb => cb.Text = value.ToString());
            }
        }

        public void ClearFilter()
        {
            CrossThreadUtility.InvokeControlAction<ComboBox>(cbRole, cb => cb.Text = "");
            CrossThreadUtility.InvokeControlAction<TextBox>(tbName, cb => cb.Text = "");
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
            if (e.ColumnIndex == 0)
            {
                bool value = !(bool)dataGridView1.Rows[e.RowIndex].Cells["IsFavorite"].Value;

                var worker = new BackgroundWorker();

                panelWait.Visible = true;

                worker.DoWork += (ssender, es) =>
                {
                    if (!value)
                    {
                        ServiceHelper.DeleteFavorite((Guid)dataGridView1.Rows[e.RowIndex].Cells["CandidateID"].Value);
                    }
                    else
                    {
                        ServiceHelper.AddFavorite((Candidate)dataGridView1.Rows[e.RowIndex].DataBoundItem);
                    }
                };

                worker.RunWorkerCompleted += (ssender, es) =>
                {
                    CrossThreadUtility.InvokeControlAction<DataGridView>(dataGridView1, dg =>
                    {
                        dg.Rows[e.RowIndex].Cells["IsFavorite"].Value = value;
                        m_mainGridBindingSource.ResetBindings(true);
                    });

                    CrossThreadUtility.InvokeControlAction<Panel>(panelWait, p => p.Visible = false);
                };

                worker.RunWorkerAsync();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ServiceHelper.IsLoggedIn)
            {
                bool result = ServiceHelper.Login(ServiceHelper.LastLogin.Username, ServiceHelper.LastLogin.Password);
            }
        }

        private void showFormTimer_Tick(object sender, EventArgs e)
        {
            showFormTimer.Enabled = false;

            if (m_areas == null && !roleWorker.IsBusy)
            {
                panelWait.Visible = true;
                roleWorker.RunWorkerAsync();
            }
            else if (!roleWorker.IsBusy)
            {
                RefreshAreas();
                RefreshRoles();
                RefreshCandidatesStatuses();

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
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            GoFirstPage();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            GoPreviousPage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            GoNextPage();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            GoLastPage();
        }

        private void candidatesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CrossThreadUtility.InvokeControlAction<Panel>(panelWait, p => p.Visible = true);

            CandidatesApiRequest request = new CandidatesApiRequest();
            request.PageSize = Properties.Settings.Default.PageSize;
            request.PageNumber = m_CurrentPage;

            IEnumerable<String> areas = null;
            CrossThreadUtility.InvokeControlAction<TreeView>(tvAreas, tree =>
            {
                areas = GetCheckedAreas(tree.Nodes, false).ToArray<string>();
            });

            request.FilterFavorites = this.FilterFavorites;

            if (areas.Count() > 0)
            {
                request.FilterAreas = areas.Aggregate((i, j) => i + "," + j);
            }

            if (!string.IsNullOrEmpty(tbName.Text))
            {
                request.FilterFullName = tbName.Text.Trim();
            }

            CrossThreadUtility.InvokeControlAction<ComboBox>(cbRole, cb =>
            {
                if (!string.IsNullOrEmpty(cb.Text))
                {
                    request.FilterRole = cb.Text;
                }
            });

            CrossThreadUtility.InvokeControlAction<ComboBox>(cbStatus, cb =>
            {
                if (!string.IsNullOrEmpty(cb.Text))
                {
                    request.FilterStatus = cb.Text;
                }
            });

            CrossThreadUtility.InvokeControlAction<TextBox>(tbNumber, tb =>
            {
                if (!string.IsNullOrEmpty(tb.Text))
                {
                    bool parse;
                    int result;

                    parse = int.TryParse(tb.Text, out result);

                    if (parse)
                    {
                        request.FilterCandidateNumber = result;
                    }
                }

            });
            CrossThreadUtility.InvokeControlAction<CheckBox>(checkBox1, cb =>
            {
                if (cb.Checked)
                {
                    DateTime start = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 0, 0, 0);
                    DateTime end = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day, 23, 59, 59);

                    request.FilterRegistrationStartDate = start;
                    request.FilterRegistrationEndDate = end;
                }
            });

            CrossThreadUtility.InvokeControlAction<DataGridView>(dataGridView1, dg =>
            {
                if (m_oldSortingIndex > -1)
                {
                    request.SortField = dg.Columns[m_oldSortingIndex].Name;
                }
                else
                {
                    request.SortField = "CandidateNumber";
                }

                request.SortType = m_oldSortingAscending ? 2 : 1;
            });

            e.Result = ServiceHelper.SearchCandidates(request);
        }

        public bool IsCandidatesWorkerBusy
        {
            get
            {
                return candidatesWorker.IsBusy;
            }
        }

        private void candidatesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {

            }
            else if (e.Error != null)
            {
                MessageBox.Show("Login failed, please try again\n\nError:" + e.Error.Message, "HunterCV");
            }
            else
            {

                var response = (CandidatesApiResponse)e.Result;

                m_TotalPages = response.TotalPages;
                m_TotalRecords = response.TotalRows;

                m_candidates = new BindingList<Candidate>( response.Candidates.ToList() );

                SetCandidatesInGridView();

                CrossThreadUtility.InvokeControlAction<Panel>(panelWait, p => p.Visible = false);

                if (this.CurrentCandidateForm != null)
                {
                    CrossThreadUtility.InvokeControlAction<DataGridView>(dataGridView1, dg =>
                    {
                        dg.ClearSelection();

                        if (this.GridRowSelectionType == GridRowSelectionTypes.First)
                        {
                            dg.Rows[0].Selected = true;
                        }
                        else
                        {
                            dg.Rows[dg.Rows.Count - 1].Selected = true;
                        }

                        this.CurrentCandidateForm.Candidate = dg.SelectedRows[0].DataBoundItem as Candidate;

                        this.CurrentCandidateForm.SetFormValues();
                        this.CurrentCandidateForm.SetFormTitle();
                        this.CurrentCandidateForm.LoadResumes();

                        CrossThreadUtility.InvokeControlAction<CandidateEditForm>(this.CurrentCandidateForm, form =>
                            {
                                form.Enabled = true;
                                this.CurrentCandidateForm = null;
                            });
                    });
                }

            }

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "FavoriteIcon")
            {
                e.Value = (bool)dataGridView1.Rows[e.RowIndex].Cells["IsFavorite"].Value ? Properties.Resources.gold16_star : Properties.Resources.silver16_star;
            } 
        }

        private void tbNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                button1_Click(null, new EventArgs());
            }

        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                button1_Click(null, new EventArgs());
            }
        }

        private void cbStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                button1_Click(null, new EventArgs());
            }
        }

        private void cbRole_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                button1_Click(null, new EventArgs());
            }
        }

    }
}
