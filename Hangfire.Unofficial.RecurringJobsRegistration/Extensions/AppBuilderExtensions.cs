using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangfire.Unofficial.RecurringJobsRegistration.Extensions
{
    public static class RecurringJobsRegistration
    {
        public static void Register<TRecurringJob>(string cronExpression) where TRecurringJob : IRecurringJob
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                                               .SelectMany(_ => _.GetImplementationTypesByBase(typeof(TRecurringJob)));
            RegisterRecurringJobsByType<TRecurringJob>(types, cronExpression);
        }

        private static void RegisterRecurringJobsByType<TRecurringJob>(IEnumerable<Type> jobTypes, string cronExpression) where TRecurringJob : IRecurringJob
        {
            var type = typeof(TRecurringJob);
            foreach (var jobType in jobTypes)
            {
                if (type.IsAssignableFrom(jobType))
                {
                    RegisterRecurringJob(jobType, cronExpression);
                }
            }
        }

        private static void RegisterRecurringJob(Type jobType, string cronExpression)
        {
            var registratorType = typeof(JobRegistrator<>).MakeGenericType(jobType);
            var method = registratorType.GetMethod("RegisterAsRecurring");
            method.Invoke(null, new object[] { jobType.Name, cronExpression });
        }
    }
}
