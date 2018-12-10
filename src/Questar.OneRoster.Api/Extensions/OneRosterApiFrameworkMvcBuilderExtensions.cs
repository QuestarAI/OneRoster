namespace Questar.OneRoster.Api.Extensions
{
    using System;
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;

    public static class OneRosterApiFrameworkMvcBuilderExtensions
    {
        public static IMvcBuilder AddOneRosterApiFramework(this IMvcBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            return builder
                .AddApplicationPart(Assembly.GetExecutingAssembly());
        }
    }
}