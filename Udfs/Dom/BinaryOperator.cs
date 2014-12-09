using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Dom
{
    [Serializable]
    public class BinaryOperator : Operator
    {
        public Atom Left { get; private set; }
        public Atom Right { get; private set; }

        public BinaryOperator(OperatorType type, Atom left, Atom right)
            : base(type)
        {
            Left = left;
            Right = right;
        }
    }
}
