using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Roger.Framework.CQRS;
using Roger.Framework.CQRS.Bus;
using Roger.Framework.CQRS.Message;
using Roger.Framework.CQRS.Models;
using Roger.Framework.DomainDrivenDesign.CrossCutting;
using Roger.Framework.DomainDrivenDesign.Domain.Engine;
using Roger.Framework.DomainDrivenDesign.Domain.UnityOfWork;
using Roger.Framework.DomainDrivenDesign.Infra.CQRS;
using Roger.Framework.DomainDrivenDesign.Infra.DataTransferObjects;
using Roger.Framework.DomainDrivenDesign.Web.Filters;
using Roger.Framework.Web.Filters;
using Roger.ParseTheParcel.Application.Interface;
using Roger.ParseTheParcel.Application.Services;
using Roger.ParseTheParcel.Domain.Models.Package.Commands;
using Roger.ParseTheParcel.Domain.Models.Package.Commands.CommandHandlers;
using Roger.ParseTheParcel.Domain.Models.Package.Events;
using Roger.ParseTheParcel.Domain.Models.Package.Repository;
using Roger.ParseTheParcel.Domain.Models.PackageCost.Events.EventHandlers;
using Roger.ParseTheParcel.Infra.Data.Context;
using Roger.ParseTheParcel.Infra.Data.Repository;

namespace Roger.ParseTheParcel.Infra.CrossCutting.IoC
{
    /// <summary>
    /// Register services needed to run the application
    /// </summary>
    public class DependencyInjector
    {
        /// <summary>
        /// Register services needed to run the application
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(IServiceCollection services)
        {
            AddAppInfrastructure(services);
            AddMemoryHandlers(services);
            AddAppServices(services);
            AddRepositories(services);
        }

        /// <summary>
        /// Technical resources for application operation, low-level application frameworks
        /// </summary>
        /// <param name="services"></param>
        private static void AddAppInfrastructure(IServiceCollection services)
        {
            // List of registered services for the dependency injection container. Using InMemoryBus
            services.AddSingleton(services);

            // Obtain single instance of infra-centralized resources
            services.AddScoped<IUnityOfWork, UnityOfWork<ParseTheParcelContext>>();
            services.AddScoped<IAppEngine, AppEngine>();
            services.AddScoped<ISessionUser, SessionUser>();

            // Integrations / Web APIs
            services
                .AddScoped<IApiActionExceptionFilterResultResolver, ApiActionExceptionFilterResultDefaultResolver>();

            // Bus
            services.AddScoped<IInMemoryBus, InMemoryBus>();
            services.AddScoped<IQueryBus, InMemoryBus>();
            services.AddScoped<ICommandBus, InMemoryBus>();
            services.AddScoped<IRemoteBus, AmqpBus>();

            // Bus - Messaging AMQP - Singleton to maintain the same connection connection with the RabbitMQ server.
            // The AMQP protocol connection supports multiple isolated channels running simultaneously, it is recommended to use a single connection for the entire application.
            // Start new TCP / IP connections is defective for the operating system

            services.AddSingleton<IPublishMessageBusConfigurations, PublishMessageBusConfigurations>();

            // AutoMapper
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(c => new Mapper(c.GetRequiredService<IConfigurationProvider>(), c.GetService));
        }

        /// <summary>
        /// Responsible handlers for performing write interactions with the database.
        /// Core application business, add your business rule handlers that must be processed within the context of the final system running information
        /// </summary>
        /// <param name="services"></param>
        private static void AddMemoryHandlers(IServiceCollection services)
        {
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<PackageCostQueryCommand, PackageCostQueryCommandResponse>, PackageCommanndHandler>();
            services.AddScoped<IHandler<PackageCostQueryEvent>, PackageEventHandler>();
        }

        /// <summary>
        /// Query services for information
        /// </summary>
        /// <param name="services"></param>
        private static void AddAppServices(IServiceCollection services)
        {
            services.AddScoped<IShippingAppService, ShippingAppService>();
        }

        /// <summary>
        /// Repositories responsible for providing / saving application data
        /// /// </summary>
        /// <param name="services"></param>
        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<ParseTheParcelContext>();

            services.AddScoped<IPackageReadRepository, PackageReadRepository>();
            services.AddScoped<IPackageWriteRepository, PackageWriteRepository>();
        }
    }
}