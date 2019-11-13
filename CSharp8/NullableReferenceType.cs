using NullableProject;
using System;
using System.Collections.Generic;

namespace CSharp8
{
    public class NullableReferenceType
    {
#nullable enable

        public List<int> Ids { get; set; }

        public List<int>? Ids2 { get; set; }


        public string Name { get; set; }

        // Nullable Reference Project
        public Canvas Canvas { get; set; }

        public NullableReferenceType()
        {
            Ids = new List<int>();
            Name = string.Empty;
            Canvas = new Canvas("Test");
        }

        public void DoSomething()
        {
            //if (!(Canvas is null))
            Console.WriteLine(Canvas.Name);
        }

#nullable restore

    }


}
