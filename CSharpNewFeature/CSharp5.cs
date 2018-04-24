using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpNewFeature
{
    class CSharp5
    {
        public void Caller()
        {
            var result = AddAsync(1, 2);
            result.ContinueWith(a =>
            {
                Console.WriteLine(a.Result);
            });
        }

        public async Task Caller2()
        {
            var result = await AddAsync(1, 2).ConfigureAwait(false);
            Console.WriteLine(result);
        }

        public void Caller3()
        {
            //var result = AddAsync(1, 2).Result;
            var result = AddAsync(1, 2).GetAwaiter().GetResult();
            Console.WriteLine(result);
        }

        public async Task Caller4()
        {
            var t1 = AddAsync(1, 2);
            var t2 = DoSomethingAsync();
            await Task.WhenAll(t1, t2);

            //var result1 = await t1.Result; 
            var result1 = await t1;
            Console.WriteLine(result1);
        }

        private Task<int> AddAsync(int a, int b)
        {
            return Task.Run<int>(() =>
            {
                Thread.Sleep(3000);
                return a + b;
            });
        }

        private async Task DoSomethingAsync()
        {
            await Task.Delay(1000);
        }

    }
}
