using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Runtime
{
    [Serializable]
    internal class IfStatement : Statement
    {
        public Expression Condition { get; private set; }
        public Block Body { get; private set; }
        public Block ElseBody { get; private set; }

        public IfStatement(Expression condition, Block body, Block elseBody = null)
        {
            this.Condition = condition;
            this.Body = body;
            this.ElseBody = elseBody;
        }

        public override double? Execute()
        {
            Condition.Execute();
            if (Condition.BooleanResult)
            {
                var ret = Body.Execute();
                if (ret != null) return ret;
            }
            else if (ElseBody != null)
            {
                var ret = ElseBody.Execute();
                if (ret != null) return ret;
            }
            return null;
        }
    }
}
