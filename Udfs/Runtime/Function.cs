using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Runtime
{
    [Serializable]
    public delegate double FunctionExecutorCallback(List<ArgumentVariable> args);

    [Serializable]
    public class Function : RuntimeElement
    {
        private Block block;
        private FunctionExecutorCallback executor;

        public List<ArgumentVariable> Args { get; private set; }

        public Block Block
        {
            get { return block; }
            set
            {
                if (executor != null)
                    throw new InvalidOperationException();
                block = value;
            }
        }

        /// <summary>
        /// Used for pre-defined functions to return the result directly with C# code
        /// </summary>
        public FunctionExecutorCallback Executor
        {
            get { return executor; }
            set
            {
                if (block != null)
                    throw new InvalidOperationException();
                executor = value;
            }
        }

        public bool IsBuiltIn
        {
            get
            {
                if (Block == null && Executor == null)
                    throw new InvalidOperationException();
                if (Block != null)
                    return false;
                return true;
            }
        }

        public Function(string name, List<ArgumentVariable> args)
            : base(name)
        {
            this.Args = args;
        }

        public double Execute(params double[] args)
        {
            if (!(Executor == null ^ Block == null))
                throw new InvalidOperationException();
            if (args.Length != Args.Count)
                throw new ArgumentOutOfRangeException();
            for (int i = 0; i < args.Length; i++)
                Args[i].Value = args[i];
            return Executor == null ? (double)Block.Execute() : Executor(Args);
        }
    }
}
