using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sketcher.Udfs.Dom
{
    [Serializable]
    public class Identifier
    {
        public string Name { get; private set; }

        public Identifier(string name)
        {
            this.Name = name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() * 101;
        }

        public override bool Equals(object obj)
        {
            if (obj is Identifier)
                return (obj as Identifier).Name == Name;
            return false;
        }
    }
}
