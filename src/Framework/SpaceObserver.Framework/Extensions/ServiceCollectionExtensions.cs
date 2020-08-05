namespace SpaceObserver.Framework.Extensions
{
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services, params Type[] types)
        {
            services.AddMediatR(types);
            return services;
        }
    }
}
