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
using Sketcher.Udfs.Runtime;
using Sketcher.Udfs;
using Sketcher.Udfs.Runtime.Debugging;

namespace Sketcher.Ui
{
    public partial class FormMain : Form
    {
        private TextEditor editor;

        public FormMain()
        {
            InitializeComponent();
            editor = new TextEditor();
            using (XmlTextReader reader = new XmlTextReader("udfs.xshd"))
                editor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
            editor.FontSize = 13;
            elementHost1.Child = editor;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            var list = RuntimeEnvironment.Instance.Update(false);
            if (list.Count > 0)
            {
                StringBuilder b = new StringBuilder("Errors occured while loading udfs objects:").AppendLine();
                foreach (var item in list)
                {
                    b.AppendLine(item.Text).AppendLine();
                }
                MessageBox.Show(this, b.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            RuntimeEnvironment.Instance.Save();
        }

        private void uDFSEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormUdfs frm = new FormUdfs())
            {
                frm.ShowDialog(this);
            }
        }

        private void definedFunctionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormViewDefFuncs frm = new FormViewDefFuncs())
            {
                frm.ShowDialog(this);
            }
        }

        private string compileExpression(out Drawing.Expressions.Expression expr)
        {
            try
            {
                expr = sketcherPictureBox1.ParseExpression(editor.Text.Trim());
                if (expr.Errors.Count > 0)
                {
                    string s = "\n";
                    for (int i = 0; i < expr.Errors.Count; ++i)
                        s += expr.Errors[i].Text + "\n";
                    return string.Format("You have {0} syntax error(s) in the expression." + s, expr.Errors.Count) +
                        "\nPlease provide a valid expression to draw";
                }
                return null;
            }
            catch (Exception ex)
            {
                expr = null;
                return ex.Message;
            }
        }

        private void drawSpecifiedExpressionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Drawing.Expressions.Expression ex;
            var ret = compileExpression(out ex);
            if (ret != null)
                MessageBox.Show(this, ret, "Compilation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                sketcherPictureBox1.Draw(ex);
        }

        private void uDFSDecompilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Choose the compiled UDFS file";
                dlg.Filter = "UDFS Object Files (*.udfsobj)|*.udfsobj|All Files (*.*)|*.*";
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    using (FormUdfs frm = new FormUdfs())
                    {
                        frm.SetText(Decompiler.Decompile(dlg.FileName));
                        frm.ShowDialog(this);
                    }
                }
            }
        }

        private void debugDrawingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Drawing.Expressions.Expression ex;
            var ret = compileExpression(out ex);
            if (ret != null)
                MessageBox.Show(this, ret, "Compilation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                Debugger.DebugExpression(ex);
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "UDFS Sketcher v. 1.0\n\nBy Mr.DDDAlKilanny, April 2014",
                "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
