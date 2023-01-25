using Microsoft.Extensions.DependencyInjection;
using TruckYeah.Services;

namespace TruckYeah
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var serviceHost = Startup.BuildHost())
            {
                // dependency injection because I am a real enterprise developer
                using (var scope = serviceHost.Services.CreateScope())
                {
                    var serviceProvider = scope.ServiceProvider;
                    serviceProvider.GetService<IProgramDriver>().Run();
                }
            }
        }
    }
}