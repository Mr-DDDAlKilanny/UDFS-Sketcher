using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Dom
{
    public class Const : Identifier
    {
        public double Value { get; private set; }

        public Const(string name, double value)
            : base(name)
        {
            Value = value;
        }
    }
}
