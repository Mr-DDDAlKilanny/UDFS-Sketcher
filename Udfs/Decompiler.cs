using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sketcher.Udfs.Runtime;

namespace Sketcher.Udfs
{
    public static class Decompiler
    {
        public static string Decompile(string fileName)
        {
            return Decompile(UdfsObject.Read(fileName));
        }

        public static string Decompile(UdfsObject obj)
        {
            StringBuilder b = new StringBuilder();
            if (obj.Constants.Count > 0)
            {
                b.Append("const " + obj.Constants[0].Name + " := " + obj.Constants[0].Value);
                for (int i = 1; i < obj.Constants.Count; ++i)
                    b.Append(",\t" + obj.Constants[i].Name + " := " + obj.Constants[i].Value);
                b.AppendLine().AppendLine();
            }
            if (obj.Globals.Count > 0)
            {
                b.Append("global " + obj.Globals[0].Name);
                for (int i = 1; i < obj.Globals.Count; ++i)
                    b.Append(",\t" + obj.Globals[i].Name);
                b.AppendLine().AppendLine();
            }
            if (obj.Functions.Count > 0)
            {
                foreach (var item in obj.Functions)
                    b.AppendLine(Decompile(item)).AppendLine();
            }
            return b.ToString();
        }

        public static string Decompile(Function function)
        {
            StringBuilder b = new StringBuilder();
            string header = "function " + function.Name + "(";
            if (function.Args.Count > 0)
            {
                header += function.Args[0].Name;
                for (int i = 1; i < function.Args.Count; ++i)
                    header += ", " + function.Args[i].Name;
            }
            header += ")";
            if (function.IsBuiltIn)
            {
                b.AppendLine("!! native " + header);
                b.AppendLine("!! [Cannot view source code for a native built-in function]");
            }
            else
            {
                b.AppendLine(header);
                List<string> tmp = new List<string>();
                appendBlock(tmp, getBlock(function.Block));
                foreach (var s in tmp)
                    b.AppendLine(s);
            }
            return b.ToString();
        }

        private static string getExpr(Dom.Atom a)
        {
            switch (a.Type)
            {
                case Sketcher.Udfs.Dom.AtomType.Number:
                    return (double)a.Value + "";
                case Sketcher.Udfs.Dom.AtomType.Variable:
                    return (a.Value as Dom.Identifier).Name;
                case Sketcher.Udfs.Dom.AtomType.Function:
                    var r = a.Value as Dom.FunctionCall;
                    string ret = r.FunctionName.Name + "(";
                    if (r.Args.Count > 0)
                    {
                        ret += getExpr(r.Args[0].Base);
                        for (int i = 1; i < r.Args.Count; ++i)
                            ret += ", " + getExpr(r.Args[i].Base);
                    }
                    return ret + ")";
                case Sketcher.Udfs.Dom.AtomType.Operator:
                    var op = a.Value as Dom.BinaryOperator;
                    return getExpr(op.Left) + " " + GetOperator(op.Type) + " " + getExpr(op.Right);
                default:
                    throw new NotImplementedException();
            }
        }

        public static string GetOperator(Dom.OperatorType ty)
        {
            switch (ty)
            {
                case Sketcher.Udfs.Dom.OperatorType.Assignment:
                    return ":=";
                case Sketcher.Udfs.Dom.OperatorType.Equals:
                    return "=";
                case Sketcher.Udfs.Dom.OperatorType.NotEquals:
                    return "!=";
                case Sketcher.Udfs.Dom.OperatorType.GreaterThan:
                    return ">";
                case Sketcher.Udfs.Dom.OperatorType.GreaterThanOrEquals:
                    return ">=";
                case Sketcher.Udfs.Dom.OperatorType.LessThan:
                    return "<";
                case Sketcher.Udfs.Dom.OperatorType.LessThanOrEquals:
                    return "<=";
                case Sketcher.Udfs.Dom.OperatorType.And:
                    return "&";
                case Sketcher.Udfs.Dom.OperatorType.Or:
                    return "|";
                case Sketcher.Udfs.Dom.OperatorType.Xor:
                    return "^";
                case Sketcher.Udfs.Dom.OperatorType.Mod:
                    return "%";
                case Sketcher.Udfs.Dom.OperatorType.Mul:
                    return "*";
                case Sketcher.Udfs.Dom.OperatorType.Div:
                    return "/";
                case Sketcher.Udfs.Dom.OperatorType.Plus:
                    return "+";
                case Sketcher.Udfs.Dom.OperatorType.Minus:
                    return "-";
                default:
                    throw new NotImplementedException();
            }
        }

        private static void appendBlock(List<string> all, List<string> body)
        {
            all.Add(body[0]);
            for (int i = 1; i < body.Count - 1; i++)
                all.Add("\t" + body[i]);
            all.Add(body[body.Count - 1]);
        }

        private static List<string> getBlock(Block b)
        {
            List<string> ret = new List<string>();
            ret.Add("{");
            if (b.LocalVariables.Count > 0)
            {
                string s = "declvar " + b.LocalVariables[0].Name;
                for (int i = 1; i < b.LocalVariables.Count; ++i)
                    s += ", " + b.LocalVariables[i].Name;
                ret.Add(s);
            }
            foreach (var item in b.Statements)
            {
                if (item is Runtime.AssignmentStatement)
                {
                    Runtime.AssignmentStatement a = item as Runtime.AssignmentStatement;
                    ret.Add(a.Left.Name + " := " + getExpr(a.Right.Dom.Base));
                }
                else if (item is Runtime.IfStatement)
                {
                    Runtime.IfStatement i = item as Runtime.IfStatement;
                    ret.Add("if " + getExpr(i.Condition.Dom.Base));
                    appendBlock(ret, getBlock(i.Body));
                    if (i.ElseBody != null)
                    {
                        ret.Add("else");
                        appendBlock(ret, getBlock(i.ElseBody));
                    }
                }
                else if (item is WhileLoopStatement)
                {
                    Runtime.WhileLoopStatement w = item as Runtime.WhileLoopStatement;
                    ret.Add("while " + getExpr(w.Condition.Dom.Base));
                    appendBlock(ret, getBlock(w.Body));
                }
                else if (item is Runtime.ResultisStatement)
                {
                    ret.Add("resultis " + getExpr((item as Runtime.ResultisStatement).Expression.Dom.Base));
                }
            }
            ret.Add("}");
            return ret;
        }
    }
}
