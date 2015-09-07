using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Hangfire.Unofficial.RecurringJobsRegistration.Extensions
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetImplementationTypesByBase(this Assembly assembly, Type type)
        {
            var types = assembly.GetLoadableTypes();
            return types.Where(t => type.IsAssignableFrom(t) && t.IsClass).ToList();
        }

        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }
    }
}
