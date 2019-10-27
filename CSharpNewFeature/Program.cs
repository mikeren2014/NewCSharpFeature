using System;
using System.Collections.Generic;
using System.Globalization;
using static System.DateTime;
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
                const string format = "MM/dd/yyyy hh:mm:ss.ff tt";
                var now = DateTime.UtcNow.ToString(format, CultureInfo.InvariantCulture);
                var test = ParseExact(now, format, System.Globalization.CultureInfo.CurrentCulture);
                //var cus = new CSharp5();
                //cus.Caller();
                Console.WriteLine("End");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();

        }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Distance => Math.Sqrt(X * X + Y * Y);

        public override string ToString() =>
            $"({X}, {Y}) is {Distance} from the origin";
    }
}
