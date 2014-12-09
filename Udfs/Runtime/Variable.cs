using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Runtime
{
    [Serializable]
    public abstract class Variable : RuntimeElement
    {
        public abstract double Value { get; set; }

        public Variable(string name)
            : base(name)
        {
        }
    }
}
