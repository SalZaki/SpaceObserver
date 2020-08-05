namespace SpaceObserver.Framework.Bus.Extensions
{
    using Domain;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainCommandDispatcher(this IServiceCollection services)
        {
            services.Replace(ServiceDescriptor.Singleton<IDomainCommandDispatcher, DomainCommandDispatcher>());
            return services;
        }
    }
}