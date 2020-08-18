using System;
using System.Linq;

namespace MG64Lib.Extensions
{
    public static class AttributeExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum e) where TAttribute : Attribute
        {
            var type = e.GetType();
            var name = Enum.GetName(type, e);
            if (name == null)
            {
                return null;
            }
            return type.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().Single();
        }
    }
}
