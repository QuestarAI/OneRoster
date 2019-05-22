namespace Questar.OneRoster.App
{
    using Api.Extensions;
    using Data.Extensions;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json.Converters;
    using Swashbuckle.AspNetCore.Swagger;

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            // manage secrets by right-clicking on the project in visual studio
            if (env.IsDevelopment()) builder.AddUserSecrets<Startup>();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOneRoster(Configuration.GetConnectionString("OneRoster"));

            services
                .AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()))
                .AddOneRosterApi();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1p1", new Info
                {
                    Title = "OneRoster® IMS Final Release Version 1.1",
                    Description = @"<a href=""https://www.imsglobal.org/oneroster-v11-final-specification"">Developer Documentation</a>",
                    Version = "v1p1",
                    Contact = new Contact { Name = "Questar Assessment Inc.", Email = "oneroster@questarai.com", Url = "https://www.questarai.com" },
                    License = new License { Name = "IMS Global Learning Consortium, Inc. Specification Document License", Url = "https://www.imsglobal.org/speclicense.html" }
                });
            });
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseOneRoster(Configuration.GetValue<bool>("Data:Initialize"));

            app.UseStaticFiles();
            app.UseSwagger(options => { options.RouteTemplate = "ims/oneroster/{documentName}/swagger.json"; });
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "ims/oneroster";
                c.SwaggerEndpoint("/ims/oneroster/v1p1/swagger.json", "OneRoster® IMS Final Release Version 1.1");
            });

            app.UseMvc();
        }
    }
}