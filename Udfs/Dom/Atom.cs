using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Dom
{
    [Serializable]
    public enum AtomType
    {
        Number,
        Variable,
        Function,
        Operator
    }

    [Serializable]
    public class Atom
    {
        public AtomType Type { get; private set; }
        public object Value { get; private set; }

        public Atom(AtomType type, object value)
        {
            this.Type = type;
            this.Value = value;
        }
    }
}
