using Autofac;
using VotingApp.Infrastructure.Redis.Interfaces;
using VotingApp.Infrastructure.Redis.Repositories;
using Module = Autofac.Module;

namespace VotingApp.Infrastructure.Redis;

public class RedisModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<RedisContext>()
            .InstancePerLifetimeScope();

        builder.RegisterType<VoteRepository>()
            .As<IVoteRepository>()
            .InstancePerLifetimeScope();
    }
}
