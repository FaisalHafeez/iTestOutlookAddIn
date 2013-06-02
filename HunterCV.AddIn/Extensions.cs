using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using HunterCV.Common;
using System.Drawing;

namespace HunterCV.AddIn.ExtensionMethods
{
    public static class Extensions
    {
        private static RichTextBox m_rtb = new RichTextBox();

        public static string GetQueryString(this object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + System.Uri.EscapeDataString(p.GetValue(obj, null).ToString());

            return String.Join("&", properties.ToArray());
        }

        public static string ReplaceCandidateWildCards(this string rtf, Candidate candidate)
        {
            return ReplaceCandidateWildCards(rtf, candidate, false);
        }

        private static void ReplaceWildCard(string wildcard, string replaceWith)
        {
            int index = m_rtb.Find(wildcard);

            if (index >= 0)
            {
                m_rtb.Select(index, wildcard.Length);
                m_rtb.SelectedText = replaceWith;
            }
        }

        public static string ReplaceCandidateWildCards(this string rtf, Candidate candidate,bool blEncodeRtf )
        {
            CrossThreadUtility.InvokeControlAction<RichTextBox>(m_rtb, t =>
           {
               if (blEncodeRtf)
               {
                   t.Clear();
                   
                   m_rtb.Rtf = rtf;

                   ReplaceWildCard(@"{FIRSTNAME}", candidate.FirstName);
                   ReplaceWildCard(@"{LASTNAME}", candidate.LastName);
                   ReplaceWildCard(@"{EMAIL}", candidate.EMailAddress);
                   ReplaceWildCard(@"{MOBILE}", candidate.Mobile);
                   ReplaceWildCard(@"{PHONE}", candidate.Phone);
                   ReplaceWildCard(@"{CANDIDATENUMBER}", candidate.CandidateNumber.Value.ToString());


                   rtf = m_rtb.Rtf;
               }
               else
               {
                   rtf = Regex.Replace(rtf, @"(\{)(FIRSTNAME)(\})", candidate.FirstName ?? string.Empty);
                   rtf = Regex.Replace(rtf, @"(\{)(LASTNAME)(\})", candidate.LastName ?? string.Empty);
                   rtf = Regex.Replace(rtf, @"(\{)(EMAIL)(\})", candidate.EMailAddress ?? string.Empty);
                   rtf = Regex.Replace(rtf, @"(\{)(MOBILE)(\})", candidate.Mobile ?? string.Empty);
                   rtf = Regex.Replace(rtf, @"(\{)(PHONE)(\})", candidate.Phone ?? string.Empty);
                   rtf = Regex.Replace(rtf, @"(\{)(CANDIDATENUMBER)(\})", candidate.CandidateNumber.Value.ToString());
               }
           });

            return rtf;
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
