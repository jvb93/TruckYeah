using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TruckYeah.Services;

namespace TruckYeah
{
    public static class Startup
    {
        public static IHost BuildHost()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddScoped<IProgramDriver, ProgramDriver>();
                    services.AddScoped<IFileReaderService, FileReaderService>();
                    services.AddScoped<IValidatorService, ValidatorService>();
                    services.AddScoped<IScoringService, ScoringService>();
                })
                .Build();
        }
    }
}