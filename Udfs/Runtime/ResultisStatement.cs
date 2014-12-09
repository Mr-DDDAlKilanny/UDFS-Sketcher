using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Runtime
{
    [Serializable]
    internal class ResultisStatement : Statement
    {
        public Expression Expression { get; private set; }

        public ResultisStatement(Expression expr)
        {
            this.Expression = expr;
        }

        public override double? Execute()
        {
            return Expression.Execute();
        }
    }
}
