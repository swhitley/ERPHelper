using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ERPHelper
{
    public partial class CTreeView : TreeView
    {
        public void Update(string dir, string filter, CTreeNode parentNode)
        {
            try
            {
                if (Directory.Exists(dir))
                {
                    this.BeginUpdate();
                    this.Nodes.Clear();
                    this.GetDirectories(parentNode, dir, filter, 0);
                    if (parentNode == null)
                    {
                        parentNode = new CTreeNode();
                        parentNode.GetFiles(dir, filter);
                    }
                    for (int i = this.Nodes.Count - 1; i >= 0; i--)
                    {
                        ((CTreeNode) this.Nodes[i]).RemoveEmptyNode(0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Directory Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.EndUpdate();
            }
        }
        public void GetDirectories(TreeNode parent, string dir, string filter, int level)
        {
            level++;

            if (level < 20)
            {
                try
                {
                    DirectoryInfo di = new DirectoryInfo(dir);

                    foreach (DirectoryInfo diChild in di.GetDirectories())
                    {
                        try
                        {
                            CTreeNode node = new CTreeNode(diChild.Name, 0, 1);
                            node.Tag = "...";
                            if (level > 1)
                            {
                                node.Expand();
                            }
                            if (diChild.GetDirectories().Length > 0)
                            {
                                GetDirectories(node, diChild.FullName, filter, level);
                            }
                            if (diChild.GetFiles().Length > 0)
                            {
                                node.GetFiles(diChild.FullName, filter);
                            }
                            if (parent == null)
                            {
                                this.Nodes.Add(node);
                            }
                            else
                            {
                                parent.Nodes.Add(node);
                            }
                        }
                        catch
                        {
                            // ignore exception
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Directory Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
