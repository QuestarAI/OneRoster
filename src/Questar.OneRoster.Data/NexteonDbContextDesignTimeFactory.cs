namespace Questar.OneRoster.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    internal class NexteonDbContextDesignTimeFactory : IDesignTimeDbContextFactory<NexteonDbContext>
    {
        public NexteonDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<NexteonDbContext>();

            options.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=Nexteon;Integrated Security=True");

            return new NexteonDbContext(options.Options);
        }
    }
}