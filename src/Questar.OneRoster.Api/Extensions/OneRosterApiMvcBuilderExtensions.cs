namespace Questar.OneRoster.Api.Extensions
{
    using System;
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;

    public static class OneRosterApiMvcBuilderExtensions
    {
        public static IMvcBuilder AddOneRosterApi(this IMvcBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            return builder
                .AddApplicationPart(Assembly.GetExecutingAssembly());
        }
    }
}