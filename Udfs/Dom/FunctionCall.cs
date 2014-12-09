using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Dom
{
    [Serializable]
    public class FunctionCall
    {
        public Identifier FunctionName { get; private set; }
        public List<Expression> Args { get; private set; }

        public FunctionCall(Identifier name, List<Expression> a)
        {
            this.FunctionName = name;
            this.Args = a;
        }
    }
}
