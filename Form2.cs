using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace Udfs
{
    public partial class Form2 : Form
    {
        public Form2(ITree tree)
        {
            InitializeComponent();
            TreeNode node = new TreeNode() { Text = "Src" };
            populate(tree, node);
            treeView1.Nodes.Add(node);
        }

        private void populate(ITree tree, TreeNode node)
        {
            for (int i = 0; i < tree.ChildCount; i++)
            {
                if (!string.IsNullOrWhiteSpace(tree.GetChild(i).Text))
                {
                    var n = new TreeNode() { Text = tree.GetChild(i).Text };
                    populate(tree.GetChild(i), n);
                    node.Nodes.Add(n);
                }
            }
        }
    }
}
