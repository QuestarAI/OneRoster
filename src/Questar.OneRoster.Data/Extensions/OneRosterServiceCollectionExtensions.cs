namespace Questar.OneRoster.Data.Extensions
{
    using System;
    using AutoMapper;
    using AutoMapper.EquivalencyExpression;
    using AutoMapper.Extensions.ExpressionMapping;
    using DataServices;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Services;

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
            services.AddScoped<IWorkspace, OneRosterDbContextWorkspace>();
        }
    }
}