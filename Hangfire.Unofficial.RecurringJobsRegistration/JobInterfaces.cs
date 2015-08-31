namespace Hangfire.Unofficial.RecurringJobsRegistration
{
    public interface IJob
    {
        void Run();
    }
    public interface IRecurringJob : IJob { }
    public interface IMinutelyRecurringJob : IRecurringJob { }
    public interface IHourlyRecurringJob : IRecurringJob { }
    public interface IDailyRecurringJob : IRecurringJob { }
}
