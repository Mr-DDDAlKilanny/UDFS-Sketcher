using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Sketcher.Udfs.Runtime
{
    public class RuntimeEnvironment
    {
        private static readonly UdfsObject SystemUdfsObject;

        private static RuntimeEnvironment instance;

        public static RuntimeEnvironment Instance
        {
            get
            {
                if (instance == null)
                    instance = new RuntimeEnvironment();
                return instance;
            }
        }

        static RuntimeEnvironment()
        {
            List<Function> funcs = new List<Function>();
            List<Constant> con = new List<Constant>();
            List<GlobalVariable> glob = new List<GlobalVariable>();
            SystemUdfsObject = new UdfsObject("<sysobj>", "<sys>", funcs, con, glob);

            #region sin, cos, tan, their reverse
            var g = new List<ArgumentVariable>();
            Function f = new Function("sin", g);
            g.Add(new ArgumentVariable("n", f));
            f.Executor = delegate(List<ArgumentVariable> args)
            {
                return Math.Sin(args[0].Value);
            };
            f.Object = SystemUdfsObject;
            funcs.Add(f);

            g = new List<ArgumentVariable>();
            f = new Function("cos", g);
            g.Add(new ArgumentVariable("n", f));
            f.Executor = delegate(List<ArgumentVariable> args)
            {
                return Math.Cos(args[0].Value);
            };
            f.Object = SystemUdfsObject;
            funcs.Add(f);

            g = new List<ArgumentVariable>();
            f = new Function("tan", g);
            g.Add(new ArgumentVariable("n", f));
            f.Executor = delegate(List<ArgumentVariable> args)
            {
                return Math.Tan(args[0].Value);
            };
            f.Object = SystemUdfsObject;
            funcs.Add(f);

            g = new List<ArgumentVariable>();
            f = new Function("arcsin", g);
            g.Add(new ArgumentVariable("n", f));
            f.Executor = delegate(List<ArgumentVariable> args)
            {
                return Math.Asin(args[0].Value);
            };
            f.Object = SystemUdfsObject;
            funcs.Add(f);

            g = new List<ArgumentVariable>();
            f = new Function("arccos", g);
            g.Add(new ArgumentVariable("n", f));
            f.Executor = delegate(List<ArgumentVariable> args)
            {
                return Math.Acos(args[0].Value);
            };
            f.Object = SystemUdfsObject;
            funcs.Add(f);

            g = new List<ArgumentVariable>();
            f = new Function("arctan", g);
            g.Add(new ArgumentVariable("n", f));
            f.Executor = delegate(List<ArgumentVariable> args)
            {
                return Math.Atan(args[0].Value);
            };
            f.Object = SystemUdfsObject;
            funcs.Add(f);
            #endregion

            #region hyper-polic
            g = new List<ArgumentVariable>();
            f = new Function("sinh", g);
            g.Add(new ArgumentVariable("n", f));
            f.Executor = delegate(List<ArgumentVariable> args)
            {
                return Math.Sinh(args[0].Value);
            };
            f.Object = SystemUdfsObject;
            funcs.Add(f);

            g = new List<ArgumentVariable>();
            f = new Function("cosh", g);
            g.Add(new ArgumentVariable("n", f));
            f.Executor = delegate(List<ArgumentVariable> args)
            {
                return Math.Cosh(args[0].Value);
            };
            f.Object = SystemUdfsObject;
            funcs.Add(f);

            g = new List<ArgumentVariable>();
            f = new Function("tanh", g);
            g.Add(new ArgumentVariable("n", f));
            f.Executor = delegate(List<ArgumentVariable> args)
            {
                return Math.Tanh(args[0].Value);
            };
            f.Object = SystemUdfsObject;
            funcs.Add(f);
            #endregion

            #region other functions
            g = new List<ArgumentVariable>();
            f = new Function("log", g);
            g.Add(new ArgumentVariable("n", f));
            g.Add(new ArgumentVariable("base", f));
            f.Executor = delegate(List<ArgumentVariable> args)
            {
                return Math.Log(args[0].Value, args[1].Value);
            };
            f.Object = SystemUdfsObject;
            funcs.Add(f);

            g = new List<ArgumentVariable>();
            f = new Function("pow", g);
            g.Add(new ArgumentVariable("n", f));
            g.Add(new ArgumentVariable("power", f));
            f.Executor = delegate(List<ArgumentVariable> args)
            {
                return Math.Pow(args[0].Value, args[1].Value);
            };
            f.Object = SystemUdfsObject;
            funcs.Add(f);
            #endregion

            con.Add(new Constant("posinf", double.PositiveInfinity) { Object = SystemUdfsObject });
            con.Add(new Constant("neginf", double.NegativeInfinity) { Object = SystemUdfsObject });
            con.Add(new Constant("nan", double.NaN) { Object = SystemUdfsObject });
            con.Add(new Constant("e", Math.E) { Object = SystemUdfsObject });
            con.Add(new Constant("PI", Math.PI) { Object = SystemUdfsObject });

            glob.Add(new GlobalVariable("x") { Object = SystemUdfsObject });
        }

        private readonly string SettingsFile = "objects.ini";

        private bool initialized = false;
        private List<Constant> constants;
        private List<Function> functions;
        private List<GlobalVariable> globalVariables;
        private List<string> objFiles;

        public List<Constant> Constants
        {
            get
            {
                if (!initialized)
                    throw new InvalidOperationException();
                return constants;
            }
        }

        public List<Function> Functions 
        {
            get
            {
                if (!initialized)
                    throw new InvalidOperationException();
                return functions;
            }
        }

        public List<GlobalVariable> GlobalVariables
        {
            get
            {
                if (!initialized)
                    throw new InvalidOperationException();
                return globalVariables;
            }
        }

        public bool Updated { get { return initialized; } }

        private void addWithConflictChecking<T>(List<T> original, List<T> _new,
            List<Error> err, string filename)
            where T : RuntimeElement
        {
            List<T> add = new List<T>();
            foreach (var item in _new)
            {
                var tmp = original.Find(i => i.Name == item.Name);
                if (tmp != null)
                {
                    err.Add(new Error(string.Format("Failed to add declaration '{0}' "
                        + "because it is already declared in file \"{1}\"",
                        tmp.Name, tmp.Object.SourceFileName)));
                }
                else add.Add(item);
            }
            original.AddRange(add);
        }

        public List<Error> Update(bool forceUpdate)
        {
            List<Error> ret = new List<Error>(0);
            if (!forceUpdate && initialized)
                return ret;

            constants = new List<Constant>(SystemUdfsObject.Constants);
            functions = new List<Function>(SystemUdfsObject.Functions);
            globalVariables = new List<GlobalVariable>(SystemUdfsObject.Globals);

            if (File.Exists(SettingsFile))
            {
                objFiles = new List<string>();
                using (FileStream fs = new FileStream(SettingsFile, FileMode.Open))
                using (StreamReader reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (!line.TrimStart().StartsWith("#"))
                        {
                            try
                            {
                                if (File.Exists(line))
                                {
                                    objFiles.Add(line);
                                    var res = UdfsObject.Read(line);
                                    addWithConflictChecking(constants, res.Constants, ret, line);
                                    addWithConflictChecking(globalVariables, res.Globals, ret, line);
                                    addWithConflictChecking(functions, res.Functions, ret, line);
                                }
                                else
                                    ret.Add(new Error(string.Format("Object file \"{0}\" does not exist",
                                        line)));
                            }
                            catch
                            {
                                ret.Add(new Error(string.Format("Error occured reading object file \"{0}\"",
                                        line)));
                            }
                        }
                    }
                }
            }
            initialized = true;
            return ret;
        }

        public void Save()
        {
            using (FileStream fs = new FileStream(SettingsFile, FileMode.Create))
            using (StreamWriter wr = new StreamWriter(fs))
            {
                wr.WriteLine("# This file contains the *.udfsobj file paths that contain");
                wr.WriteLine("# the compiled source code objects.");
                Dictionary<string, UdfsObject> fileNames = new Dictionary<string,UdfsObject>();
                
                foreach (var item in functions)
                    if (!fileNames.ContainsKey(item.Object.FileName))
                        fileNames.Add(item.Object.FileName, item.Object);
                foreach (var item in constants)
                    if (!fileNames.ContainsKey(item.Object.FileName))
                        fileNames.Add(item.Object.FileName, item.Object);
                foreach (var item in globalVariables)
                    if (!fileNames.ContainsKey(item.Object.FileName))
                        fileNames.Add(item.Object.FileName, item.Object);
                foreach (var item in fileNames)
                {
                    if (item.Key == SystemUdfsObject.FileName) continue;
                    if (!File.Exists(item.Key))
                        item.Value.Write();
                    wr.WriteLine(item.Key);
                }
            }
        }

        private RuntimeEnvironment()
        {
        }
    }
}
