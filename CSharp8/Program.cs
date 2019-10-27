using System;

namespace CSharp8
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Readonly members
            var point = new Point { X = 1, Y = 2 };
            Console.WriteLine(point);

            // 2. 
            IProductManager productManager = new ProductManager();
            var sku = productManager.GetSku();
            var name = productManager.GetNamge();
            Console.WriteLine($"{sku}--{name}");

            Console.ReadKey();

        }
    }
}
