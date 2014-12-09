using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Dom
{
    public class DeclVar
    {
        public List<Identifier> Vars { get; private set; }

        public DeclVar(List<Identifier> i)
        {
            Vars = i;
        }
    }
}
