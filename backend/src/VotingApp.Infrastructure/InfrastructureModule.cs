using Autofac;
using VotingApp.Infrastructure.Redis;
using Module = Autofac.Module;

namespace VotingApp.Infrastructure;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule(new RedisModule());
    }
}
