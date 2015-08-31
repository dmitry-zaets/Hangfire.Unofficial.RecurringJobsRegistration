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
            var types = assembly.GetTypes();
            return types.Where(t => type.IsAssignableFrom(t) && t.IsClass).ToList();
        }
    }
}
