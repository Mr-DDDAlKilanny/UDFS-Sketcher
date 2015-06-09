using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Sketcher.Udfs.Runtime;
using System.CodeDom;

namespace Sketcher.Udfs
{
    [Serializable]
    public class UdfsObject
    {
        public List<Function> Functions { get; private set; }
        public List<Constant> Constants { get; private set; }
        public List<GlobalVariable> Globals { get; private set; }
        public string FileName { get; private set; }
        public string SourceFileName { get; private set; }

        public UdfsObject(string fileName, string srcFileName, List<Function> funcs,
            List<Constant> consts, List<GlobalVariable> globals)
        {
            this.Functions = funcs;
            this.Constants = consts;
            this.Globals = globals;
            this.FileName = fileName;
            this.SourceFileName = srcFileName;
        }

        public void Write()
        {
            using (FileStream str = new FileStream(FileName, FileMode.Create))
                new BinaryFormatter().Serialize(str, this);
        }

        public static UdfsObject Read(string fileName)
        {
            using (FileStream str = new FileStream(fileName, FileMode.Open))
                return new BinaryFormatter().Deserialize(str) as UdfsObject;
        }

        public void UpdateAll()
        {
            foreach (var item in Functions)
            {
                item.Object = this;
            }
            foreach (var item in Constants)
            {
                item.Object = this;
            }
            foreach (var item in Globals)
            {
                item.Object = this;
            }
        }

        public CodeCompileUnit ToCSharp()
        {
            return UdfsToCSharpHelper.Get(new List<UdfsObject>() { this });
        }
    }
}
