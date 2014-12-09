using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Dom
{
    [Serializable]
    public enum OperatorType
    {
        Assignment,
        Equals,
        NotEquals,
        GreaterThan,
        GreaterThanOrEquals,
        LessThan,
        LessThanOrEquals,
        And,
        Or,
        Xor,
        Mod,
        Mul,
        Div,
        Plus,
        Minus
    }
    
    [Serializable]
    public abstract class Operator
    {
        public OperatorType Type { get; private set; }

        public Operator(OperatorType type)
        {
            Type = type;
        }
    }
}
