using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Runtime
{
    internal static class Operator
    {
        private static int compare(double a1, double a2)
        {
            if (Math.Abs(a1 - a2) < double.Epsilon)
                return 0;
            if (a1 - a2 < 0) return -1;
            return 1;
        }

        public static double Execute(Udfs.Dom.Operator op, double arg1, double arg2)
        {
            switch (op.Type)
            {
                case Sketcher.Udfs.Dom.OperatorType.Assignment:
                    throw new InvalidOperationException("Assignment should be executed with variables, not values");
                case Sketcher.Udfs.Dom.OperatorType.Equals:
                    return compare(arg1, arg2) == 0 ? 1 : 0;
                case Sketcher.Udfs.Dom.OperatorType.NotEquals:
                    return compare(arg1, arg2) != 0 ? 1 : 0;
                case Sketcher.Udfs.Dom.OperatorType.GreaterThan:
                    return compare(arg1, arg2) == 1 ? 1 : 0;
                case Sketcher.Udfs.Dom.OperatorType.GreaterThanOrEquals:
                    return compare(arg1, arg2) >= 0 ? 1 : 0;
                case Sketcher.Udfs.Dom.OperatorType.LessThan:
                    return compare(arg1, arg2) == -1 ? 1 : 0;
                case Sketcher.Udfs.Dom.OperatorType.LessThanOrEquals:
                    return compare(arg1, arg2) <= 0 ? 1 : 0;
                case Sketcher.Udfs.Dom.OperatorType.And:
                    return (long)arg1 & (long)arg2;
                case Sketcher.Udfs.Dom.OperatorType.Or:
                    return (long)arg1 | (long)arg2;
                case Sketcher.Udfs.Dom.OperatorType.Xor:
                    return (long)arg1 ^ (long)arg2;
                case Sketcher.Udfs.Dom.OperatorType.Mod:
                    long tmp;
                    Math.DivRem((long)arg1, (long)arg2, out tmp);
                    return tmp;
                case Sketcher.Udfs.Dom.OperatorType.Mul:
                    return arg1 * arg2;
                case Sketcher.Udfs.Dom.OperatorType.Div:
                    return arg1 / arg2;
                case Sketcher.Udfs.Dom.OperatorType.Plus:
                    return arg1 + arg2;
                case Sketcher.Udfs.Dom.OperatorType.Minus:
                    return arg1 - arg2;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
