using WorkSync.Application.Interfaces;
using WorkSync.Application.Services;
using WorkSync.Domain.CommandHandlers;
using WorkSync.Domain.Commands;
using WorkSync.Domain.Core.Bus;
using WorkSync.Domain.Core.Events;
using WorkSync.Domain.Core.Notifications;
using WorkSync.Domain.EventHandlers;
using WorkSync.Domain.Events;
using WorkSync.Domain.Interfaces;
using WorkSync.Domain.Providers.Crons;
using WorkSync.Domain.Providers.Http;
using WorkSync.Domain.Providers.Hubs;
using WorkSync.Domain.Providers.Mail;
using WorkSync.Domain.Providers.Office;
using WorkSync.Domain.Providers.Webhooks;
using WorkSync.Infra.CrossCutting.Bus;
using WorkSync.Infra.CrossCutting.Identity.Authorization;
using WorkSync.Infra.CrossCutting.Identity.Models;
using WorkSync.Infra.CrossCutting.Identity.Services;
using WorkSync.Infra.Data.EventSourcing;
using WorkSync.Infra.Data.Repository;
using WorkSync.Infra.Data.Repository.EventSourcing;
using WorkSync.Infra.Data.UoW;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace WorkSync.Infra.CrossCutting.IoC;

public class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        // ASP.NET HttpContext dependency
        services.AddHttpContextAccessor();

        // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        // Domain Bus (Mediator)
        services.AddScoped<IMediatorHandler, InMemoryBus>();

        // ASP.NET Authorization Polices
        services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

        // Application
        services.AddScoped<ICustomerAppService, CustomerAppService>();

        // Domain - Events
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
        services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
        services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

        // Domain - Commands
        services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, bool>, CustomerCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateCustomerCommand, bool>, CustomerCommandHandler>();
        services.AddScoped<IRequestHandler<RemoveCustomerCommand, bool>, CustomerCommandHandler>();

        // Domain - Providers, 3rd parties
        services.AddScoped<IHttpProvider, HttpProvider>();
        services.AddScoped<IMailProvider, MailProvider>();
        services.AddScoped<INotificationProvider, NotificationProvider>();
        services.AddScoped<IWebhookProvider, WebhookProvider>();
        services.AddScoped<ICronProvider, CronProvider>();
        services.AddScoped<IOfficeProvider, OfficeProvider>();

        // Infra - Data
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Infra - Data EventSourcing
        services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
        services.AddScoped<IEventStore, SqlEventStore>();

        // Infra - Identity Services
        services.AddTransient<IEmailSender, AuthEmailMessageSender>();
        services.AddTransient<ISmsSender, AuthSMSMessageSender>();

        // Infra - Identity
        services.AddScoped<IUser, AspNetUser>();
        services.AddSingleton<IJwtFactory, JwtFactory>();
    }
}
