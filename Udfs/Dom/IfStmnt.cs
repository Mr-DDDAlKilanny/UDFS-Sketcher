using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Dom
{
    public class IfStmnt : Statement
    {
        public Expression Expression { get; private set; }
        public Statement Block { get; private set; }
        public ElseStmnt ElseStmnt { get; private set; }

        public IfStmnt(Expression expr, Statement b, ElseStmnt elseSmnt)
        {
            this.Block = b;
            this.Expression = expr;
            this.ElseStmnt = elseSmnt;
        }
    }
}
