using System;
using static System.String;
using static System.Math;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpNewFeature
{
    class Student
    {
        //Initializers for auto-properties, note "This" (mutable and immutable types)
        public string FirstName { get; set; } = "Mingjin";

        private string name2;
        public string Name2
        {
            get => name2;
            set => name2 = value;
        }

        //Getter-only auto-properties
        public string LastName { get; } = "Ren";

        public string Name { get; }

        //Assign value in contructor
        public Student(string first, string last)
        {
            Name = first + last;
        }

        public void OutputName(string first, string last)
        {
            //This is not legal
            //Name = first + last;
        }

        //Expression-bodied function members
        public void SayHello1(string name)
        {
            Console.WriteLine($"Hello,{name}");
        }
        public void SayHello(string name) => Console.WriteLine($"Hello,{name}");
        public int Add(int n1, int n2) => n1 + n2;

        //Expression bodies on property-like function members
        public string Name3
        {
            get { return FirstName + LastName; }
        }
        public string Name4 => FirstName + LastName;

        //Using static
        public string EmptyString => Empty;
        public int GetAbs(int value)
        {
            return Abs(value);
        }

        //Null-conditional operators
        public string GetName(Student stu)
        {
            //return stu == null? Null: stu.Name;
            return stu?.Name;
        }

        //String interpolation
        public void SelfIntroduce()
        {
            Console.WriteLine($"Hello, this is {Name}");
        }

        //nameof expressions
        public void DoSomething1()
        {
            if (Name == null)
                Console.WriteLine($"{nameof(Name)} is null");
            throw new Exception(nameof(DoSomething1));
        }

        //Index initializers
        public void ConstructDic()
        {
            var numbers = new Dictionary<int, string>
            {
                { 2, "Two"},
                { 3, "Tree"}
            };
            var numbers2 = new Dictionary<int, string>
            {
                [2] = "Two",
                [3] = "Tree"
            };

            var students = new Dictionary<string, Student>
            {
                ["Zhang"] = new Student("Zhang", "San"),
                ["Wang"] = new Student("Wang", "Wu"),
                //[2] = new Student("","") Invalid
            };
        }

        public Task DoSomethingAsync()
        {
            return Task.Run(() => { });
        }

        //Exception Filter
        public bool HandleSomeException(Exception ex)
        {
            if (ex.Message == "something")
            {
                //Log(ex.Message);
                return false;
            }
            return true;
        }

        //Await in catch and finally blocks
        public async Task TryCatchBlock()
        {
            try
            {
                await DoSomethingAsync();
            }
            catch (Exception ex) when (HandleSomeException(ex))
            {
                await DoSomethingAsync();
                throw;
            }
            finally
            {
                await DoSomethingAsync();
            }
        }


    }
}
