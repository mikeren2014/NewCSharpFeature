using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpNewFeature
{
    class CSharp4
    {
        public void Caller()
        {
            FooA(paramA: 1, paramB: 2);
            FooB();
            FooB(paramB: 2);

            var cSharp3 = new CSharp3();
            cSharp3.DoSomething(1);
        }

        private void FooA(int paramA, int paramB)
        {
            Console.Write(paramA + paramB);
        }

        private void FooB(int paramA = 0, int paramB = 0)
        {
            Console.Write(paramA + paramB);
        }

        private List<string> Test()
        {
            var listB = new List<string> { "a","b","c" };
            var listA = new List<string>();
            foreach (var c in listB)
            {
                listA.Add(c.ToUpper());
            }
            return listA;
        }
    }

    public class CSharp3: ICSharp3
    {
        
    }

    public interface ICSharp3
    { }

    public static class ICSharp3Extensions
    {
        public static void DoSomething(this ICSharp3 cSharp3, int a)
        {
            Console.WriteLine(a);
        }
    }
}
