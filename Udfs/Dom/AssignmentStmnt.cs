using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Dom
{
    public class AssignmentStmnt : Statement
    {
        public Identifier Left { get; private set; }
        public Expression Right { get; private set; }

        public AssignmentStmnt(Identifier left, Expression right)
        {
            Left = left;
            Right = right;
        }
    }
}
