namespace Questar.OneRoster.ApiFramework.Extensions
{
    using System;
    using Microsoft.Extensions.DependencyInjection;

    public static class OneRosterApiFrameworkServiceCollectionExtensions
    {
        public static void AddOneRosterApiFramework(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
        }

        public static void AddOneRosterApiFramework(this IServiceCollection services, Action<OneRosterApiFrameworkOptions> setupAction)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));
            services.AddOneRosterApiFramework();
            services.Configure(setupAction);
        }
    }
}