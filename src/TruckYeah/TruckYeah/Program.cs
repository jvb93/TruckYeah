using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TruckYeah.Services;

namespace TruckYeah
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var serviceHost = Startup.BuildHost())
            {
                using (var scope = serviceHost.Services.CreateScope())
                {
                    var serviceProvider = scope.ServiceProvider;
                    serviceProvider.GetService<IProgramDriver>().Run();
                }
            }
        }
    }
}