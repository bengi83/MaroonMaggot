using Autofac;
using MaroonMaggot.Core.Interfaces;
using MaroonMaggot.Core.Services;

namespace MaroonMaggot.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ToDoItemSearchService>()
                .As<IToDoItemSearchService>().InstancePerLifetimeScope();
        }
    }
}
