using System.Text.Json;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http.Connections;
using VotingApp.Api.Hubs;
using VotingApp.Application;
using VotingApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(containerBuild =>
{
    containerBuild.RegisterModule(new InfrastructureModule());
    containerBuild.RegisterModule(new ApplicationModule());
}));

builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
    options.KeepAliveInterval = TimeSpan.FromMinutes(1);
}).AddJsonProtocol(options => { options.PayloadSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; });
;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<VotingResultHub>("/votingResults", options =>
    {
        options.Transports =
            HttpTransportType.WebSockets |
            HttpTransportType.LongPolling;
    });
    endpoints.MapControllers();
});

app.Run();

public partial class Program
{
}
