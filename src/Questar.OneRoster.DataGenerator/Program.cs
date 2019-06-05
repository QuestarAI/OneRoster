using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Questar.OneRoster.Data.Services;

namespace Questar.OneRoster.DataGenerator
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            using (var context = new OneRosterDbContext())
            {
                await context.Database.MigrateAsync();
            }

            Console.WriteLine("Initializing...");

            await new OneRosterDbContextInitializer().InitializeAsync();

            Console.WriteLine();
            Console.WriteLine("Complete. Press any key to continue...");
            Console.ReadKey();
        }
    }
}