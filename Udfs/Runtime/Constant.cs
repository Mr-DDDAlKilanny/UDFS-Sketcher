using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Runtime
{
    [Serializable]
    public class Constant : Variable
    {
        private double value;

        public override double Value { get { return value; } set { throw new InvalidOperationException(); } }

        public Constant(string name, double value)
            : base(name)
        {
            this.value = value;
        }
    }
}
