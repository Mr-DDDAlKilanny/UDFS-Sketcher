using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Dom
{
    public class ElseStmnt
    {
        public Statement Block { get; private set; }

        public ElseStmnt(Statement b)
        {
            Block = b;
        }
    }
}
