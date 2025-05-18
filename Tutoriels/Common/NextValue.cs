using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class NextValueAttribute : Attribute
    {
        private readonly string _value;

        public NextValueAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }

    public static class NextEnum
    {
        public static string GetNextValue(this System.Enum value)
        {
            string output = null;
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            NextValueAttribute[] attrs = fi.GetCustomAttributes(typeof(NextValueAttribute), false) as NextValueAttribute[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }
            return output;
        }
    }

}
