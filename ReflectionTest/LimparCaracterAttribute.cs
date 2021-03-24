using System;

namespace ReflectionTest
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class LimparCaracterAttribute : Attribute
    {
    }
}
