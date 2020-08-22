using System;

namespace MG64Lib.Attributes
{
    public class InternalNameAttribute : Attribute
    {
        public string Name { get; private set; }

        public InternalNameAttribute(string name)
        {
            Name = name;
        }
    }
}
