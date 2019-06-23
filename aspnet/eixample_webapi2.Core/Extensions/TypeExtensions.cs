using System;
using System.Reflection;

namespace eixample_webapi2.Extensions
{
    public static class TypeExtensions
    {
        public static Assembly GetAssembly(this Type type)
        {
            var result = type.GetTypeInfo().Assembly;
            return result;
        }
    }
}
