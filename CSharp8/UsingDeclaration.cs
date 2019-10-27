using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp8
{
    public class UsingDeclaration
    {

        public static void WriteLinesToFile()
        {
            var lines = new List<string> {"line1", "line2" };
            using (var file = new System.IO.StreamWriter("WriteLines2.txt"))
            {
                foreach (string line in lines)
                    file.WriteLine(line);
            }
        }

        public class DisosableObjManager
        {
            public class DisoableObject1 : IDisposable
            {
                public DisoableObject1(string name)
                {
                    Name = name;
                }
                public string Name { get; set; }

                public async Task<string> GetName()
                {
                    await Task.Delay(1);
                    return Name;
                }

                public void Dispose()
                {
                    Name = null;
                }
            }

            public static Task<string> GetName()
            {
                using var obj1 = new DisoableObject1("obj1");
                return obj1.GetName();
            }
        }

        
    }

    public class StaticLocalFunctions
    {
        public int Fun()
        {
            int y = 5;
            int x = 7;
            return Add(x, y);

            static int Add(int left, int right) => left + right;
        }
    }
}
