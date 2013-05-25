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
    public partial class ManageAreasForm : Form
    {
        MainRegion m_region = null;
        private TreeNode NodeToBeDeleted;
        private TreeNode NodePt = null;
        private int nNodeCount = 0;
        private Point Position = new Point(0, 0);

        public ManageAreasForm(MainRegion region)
        {
            InitializeComponent();

            m_region = region;
        }

        // This event handler is where the time-consuming work is done. 
        private void updateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ServiceHelper.Update(new Area
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
                m_region.Areas = tvAreas.Nodes.CloneNodes();
                m_region.RefreshAreas();

                this.Close();
            }
        }


        private void ManageAreasForm_Load(object sender, EventArgs e)
        {
            tvAreas.Nodes.AddRange(m_region.Areas.CloneNodes());
            tvAreas.ExpandAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tvAreas_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            NodeToBeDeleted = (TreeNode)e.Item;
            string strItem = e.Item.ToString();
            DoDragDrop(strItem, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void tvAreas_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Position.X = e.X;
            Position.Y = e.Y;
            Position = tvAreas.PointToClient(Position);
            TreeNode DropNode = this.tvAreas.GetNodeAt(Position);
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
                    tvAreas.Nodes.Remove(this.NodeToBeDeleted);
                    tvAreas.Nodes.Insert(DropNode.Index + 1, DragNode);
                }
            }
        }

        private void tvAreas_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
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

            string xml = populateTreeXml(tvAreas);

            updateWorker.RunWorkerAsync(xml);
        }

        public string populateTreeXml(TreeView tv)
        {
            StringBuilder sr = new StringBuilder();
            //Write the header
            sr = sr.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            //Write our root node
            sr = sr.Append("<areas>");

            foreach (TreeNode node in tv.Nodes)
            {
                sr = sr.Append("<area title=\"" + node.Text.Replace("\"","&quot;") + "\">");
                sr = sr.Append(populateNodeXml(node.Nodes));
                sr = sr.Append("</area>");
            }
            //Close the root node

            sr = sr.Append("</areas>");

            return sr.ToString();
        }

        private string populateNodeXml(TreeNodeCollection tnc)
        {
            StringBuilder sr = new StringBuilder();

            foreach (TreeNode node in tnc)
            {
                sr = sr.Append("<area title=\"" + node.Text.Replace("\"", "&quot;") + "\">");
                sr = sr.Append(populateNodeXml(node.Nodes));
                sr = sr.Append("</area>");
            }

            return sr.ToString();
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TreeNode NewNode = new TreeNode();
            NewNode.Text = "Area ";
            NewNode.Text += this.nNodeCount;
            this.tvAreas.Nodes.Add(NewNode);
            this.tvAreas.SelectedNode = NewNode;
            NewNode.BeginEdit();
            nNodeCount++;
          
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NodePt = this.tvAreas.SelectedNode;

            if (NodePt != null && NodePt == this.tvAreas.SelectedNode)
            {
                this.tvAreas.Nodes.Remove(this.tvAreas.SelectedNode);
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            NodePt = this.tvAreas.SelectedNode;

            if (NodePt != null && NodePt == this.tvAreas.SelectedNode)
            {
                TreeNode NewNode = new TreeNode();
                NewNode.Text = "Area ";
                NewNode.Text += this.nNodeCount;
                if (NodePt.GetNodeCount(false) != 0)
                    this.NodePt.Nodes.Insert(NodePt.GetNodeCount(false), NewNode);
                else
                    this.NodePt.Nodes.Add(NewNode);

                this.tvAreas.SelectedNode.Expand();
                this.tvAreas.SelectedNode = NewNode;
                NewNode.BeginEdit();
                nNodeCount++;
            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            NodePt = this.tvAreas.SelectedNode;

            if (NodePt != null && NodePt == this.tvAreas.SelectedNode)
            {
                this.tvAreas.SelectedNode.BeginEdit();
            }

        }
    }
}
