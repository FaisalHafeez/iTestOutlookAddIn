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

        public static TreeNode[] Companies
        {
            get
            {
                var doc = XDocument.Load(Settings.AppPath + "XML\\companies.xml");
                var elements = doc.Root.Elements();
                List<TreeNode> x = new List<TreeNode>();

                foreach (XElement root in elements)
                {
                    x.AddRange(GetNodes(new TreeNode((string)root.Attribute("title")), root));
                }

                return x.ToArray();
            }
        }

        public static TreeNode[] Areas
        {
            get
            {
                var doc = XDocument.Load(Settings.AppPath + "XML\\areas.xml");
                var elements = doc.Root.Elements();
                List<TreeNode> x = new List<TreeNode>();

                foreach (XElement root in elements)
                {
                    x.AddRange(GetNodes(new TreeNode((string)root.Attribute("title")), root));
                }

                return x.ToArray();
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


        public static string[] Statuses
        {
            get
            {
                var doc = XDocument.Load(Settings.AppPath + "XML\\statuses.xml");
                return doc.Root.Elements().Select(p => (string)p.Attribute("title")).ToArray();
            }
        }

        public static string[] Roles
        {
            get
            {
                var doc = XDocument.Load(Settings.AppPath + "XML\\roles.xml");
                return doc.Root.Elements().Select(p => (string)p.Attribute("title")).ToArray();
            }
        }
    }
    
}
