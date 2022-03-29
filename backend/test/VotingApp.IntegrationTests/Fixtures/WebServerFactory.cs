using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace VotingApp.IntegrationTests.Fixtures;

public class WebServerFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        Environment.SetEnvironmentVariable("REDIS_CONNECTION_STRING", "localhost");

        builder.UseEnvironment("Production");
    }
}
