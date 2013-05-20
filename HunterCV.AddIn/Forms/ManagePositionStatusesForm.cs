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
    public partial class ManagePositionStatusesForm : Form
    {
        MainRegion m_region = null;
        private TreeNode NodeToBeDeleted;
        private TreeNode NodePt = null;
        private int nNodeCount = 0;
        private Point Position = new Point(0, 0);

        public ManagePositionStatusesForm(MainRegion region)
        {
            InitializeComponent();

            m_region = region;
        }

        // This event handler is where the time-consuming work is done. 
        private void updateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ServiceHelper.Update(new PositionStatus
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
                m_region.PositionsStatuses = tvStatuses.Nodes.ToArray() ;
                //m_region.RefreshCandidatesStatuses();
                this.Close();
            }
        }


        private void ManageStatusesForm_Load(object sender, EventArgs e)
        {
            tvStatuses.Nodes.AddRange(m_region.PositionsStatuses.AsNodeCollection());
            tvStatuses.ExpandAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tvStatuses_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            NodeToBeDeleted = (TreeNode)e.Item;
            string strItem = e.Item.ToString();
            DoDragDrop(strItem, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void tvStatuses_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Position.X = e.X;
            Position.Y = e.Y;
            Position = tvStatuses.PointToClient(Position);
            TreeNode DropNode = this.tvStatuses.GetNodeAt(Position);
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
                    tvStatuses.Nodes.Remove(this.NodeToBeDeleted);
                    tvStatuses.Nodes.Insert(DropNode.Index + 1, DragNode);
                }
            }
        }

        private void tvStatuses_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            panelWait.Visible = true;

            string xml = populateTreeXml(tvStatuses);

            updateWorker.RunWorkerAsync(xml);
        }

        public string populateTreeXml(TreeView tv)
        {
            StringBuilder sr = new StringBuilder();
            //Write the header
            sr = sr.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            //Write our root node
            sr = sr.Append("<statuses>");

            foreach (TreeNode node in tv.Nodes)
            {
                sr = sr.Append("<status title=\"" + node.Text.Replace("\"","&quot;") + "\">");
                sr = sr.Append(populateNodeXml(node.Nodes));
                sr = sr.Append("</status>");
            }
            //Close the root node

            sr = sr.Append("</statuses>");

            return sr.ToString();
        }

        private string populateNodeXml(TreeNodeCollection tnc)
        {
            StringBuilder sr = new StringBuilder();

            foreach (TreeNode node in tnc)
            {
                sr = sr.Append("<status title=\"" + node.Text.Replace("\"", "&quot;") + "\">");
                sr = sr.Append(populateNodeXml(node.Nodes));
                sr = sr.Append("</status>");
            }

            return sr.ToString();
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TreeNode NewNode = new TreeNode();
            NewNode.Text = "Status ";
            NewNode.Text += this.nNodeCount;
            this.tvStatuses.Nodes.Add(NewNode);
            this.tvStatuses.SelectedNode = NewNode;
            NewNode.BeginEdit();
            nNodeCount++;
          
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NodePt = this.tvStatuses.SelectedNode;

            if (NodePt != null && NodePt == this.tvStatuses.SelectedNode)
            {
                this.tvStatuses.Nodes.Remove(this.tvStatuses.SelectedNode);
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            NodePt = this.tvStatuses.SelectedNode;

            if (NodePt != null && NodePt == this.tvStatuses.SelectedNode)
            {
                TreeNode NewNode = new TreeNode();
                NewNode.Text = "Status ";
                NewNode.Text += this.nNodeCount;
                if (NodePt.GetNodeCount(false) != 0)
                    this.NodePt.Nodes.Insert(NodePt.GetNodeCount(false), NewNode);
                else
                    this.NodePt.Nodes.Add(NewNode);

                this.tvStatuses.SelectedNode.Expand();
                this.tvStatuses.SelectedNode = NewNode;
                NewNode.BeginEdit();
                nNodeCount++;
            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            NodePt = this.tvStatuses.SelectedNode;

            if (NodePt != null && NodePt == this.tvStatuses.SelectedNode)
            {
                this.tvStatuses.SelectedNode.BeginEdit();
            }

        }
    }
}
