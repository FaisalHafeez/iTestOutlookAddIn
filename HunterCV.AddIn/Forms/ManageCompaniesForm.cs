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
using System.Xml.Linq;
using HunterCV.AddIn.Forms;

namespace HunterCV.AddIn
{
    public partial class ManageCompaniesForm : Form
    {
        MainRegion m_region = null;
        private TreeNode NodeToBeDeleted;
        private TreeNode NodePt = null;
        private int nNodeCount = 0;
        private Point Position = new Point(0, 0);
        BindingList<Contact> contactsBinding = null;
        private string m_initialCompany = string.Empty;

        public ManageCompaniesForm(MainRegion region)
        {
            InitializeComponent();

            m_region = region;

        }

        public ManageCompaniesForm(MainRegion region, string initialCompany)
        {
            InitializeComponent();

            m_region = region;
            m_initialCompany = initialCompany;
        }

        void contactsBinding_AddingNew(object sender, AddingNewEventArgs e)
        {
        }


        // This event handler is where the time-consuming work is done. 
        private void updateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = e.Argument;

            ServiceHelper.Update(new Company
                {
                    Xml = (string)e.Argument
                });
        }

        private void updateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                m_region.Companies = XDocument.Parse((string)e.Result).Root.Elements(); 

                this.Close();
            }
        }

        private XElement WrapNode(XElement element)
        {
            if (element.Element("details") == null)
            {
                element.Add(new XElement("details"));
            }

            if (element.Element("contacts") == null)
            {
                element.Add(new XElement("contacts"));
            }

            return element;
        }

        private void ManageCompaniesForm_Load(object sender, EventArgs e)
        {
            tvCompanies.Nodes.AddRange(m_region.Companies.ToTreeNodes().CloneNodes().Select(node =>
            {
                XElement element = node.Tag as XElement;

                element = WrapNode(element);
                
                return node;

            }).ToArray());
            tvCompanies.ExpandAll();

            if (!string.IsNullOrEmpty(m_initialCompany))
            {
                TreeNode[] finds = tvCompanies.Nodes
                                    .Cast<TreeNode>()
                                    .Where(r => r.Text == m_initialCompany)
                                    .ToArray();

                if (finds.Count() > 0)
                {
                    tvCompanies.SelectedNode = finds[0];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tvCompanies_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            NodeToBeDeleted = (TreeNode)e.Item;
            string strItem = e.Item.ToString();
            DoDragDrop(strItem, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void tvCompanies_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Position.X = e.X;
            Position.Y = e.Y;
            Position = tvCompanies.PointToClient(Position);
            TreeNode DropNode = this.tvCompanies.GetNodeAt(Position);
            if (DropNode != null && DropNode.Parent == this.NodeToBeDeleted.Parent)
            {
                TreeNode DragNode = this.NodeToBeDeleted;
                if (DropNode.Parent != null)
                {
                    DropNode.Parent.Nodes.Remove(this.NodeToBeDeleted);
                    DropNode.Parent.Nodes.Insert(DropNode.Index + 1, DragNode);
                }
                else
                {
                    tvCompanies.Nodes.Remove(this.NodeToBeDeleted);
                    tvCompanies.Nodes.Insert(DropNode.Index + 1, DragNode);
                }
            }
        }

        private void tvCompanies_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            btnClose.Enabled = false;
            panelWait.Visible = true;

            string xml = populateTreeXml(tvCompanies);

            updateWorker.RunWorkerAsync(xml);
        }

        public string populateTreeXml(TreeView tv)
        {
            StringBuilder sr = new StringBuilder();
            //Write the header
            sr = sr.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            //Write our root node
            sr = sr.Append("<companies>");

            foreach (TreeNode node in tv.Nodes)
            {
                sr = sr.Append("<company title=\"" + node.Text.Replace("\"","&quot;") + "\">");
                sr = sr.Append(populateNodeXml(node));
                sr = sr.Append("</company>");
            }
            //Close the root node

            sr = sr.Append("</companies>");

            return sr.ToString();
        }

        private string populateNodeXml(TreeNode node)
        {
            StringBuilder sr = new StringBuilder();

            if (node.Tag is XElement)
            {
                var element = node.Tag as XElement;

                sr = sr.Append(string.Concat(element.Nodes()));
            }

            return sr.ToString();
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TreeNode NewNode = new TreeNode();
            NewNode.Tag = WrapNode( new XElement("company") );
            NewNode.Text = "Company ";
            NewNode.Text += this.nNodeCount;
            this.tvCompanies.Nodes.Add(NewNode);
            this.tvCompanies.SelectedNode = NewNode;
            NewNode.BeginEdit();
            nNodeCount++;
          
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NodePt = this.tvCompanies.SelectedNode;

            if (NodePt != null && NodePt == this.tvCompanies.SelectedNode)
            {
                this.tvCompanies.Nodes.Remove(this.tvCompanies.SelectedNode);
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            NodePt = this.tvCompanies.SelectedNode;

            if (NodePt != null && NodePt == this.tvCompanies.SelectedNode)
            {
                TreeNode NewNode = new TreeNode();
                NewNode.Text = "Company ";
                NewNode.Text += this.nNodeCount;
                if (NodePt.GetNodeCount(false) != 0)
                    this.NodePt.Nodes.Insert(NodePt.GetNodeCount(false), NewNode);
                else
                    this.NodePt.Nodes.Add(NewNode);

                this.tvCompanies.SelectedNode.Expand();
                this.tvCompanies.SelectedNode = NewNode;
                NewNode.BeginEdit();
                nNodeCount++;
            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            NodePt = this.tvCompanies.SelectedNode;

            if (NodePt != null && NodePt == this.tvCompanies.SelectedNode)
            {
                this.tvCompanies.SelectedNode.BeginEdit();
            }

        }

        private void SetContacts(XElement element)
        {
            contactsBinding = new BindingList<Contact>(element.Elements("contact").Select(c => new Contact
            {
                ID = new Guid( c.Element("id").Value ),
                FullName = c.Element("fullname").Value,
                Email = c.Element("email").Value,
                Phone = c.Element("phone").Value,
                Fax = c.Element("fax").Value,
                Mobile = c.Element("mobile").Value,
                Position = c.Element("position").Value,
                Remarks = c.Element("remarks").Value
            }).ToList());

            dgContacts.DataSource = contactsBinding;
            dgContacts.Columns[0].Visible = false;

        }

        private void SetDetails(XElement element)
        {
            if (element != null)
            {
                tbIdentity.Text = element.Element("identity") != null ? element.Element("identity").Value : string.Empty;
                tbPhone.Text = element.Element("phone") != null ? element.Element("phone").Value : string.Empty;
                tbFax.Text = element.Element("fax") != null ? element.Element("fax").Value : string.Empty;
                tbEmail.Text = element.Element("email") != null ? element.Element("email").Value : string.Empty;
                tbCommision.Text = element.Element("commision") != null ? element.Element("commision").Value : string.Empty;
                tbRemarks.Text = element.Element("remarks") != null ? element.Element("remarks").Value : string.Empty;
            }
        }

        private void tvCompanies_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnRemoveContact.Enabled = false;

            if (e.Node != null)
            {
                if (e.Node.Tag is XElement)
                {
                    var element = (XElement)e.Node.Tag;

                    SetDetails(element.Element("details"));
                    SetContacts(element.Element("contacts"));
                }
            }
        }

        private void tbIdentity_TextChanged(object sender, EventArgs e)
        {
            if (tvCompanies.SelectedNode != null)
            {
                var element = tvCompanies.SelectedNode.Tag as XElement;

                element.Element("details").SetElementValue("identity", tbIdentity.Text);
            }
        }

        private void tbPhone_TextChanged(object sender, EventArgs e)
        {
            if (tvCompanies.SelectedNode != null)
            {
                var element = tvCompanies.SelectedNode.Tag as XElement;

                element.Element("details").SetElementValue("phone", tbPhone.Text);
            }
        }

        private void tbFax_TextChanged(object sender, EventArgs e)
        {
            if (tvCompanies.SelectedNode != null)
            {
                var element = tvCompanies.SelectedNode.Tag as XElement;

                element.Element("details").SetElementValue("fax", tbFax.Text);
            }
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            if (tvCompanies.SelectedNode != null)
            {
                var element = tvCompanies.SelectedNode.Tag as XElement;

                element.Element("details").SetElementValue("email", tbEmail.Text);
            }
        }

        private void tbCommision_TextChanged(object sender, EventArgs e)
        {
            if (tvCompanies.SelectedNode != null)
            {
                var element = tvCompanies.SelectedNode.Tag as XElement;

                element.Element("details").SetElementValue("commision", tbCommision.Text);
            }
        }

        private void tbRemarks_TextChanged(object sender, EventArgs e)
        {
            if (tvCompanies.SelectedNode != null)
            {
                var element = tvCompanies.SelectedNode.Tag as XElement;

                element.Element("details").SetElementValue("remarks", tbRemarks.Text);
            }
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            using (var form = new ContactEditForm(new Contact { ID = Guid.NewGuid() } ))
            {
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    contactsBinding.Add(form.Entity);

                    var element = tvCompanies.SelectedNode.Tag as XElement;
                    element.Element("contacts").Add(new XElement("contact",
                                                            new XElement("id", form.Entity.ID.ToString() ),
                                                            new XElement("fullname", form.Entity.FullName),
                                                            new XElement("phone", form.Entity.Phone),
                                                            new XElement("mobile", form.Entity.Mobile),
                                                            new XElement("fax", form.Entity.Fax),
                                                            new XElement("email", form.Entity.Email),
                                                            new XElement("position", form.Entity.Position),
                                                            new XElement("remarks", form.Entity.Remarks)));

                }
            }
        }

        private void dgContacts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgContacts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgContacts.SelectedRows.Count > 0)
            {
                Contact selectedContact = dgContacts.SelectedRows[0].DataBoundItem as Contact;

                using (var form = new ContactEditForm(selectedContact))
                {
                    if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        var id = selectedContact.ID.ToString();
                        var element = tvCompanies.SelectedNode.Tag as XElement;

                        var contact = (from c in element.Element("contacts").Elements("contact")
	                            where id == c.Element("id").Value
	                            select c).Single();

                        contact.SetElementValue("fullname", selectedContact.FullName);
                        contact.SetElementValue("phone", selectedContact.Phone);
                        contact.SetElementValue("mobile", selectedContact.Mobile);
                        contact.SetElementValue("fax", selectedContact.Fax);
                        contact.SetElementValue("email", selectedContact.Email);
                        contact.SetElementValue("position", selectedContact.Position);
                        contact.SetElementValue("remarks", selectedContact.Remarks);
                    }
                }
            }

        }

        private void dgContacts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgContacts.SelectedRows.Count > 0)
            {
                btnRemoveContact.Enabled = true;
            }

        }

        private void btnRemoveContact_Click(object sender, EventArgs e)
        {
            Contact selectedContact = dgContacts.SelectedRows[0].DataBoundItem as Contact;

            if (selectedContact != null && 
                MessageBox.Show("Are You sure to delete this contact ?", "HunterCV", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                var id = selectedContact.ID.ToString();
                var element = tvCompanies.SelectedNode.Tag as XElement;

                (from c in element.Element("contacts").Elements("contact")
                               where id == c.Element("id").Value
                               select c).Single().Remove();
                
                contactsBinding.Remove(dgContacts.SelectedRows[0].DataBoundItem as Contact);

                btnRemoveContact.Enabled = false;
            }
        }
    }
}
