using Microsoft.Extensions.DependencyInjection;
using TruckYeah.Services;
using Xunit;

namespace TruckYeah.Tests.Services
{
    public class StartupTests
    {
        [Fact]
        public void Startup_Should_Init_Services()
        {
            // Arrange-Act
            var host = Startup.BuildHost();

            // Assert
            using (var serviceHost = host)
            {
                using (var scope = serviceHost.Services.CreateScope())
                {
                    var serviceProvider = scope.ServiceProvider;
                    Assert.NotNull(serviceProvider.GetService<IProgramDriver>());
                    Assert.NotNull(serviceProvider.GetService<IValidatorService>());
                    Assert.NotNull(serviceProvider.GetService<IScoringService>());
                    Assert.NotNull(serviceProvider.GetService<IFileReaderService>());
                }
            }
        }
    }
}