using JetBrains.Annotations;

namespace Questar.OneRoster.Api
{
    using Data;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Console;
    using Newtonsoft.Json.Converters;

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
            services
                .AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));
            // TODO: Consolidate where this connection string comes from.
            const string connection = @"Data Source=.;Initial Catalog=OneRoster;Integrated Security=True";

            var myLoggerFactory = new LoggerFactory(new[] {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information, true)
            });
            
            services.AddDbContext<OneRosterDbContext>(options =>
            {
                options.UseSqlServer(connection);
                options.UseLoggerFactory(myLoggerFactory);
            });
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