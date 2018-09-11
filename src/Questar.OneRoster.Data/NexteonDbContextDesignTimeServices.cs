namespace Questar.OneRoster.Data
{
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.DependencyInjection;

    internal class NexteonDbContextDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>().AddDefaultTokenProviders(); //.AddEntityFrameworkStores<NexteonDbContext>();
        }
    }
}