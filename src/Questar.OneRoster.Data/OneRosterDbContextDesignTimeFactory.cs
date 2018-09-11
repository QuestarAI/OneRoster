namespace Questar.OneRoster.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    internal class OneRosterDbContextDesignTimeFactory : IDesignTimeDbContextFactory<OneRosterDbContext>
    {
        public OneRosterDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<OneRosterDbContext>();

            options.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=OneRoster;Integrated Security=True");

            return new OneRosterDbContext(options.Options);
        }
    }
}