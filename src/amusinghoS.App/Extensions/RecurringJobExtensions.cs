using amusinghoS.Redis;
using Hangfire;

namespace amusinghoS.App.Extensions
{
    public static class RecurringJobExtensions
    {
        public static void AddRecurringJobs()
        {
            RecurringJob.AddOrUpdate(() => DataSynchronize.SynchronizeAsync(), Cron.Minutely());
        }
    }
}
