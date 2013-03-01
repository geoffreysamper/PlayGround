using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Mono.Cecil;

namespace depAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("please run the depAnalyser.exe with a path \n example: depanalyser.exe c:\temp\bin");
                return;
            }


            string path = args[0];
            bool hasConflict = false;
            var files = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories);

            foreach (var f in files)
            {
                var ass = AssemblyDefinition.ReadAssembly(f, new ReaderParameters(ReadingMode.Immediate));
                
                
                
                foreach (var m in  ass.Modules)
                {
                    
                    foreach (var reference in m.AssemblyReferences)
                    {
                        if (reference.FullName.IndexOf("autofac", System.StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            if (reference.Version == new Version("2.3.2.632"))
                            {
                                hasConflict = true;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("assembly {0} has a reference to an old autofac '{1}' 2.3.2.632 ", ass.Name.Name, reference.Name);
                                
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                                
                        }



                        
                    }
                }

            }

            if (!hasConflict)
            {
                Console.WriteLine("no conflicts found.");
            }
        }
    }
}
