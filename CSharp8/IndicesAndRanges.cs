using System;
using System.Collections.Generic;

namespace CSharp8
{
    public class IndicesAndRanges
    {
        readonly string[] words = new string[]
        {
                        // index from start    index from end
            "1",        // 0                   ^9
            "2",        // 1                   ^8
            "3",        // 2                   ^7
            "4",        // 3                   ^6
            "5",        // 4                   ^5
            "6",        // 5                   ^4
            "7",        // 6                   ^3
            "8",        // 7                   ^2
            "9"         // 8                   ^1
        };              // 9 (or words.Length) ^0

        

        public void Demo()
        {
            // End operator ^
            // Range operator ..


            // Valid
            var result = words[0];
            var result1 = words[..];
            var result2 = words[1..];
            var result3 = words[..4];
            var result4 = words[1..^0];
            var result5 = words[4..^1];

            // Invalid
            var result6 = words[4..1];
            var result0 = words[^0];


            // Variables
            var nine = 1;
            var result7 = words[nine];
            var range = 1..4;
            var result8 = words[range];

            // Others
            List<int> list = new List<int> { 1, 2, 3 };
            var test = list[^1];
            //var test0 = list[1..2];

            var myCollection = new MyCollection();
            var test2 = myCollection[1];
            var test3 = myCollection[0..2];

        }
    }

    #region Implicit Index support 

    public class MyCollection
    {
        private int[] _array = new[] { 1, 2, 3 };
        
        public int Length
        {
            get
            {
                Console.Write("Length ");
                return _array.Length;
            }
        }

        // Implicit Index support
        public int this[int index] => _array[index];

        // Implicit Range support
        public int[] Slice(int start, int length)
        {
            var slice = new int[length];
            Array.Copy(_array, start, slice, 0, length);
            return slice;
        }
    }

    #endregion

}
