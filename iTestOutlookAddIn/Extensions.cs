using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using HunterCV.Common;

namespace iTestOutlookAddIn.ExtensionMethods
{
    public static class Extensions
    {
        public static string ReplaceCandidateWildCards(this string text, Candidate candidate)
        {
            text = Regex.Replace(text, @"((\{)(FIRSTNAME)(\}))|((\\\{)(FIRSTNAME)(\\\}))", candidate.FirstName ?? string.Empty);
            text = Regex.Replace(text, @"((\{)(LASTNAME)(\}))|((\\\{)(LASTNAME)(\\\}))", candidate.LastName ?? string.Empty);
            text = Regex.Replace(text, @"((\{)(EMAIL)(\}))|((\\\{)(EMAIL)(\\\}))", candidate.EMailAddress ?? string.Empty);
            text = Regex.Replace(text, @"((\{)(MOBILE)(\}))|((\\\{)(MOBILE)(\\\}))", candidate.Mobile ?? string.Empty);
            text = Regex.Replace(text, @"((\{)(PHONE)(\}))|((\\\{)(PHONE)(\\\}))", candidate.Phone ?? string.Empty);
            text = Regex.Replace(text, @"((\{)(CANDIDATENUMBER)(\}))|((\\\{)(CANDIDATENUMBER)(\\\}))", candidate.CandidateNumber.Value.ToString());

            return text;
        }

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
