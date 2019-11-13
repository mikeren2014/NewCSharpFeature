using NullableProject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp8
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 0. Support 3.0

            // 1. Readonly members
            new Point { X = 1, Y = 2 };

            // 2. Default interface methods
            new ProductManager();

            // 3. Pattern matching
            new PatternMatching();

            //4. Using declarations
            new UsingDeclaration();

            //5. Static local functions
            new StaticLocalFunction();

            // 6. NullableProject
            new NullableReferenceType();

            // 7. Asynchronous streams
            new AsynchronousStreams();

            // 8. Null-coalescing assignment
            new NullCoalescingAssignment();

            // Enhancement of interpolated verbatim strings
            new StringFormatter();

            // Indices and ranges
            new IndicesAndRanges();

            await Task.Delay(0);

            Console.ReadKey();

        }
    }
}
