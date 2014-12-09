using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs
{
    public abstract class CompileMessage
    {
        public string Text { get; private set; }

        public CompileMessage(string msg)
        {
            Text = msg;
        }
    }

    public class Info : CompileMessage
    {
        public Info(string msg)
            : base(msg)
        {
        }
    }

    public class Warning : CompileMessage
    {
        public Warning(string msg)
            : base(msg)
        {
        }
    }

    public class Error : CompileMessage
    {
        public Error(string msg)
            : base(msg)
        {
        }
    }
}
