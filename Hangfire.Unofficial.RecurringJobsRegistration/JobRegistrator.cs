namespace Hangfire.Unofficial.RecurringJobsRegistration
{
    public static class JobRegistrator<TJob> where TJob : IJob
    {
        public static void RegisterAsRecurring(string jobName, string cronExpression)
        {
            RecurringJob.AddOrUpdate<TJob>(jobName, job => job.Run(), cronExpression);
        }

        public static void Register()
        {
            BackgroundJob.Enqueue<TJob>(job => job.Run());
        }
    }
}
