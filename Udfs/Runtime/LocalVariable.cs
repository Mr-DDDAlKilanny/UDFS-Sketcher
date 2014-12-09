using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Runtime
{
    [Serializable]
    public class LocalVariable : Variable
    {
        public Block Block { get; private set; }

        public override double Value { get; set; }

        public LocalVariable(string name, Block block)
            : base(name)
        {
            this.Block = block;
        }
    }
}
