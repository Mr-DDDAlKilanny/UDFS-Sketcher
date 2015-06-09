using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sketcher.Udfs
{
    internal static class UdfsToCSharpHelper
    {
        private static readonly string ClassName = "UserFunctions";

        public static CodeCompileUnit Get(IEnumerable<UdfsObject> objs)
        {
            var res = new CodeCompileUnit();
            var name = new CodeNamespace();
            res.Namespaces.Add(name);
            var cls = new CodeTypeDeclaration(ClassName);
            cls.IsClass = true;
            cls.TypeAttributes = TypeAttributes.Public | TypeAttributes.Sealed;
            cls.Members.Add(new CodeConstructor() { Attributes = MemberAttributes.Private });
            name.Types.Add(cls);
            foreach (var obj in objs)
            {
                foreach (var item in obj.Constants)
                {
                    cls.Members.Add(new CodeMemberField()
                    {
                        Name = item.Name,
                        Type = new CodeTypeReference(typeof(double)),
                        InitExpression = new CodePrimitiveExpression(item.Value),
                        Attributes = MemberAttributes.Public | MemberAttributes.Const
                    });
                }
                foreach (var item in obj.Globals)
                {
                    cls.Members.Add(new CodeMemberField()
                    {
                        Name = item.Name,
                        Type = new CodeTypeReference(typeof(double)),
                        InitExpression = new CodePrimitiveExpression(item.Value),
                        Attributes = MemberAttributes.Public | MemberAttributes.Static
                    });
                }
                foreach (var item in obj.Functions)
                {
                    CodeMemberMethod method = new CodeMemberMethod();
                    method.Name = item.Name;
                    foreach (var arg in item.Args)
                    {
                        method.Parameters.Add(new CodeParameterDeclarationExpression(typeof(double), arg.Name));
                    }
                    method.ReturnType = new CodeTypeReference(typeof(double));
                    method.Attributes = MemberAttributes.Public | MemberAttributes.Final | MemberAttributes.Static;
                    method.Statements.AddRange(get(item.Block).ToArray());
                    cls.Members.Add(method);
                }
            }
            return res;
        }

        private static IEnumerable<CodeStatement> get(Runtime.Block b)
        {
            List<CodeStatement> stmnt = new List<CodeStatement>();
            foreach (var item in b.LocalVariables)
            {
                stmnt.Add(new CodeVariableDeclarationStatement(typeof(double), item.Name, new CodePrimitiveExpression(item.Value)));
            }
            foreach (var item in b.Statements)
            {
                if (item is Runtime.IfStatement)
                {
                    var p = item as Runtime.IfStatement;
                    CodeConditionStatement st;
                    stmnt.Add(st = new CodeConditionStatement(get(p.Condition.Dom.Base), get(p.Body).ToArray()));
                    if (p.ElseBody != null)
                        st.FalseStatements.AddRange(get(p.ElseBody).ToArray());
                }
                else if (item is Runtime.WhileLoopStatement)
                {
                    var p = item as Runtime.WhileLoopStatement;
                    stmnt.Add(new CodeIterationStatement(new CodeCommentStatement(),
                        get(p.Condition.Dom.Base),
                        new CodeCommentStatement(),
                        get(p.Body).ToArray()));
                }
                else if (item is Runtime.AssignmentStatement)
                {
                    var p = item as Runtime.AssignmentStatement;
                    stmnt.Add(new CodeAssignStatement(new CodeVariableReferenceExpression(p.Left.Name), get(p.Right.Dom.Base)));
                }
                else if (item is Runtime.ResultisStatement)
                {
                    var p = item as Runtime.ResultisStatement;
                    stmnt.Add(new CodeMethodReturnStatement(get(p.Expression.Dom.Base)));
                }
            }
            return stmnt;
        }

        private static CodeExpression get(Dom.Atom a)
        {
            switch (a.Type)
            {
                case Sketcher.Udfs.Dom.AtomType.Number:
                    return new CodePrimitiveExpression(a.Value);
                case Sketcher.Udfs.Dom.AtomType.Variable:
                    return new CodeVariableReferenceExpression((a.Value as Dom.Identifier).Name);
                case Sketcher.Udfs.Dom.AtomType.Function:
                    var f = a.Value as Udfs.Dom.FunctionCall;
                    var args = new CodeExpression[f.Args.Count];
                    for (int i = 0; i < args.Length; i++)
                        args[i] = get(f.Args[i].Base);
                    return new CodeMethodInvokeExpression(
                        new CodeMethodReferenceExpression(
                            new CodeTypeReferenceExpression(ClassName), f.FunctionName.Name),
                        args);
                case Sketcher.Udfs.Dom.AtomType.Operator:
                    var op = a.Value as Udfs.Dom.BinaryOperator;
                    return new CodeBinaryOperatorExpression(get(op.Left), get(op.Type), get(op.Right));
                default:
                    throw new NotImplementedException();
            }
        }

        private static CodeBinaryOperatorType get(Dom.OperatorType op)
        {
            switch (op)
            {
                case Sketcher.Udfs.Dom.OperatorType.Assignment:
                    return CodeBinaryOperatorType.Assign;
                case Sketcher.Udfs.Dom.OperatorType.Equals:
                    return CodeBinaryOperatorType.IdentityEquality;
                case Sketcher.Udfs.Dom.OperatorType.NotEquals:
                    return CodeBinaryOperatorType.IdentityInequality;
                case Sketcher.Udfs.Dom.OperatorType.GreaterThan:
                    return CodeBinaryOperatorType.GreaterThan;
                case Sketcher.Udfs.Dom.OperatorType.GreaterThanOrEquals:
                    return CodeBinaryOperatorType.GreaterThanOrEqual;
                case Sketcher.Udfs.Dom.OperatorType.LessThan:
                    return CodeBinaryOperatorType.LessThan;
                case Sketcher.Udfs.Dom.OperatorType.LessThanOrEquals:
                    return CodeBinaryOperatorType.LessThanOrEqual;
                case Sketcher.Udfs.Dom.OperatorType.And:
                    return CodeBinaryOperatorType.BitwiseAnd;
                case Sketcher.Udfs.Dom.OperatorType.Or:
                    return CodeBinaryOperatorType.BitwiseOr;
                case Sketcher.Udfs.Dom.OperatorType.Xor:
                    throw new NotImplementedException();
                case Sketcher.Udfs.Dom.OperatorType.Mod:
                    return CodeBinaryOperatorType.Modulus;
                case Sketcher.Udfs.Dom.OperatorType.Mul:
                    return CodeBinaryOperatorType.Multiply;
                case Sketcher.Udfs.Dom.OperatorType.Div:
                    return CodeBinaryOperatorType.Divide;
                case Sketcher.Udfs.Dom.OperatorType.Plus:
                    return CodeBinaryOperatorType.Add;
                case Sketcher.Udfs.Dom.OperatorType.Minus:
                    return CodeBinaryOperatorType.Subtract;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
