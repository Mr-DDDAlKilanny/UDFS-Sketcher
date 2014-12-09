using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs
{
    public class SemanticAnalyzer
    {
        private CompilationResult compilationResult;
        private List<Runtime.Function> predefFuncs;
        private List<Runtime.GlobalVariable> globalVars;
        private List<Runtime.Constant> consts;
        private List<CompileMessage> msgs;
        private Dom.Function currentFunction;
        private Stack<Dom.Statement> blocks = new Stack<Dom.Statement>();

        private enum Element
        {
            GlobalVariable,
            ConstVariable,
            FunctionName,
            LocalVariable,
            ArgumentVariable
        }

        /// <summary>
        /// A global\const\var can be the same as function name.
        /// Global and const cannot have the same name.
        /// Two functions can be the same name but having different arg count
        /// If a var has the same name of global, var hides global (no error, only warning).
        /// </summary>
        private CompileMessage checkDecl(string name, Element e, int argCount)
        {
            Runtime.RuntimeElement tmp;
            if (e != Element.FunctionName && (tmp = consts.Find(i => i.Name == name)) != null)
            {
                if (e == Element.LocalVariable)
                    return new Warning(string.Format("A constant with name '{0}' already declared in file \"{1}\".\n"
                        + "The constant will be hidden by this local variable in its scope",
                        name, tmp.Object.SourceFileName));
                return new Error(string.Format("A constant with name '{0}' already declared in file \"{1}\"",
                        name, tmp.Object.SourceFileName));
            }
            if (e == Element.FunctionName
                && (tmp = predefFuncs.Find(i => i.Name == name && i.Args.Count == argCount)) != null)
                return new Error(string.Format("A function with name '{0}' with the same argument count"
                    + "already declared in file \"{1}\"",
                    name, tmp.Object.SourceFileName));
            if (e != Element.FunctionName && (tmp = globalVars.Find(i => i.Name == name)) != null)
            {
                if (e == Element.LocalVariable)
                    return new Warning(string.Format("A global variable with name '{0}' already declared in file \"{1}\".\n"
                        + "The global variable will be hidden by this local variable in its scope",
                        name, tmp.Object.SourceFileName));
                return new Error(string.Format("A global variable with name '{0}' already declared in file \"{1}\"",
                        name, tmp.Object.SourceFileName));
            }
            var c = compilationResult.Unit.AllConstDecls;
            var f = compilationResult.Unit.AllFunctions;
            var g = compilationResult.Unit.AllGlobalDecls;
            if (e != Element.FunctionName &&
                c.Find(co => co.Consts.FindAll(i => i.Name == name).Count > (e == Element.ConstVariable ? 1 : 0)) != null)
            {
                if (e == Element.LocalVariable)
                    return new Warning(string.Format("A constant with name '{0}' already declared.\n"
                        + "The constant will be hidden by this local variable in its scope", name));
                return new Error(string.Format("A constant with name '{0}' already declared", name));
            }
            if (e == Element.FunctionName &&
                f.FindAll(fn => (fn.Name == name && fn.Args.Count == argCount)).Count > 1)
                return new Error(string.Format("A function with name '{0}' with the same argument count", name));
            if (e != Element.FunctionName &&
                g.Find(co => co.Globals.FindAll(i => i.Name == name).Count > (e == Element.GlobalVariable ? 1 : 0)) != null)
            {
                if (e == Element.LocalVariable)
                    return new Warning(string.Format("A global variable with name '{0}' already declared.\n"
                        + "The global variable will be hidden by this local variable in its scope", name));
                return new Error(string.Format("A global variable with name '{0}' already declared", name));
            }
            return null;
        }

        private bool find(string name, Element e, int argCount = -1)
        {
            switch (e)
            {
                case Element.GlobalVariable:
                    if (this.globalVars.Find(i => i.Name == name) != null)
                        return true;
                    foreach (var item in compilationResult.Unit.AllGlobalDecls)
                        if (item.Globals.Find(i => i.Name == name) != null) return true;
                    return false;
                case Element.ConstVariable:
                    if (this.consts.Find(i => i.Name == name) != null)
                        return true;
                    foreach (var item in compilationResult.Unit.AllConstDecls)
                        if (item.Consts.Find(i => i.Name == name) != null) return true;
                    return false;
                case Element.FunctionName:
                    if (this.predefFuncs.Find(i => (i.Name == name && i.Args.Count == argCount)) != null)
                        return true;
                    if (compilationResult.Unit.AllFunctions.Find(i => (i.Name == name && i.Args.Count == argCount)) != null)
                        return true;
                    return false;
                case Element.LocalVariable:
                    for (int i = 0; i < blocks.Count; ++i)
                    {
                        var el = blocks.ElementAt(i);
                        if (!(el is Dom.Block)) continue;
                        var b = el as Dom.Block;
                        if (b.DeclVar != null)
                            if (b.DeclVar.Vars.Find(j => j.Name == name) != null)
                                return true;
                    }
                    return false;
                case Element.ArgumentVariable:
                    return currentFunction.Args.Find(a => a.Name == name) != null;
                default:
                    throw new NotImplementedException();
            }
        }

        public List<CompileMessage> Analyze(CompilationResult cr,
            List<Runtime.Function> predefFuncs,
            List<Runtime.GlobalVariable> globalVars,
            List<Runtime.Constant> consts)
        {
            msgs = new List<CompileMessage>();
            this.compilationResult = cr;
            this.consts = consts;
            this.predefFuncs = predefFuncs;
            this.globalVars = globalVars;

            foreach (var item in cr.Unit.AllConstDecls)
            {
                foreach (var item2 in item.Consts)
                {
                    var tmp = checkDecl(item2.Name, Element.ConstVariable, -1);
                    if (tmp != null) msgs.Add(tmp);
                }
            }

            foreach (var item in cr.Unit.AllGlobalDecls)
            {
                foreach (var item2 in item.Globals)
                {
                    var tmp = checkDecl(item2.Name, Element.GlobalVariable, -1);
                    if (tmp != null) msgs.Add(tmp);
                }
            }

            foreach (var item in cr.Unit.AllFunctions)
            {
                currentFunction = item;
                var tmp = checkDecl(item.Name, Element.FunctionName, item.Args.Count);
                if (tmp != null) msgs.Add(tmp);
                checkBlock(item.Block);
            }

            return msgs;
        }

        private void checkLocalDecl(Dom.Identifier i)
        {
            var tmp = checkDecl(i.Name, Element.LocalVariable, -1);
            if (tmp != null) msgs.Add(tmp);
        }

        private bool variableExists(string name)
        {
            return find(name, Element.ArgumentVariable) ||
                find(name, Element.LocalVariable) ||
                find(name, Element.ConstVariable) ||
                find(name, Element.GlobalVariable);
        }

        private void checkExpr(Dom.Atom ex)
        {
            switch (ex.Type)
            {
                case Sketcher.Udfs.Dom.AtomType.Number:
                    break;
                case Sketcher.Udfs.Dom.AtomType.Variable:
                    var i = ex.Value as Dom.Identifier;
                    if (!variableExists(i.Name))
                        msgs.Add(new Error(string.Format("Could not find a declaration for variable\\const '{0}'",
                            i.Name)));
                    break;
                case Sketcher.Udfs.Dom.AtomType.Function:
                    var r = ex.Value as Dom.FunctionCall;
                    if (!find(r.FunctionName.Name, Element.FunctionName, r.Args.Count))
                        msgs.Add(new Error(string.Format(
                            "Could not find a function with name '{0}' taking {1} arguments",
                            r.FunctionName, r.Args.Count)));
                    foreach (var item in r.Args)
                        checkExpr(item.Base);
                    break;
                case Sketcher.Udfs.Dom.AtomType.Operator:
                    var op = ex.Value as Dom.BinaryOperator;
                    if (op.Type == Dom.OperatorType.Assignment)
                        checkAssignmentLeft(op.Left);
                    else checkExpr(op.Left);
                    checkExpr(op.Right);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void checkOuterBlocks(List<Dom.Identifier> locals)
        {
            for (int i = 0; i < blocks.Count - 1; i++)
            {
                var el = blocks.ElementAt(i);
                if (!(el is Dom.Block)) continue;
                var b = el as Dom.Block;
                if (b.DeclVar != null)
                    foreach (var item in locals)
                        if (b.DeclVar.Vars.Find(kj => kj.Name == item.Name) != null)
                            msgs.Add(new Warning(string.Format("A variable with name '{0}' already declared in an outer block.\n"
                                + "It will be hidden by the new declaration",
                                item.Name)));
            }
        }

        private void checkAssignmentLeft(Dom.Atom a)
        {
            switch (a.Type)
            {
                case Sketcher.Udfs.Dom.AtomType.Number:
                case Sketcher.Udfs.Dom.AtomType.Function:
                case Sketcher.Udfs.Dom.AtomType.Operator:
                    msgs.Add(new Error(string.Format("Cannot assign to a non modifiable left hand side")));
                    break;
                case Sketcher.Udfs.Dom.AtomType.Variable:
                    Dom.Identifier i = a.Value as Dom.Identifier;
                    if (!variableExists(i.Name))
                        msgs.Add(new Error(string.Format("Could not find a declaration of variable\\const '{0}'",
                            i.Name)));
                    else if (find(i.Name, Element.ConstVariable))
                        msgs.Add(new Error(string.Format("Cannot assign to a non modifiable left hand side (constant '{0}')",
                            i.Name)));
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void checkBlock(Dom.Statement s)
        {
            blocks.Push(s);
            if (!(s is Dom.Block))
            {
                if (s is Dom.AssignmentStmnt)
                {
                    var a = s as Dom.AssignmentStmnt;
                    checkAssignmentLeft(new Dom.Atom(Dom.AtomType.Variable, a.Left));
                    checkExpr(a.Right.Base);
                }
                else if (s is Dom.IfStmnt)
                {
                    var i = s as Dom.IfStmnt;
                    checkExpr(i.Expression.Base);
                    checkBlock(i.Block);
                    if (i.ElseStmnt != null)
                        checkBlock(i.ElseStmnt.Block);
                }
                else if (s is Dom.WhileLoop)
                {
                    var l = s as Dom.WhileLoop;
                    checkExpr(l.Expression.Base);
                    checkBlock(l.Block);
                }
                else if (s is Dom.Resultis)
                    checkExpr((s as Dom.Resultis).Expression.Base);
                else throw new NotImplementedException();
            }
            else
            {
                Dom.Block b = s as Dom.Block;
                if (b.DeclVar != null)
                {
                    // check local variable is declared before in the same block?
                    foreach (var item in b.DeclVar.Vars.FindAllDuplicates())
                        msgs.Add(new Error(string.Format("A local variable with name '{0}' already declared in this scope",
                            item.Name)));
                    // in the outer block? (hides them)
                    checkOuterBlocks(b.DeclVar.Vars);
                    // Againts functs, decls, 
                    foreach (var item in b.DeclVar.Vars)
                        checkLocalDecl(item);
                }
                foreach (var item in b.Statements)
                {
                    if (item is Dom.AssignmentStmnt)
                    {
                        var a = item as Dom.AssignmentStmnt;
                        checkAssignmentLeft(new Dom.Atom(Dom.AtomType.Variable, a.Left));
                        checkExpr(a.Right.Base);
                    }
                    else if (item is Dom.IfStmnt)
                    {
                        var i = item as Dom.IfStmnt;
                        checkExpr(i.Expression.Base);
                        checkBlock(i.Block);
                        if (i.ElseStmnt != null)
                            checkBlock(i.ElseStmnt.Block);
                    }
                    else if (item is Dom.WhileLoop)
                    {
                        var l = item as Dom.WhileLoop;
                        checkExpr(l.Expression.Base);
                        checkBlock(l.Block);
                    }
                    else if (item is Dom.Resultis)
                        checkExpr((item as Dom.Resultis).Expression.Base);
                    else throw new NotImplementedException();
                }
            }
            blocks.Pop();
        }
    }
}
