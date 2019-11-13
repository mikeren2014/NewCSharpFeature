using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp8
{
    public class AsynchronousStreams
    {
        #region What's Iterator

        public IEnumerable<int> GetNumbers()
        {
            var list = new List<int>();
            for (var i = 0; i <= 20; i++)
                list.Add(i);
            return list;
        }

        public IEnumerable<int> GetNumbers2()
        {
            for (var i = 1; i <= 20; i++)
                yield return i;
        }

        public void Demo()
        {
            foreach (var item in GetNumbers())
                Console.WriteLine(item);
        }
        #endregion

        #region Asynchronous

        public async Task<IEnumerable<int>> GetNumbersAsync()
        {
            var list = new List<int>();
            for (var i = 0; i <= 20; i++)
            {
                await Task.Delay(0);
                list.Add(i);
            }
            return list;
        }

        public async IAsyncEnumerable<int> GetNumbersAsync2()
        {
            for (var i = 0; i <= 20; i++)
            { 
                await Task.Delay(0);
                yield return i;
            }
        }

        public async Task DemoAsync()
        {
            foreach (var item in await GetNumbersAsync())
                Console.WriteLine(item);

            await foreach (var item in GetNumbersAsync2())
                Console.WriteLine(item);
        }

        #endregion

    }
}
