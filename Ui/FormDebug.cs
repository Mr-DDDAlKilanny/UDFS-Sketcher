using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.AvalonEdit;
using System.Xml;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Highlighting;
using Sketcher.Udfs.Runtime.Debugging;
using Sketcher.Udfs.Runtime;

namespace Sketcher.Ui
{
    public partial class FormDebug : Form
    {
        private readonly Debugger dbg;

        private TextEditor editor;
        // we don't need this because actually all expressions within a block share the same ScopeVisibleVariables
        //private Stack<Runtime.Expression> stack = new Stack<Runtime.Expression>();
        private List<Variable> watchList = new List<Variable>();
        private List<Variable> curVisibleVars;

        public FormDebug(Debugger dbg, Function func, string src)
        {
            this.dbg = dbg;
            InitializeComponent();
            editor = new TextEditor();
            using (XmlTextReader reader = new XmlTextReader("udfs.xshd"))
                editor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
            editor.ShowLineNumbers = true;
            editor.FontSize = 16;
            editor.IsReadOnly = true;
            editor.Text = src;
            editor.KeyUp += new System.Windows.Input.KeyEventHandler(editor_KeyUp);
            elementHost1.Child = editor;

            initWatchList(func.Block);
            watchList.Sort((i, j) => i.Name.CompareTo(j.Name));
            for (int i = 0; i < watchList.Count; ++i)
            {
                string ty;
                if (watchList[i] is GlobalVariable)
                    ty = "Global";
                else if (watchList[i] is Constant)
                    ty = "Constant";
                else if (watchList[i] is ArgumentVariable)
                    ty = "Argument";
                else
                    ty = "Local";
                listView1.Items.Add(new ListViewItem(new[] { watchList[i].Name, ty, watchList[i].Value + "" }));
            }
        }

        private void initWatchList(Sketcher.Udfs.Dom.Atom a)
        {
            switch (a.Type)
            {
                case Sketcher.Udfs.Dom.AtomType.Number:
                    break;
                case Sketcher.Udfs.Dom.AtomType.Variable:
                    var v = curVisibleVars.Find(i => i.Name == (a.Value as Sketcher.Udfs.Dom.Identifier).Name);
                    if (!watchList.Contains(v))
                        watchList.Add(v);
                    break;
                case Sketcher.Udfs.Dom.AtomType.Function:
                    var c = a.Value as Sketcher.Udfs.Dom.FunctionCall;
                    foreach (var item in c.Args)
                        initWatchList(item.Base);
                    break;
                case Sketcher.Udfs.Dom.AtomType.Operator:
                    var op = a.Value as Sketcher.Udfs.Dom.BinaryOperator;
                    initWatchList(op.Left);
                    initWatchList(op.Right);
                    break;
                default:
                    break;
            }
        }

        private void initWatchList(Block b)
        {
            curVisibleVars = b.VisibleVariables;
            foreach (var item in b.Statements)
            {
                if (item is WhileLoopStatement)
                {
                    var w = item as WhileLoopStatement;
                    initWatchList(w.Body);
                    curVisibleVars = w.Condition.ScopeVisibleVariables;
                    initWatchList(w.Condition.Dom.Base);
                }
                else if (item is IfStatement)
                {
                    var i = item as IfStatement;
                    initWatchList(i.Body);
                    if (i.ElseBody != null)
                        initWatchList(i.ElseBody);
                    initWatchList(i.Condition.Dom.Base);
                }
                else if (item is ResultisStatement)
                {
                    var r = item as ResultisStatement;
                    initWatchList(r.Expression.Dom.Base);
                }
                else if (item is AssignmentStatement)
                {
                    var a = item as AssignmentStatement;
                    if (!watchList.Contains(a.Left))
                        watchList.Add(a.Left);
                    initWatchList(a.Right.Dom.Base);
                }
            }
        }

        private void updateWatchListUI()
        {
            for (int i = 0; i < watchList.Count; ++i)
            {
                var old = listView1.Items[i].SubItems[2].Text;
                var n = watchList[i].Value + "";
                if (old != n)
                {
                    listView1.Items[i].SubItems[2].ForeColor = Color.Red;
                    listView1.Items[i].SubItems[2].Text = n;
                }
                else listView1.Items[i].SubItems[2].ForeColor = Color.Black;
            }
        }

        void editor_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case System.Windows.Input.Key.F10:
                    stepOverToolStripMenuItem_Click(sender, e);
                    break;
                case System.Windows.Input.Key.F11:
                    stepInToolStripMenuItem_Click(sender, e);
                    break;
                case System.Windows.Input.Key.F12:
                    stepOutToolStripMenuItem_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        public void UpdateStatus(int codeLine)
        {
            updateWatchListUI();
        }

        private void stepOverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbg.StepOver();
        }

        private void stepInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbg.StepIn();
        }

        private void stepOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbg.StepOut();
        }
    }
}
