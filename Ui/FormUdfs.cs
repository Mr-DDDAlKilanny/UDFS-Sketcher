using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sketcher.Udfs.Parser;
using Sketcher.Udfs.Lexer;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using System.Xml;
using Antlr.Runtime;
using System.IO;
using ICSharpCode.AvalonEdit.Folding;
using Sketcher.Udfs.Dom;
using ICSharpCode.AvalonEdit.Search;
using Sketcher.Udfs;
using Sketcher.Udfs.Runtime;
using System.Windows.Threading;
using System.Windows.Input;
using ICSharpCode.AvalonEdit.CodeCompletion;
using System.Windows.Controls;
using ICSharpCode.AvalonEdit.Indentation.CSharp;
using AvalonEdit.Sample;

namespace Sketcher.Ui
{
    public partial class FormUdfs : Form
    {
        private bool changed, fileExists, objGenerated;
        private string currentFile = "untitled.udfs";
        private TextEditor editor;
        private FoldingManager foldingManager;
        private AbstractFoldingStrategy foldingStrategy;
        private ParsingHelper helper = new ParsingHelper();
        private SemanticAnalyzer analyzer = new SemanticAnalyzer();
        private ObjectGenerator generator = new ObjectGenerator();
        private CompletionWindow completionWindow;
        private CompilationResult lastCompilationResult;

        public FormUdfs()
        {
            InitializeComponent();
            editor = new TextEditor();
            foldingStrategy = new BraceFoldingStrategy();
            foldingManager = FoldingManager.Install(editor.TextArea);
            using (XmlTextReader reader = new XmlTextReader("udfs.xshd"))
                HighlightingManager.Instance.RegisterHighlighting("Udfs Highlighting", new string[] { ".udfs" },
                    editor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance));
            editor.ShowLineNumbers = true;
            editor.FontSize = 16;

            editor.TextArea.TextEntering += editor_TextArea_TextEntering;
            editor.TextArea.TextEntered += editor_TextArea_TextEntered;
            DispatcherTimer foldingUpdateTimer = new DispatcherTimer();
            foldingUpdateTimer.Interval = TimeSpan.FromSeconds(2);
            foldingUpdateTimer.Tick += foldingUpdateTimer_Tick;
            foldingUpdateTimer.Start();

            editor.TextChanged += new EventHandler(editor_TextChanged);
            elementHost1.Child = editor;
            SetText(@"const MyConst :=     13051992

function helloworld()
{
    declvar a, b, c
    a := 1
    b := 2
    c := a + b
    resultis c
}
");
        }

        public void SetText(string text)
        {
            editor.Text = text;
            foldingStrategy.UpdateFoldings(foldingManager, editor.Document);
            updateUI();
        }

        void editor_TextArea_TextEntered(object sender, TextCompositionEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.Text))
            {
                // open code completion after the user has pressed dot:
                completionWindow = new CompletionWindow(editor.TextArea);
                // provide AvalonEdit with the data:
                IList<ICompletionData> data = completionWindow.CompletionList.CompletionData;
                data.Add(new UdfsCompletionData("Item1"));
                data.Add(new UdfsCompletionData("Item2"));
                data.Add(new UdfsCompletionData("Item3"));
                data.Add(new UdfsCompletionData("Another item"));
                completionWindow.Show();
                completionWindow.Closed += delegate
                {
                    completionWindow = null;
                };
            }
        }

        void editor_TextArea_TextEntering(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length > 0 && completionWindow != null)
            {
                if (!char.IsLetterOrDigit(e.Text[0]))
                {
                    // Whenever a non-letter is typed while the completion window is open,
                    // insert the currently selected element.
                    completionWindow.CompletionList.RequestInsertion(e);
                }
            }
            // do not set e.Handled=true - we still want to insert the character that was typed
        }

        void HighlightingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            editor.TextArea.IndentationStrategy = new CSharpIndentationStrategy(editor.Options);
            foldingStrategy = new BraceFoldingStrategy();
            if (foldingManager == null)
                foldingManager = FoldingManager.Install(editor.TextArea);
            foldingStrategy.UpdateFoldings(foldingManager, editor.Document);
        }

        void foldingUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (foldingStrategy != null)
            {
                foldingStrategy.UpdateFoldings(foldingManager, editor.Document);
            }
        }
        
        void editor_TextChanged(object sender, EventArgs e)
        {
            changed = true;
        }

        private void updateUI()
        {
            Text = "UDFS Editor - " + Path.GetFileName(currentFile) 
                + (changed ? "*" : "");
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (changed && MessageBox.Show(this, "You didn't save the changes. Are you sure you want to create a new file?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Cancel)
                return;
            editor.Text = "";
            currentFile = "untitled.udfs";
            changed = false;
            fileExists = false;
            updateUI();
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            if (changed && MessageBox.Show(this, "You didn't save the changes. Are you sure you want to create a new file?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Cancel)
                return;
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Choose UDFS file to open";
                dlg.Filter = "UDFS Files (*.udfs)|*.udfs|All Files (*.*)|*.*";
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    currentFile = dlg.FileName;
                    editor.Text = File.ReadAllText(dlg.FileName);
                    foldingStrategy.UpdateFoldings(foldingManager, editor.Document);
                    changed = false;
                    fileExists = true;
                    updateUI();
                }
            }
        }

        private bool save()
        {
            if (!fileExists)
            {
                using (SaveFileDialog dlg = new SaveFileDialog())
                {
                    dlg.Title = "Save UDFS file";
                    dlg.Filter = "UDFS Files (*.udfs)|*.udfs|All Files (*.*)|*.*";
                    dlg.FileName = currentFile;
                    if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        File.WriteAllText(dlg.FileName, editor.Text);
                        currentFile = dlg.FileName;
                        fileExists = true;
                        changed = false;
                        updateUI();
                        return true;
                    }
                }
                return false;
            }
            else
            {
                File.WriteAllText(currentFile, editor.Text);
                changed = false;
                updateUI();
                return true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Title = "Save UDFS file";
                dlg.Filter = "UDFS Files (*.udfs)|*.udfs|All Files (*.*)|*.*";
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    File.WriteAllText(dlg.FileName, editor.Text);
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (changed)
            {
                var res = MessageBox.Show(this, "You didn't save the changes. Do you want to save changes before close?",
                   "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!save())
                        e.Cancel = true;
                }
                else if (res == System.Windows.Forms.DialogResult.Cancel)
                    e.Cancel = true;
            }
            base.OnClosing(e);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.SelectAll();
        }

        private void quickFindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchPanel p = SearchPanel.Install(editor);
            p.FindName("Hello");
            p.FindNext();
            return;
            System.Windows.Window wnd = new System.Windows.Window();
            wnd.Content = p;
            wnd.Show();
        }

        private void quickReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void formatDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in foldingManager.AllFoldings)
                item.IsFolded = true;
        }

        private void uncollapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in foldingManager.AllFoldings)
                item.IsFolded = false;
        }

        private void commentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sel = editor.TextArea.Selection;
            int start = sel.StartPosition.Line;
            int end = sel.EndPosition.Line;
            while (start <= end)
            {
                var line = editor.TextArea.TextView.GetVisualLine(start).TextLines[0];
                // TODO: comment lines
                ++end;
            }
        }

        private void uncommentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void compileCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objGenerated = false;
            lastCompilationResult = null;
            if (!save()) return;
            var res = lastCompilationResult = helper.Parse(currentFile);
            if (res.SyntaxErrorCount > 0)
            {
                string all = "";
                foreach (var item in res.Errors)
                    all += item.Text + ", ";
                all += '\n';
                MessageBox.Show(this, all + res.Tree.ToStringTree(), res.SyntaxErrorCount + " Syntax Error(s)",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var list = analyzer.Analyze(res, RuntimeEnvironment.Instance.Functions,
                    RuntimeEnvironment.Instance.GlobalVariables, RuntimeEnvironment.Instance.Constants);
                var warnings = list.FindAll(i => i is Warning);
                var errors = list.FindAll(i => i is Error);
                var infos = list.FindAll(i => i is Info);
                if (errors.Count > 0)
                {
                    StringBuilder b = new StringBuilder();
                    for (int i = 0; i < errors.Count; ++i)
                        b.AppendLine(errors[i].Text).AppendLine();
                    MessageBox.Show(this, b.ToString(), "Compilation Error(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (warnings.Count > 0)
                {
                    StringBuilder b = new StringBuilder();
                    for (int i = 0; i < warnings.Count; ++i)
                        b.AppendLine(warnings[i].Text).AppendLine();
                    MessageBox.Show(this, b.ToString(), "Compilation Warning(s)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (infos.Count > 0)
                {
                    StringBuilder b = new StringBuilder();
                    for (int i = 0; i < infos.Count; ++i)
                        b.AppendLine(infos[i].Text).AppendLine();
                    MessageBox.Show(this, b.ToString(), "Compilation Info(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (errors.Count == 0)
                {
                    generator.Generate(res);
                    warnings = generator.GenerationMessages.FindAll(i => i is Warning);
                    errors = generator.GenerationMessages.FindAll(i => i is Error);
                    if (errors.Count == 0)
                    {
                        objGenerated = true;
                        var gen = generator.Generated;
                        gen.Write();
                        foreach (var f in gen.Functions)
                        {
                            var replace = RuntimeEnvironment.Instance.Functions.Find(i => i.Name == f.Name);
                            if (replace != null) RuntimeEnvironment.Instance.Functions.Remove(replace);
                            RuntimeEnvironment.Instance.Functions.Add(f);
                        }
                        foreach (var c in gen.Constants)
                        {
                            RuntimeEnvironment.Instance.Constants.Add(c);
                        }
                        foreach (var g in gen.Globals)
                        {
                            RuntimeEnvironment.Instance.GlobalVariables.Add(g);
                        }
                        if (warnings.Count > 0)
                        {
                            StringBuilder b = new StringBuilder();
                            for (int i = 0; i < warnings.Count; ++i)
                                b.AppendLine(warnings[i].Text).AppendLine();
                            MessageBox.Show(this, b.ToString(), "Compilation Warning(s)",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            MessageBox.Show(this, "Code compiled without warnings\\errors.\nObject file has been created into '"
                                + gen.FileName + "'",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        StringBuilder b = new StringBuilder();
                        for (int i = 0; i < errors.Count; ++i)
                            b.AppendLine(errors[i].Text).AppendLine();
                        MessageBox.Show(this, b.ToString(), "Compilation Error(s)",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void viewTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (changed || !objGenerated)
            {
                MessageBox.Show(this, "The code must compile successfully first!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (FormViewAST ast = new FormViewAST(lastCompilationResult, generator.Generated))
                ast.ShowDialog(this);
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show line numbers, tab size, ...
        }
    }
}
