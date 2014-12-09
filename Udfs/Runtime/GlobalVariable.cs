using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Runtime
{
    [Serializable]
    public class GlobalVariable : Variable
    {
        public override double Value { get; set; }

        public GlobalVariable(string name)
            : base(name)
        {
        }
    }
}
