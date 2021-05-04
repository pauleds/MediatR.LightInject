namespace MediatR.LightInject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using global::LightInject;

    public static class ServiceContainerExtensions
    {
        /// <summary>
        /// Registers handlers and mediator types from the executing assembly
        /// </summary>
        /// <param name="services">Service container</param>
        /// <returns>Service container</returns>
        public static ServiceContainer AddMediatR(this ServiceContainer services)
            => services.AddMediatR(Assembly.GetExecutingAssembly());

        /// <summary>
        /// Registers handlers and mediator types from the specified assemblies
        /// </summary>
        /// <param name="services">Service container</param>
        /// <param name="assemblies">Assemblies to scan</param>
        /// <returns>Service container</returns>
        public static ServiceContainer AddMediatR(this ServiceContainer services, params Assembly[] assemblies)
            => services.AddMediatR(assemblies.ToList());

        /// <summary>
        /// Registers handlers and mediator types from the specified assemblies
        /// </summary>
        /// <param name="services">Service container</param>
        /// <param name="assemblies">Assemblies to scan</param>
        /// <returns>Service container</returns>
        public static ServiceContainer AddMediatR(this ServiceContainer services, IEnumerable<Assembly> assemblies)
        {
            if (!assemblies.Any())
            {
                throw new ArgumentException("No assemblies found to scan. Supply at least one assembly to scan for handlers.");
            }

            ServiceRegistrar.AddRequiredServices(services);

            ServiceRegistrar.AddMediatRClasses(services, assemblies);

            return services;
        }

        /// <summary>
        /// Registers handlers and mediator types from the assemblies that contain the specified types
        /// </summary>
        /// <param name="services"></param>
        /// <param name="handlerAssemblyMarkerTypes"></param>
        /// <returns>Service container</returns>
        public static ServiceContainer AddMediatR(this ServiceContainer services, params Type[] handlerAssemblyMarkerTypes)
            => services.AddMediatR(handlerAssemblyMarkerTypes.ToList());

        /// <summary>
        /// Registers handlers and mediator types from the assemblies that contain the specified types
        /// </summary>
        /// <param name="services"></param>
        /// <param name="handlerAssemblyMarkerTypes"></param>
        /// <returns>Service container</returns>
        public static ServiceContainer AddMediatR(this ServiceContainer services, IEnumerable<Type> handlerAssemblyMarkerTypes)
            => services.AddMediatR(handlerAssemblyMarkerTypes.Select(t => t.GetTypeInfo().Assembly));
    }
}
