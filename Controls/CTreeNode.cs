using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ERPHelper
{
    public partial class CTreeNode : TreeNode
    {
        public CTreeNode () : base()
        {

        }

        public CTreeNode(string text, int imageIndex, int selectedImageIndex) : base(text, imageIndex, selectedImageIndex)
        {
        }

        public void GetFiles(string dir, string filterInput)
        {
            try
            {
                string[] filters = filterInput.Split(',');
                string[] files = { };
                foreach (string filter in filters)
                {
                    files = files.Concat(Directory.GetFiles(dir, filter.Trim())).ToArray();
                }

                foreach (string file in files)
                {
                    try
                    {
                        FileInfo fi = new FileInfo(file);
                        CTreeNode node = new CTreeNode(fi.Name, 0, 1);
                        node.Tag = fi.FullName;
                        node.StateImageIndex = 1;
                        this.Nodes.Add(node);
                    }
                    catch
                    {
                        // ignore exception
                    }
                }
            }
            catch
            {
                // ignore exception
            }
        }

        public CTreeNode RemoveEmptyNode(int level)
        {
            level++;

            if (level < 20)
            {
                try
                {
                    for (int i = this.Nodes.Count - 1; i >= 0; i--)
                    {
                        CTreeNode childNode = (CTreeNode) this.Nodes[i];
                        // Directory
                        if (childNode.Tag.ToString() == "...")
                        {
                            if (childNode.Nodes.Count > 0)
                            {
                                childNode = childNode.RemoveEmptyNode(level);
                            }
                            if (childNode != null && childNode.Nodes.Count == 0)
                            {
                                childNode.Remove();
                            }
                        }
                    }
                }
                catch
                {
                    // ignore exception
                }
            }
            return this;
        }
    }
}
