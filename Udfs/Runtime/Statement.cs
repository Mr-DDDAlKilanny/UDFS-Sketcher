using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Runtime
{
    [Serializable]
    public abstract class Statement
    {
        public abstract double? Execute();
    }
}
