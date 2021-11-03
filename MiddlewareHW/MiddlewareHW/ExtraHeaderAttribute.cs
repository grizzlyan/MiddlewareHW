using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareHW
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class ExtraHeaderAttribute : Attribute
    {
        public ExtraHeaderAttribute(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; }
        public string Value { get; }
    }
}
