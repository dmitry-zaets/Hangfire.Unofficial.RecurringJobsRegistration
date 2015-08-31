# Hangfire.Unofficial.RecurringJobsRegistration
**Unofficial** extension for dynamic registration of recurring jobs.

Have a lot of recurring jobs which are running in same perios of time?
Want to register all of them in one place?

It's easy!

###Usage:

Create a job which will recurr hourly by implementing interface ```IHourlyRecurringJob```:
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
Register all jobs by registering interface at start of your application, for example in Owin Startup class:
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
        }
    }
}
```
