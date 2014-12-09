using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sketcher.Ui;

namespace Sketcher.Udfs.Runtime.Debugging
{
    public class Debugger
    {
        private readonly Function function;
        private readonly string sourceCode;
        private readonly int codeLineCount;

        private FormDebug myForm;
        private List<Statement>.Enumerator iterator;
        private Dictionary<Statement, int> lineNumbers = new Dictionary<Statement, int>();

        public Statement CurrentStatement { get { return iterator.Current; } }
        public int CurrentLineNumberInSourceCode { get; private set; }

        public Debugger(Runtime.Function function)
        {
            this.function = function;
            sourceCode = Decompiler.Decompile(function);
        }

        public static void DebugExpression(Drawing.Expressions.Expression expr)
        {
            
        }

        public void Start(List<Runtime.ArgumentVariable> args, IWin32Window wnd)
        {
            CurrentLineNumberInSourceCode = 1;
            using (FormDebug dbg = new FormDebug(this, function, sourceCode))
            {
                myForm = dbg;
                dbg.ShowDialog(wnd);
            }
        }

        public void StepIn()
        {
            if (CurrentStatement is Runtime.ResultisStatement)
            {
                myForm.UpdateStatus(codeLineCount);
            }
        }

        public void StepOut()
        {

        }

        public void StepOver()
        {

        }

        public void Stop()
        {

        }
    }
}
