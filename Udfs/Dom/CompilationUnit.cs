using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Dom
{
    public class CompilationUnit
    {
        public List<ConstDecls> AllConstDecls { get; private set; }
        public List<Function> AllFunctions { get; private set; }
        public List<GlobalDecls> AllGlobalDecls { get; private set; }
        public string FileName { get; private set; }
        public DateTime CompileTime { get; private set; }

        public CompilationUnit(List<ConstDecls> c, List<Function> f, List<GlobalDecls> g, string fileName,
            DateTime time)
        {
            this.AllConstDecls = c;
            this.AllFunctions = f;
            this.AllGlobalDecls = g;
            this.FileName = fileName;
            this.CompileTime = time;
        }
    }
}
