using System;

namespace CSharp8
{
    public class NullCoalescingAssignment
    {
        public string _name;

        public void SetName(string name)
        {
            if (_name == null)
                _name = name;
        }

        // C# 7.0
        public void SetName2(string name) =>
            _name ??= name;

        // C# 8.0
        public void SetName3(string name) =>
            throw new NotImplementedException();
    }
}
