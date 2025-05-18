using System.Reflection;

namespace Common
{
    public class TypeValueAttribute : Attribute
    {
        private readonly Type _value;

        public TypeValueAttribute(Type value)
        {
            _value = value;
        }

        public Type Value
        {
            get { return _value; }
        }
    }

    public static class TypeEnum
    {
        public static Type GetTypeValue(this System.Enum value)
        {
            Type output = null;
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            TypeValueAttribute[] attrs = fi.GetCustomAttributes(typeof(TypeValueAttribute), false) as TypeValueAttribute[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }
            return output;
        }
    }

}
