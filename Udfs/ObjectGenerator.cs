using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sketcher.Udfs
{
    public class ObjectGenerator
    {
        private List<CompileMessage> msgs;

        public List<CompileMessage> GenerationMessages { get { return msgs; } }
        public UdfsObject Generated { get; private set; }

        private string getObjFileName(string srcFileName)
        {
            return Path.Combine(srcFileName.Substring(0, srcFileName.LastIndexOf('\\')), 
                Path.GetFileNameWithoutExtension(srcFileName) + ".udfsobj");
        }

        public void Generate(CompilationResult result)
        {
            msgs = new List<CompileMessage>();
            List<Runtime.Function> funcs = new List<Runtime.Function>();
            List<Runtime.Constant> c = new List<Runtime.Constant>();
            List<Runtime.GlobalVariable> g = new List<Runtime.GlobalVariable>();
            Generated = new UdfsObject(getObjFileName(result.Unit.FileName), result.Unit.FileName,
                funcs, c, g);
            foreach (var item in result.Unit.AllConstDecls)
            {
                foreach (var item2 in item.Consts)
                {
                    c.Add(new Runtime.Constant(item2.Name, item2.Value));
                }
            }
            foreach (var item in result.Unit.AllGlobalDecls)
            {
                foreach (var item2 in item.Globals)
                {
                    g.Add(new Runtime.GlobalVariable(item2.Name));
                }
            }
            List<Runtime.Variable> visibleVars = new List<Runtime.Variable>();
            visibleVars.AddRange(Runtime.RuntimeEnvironment.Instance.Constants);
            visibleVars.AddRange(c);
            visibleVars.AddRange(Runtime.RuntimeEnvironment.Instance.GlobalVariables);
            visibleVars.AddRange(g);
            foreach (var item in result.Unit.AllFunctions)
            {
                List<Runtime.ArgumentVariable> args = new List<Runtime.ArgumentVariable>();
                List<Runtime.Variable> myVars = new List<Runtime.Variable>(visibleVars);
                var f = new Runtime.Function(item.Name, args);
                foreach (var item2 in item.Args)
                    args.Add(new Runtime.ArgumentVariable(item2.Name, f));
                //myVars.AddRange(args);
                myVars = update(myVars, args.ToList<Runtime.Variable>());
                f.Block = getBlock(item.Block, myVars);
                if (!allPathsReturn(f.Block))
                    msgs.Add(new Error(string.Format("Function '{0}': not all paths return a value", f.Name)));
                else funcs.Add(f);
            }
            Generated.UpdateAll();
        }

        private List<Runtime.Variable> update(List<Runtime.Variable> original, List<Runtime.Variable> _new)
        {
            List<Runtime.Variable> ret = new List<Runtime.Variable>();
            foreach (var item in original)
                ret.Add(_new.Find(i => i.Name == item.Name) ?? item);
            foreach (var item in _new)
                ret.Add(original.Find(i => i.Name == item.Name) ?? item);
            return ret;
        }

        private Runtime.Block getBlock(Dom.Statement s, List<Runtime.Variable> visibleVariables)
        {
            List<Runtime.LocalVariable> locals = new List<Runtime.LocalVariable>();
            List<Runtime.Statement> st = new List<Runtime.Statement>();
            var ret = new Runtime.Block(locals, st) { VisibleVariables = visibleVariables };
            if (!(s is Dom.Block))
            {
                Runtime.Statement add;
                if (s is Dom.IfStmnt)
                {
                    var i = s as Dom.IfStmnt;
                    add = new Runtime.IfStatement(new Runtime.Expression(i.Expression, visibleVariables),
                        getBlock(i.Block, visibleVariables),
                        i.ElseStmnt == null ? null : getBlock(i.ElseStmnt.Block, visibleVariables));
                }
                else if (s is Dom.WhileLoop)
                {
                    var w = s as Dom.WhileLoop;
                    add = new Runtime.WhileLoopStatement(new Runtime.Expression(w.Expression, visibleVariables),
                        getBlock(w.Block, visibleVariables));
                }
                else if (s is Dom.AssignmentStmnt)
                {
                    var a = s as Dom.AssignmentStmnt;
                    add = new Runtime.AssignmentStatement(visibleVariables.Find(i => i.Name == a.Left.Name),
                        new Runtime.Expression(a.Right, visibleVariables));
                }
                else if (s is Dom.Resultis)
                {
                    var r = s as Dom.Resultis;
                    add = new Runtime.ResultisStatement(new Runtime.Expression(r.Expression, visibleVariables));
                }
                else throw new NotImplementedException();
                st.Add(add);
            }
            else
            {
                Dom.Block b = s as Dom.Block;
                if (b.DeclVar != null)
                {
                    foreach (var item in b.DeclVar.Vars)
                        locals.Add(new Runtime.LocalVariable(item.Name, ret));
                }
                var mine = update(visibleVariables, locals.ToList<Runtime.Variable>());
                ret.VisibleVariables = mine;
                foreach (var item in b.Statements)
                {
                    if (item is Dom.IfStmnt)
                    {
                        var i = item as Dom.IfStmnt;
                        st.Add(new Runtime.IfStatement(new Runtime.Expression(i.Expression, mine),
                            getBlock(i.Block, mine), i.ElseStmnt == null ? null : getBlock(i.ElseStmnt.Block, mine)));
                    }
                    else if (item is Dom.WhileLoop)
                    {
                        var w = item as Dom.WhileLoop;
                        st.Add(new Runtime.WhileLoopStatement(new Runtime.Expression(w.Expression, mine),
                            getBlock(w.Block, mine)));
                    }
                    else if (item is Dom.AssignmentStmnt)
                    {
                        var a = item as Dom.AssignmentStmnt;
                        st.Add(new Runtime.AssignmentStatement(mine.Find(i => i.Name == a.Left.Name),
                            new Runtime.Expression(a.Right, mine)));
                    }
                    else if (item is Dom.Resultis)
                    {
                        var r = item as Dom.Resultis;
                        st.Add(new Runtime.ResultisStatement(new Runtime.Expression(r.Expression, mine)));
                    }
                    else throw new NotImplementedException();
                }
            }
            return ret;
        }

        #region All paths return value
        private bool isConstExpr(Dom.Atom a, List<Runtime.Variable> visibleVars)
        {
            switch (a.Type)
            {
                case Sketcher.Udfs.Dom.AtomType.Number:
                    return true;
                case Sketcher.Udfs.Dom.AtomType.Variable:
                    return visibleVars
                        .Find(i => i.Name == (a.Value as Dom.Identifier).Name)
                        is Runtime.Constant;
                case Sketcher.Udfs.Dom.AtomType.Function:
                    return false;
                case Sketcher.Udfs.Dom.AtomType.Operator:
                    var op = a.Value as Dom.BinaryOperator;
                    return isConstExpr(op.Left, visibleVars) && isConstExpr(op.Right, visibleVars);
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// function temp()
        /// {
        ///     while 1
        ///     {
        ///     }
        ///     !! This should compile successfully !!
        /// }
        /// 
        /// Consider too:
        /// string temp()
        /// {
        ///    if (false)
        ///    {
        ///    }
        ///    else
        ///    {
        ///        ToString();
        ///        while (true)
        ///        {
        ///
        ///        }
        ///    }
        /// }
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        //private bool findResultis(Runtime.Block b)
        //{
        //    for (int i = 0; i < b.Statements.Count; i++)
        //    {
        //        var item = b.Statements[i];
        //        if (item is Runtime.ResultisStatement) return true;
        //        if (item is Runtime.IfStatement)
        //        {
        //            var f = item as Runtime.IfStatement;
        //            if (isConstExpr(f.Condition.Dom.Base, f.Body.VisibleVariables))
        //            {
        //                f.Condition.Execute();
        //                if (!f.Condition.BooleanResult)
        //                {
        //                    msgs.Add(new Warning("If block never executes"));
        //                    if (f.ElseBody != null && findResultis(f.ElseBody)) return true;
        //                }
        //                else if (f.ElseBody != null)
        //                {
        //                    msgs.Add(new Warning("Else block never executes"));
        //                    if (findResultis(f.Body)) return true;
        //                }
        //            }
        //            else if (f.ElseBody != null && findResultis(f.Body) && findResultis(f.ElseBody))
        //                return true;
        //        }
        //        else if (item is Runtime.WhileLoopStatement)
        //        {
        //            var w = item as Runtime.WhileLoopStatement;
        //            if (isConstExpr(w.Condition.Dom.Base, w.Body.VisibleVariables))
        //            {
        //                w.Condition.Execute();
        //                if (w.Condition.BooleanResult)
        //                {
        //                    if (i + 1 < b.Statements.Count)
        //                        msgs.Add(new Warning("Unreachable statements found after endless-whileloop"));
        //                    return findResultis(w.Body); // an infinite while loop MUST contain (break | return)
        //                }
        //                else msgs.Add(new Warning("Whileloop never executes"));
        //            }
        //        }
        //    }
        //    return false;
        //}

        private bool allPathsReturn(Runtime.Block b)
        {
            for (int j = 0; j < b.Statements.Count; ++j)
            {
                var item = b.Statements[j];
                if (item is Runtime.IfStatement)
                {
                    var i = item as Runtime.IfStatement;
                    if (!isConstExpr(i.Condition.Dom.Base, i.Body.VisibleVariables))
                    {
                        if (i.ElseBody != null && allPathsReturn(i.Body) && allPathsReturn(i.ElseBody))
                        {
                            if (j + 1 < b.Statements.Count)
                                msgs.Add(new Warning("Unreachable statements found after if\\else blocks"));
                            return true;
                        }
                    }
                    else
                    {
                        bool retn = false;
                        try
                        {
                            i.Condition.Execute();
                            if (i.Condition.BooleanResult)
                            {
                                if (i.ElseBody != null)
                                    msgs.Add(new Warning("Else block never executes"));
                                if (allPathsReturn(i.Body)) return retn = true;
                            }
                            else
                            {
                                msgs.Add(new Warning("If block never executes"));
                                if (i.ElseBody != null && allPathsReturn(i.ElseBody))
                                    return retn = true;
                            }
                        }
                        finally
                        {
                            if (retn && j + 1 < b.Statements.Count)
                                msgs.Add(new Warning("Unreachable statements found after constant if blocks"));
                        }
                    }
                }
                else if (item is Runtime.WhileLoopStatement)
                {
                    var w = item as Runtime.WhileLoopStatement;
                    if (isConstExpr(w.Condition.Dom.Base, w.Body.VisibleVariables))
                    {
                        w.Condition.Execute();
                        if (w.Condition.BooleanResult)
                        {
                            if (j + 1 < b.Statements.Count)
                                msgs.Add(new Warning("Unreachable statements found after endless-whileloop"));
                            return true; // He is responsible of this // findResultis(w.Body);
                        }
                        else
                            msgs.Add(new Warning("Whileloop never executes"));
                    }
                }
                else if (item is Runtime.ResultisStatement)
                {
                    if (j + 1 < b.Statements.Count)
                        msgs.Add(new Warning("Unreachable statements found after resultis"));
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
