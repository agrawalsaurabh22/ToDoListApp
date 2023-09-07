using Autofac;
using Autofac.Integration.Mvc;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using System.Web.Mvc;
using ToDoList.ApplicationCore.Feature.ToDoListFeature.Handler;
using ToDoList.Domain.Repository.Interface;
using ToDoList.Infrastructure.DbProvider;
using ToDoList.Infrastructure.Interface;
using ToDoList.Infrastructure.Repository;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;

namespace ToDoList
{
    public static class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            var configuration = MediatRConfigurationBuilder.Create(typeof(CreateToDoListItemHandler).Assembly)
            .WithAllOpenGenericHandlerTypesRegistered()
            .Build();

            builder.RegisterMediatR(configuration);

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            
            builder.RegisterType<DbConnectionFactory>().As<IDbConnectionFactory>();
            builder.RegisterType<ToDoListRepository>().As<IToDoListRepository>();

            var container = builder.Build();

            container.Resolve<IMediator>();
            container.Resolve<IDbConnectionFactory>();
            container.Resolve<IToDoListRepository>();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}