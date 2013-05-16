using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace iTestOutlookAddIn
{
    public static class Extensions
    {
        public static IEnumerable<TreeNode> AddRange(this TreeNode collection, IEnumerable<TreeNode> nodes)
        {
            var items = nodes.ToArray();
            collection.Nodes.AddRange(items);
            return new[] { collection };
        }
    }

    public static class Settings
    {
        public static string AppPath = @"C:\iTest Resumes\";

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

    }
    
}
