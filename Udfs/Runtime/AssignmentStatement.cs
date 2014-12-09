using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Runtime
{
    [Serializable]
    internal class AssignmentStatement : Statement
    {
        public Variable Left { get; private set; }
        public Expression Right { get; private set; }

        public AssignmentStatement(Variable left, Expression right)
        {
            this.Left = left;
            this.Right = right;
        }

        public override double? Execute()
        {
            return Left.Value = (double)Right.Execute();
        }
    }
}
