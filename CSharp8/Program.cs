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

            // 2. Default interface methods
            IProductManager productManager = new ProductManager();
            var productInfo = productManager.GetProductInfo("1","2");
            Console.WriteLine(productInfo);

            Console.ReadKey();

        }
    }
}
