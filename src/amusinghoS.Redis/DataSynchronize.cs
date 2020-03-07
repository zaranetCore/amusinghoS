using System.Threading.Tasks;

namespace amusinghoS.Redis
{
    //Redis and database data consistency synchronization dispatched by Hangfire
    public static class DataSynchronize
    {
        public static async Task SynchronizeAsync()
        {
            await Task.Run(() =>
            {
                System.Console.WriteLine("呵呵哒");
            });
        }
    }
}
