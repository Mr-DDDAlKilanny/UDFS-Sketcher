using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sketcher.Udfs;
using Sketcher.Udfs.Runtime;

namespace Sketcher.Drawing.Expressions
{
    public class Expression
    {
        private List<Error> msgs;

        public List<Error> Errors { get { return msgs; } }
        public Udfs.Dom.Expression Dom { get; private set; }

        public Expression(Udfs.Dom.Expression expr)
        {
            this.Dom = expr;
            msgs = new List<Error>();
            checkExpr(expr.Base);
        }

        public Expression(int errors)
        {
            //TODO: Fix this
            msgs = new List<Error>();
            for (int i = 0; i < errors; ++i)
                msgs.Add(new Error(""));
        }

        private void checkExpr(Udfs.Dom.Atom ex)
        {
            switch (ex.Type)
            {
                case Sketcher.Udfs.Dom.AtomType.Number:
                    break;
                case Sketcher.Udfs.Dom.AtomType.Variable:
                    string s = (ex.Value as Udfs.Dom.Identifier).Name;
                    if (Udfs.Runtime.RuntimeEnvironment.Instance.GlobalVariables
                        .Find(i => i.Name == s) == null
                        && Udfs.Runtime.RuntimeEnvironment.Instance.Constants
                        .Find(i => i.Name == s) == null)
                        msgs.Add(new Error(string.Format("Could not find a declaration for variable\\const '{0}'", s)));
                    break;
                case Sketcher.Udfs.Dom.AtomType.Function:
                    var r = ex.Value as Udfs.Dom.FunctionCall;
                    if (Udfs.Runtime.RuntimeEnvironment.Instance.Functions
                        .Find(i => (i.Name == r.FunctionName.Name && i.Args.Count == r.Args.Count)) == null)
                        msgs.Add(new Error(string.Format(
                            "Could not find a function with name '{0}' taking {1} arguments",
                            r.FunctionName.Name, r.Args.Count)));
                    foreach (var item in r.Args)
                        checkExpr(item.Base);
                    break;
                case Sketcher.Udfs.Dom.AtomType.Operator:
                    var op = ex.Value as Udfs.Dom.BinaryOperator;
                    checkExpr(op.Left);
                    checkExpr(op.Right);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public double Execute()
        {
            if (Errors.Count > 0)
                throw new InvalidOperationException();
            return execute(Dom.Base);
        }

        private double execute(Sketcher.Udfs.Dom.Atom a)
        {
            switch (a.Type)
            {
                case Sketcher.Udfs.Dom.AtomType.Number:
                    return (double)a.Value;
                case Sketcher.Udfs.Dom.AtomType.Variable:
                    return RuntimeEnvironment.Instance.GlobalVariables
                        .Find(i => i.Name == (a.Value as Udfs.Dom.Identifier).Name).Value;
                case Sketcher.Udfs.Dom.AtomType.Function:
                    var f = a.Value as Udfs.Dom.FunctionCall;
                    var args = new double[f.Args.Count];
                    for (int i = 0; i < args.Length; ++i)
                        args[i] = execute(f.Args[i].Base);
                    return RuntimeEnvironment.Instance.Functions
                        .Find(i => i.Name == f.FunctionName.Name).Execute(args);
                case Sketcher.Udfs.Dom.AtomType.Operator:
                    Udfs.Dom.BinaryOperator op = a.Value as Udfs.Dom.BinaryOperator;
                    return Operator.Execute(op, execute(op.Left), execute(op.Right));
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
