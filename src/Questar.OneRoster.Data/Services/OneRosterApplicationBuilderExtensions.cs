namespace Questar.OneRoster.Data.Services
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class OneRosterApplicationBuilderExtensions
    {
        public static void UseOneRoster(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var context = scope.ServiceProvider.GetService<OneRosterDbContext>())
            {
                context.Database.Migrate();
            }
        }
    }
}