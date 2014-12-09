using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Dom
{
    public class Function : Identifier
    {
        public List<Identifier> Args { get; private set; }
        public Statement Block { get; private set; }

        public Function(string name, List<Identifier> i, Statement b)
            : base(name)
        {
            this.Args = i;
            this.Block = b;
        }
    }
}
