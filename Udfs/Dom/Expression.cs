using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Dom
{
    [Serializable]
    public class Expression
    {
        public Atom Base { get; private set; }

        public Expression(Atom a)
        {
            Base = a;
        }
    }
}
