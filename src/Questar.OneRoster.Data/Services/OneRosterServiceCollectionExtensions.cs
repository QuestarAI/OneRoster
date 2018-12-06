namespace Questar.OneRoster.Data.Services
{
    using System;
    using AutoMapper;
    using AutoMapper.EquivalencyExpression;
    using AutoMapper.Extensions.ExpressionMapping;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class OneRosterServiceCollectionExtensions
    {
        public static void AddOneRoster(this IServiceCollection services, string connectionString)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddDbContext<OneRosterDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddAutoMapper(config =>
            {
                config.AddExpressionMapping();
                config.AddCollectionMappers();
            });
            services.AddScoped<OneRosterDbContext>();
            services.AddScoped<IWorkspace, ModelWorkspace>();
        }

        public static void AddOneRoster(this IServiceCollection services, string connectionString, Action<OneRosterOptions> setupAction)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));
            services.AddOneRoster(connectionString);
            services.Configure(setupAction);
        }
    }
}