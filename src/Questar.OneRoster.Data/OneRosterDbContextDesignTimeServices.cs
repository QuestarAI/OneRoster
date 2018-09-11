namespace Questar.OneRoster.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.DependencyInjection;
    using Models;

    internal class OneRosterDbContextDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>().AddDefaultTokenProviders(); //.AddEntityFrameworkStores<OneRosterDbContext>();
        }
    }
}