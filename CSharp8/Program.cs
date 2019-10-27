using System;
using System.Threading.Tasks;
using static CSharp8.TuplePattern.RockPaperScissorType;

namespace CSharp8
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 1. Readonly members
            new Point { X = 1, Y = 2 };

            // 2. Default interface methods
            IProductManager productManager = new ProductManager();
            var productInfo = productManager.GetProductInfo("1", "2");
            Console.WriteLine(productInfo);

            // 3. Pattern matching
            SwitchPattern.GetRainbowColor1(SwitchPattern.Rainbow.Red);
            PropertyPattern.GetTax(new PropertyPattern.Address { State = "MN", ZipCode = "100" });
            TuplePattern.RockPaperScissors(Rock, Paper);
            TuplePattern.RockPaperScissors(new TuplePattern.RockPaperScissorsCombine());

            //4. Using declarations
            UsingDeclaration.WriteLinesToFile();
            var result = await UsingDeclaration.DisosableObjManager.GetName();

            //5. Static local functions
            new StaticLocalFunctions().Fun();


            Console.ReadKey();

        }
    }
}
