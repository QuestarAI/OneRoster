namespace Questar.OneRoster.Data.Services
{
    using System;
    using Microsoft.EntityFrameworkCore.Internal;

    public class OneRosterDbContextInitializer
    {
        public OneRosterDbContextInitializer(OneRosterDbContext context) => Context = context;

        public OneRosterDbContext Context { get; }

        public void Initialize()
        {
        }
    }
}