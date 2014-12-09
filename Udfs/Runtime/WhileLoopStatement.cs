using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Runtime
{
    [Serializable]
    internal class WhileLoopStatement : Statement
    {
        public Expression Condition { get; private set; }
        public Block Body { get; private set; }

        public WhileLoopStatement(Expression condition, Block block)
        {
            this.Condition = condition;
            this.Body = block;
        }

        public override double? Execute()
        {
            while (true)
            {
                Condition.Execute();
                if (!Condition.BooleanResult) break;
                var ret = Body.Execute();
                if (ret != null) return ret;
            }
            return null;
        }
    }
}
