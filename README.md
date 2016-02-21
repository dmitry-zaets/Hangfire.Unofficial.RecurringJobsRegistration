# Hangfire Unofficial Recurring Jobs Registration
**Unofficial** extension for dynamic registration of recurring jobs.

Have a lot of recurring jobs which are running in same perios of time?
Want to register all of them in one place?

It's easy!

###Usage:

####Create a job which will recurr hourly by implementing interface ```IHourlyRecurringJob```:
```
namespace App.Web
{
    public class MyJob: IHourlyRecurringJob
    {
      public void Run() {
        //Do the job.
      }
    }
}
```
####Create a new recurring job type by creating new interface derived from ```IRecurringJob```:
```
namespace App.Web
{
    public interface IMidnightRecurringJob : IRecurringJob { }
}
```
####Create jobs by implementing interface ```IMidnightRecurringJob```: 
```
namespace App.Web
{
    public class MyMidnightJob1: IMidnightRecurringJob
    {
      public void Run() {
        //Do the job.
      }
    }
    
    public class MyMidnightJob2: IMidnightRecurringJob
    {
      public void Run() {
        //Do the job.
      }
    }
    
    public class MyMidnightJob3: IMidnightRecurringJob
    {
      public void Run() {
        //Do the job.
      }
    }
}
```
####Add all jobs by registering interfaces at start of your application, for example in Owin Startup class:
```
[assembly: OwinStartup(typeof(App.Web.Startup))]
namespace App.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          // Configurations of your app...
          
          // When all parts are configured - it's time to register jobs.
          RecurringJobsRegistration.Register<IHourlyRecurringJob>(Cron.Hourly());
          RecurringJobsRegistration.Register<IMidnightRecurringJob>("0 0 * * *");
          
        }
    }
}
```
