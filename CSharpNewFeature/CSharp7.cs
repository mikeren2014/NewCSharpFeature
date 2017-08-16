using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpNewFeature
{
    class Customer
    {
        //Tuples Install-Package System.ValueTuple
        public void Tuples()
        {
            var oldTuples = new Tuple<string, string>("FirstName", "LastName");
            var newTuples = ("FirstName", "LastName");
            //Both of above two varialbes can be accessed by 
            Console.WriteLine($"{oldTuples.Item1}{oldTuples.Item2}");
            Console.WriteLine($"{newTuples.Item1}{newTuples.Item2}");

            (string first, string last) betterTuples = ("FirstName", "LastName");
            Console.WriteLine($"{betterTuples.first}{betterTuples.last}");

            var betterTuples2 = (first: "FirstName", last: "LastName");
            Console.WriteLine($"{betterTuples2.first}{betterTuples2.last}");
        }

        private (int Max, int Min) Range(IEnumerable<int> numbers)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            foreach (var n in numbers)
            {
                min = (n < min) ? n : min;
                max = (n > max) ? n : max;
            }
            return (max, min);
        }

        private void Caller()
        {
            var members = new List<int> { 1, 2, 3 };
            var range = Range(members);
            //Unpack the tuple or called deconstructing 
            (int min, int max) = Range(members);
            Console.WriteLine($"The minimum value is {min}, the maximum value is {max}");

            (var min2, var max2) = Range(members);
            Console.WriteLine($"The minimum value is {min2}, the maximum value is {max2}");

            var (min3, max3) = Range(members);
            Console.WriteLine($"The minimum value is {min3}, the maximum value is {max3}");

            var p = new Person("Althea", "Goodwin");
            var (first, last) = p;
        }

        //Out
        public void OldOut()
        {
            int result = 0;
            var input = "10";
            if (int.TryParse(input, out result))
                Console.WriteLine($"ok, the value is {result}");

        }
        public void NewOut(string input)
        {
            if (int.TryParse(input, out var result))
                Console.WriteLine($"ok, the value is {result}");
            Console.WriteLine($"{result}");
        }

        //Pattern matching
        public void TypePatternMatching()
        {
            object[] objs = { new Person("Mike", "Ren") };
            foreach (var obj in objs)
            {
                //Old way
                var person2 = obj as Person;
                if (person2 != null)
                {
                    Console.WriteLine($"{person2.FirstName}");
                }

                //New feature: Type patten
                if (obj is Person person)
                    Console.WriteLine($"{person.FirstName}");
            }
        }

        public void ConsotPatternMatching()
        {
            //integral types: ==
            //Otherwise, call to Object.Equals
            const double PI = 3.14;
            var value = new Random().NextDouble();
            if (value is PI)
            {
                Console.WriteLine("OK");
            }
        }

        public void VarPatternMatching()
        {
            object p = null;
            if (p is var obj)
            {
                Console.WriteLine("true");
            //{
            //    Console.WriteLine($"{p.GetType().Name}, value: {p}");
            //    Console.WriteLine($"{obj.GetType().Name}, value: {obj}");
            }
        }

        public void SwitchPattern(object o)
        {
            //The order will matter
            switch (o)
            {
                case null:
                    Console.WriteLine("it's a constant pattern");
                    break;
                case int i:
                    Console.WriteLine("it's an int");
                    break;
                case Person p when p.FirstName.StartsWith("Ka"):
                    Console.WriteLine($"a Ka person {p.FirstName}");
                    break;
                case Person p:
                    Console.WriteLine($"any other person {p.FirstName}");
                    break;
                case var x:
                    Console.WriteLine($"it's a var pattern with the type {x?.GetType().Name} ");
                    break;
                default:
                    break;
            }
        }

        //Discards
        public void TryDiscard()
        {
            //Deconstruce
            var p = new Person("Althea", "Goodwin");
            var (first, _) = p;

            //var a = _; Invalid
            //var _ = "aa";
            //Console.WriteLine(_);

            // is/switch
            if (p is Person _)
            {
                Console.WriteLine("This object is person");
            }
        }

        public void StandaloneDiscard(string _)
        {
            Console.WriteLine(_);
        }

        //ref local
        //Limitations:
        //ref int i = sequence.Count(); not valid
        //Variable scope
        int[] mumbers = { 1, 2, 3, 4 };
        public void UpdateRefValue()
        {
            ref var value = ref FindValue(1);
            value = 10;
            //Console.WriteLine(mumbers[0]);
        }


        public ref int FindValue(int value)
        {
            for (int i = 0; i < mumbers.Length; i++)
            {
                if (mumbers[i] == value)
                    return ref mumbers[i];
            }
            throw new InvalidOperationException("Not found");
        }

        public void RefOut(ref int n1)
        {
            n1 = 10;
        }

        //Local functions
        public async Task FooCaller()
        {
            Console.WriteLine($"FooCaller begins:{Thread.CurrentThread.ManagedThreadId}");
            var task = Foo2("a");
            Console.WriteLine($"FooCaller continues:{Thread.CurrentThread.ManagedThreadId}");
            await task;
            Console.WriteLine($"Task ends:{Thread.CurrentThread.ManagedThreadId}");
        }

        public async Task Foo(string name)
        {
            Console.WriteLine($"Foo begins!Thread:{Thread.CurrentThread.ManagedThreadId}");
            if (name == "a")
                throw new Exception();
            await Task.Delay(10000);
            Console.WriteLine($"Foo finished!Thread:{Thread.CurrentThread.ManagedThreadId}");
        }

        public Task Foo2(string name)
        {
            Console.WriteLine($"Foo begins!Thread:{Thread.CurrentThread.ManagedThreadId}");
            if (name == "a")
                throw new Exception();
            return LocalFoo();

            async Task LocalFoo()
            {
                await Task.Delay(10000);
                Console.WriteLine($"Foo finished!Thread:{Thread.CurrentThread.ManagedThreadId}");
            }
        }

        //expression-bodied members
        private string lable;
        public string Lable
        {
            get => lable;
            set => this.lable = value ?? "Default Value";
        }

        public Customer(string lable) => this.lable = lable;

        public Customer()
        {
        }

        ~Customer() => Console.WriteLine("Finalized");

        //Throw expressions
        //statement vs expression vs operator
        private string name;
        public string Name
        {
            get => name;
            set => name = value ??
                throw new ArgumentNullException(paramName: nameof(value), message: "New name must not be null");
        }

        //Generalized async return types
        //Install-Package System.Threading.Tasks.Extensions
        public ValueTask<int> AsyncReturnTypes()
        {
            var cachedValue = 100;
            var useCache = true;
            var value = useCache ? new ValueTask<int>(cachedValue) : new ValueTask<int>(GetValue());
            return value;


            async Task<int> GetValue()
            {
                await Task.Delay(0);
                return 10;
            }
        }

        //Numeric literal syntax improvements
        public void Numbers()
        {
            int One = 0b0001;
            int Two = 0b0010;
            int Four = 0b0100;
            int Eight = 0b1000;
            Console.WriteLine($"One:{One} Two:{Two} Four:{Four} Eight:{Eight}");

            int Sixteen = 0b0001_0000;
            int ThirtyTwo = 0b0010_0000;
            int SixtyFour = 0b0100_0000;
            int OneHundredTwentyEight = 0b1000_0000;
            Console.WriteLine($"Sixteen:{Sixteen} ThirtyTwo:{ThirtyTwo} SixtyFour:{SixtyFour} OneHundredTwentyEight:{OneHundredTwentyEight}");

            long BillionsAndBillions = 1000_00_000_000;
            double AvogadroConstant = 6.022_140_857_747_474e23;
            Console.WriteLine($"BillionsAndBillions:{BillionsAndBillions} AvogadroConstant:{AvogadroConstant}");

        }
    }



    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Person(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }

        //Can even be extension method
        public void Deconstruct(out string firstName, out string lastName)
        {
            firstName = FirstName;
            lastName = LastName;
        }

        public override string ToString()
        {
            return this.FirstName;
        }
    }
}
