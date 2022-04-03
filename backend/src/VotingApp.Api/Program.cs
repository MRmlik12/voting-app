using Autofac;
using Autofac.Extensions.DependencyInjection;
using VotingApp.Infrastructure;
using VotingApp.Application;
using Vulder.SharedKernel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDefaultCorsPolicy();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory((containerBuild) =>
{
    containerBuild.RegisterModule(new InfrastructureModule());
    containerBuild.RegisterModule(new ApplicationModule());
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CORS");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program{}
