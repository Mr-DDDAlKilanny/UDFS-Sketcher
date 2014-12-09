using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Runtime
{
    [Serializable]
    public abstract class RuntimeElement
    {
        public string Name { get; private set; }
        public UdfsObject Object { get; set; }

        public RuntimeElement(string name)
        {
            this.Name = name;
        }
    }
}
