using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Dom
{
    public class GlobalDecls
    {
        public List<Identifier> Globals { get; private set; }

        public GlobalDecls(List<Identifier> i)
        {
            Globals = i;
        }
    }
}
