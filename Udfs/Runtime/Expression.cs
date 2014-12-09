using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Runtime
{
    [Serializable]
    internal class Expression : Statement
    {
        public Dom.Expression Dom { get; private set; }
        public double Result { get; private set; }
        public bool BooleanResult { get { return Math.Abs(Result) > double.Epsilon; } }
        public List<Variable> ScopeVisibleVariables { get; private set; }

        public Expression(Dom.Expression expr, List<Variable> scopeVisibleVariables)
        {
            this.Dom = expr;
            this.ScopeVisibleVariables = scopeVisibleVariables;
        }

        public override double? Execute()
        {
            return Result = execute(Dom.Base);
        }

        private double execute(Sketcher.Udfs.Dom.Atom a)
        {
            switch (a.Type)
            {
                case Sketcher.Udfs.Dom.AtomType.Number:
                    return (double)a.Value;
                case Sketcher.Udfs.Dom.AtomType.Variable:
                    return ScopeVisibleVariables.Find(i => i.Name == (a.Value as Dom.Identifier).Name).Value;
                case Sketcher.Udfs.Dom.AtomType.Function:
                    var f = a.Value as Udfs.Dom.FunctionCall;
                    var args = new double[f.Args.Count];
                    for (int i = 0; i < args.Length; ++i)
                        args[i] = new Expression(f.Args[i], ScopeVisibleVariables).execute(f.Args[i].Base);
                    return RuntimeEnvironment.Instance.Functions
                        .Find(i => i.Name == f.FunctionName.Name).Execute(args);
                case Sketcher.Udfs.Dom.AtomType.Operator:
                    Udfs.Dom.BinaryOperator op = a.Value as Udfs.Dom.BinaryOperator;
                    if (op.Type != Udfs.Dom.OperatorType.Assignment)
                        return Operator.Execute(op, execute(op.Left), execute(op.Right));
                    else // internal assignment (within the expression, not a statement)
                        return ScopeVisibleVariables.Find(i => i.Name == op.Left.Value as string)
                            .Value = execute(op.Right);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
