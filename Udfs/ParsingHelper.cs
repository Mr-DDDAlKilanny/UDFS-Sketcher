using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sketcher.Udfs.Dom;
using Sketcher.Udfs.Parser;
using Antlr.Runtime;
using Sketcher.Udfs.Lexer;
using System.IO;

namespace Sketcher.Udfs
{
    public class CompilationResult
    {
        private List<Error> errors = new List<Error>();

        public int SyntaxErrorCount { get; private set; }
        public Antlr.Runtime.Tree.CommonTree Tree { get; private set; }
        public CompilationUnit Unit { get; private set; }
        public List<Error> Errors { get { return errors; } }

        public CompilationResult(int erros, Antlr.Runtime.Tree.CommonTree tree, CompilationUnit unit)
        {
            this.SyntaxErrorCount = erros;
            this.Tree = tree;
            this.Unit = unit;
        }
    }

    public class ParsingHelper
    {
        public CompilationResult Parse(string fileName)
        {
            udfsParser parser = new udfsParser(
                new CommonTokenStream(
                    new udfsLexer(
                        new ANTLRFileStream(fileName))));
            var ret = parser.compileUnit();
            if (parser.NumberOfSyntaxErrors > 0)
                return new CompilationResult(parser.NumberOfSyntaxErrors, ret.Tree, null);
            removeWhiteSpaces(ret.Tree);
            List<ConstDecls> d = new List<ConstDecls>();
            List<Function> f = new List<Function>();
            List<GlobalDecls> g = new List<GlobalDecls>();
            try
            {
                foreach (var item in ret.Tree.Children)
                {
                    if (item.Text == "const")
                    {
                        List<Const> c = new List<Const>();
                        for (int i = 0; i < item.ChildCount; i++)
                        {
                            c.Add(new Const(item.GetChild(i).Text,
                                Convert.ToDouble(item.GetChild(i).GetChild(0).Text)));
                        }
                        d.Add(new ConstDecls(c));
                    }
                    else if (item.Text == "global")
                    {
                        List<Identifier> id = new List<Identifier>();
                        for (int i = 0; i < item.ChildCount; i++)
                        {
                            id.Add(new Identifier(item.GetChild(i).Text));
                        }
                        g.Add(new GlobalDecls(id));
                    }
                    else if (item.Text == "function")
                    {
                        var id = item.GetChild(0).Text;
                        List<Identifier> args = new List<Identifier>();
                        for (int j = 0; j < item.GetChild(1).ChildCount; j++)
                            args.Add(new Identifier(item.GetChild(1).GetChild(j).Text));
                        f.Add(new Function(id, args, getBlockStatement(item.GetChild(2))));
                    }
                }
                return new CompilationResult(parser.NumberOfSyntaxErrors, ret.Tree,
                    new CompilationUnit(d, f, g, fileName, DateTime.Today));
            }
            catch (Exception ex)
            {
                var r = new CompilationResult(parser.NumberOfSyntaxErrors + 1, ret.Tree,
                    null);
                r.Errors.Add(new Error(ex.Message));
                return r;
            }
        }

        private static void removeWhiteSpaces(Antlr.Runtime.Tree.ITree tr)
        {
            for (int i = tr.ChildCount - 1; i >= 0; i--)
            {
                if (string.IsNullOrWhiteSpace(tr.GetChild(i).Text))
                    tr.DeleteChild(i);
                else removeWhiteSpaces(tr.GetChild(i));
            }
        }

        public static Udfs.Dom.Expression BuildExpression(Antlr.Runtime.Tree.ITree tr)
        {
            removeWhiteSpaces(tr);
            return expr(tr.GetChild(0));
        }

        private static Udfs.Dom.Expression expr(Antlr.Runtime.Tree.ITree tr)
        {
            return new Udfs.Dom.Expression(atom(tr));
        }

        private static Atom atom(Antlr.Runtime.Tree.ITree tr)
        {
            if (Char.IsDigit(tr.Text[0]))
                return new Atom(AtomType.Number, double.Parse(tr.Text));
            else if (Char.IsLetter(tr.Text[0]))
            {
                if (tr.ChildCount == 0)
                    return new Atom(AtomType.Variable, new Identifier(tr.Text));
                else
                {
                    var list = new List<Udfs.Dom.Expression>();
                    for (int i = 1; i < tr.ChildCount; ++i)
                        list.Add(expr(tr.GetChild(i)));
                    return new Atom(AtomType.Function, new FunctionCall(new Identifier(tr.Text), list));
                }
            }
            else
            {
                OperatorType t;
                switch (tr.Text)
                {
                    case "&":
                        t = OperatorType.And;
                        break;
                    case ":=":
                        t = OperatorType.Assignment;
                        break;
                    case "/":
                        t = OperatorType.Div;
                        break;
                    case "=":
                        t = OperatorType.Equals;
                        break;
                    case ">":
                        t = OperatorType.GreaterThan;
                        break;
                    case ">=":
                        t = OperatorType.GreaterThanOrEquals;
                        break;
                    case "<":
                        t = OperatorType.LessThan;
                        break;
                    case "<=":
                        t = OperatorType.LessThanOrEquals;
                        break;
                    case "-":
                        t = OperatorType.Minus;
                        break;
                    case "%":
                        t = OperatorType.Mod;
                        break;
                    case "*":
                        t = OperatorType.Mul;
                        break;
                    case "!=":
                        t = OperatorType.NotEquals;
                        break;
                    case "|":
                        t = OperatorType.Or;
                        break;
                    case "+":
                        t = OperatorType.Plus;
                        break;
                    case "^":
                        t = OperatorType.Xor;
                        break;
                    default:
                        throw new NotImplementedException();
                }
                return new Atom(AtomType.Operator, new BinaryOperator(t, atom(tr.GetChild(0)), atom(tr.GetChild(1))));
            }
        }

        private Statement stmnt(Antlr.Runtime.Tree.ITree tr)
        {
            if (tr.Text == ":=")
                return new AssignmentStmnt(new Identifier(tr.GetChild(0).Text), expr(tr.GetChild(1)));
            else if (tr.Text == "while")
                return new WhileLoop(expr(tr.GetChild(0)), getBlockStatement(tr.GetChild(1)));
            else if (tr.Text == "if")
                return new IfStmnt(expr(tr.GetChild(0)), getBlockStatement(tr.GetChild(1)),
                    tr.ChildCount > 2 ? new ElseStmnt(getBlockStatement(tr.GetChild(2))) : null);
            else if (tr.Text == "resultis")
                return new Resultis(expr(tr.GetChild(0)));
            else throw new InvalidDataException("Unknown/unexpected statement: " + tr.Text);
        }

        private Statement getBlockStatement(Antlr.Runtime.Tree.ITree tr)
        {
            if (tr.Text != "{")
            {
                if (tr.Text == "else")
                    return getBlockStatement(tr.GetChild(0));
                else return stmnt(tr);
            }
            // -> ^(LBRCT varDeclarations? $i* RBRCT)
            if (tr.ChildCount == 1)
            {
                if (tr.GetChild(0).Text == "}")
                    return new Block(null, new List<Statement>());
                else
                    tr.AddChild(tr.GetChild(0));
            }
            List<Identifier> vv = new List<Identifier>();
            List<Statement> s = new List<Statement>();
            if (tr.GetChild(0).Text == "declvar")
            {
                for (int i = 0; i < tr.GetChild(0).ChildCount; i++)
                    vv.Add(new Identifier(tr.GetChild(0).GetChild(i).Text));
            }
            else s.Add(stmnt(tr.GetChild(0)));
            for (int i = 1; i < tr.ChildCount - 1; i++)
                s.Add(stmnt(tr.GetChild(i)));
            DeclVar v = vv.Count > 0 ? new DeclVar(vv) : null;
            return new Block(v, s);
        }
    }
}
