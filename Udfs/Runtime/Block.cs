using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Runtime
{
    [Serializable]
    public class Block : Statement
    {
        public List<LocalVariable> LocalVariables { get; private set; }
        public List<Statement> Statements { get; private set; }
        public List<Variable> VisibleVariables { get; set; }

        public Block(List<LocalVariable> locals, List<Statement> st)
        {
            this.LocalVariables = locals;
            this.Statements = st;
        }

        public override double? Execute()
        {
            for (int i = 0; i < LocalVariables.Count; ++i)
                LocalVariables[i].Value = 0;
            foreach (var item in Statements)
            {
                var res = item.Execute();
                if (res != null) return res;
            }
            return null;
        }
    }
}
