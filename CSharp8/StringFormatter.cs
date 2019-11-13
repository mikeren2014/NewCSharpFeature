using System;

namespace CSharp8
{
    public class StringFormatter
    {
        public void PrintPath()
        {
            Console.WriteLine(@$"{AppDomain.CurrentDomain.BaseDirectory}\no");
        }
    }
}
