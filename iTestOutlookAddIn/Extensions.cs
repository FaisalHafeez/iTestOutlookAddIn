using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iTestOutlookAddIn.ExtensionMethods
{
    public static class Extensions
    {

        public static TreeNode[] CloneNodes(this TreeNode[] nodes)
        {
            TreeNode[] cloned = new TreeNode[nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
            {
                cloned[i] = (TreeNode)nodes[i].Clone();
            }
            return cloned;
        }

        public static TreeNode[] CloneNodes(this TreeNodeCollection nodes)
        {
            TreeNode[] cloned = new TreeNode[nodes.Count];

            for (int i = 0; i < nodes.Count; i++)
            {
                cloned[i] = (TreeNode)nodes[i].Clone();
            }
            return cloned;
        }

        public static string[] ToArray(this TreeNodeCollection nodes)
        {
            string[] arr = new string[nodes.Count];

            for (int i = 0; i < nodes.Count; i++)
            {
                arr[i] = nodes[i].Text;
            }
            return arr;
        }

        public static TreeNode[] AsNodeCollection(this string[] arr)
        {
            TreeNode[] nodes = new TreeNode[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                nodes[i] = new TreeNode(arr[i]);
            }
            return nodes;
        }

    }
}
