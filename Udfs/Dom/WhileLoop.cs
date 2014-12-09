using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Dom
{
    public class WhileLoop : Statement
    {
        public Expression Expression { get; private set; }
        public Statement Block { get; private set; }

        public WhileLoop(Expression expr, Statement b)
        {
            this.Block = b;
            this.Expression = expr;
        }
    }
}
