using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Runtime
{
    [Serializable]
    public class ArgumentVariable : Variable
    {
        public override double Value { get; set; }
        public Function Function { get; private set; }

        public ArgumentVariable(string name, Function function)
            : base(name)
        {
            this.Function = function;
            this.Object = function.Object;
        }
    }
}
