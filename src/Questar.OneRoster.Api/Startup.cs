namespace Questar.OneRoster.Api
{
    using ApiFramework;
    using ApiFramework.Extensions;
    using Data.Services;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json.Converters;
    using Swashbuckle.AspNetCore.Swagger;

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOneRoster(@"Data Source=.;Initial Catalog=OneRoster;Integrated Security=True");
            services.AddOneRosterApiFramework();

            services
                .AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()))
                .AddOneRosterApiFramework();

            // TODO: Consolidate where this connection string comes from.
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1p1", new Info
                {
                    Title = "OneRoster® IMS Final Release Version 1.1",
                    Description = @"<a href=""https://www.imsglobal.org/oneroster-v11-final-specification"">Developer Documentation</a>",
                    Version = "v1p1",
                    Contact = new Contact
                    {
                        Name = "Questar Assessment Inc.",
                        Email = "oneroster@questarai.com",
                        Url = "https://www.questarai.com"
                    },
                    License = new License
                    {
                        Name = "IMS Global Learning Consortium, Inc. Specification Document License",
                        Url = "https://www.imsglobal.org/speclicense.html"
                    }
                });
            });
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseOneRoster();
            app.UseOneRosterApiFramework();

            app.UseStaticFiles();
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "ims/oneroster/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "ims/oneroster";
                c.SwaggerEndpoint("/ims/oneroster/v1p1/swagger.json", "OneRoster® IMS Final Release Version 1.1");
            });

            app.UseMvc();
        }
    }
}