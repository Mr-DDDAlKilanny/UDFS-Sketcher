using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Dom
{
    public class ConstDecls
    {
        public List<Const> Consts { get; private set; }

        public ConstDecls(List<Const> c)
        {
            this.Consts = c;
        }
    }
}
