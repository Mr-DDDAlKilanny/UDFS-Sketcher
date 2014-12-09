using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Dom
{
    public class Resultis : Statement
    {
        public Expression Expression { get; private set; }

        public Resultis(Expression ex)
        {
            this.Expression = ex;
        }
    }
}
