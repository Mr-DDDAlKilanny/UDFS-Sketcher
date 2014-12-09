using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Dom
{
    public class Block : Statement
    {
        public DeclVar DeclVar { get; private set; }
        public List<Statement> Statements { get; private set; }

        public Block(DeclVar v, List<Statement> s)
        {
            this.DeclVar = v;
            this.Statements = s;
        }
    }
}
