namespace Questar.OneRoster.Api
{
    using Data;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public IConfiguration Configuration { get; }

        [UsedImplicitly]
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [UsedImplicitly]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // TODO: Consolidate where this connection string comes from.
            const string connection = @"Data Source=.;Initial Catalog=OneRoster;Integrated Security=True";
            services.AddDbContext<OneRosterDbContext>(options => options.UseSqlServer(connection));
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}