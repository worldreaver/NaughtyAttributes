using System;

namespace NaughtyAttributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class NamedArrayAttribute : DrawerAttribute
    {
        public readonly string[] names;

        public NamedArrayAttribute(string[] names)
        {
            this.names = names;
        }

        public NamedArrayAttribute(Type enumType)
        {
            names = Enum.GetNames(enumType);
        }
    }
}