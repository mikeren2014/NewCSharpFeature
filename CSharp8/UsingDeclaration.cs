using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharp8
{
    public class UsingDeclaration
    {
        public async Task WriteToFile()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("/api/file");
                var content = await result.Content.ReadAsStringAsync();
                using (var file = new StreamWriter("WriteLines2.txt"))
                {
                    file.WriteLine(content);
                }
            }
        }
    }

    public class DisposableObjManager
    {
        public static Task<string> GetNameAsync()
        {
            using var obj1 = new DisposableObject1("obj1");
            return obj1.GetNameAsync();
        }
    }

    public class DisposableObject1 : IDisposable
    {
        public DisposableObject1(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void Dispose()
        {
            Name = null;
        }

        public async Task<string> GetNameAsync()
        {
            await Task.Delay(1).ConfigureAwait(false);
            return Name;
        }
    }
}