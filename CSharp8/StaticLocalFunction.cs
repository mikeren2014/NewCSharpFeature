using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8
{
    public class StaticLocalFunction
    {
        public int Func()
        {
            int y = 5;
            int x = 7;
            return Add();

            static int Add() => x + y;
        }

        int M()
        {
            int y = 5;
            int x = 7;
            return Add(x, y);

            static int Add(int left, int right) => left + right;
        }
    }
}
