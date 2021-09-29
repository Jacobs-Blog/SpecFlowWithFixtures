using System;
using Microsoft.Extensions.Configuration;

namespace SpecFlowWithFixtures.Specs.Fixtures
{
    public class SettingsFixture : IDisposable
    {
        public readonly AppSettings AppSettings;

        public SettingsFixture()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.local.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            AppSettings = new AppSettings
            {
                BaseAddress = configuration["AppSettings:BaseAddress"]
            };
        }

        public void Dispose()
        {
        }
    }
}