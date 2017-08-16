using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpNewFeature
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var cus = new Customer();
                cus.FooCaller();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();

        }
    }
}
