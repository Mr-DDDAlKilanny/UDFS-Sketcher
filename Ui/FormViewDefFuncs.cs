using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sketcher.Udfs;

namespace Sketcher.Ui
{
    public partial class FormViewDefFuncs : Form
    {
        public FormViewDefFuncs()
        {
            InitializeComponent();
            foreach (var item in Udfs.Runtime.RuntimeEnvironment.Instance.Functions)
            {
                string tmp = item.Name + "(";
                if (item.Args.Count > 0)
                {
                    tmp += item.Args[0].Name;
                    for (int i = 1; i < item.Args.Count; ++i)
                        tmp += ", " + item.Args[i].Name;
                }
                tmp += ")";
                listView1.Items.Add(new ListViewItem(new[] { tmp, item.Object.SourceFileName, item.Object.FileName }, 
                    listView1.Groups[0]));
            }

            foreach (var item in Udfs.Runtime.RuntimeEnvironment.Instance.Constants)
            {
                string tmp = item.Name;
                listView1.Items.Add(new ListViewItem(new[] { tmp, item.Object.SourceFileName, item.Object.FileName },
                    listView1.Groups[1]));
            }

            foreach (var item in Udfs.Runtime.RuntimeEnvironment.Instance.GlobalVariables)
            {
                string tmp = item.Name;
                listView1.Items.Add(new ListViewItem(new[] { tmp, item.Object.SourceFileName, item.Object.FileName },
                    listView1.Groups[2]));
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                var item = listView1.Items[listView1.SelectedIndices[0]];
                var s = item.Group.Header;
                s = s.Substring(0, s.Length - 1);
                MessageBox.Show(this,
                    "Source File Name: '" + item.SubItems[1].Text
                    + "'\nObject File Name: '" + item.SubItems[2].Text + "'",
                    s + ": " + item.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void displayInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1_DoubleClick(sender, e);
        }

        private void decompileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                var item = listView1.Items[listView1.SelectedIndices[0]];
                if (item.Group.Header != "Functions")
                    MessageBox.Show(this, "Only functions can be decompiled",
                        "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    using (FormUdfs frm = new FormUdfs())
                    {
                        frm.SetText(Decompiler.Decompile(Udfs.Runtime.RuntimeEnvironment.Instance.Functions
                        .Find(f => f.Name == item.Text.Substring(0, item.Text.IndexOf('(')))));
                        frm.ShowDialog(this);
                    }
                }
            }
        }
    }
}
