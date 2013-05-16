using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTestOutlookAddIn.ExtensionMethods;
using iTest.Common;

namespace iTestOutlookAddIn
{
    public partial class ManageRolesForm : Form
    {
        MainRegion m_region = null;
        private TreeNode NodeToBeDeleted;
        private TreeNode NodePt = null;
        private int nNodeCount = 0;
        private Point Position = new Point(0, 0);

        public ManageRolesForm(MainRegion region)
        {
            InitializeComponent();

            m_region = region;
        }

        // This event handler is where the time-consuming work is done. 
        private void updateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ServiceHelper.Update(new Role
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
                m_region.Roles = tvRoles.Nodes.ToArray() ;
                m_region.RefreshRoles();
                this.Close();
            }
        }


        private void ManageRolesForm_Load(object sender, EventArgs e)
        {
            tvRoles.Nodes.AddRange(m_region.Roles.AsNodeCollection());
            tvRoles.ExpandAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tvRoles_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            NodeToBeDeleted = (TreeNode)e.Item;
            string strItem = e.Item.ToString();
            DoDragDrop(strItem, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void tvRoles_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Position.X = e.X;
            Position.Y = e.Y;
            Position = tvRoles.PointToClient(Position);
            TreeNode DropNode = this.tvRoles.GetNodeAt(Position);
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
                    tvRoles.Nodes.Remove(this.NodeToBeDeleted);
                    tvRoles.Nodes.Insert(DropNode.Index + 1, DragNode);
                }
            }
        }

        private void tvRoles_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            panelWait.Visible = true;

            string xml = populateTreeXml(tvRoles);

            updateWorker.RunWorkerAsync(xml);
        }

        public string populateTreeXml(TreeView tv)
        {
            StringBuilder sr = new StringBuilder();
            //Write the header
            sr = sr.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            //Write our root node
            sr = sr.Append("<roles>");

            foreach (TreeNode node in tv.Nodes)
            {
                sr = sr.Append("<role title=\"" + node.Text.Replace("\"","&quot;") + "\">");
                sr = sr.Append(populateNodeXml(node.Nodes));
                sr = sr.Append("</role>");
            }
            //Close the root node

            sr = sr.Append("</roles>");

            return sr.ToString();
        }

        private string populateNodeXml(TreeNodeCollection tnc)
        {
            StringBuilder sr = new StringBuilder();

            foreach (TreeNode node in tnc)
            {
                sr = sr.Append("<role title=\"" + node.Text.Replace("\"", "&quot;") + "\">");
                sr = sr.Append(populateNodeXml(node.Nodes));
                sr = sr.Append("</role>");
            }

            return sr.ToString();
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TreeNode NewNode = new TreeNode();
            NewNode.Text = "Company ";
            NewNode.Text += this.nNodeCount;
            this.tvRoles.Nodes.Add(NewNode);
            this.tvRoles.SelectedNode = NewNode;
            NewNode.BeginEdit();
            nNodeCount++;
          
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NodePt = this.tvRoles.SelectedNode;

            if (NodePt != null && NodePt == this.tvRoles.SelectedNode)
            {
                this.tvRoles.Nodes.Remove(this.tvRoles.SelectedNode);
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            NodePt = this.tvRoles.SelectedNode;

            if (NodePt != null && NodePt == this.tvRoles.SelectedNode)
            {
                TreeNode NewNode = new TreeNode();
                NewNode.Text = "Company ";
                NewNode.Text += this.nNodeCount;
                if (NodePt.GetNodeCount(false) != 0)
                    this.NodePt.Nodes.Insert(NodePt.GetNodeCount(false), NewNode);
                else
                    this.NodePt.Nodes.Add(NewNode);

                this.tvRoles.SelectedNode.Expand();
                this.tvRoles.SelectedNode = NewNode;
                NewNode.BeginEdit();
                nNodeCount++;
            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            NodePt = this.tvRoles.SelectedNode;

            if (NodePt != null && NodePt == this.tvRoles.SelectedNode)
            {
                this.tvRoles.SelectedNode.BeginEdit();
            }

        }
    }
}
