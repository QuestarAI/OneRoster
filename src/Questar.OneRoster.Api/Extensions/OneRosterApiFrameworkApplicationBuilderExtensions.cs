namespace Questar.OneRoster.ApiFramework.Extensions
{
    using System;
    using System.Reflection;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.FileProviders;

    public static class OneRosterApiFrameworkApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseOneRosterApiFramework(this IApplicationBuilder app, Action<OneRosterApiFrameworkOptions> setupAction = null)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));
            var options = new OneRosterApiFrameworkOptions();
            setupAction?.Invoke(options);
            app.UseMiddleware<OneRosterApiFrameworkMiddleware>((object) options);
            app.UseFileServer(new FileServerOptions
            {
                RequestPath = string.IsNullOrEmpty(options.RoutePrefix) ? string.Empty : $"/{options.RoutePrefix}",
                FileProvider = new EmbeddedFileProvider(Assembly.GetExecutingAssembly(), "Questar.OneRoster.ApiFramework.Files")
            });
            return app;
        }
    }
}