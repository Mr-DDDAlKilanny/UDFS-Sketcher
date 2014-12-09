using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sketcher.Udfs;
using Sketcher.Udfs.Runtime;

namespace Sketcher.Ui
{
    public partial class FormViewAST : Form
    {
        private CompilationResult result;
        private UdfsObject generated;

        public FormViewAST(CompilationResult res, UdfsObject obj)
        {
            this.result = res;
            this.generated = obj;
            InitializeComponent();
            var con = treeView1.Nodes.Add("Constants");
            foreach (var item in obj.Constants)
                con.Nodes.Add(item.Name + " := " + item.Value);
            var glob = treeView1.Nodes.Add("Global Variables");
            foreach (var item in obj.Globals)
                glob.Nodes.Add(item.Name);
            var funcs = treeView1.Nodes.Add("Functions");
            foreach (var item in obj.Functions)
            {
                string tmp = item.Name + "(";
                if (item.Args.Count > 0)
                {
                    tmp += item.Args[0].Name;
                    for (int i = 1; i < item.Args.Count; ++i)
                        tmp += ", " + item.Args[i].Name;
                }
                tmp += ")";
                block(funcs.Nodes.Add(tmp), item.Block);
            }
        }

        private void expr(TreeNode node, Udfs.Dom.Atom a)
        {
            switch (a.Type)
            {
                case Sketcher.Udfs.Dom.AtomType.Number:
                    node.Nodes.Add((double)a.Value + "");
                    break;
                case Sketcher.Udfs.Dom.AtomType.Variable:
                    node.Nodes.Add((a.Value as Udfs.Dom.Identifier).Name);
                    break;
                case Sketcher.Udfs.Dom.AtomType.Function:
                    var r = a.Value as Udfs.Dom.FunctionCall;
                    var f = node.Nodes.Add(r.FunctionName.Name);
                    for (int i = 0; i < r.Args.Count; ++i)
                        expr(f, r.Args[i].Base);
                    break;
                case Sketcher.Udfs.Dom.AtomType.Operator:
                    var op = a.Value as Udfs.Dom.BinaryOperator;
                    var o = node.Nodes.Add(Decompiler.GetOperator(op.Type));
                    expr(o, op.Left);
                    expr(o, op.Right);
                    break;
                default:
                    break;
            }
        }

        private void block(TreeNode node, Block b)
        {
            if (b.LocalVariables.Count > 0)
            {
                var tmp = node.Nodes.Add("declvar");
                foreach (var item in b.LocalVariables)
                    tmp.Nodes.Add(item.Name);
            }
            foreach (var item in b.Statements)
            {
                if (item is IfStatement)
                {
                    var tmp = node.Nodes.Add("if");
                    var i = item as IfStatement;
                    var condition = tmp.Nodes.Add("condition");
                    expr(condition, i.Condition.Dom.Base);
                    var bl = tmp.Nodes.Add("block");
                    block(bl, i.Body);
                    if (i.ElseBody != null)
                    {
                        var @else = tmp.Nodes.Add("else");
                        block(@else, i.ElseBody);
                    }
                }
                else if (item is WhileLoopStatement)
                {
                    var tmp = node.Nodes.Add("while");
                    var condition = tmp.Nodes.Add("condition");
                    var bl = tmp.Nodes.Add("block");
                    var i = item as WhileLoopStatement;
                    expr(condition, i.Condition.Dom.Base);
                    block(bl, i.Body);
                }
                else if (item is AssignmentStatement)
                {
                    var tmp = node.Nodes.Add(":=");
                    var i = item as AssignmentStatement;
                    tmp.Nodes.Add(i.Left.Name);
                    expr(tmp, i.Right.Dom.Base);
                }
                else if (item is ResultisStatement)
                    expr(node.Nodes.Add("resultis"), (item as ResultisStatement).Expression.Dom.Base);
                else throw new NotImplementedException();
            }
        }

        private void copyASTToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Copy syntax tree to clipboard?",
                "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == System.Windows.Forms.DialogResult.Yes)
                Clipboard.SetText(result.Tree.ToStringTree());
        }
    }
}
