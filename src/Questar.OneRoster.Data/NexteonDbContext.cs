namespace Questar.OneRoster.Data
{
    using System;
    using Configurations;
    using Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    public class NexteonDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        public NexteonDbContext(DbContextOptions<NexteonDbContext> options)
            : base(options)
        {
        }

        public DbSet<AcademicSession> AcademicSessions { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<AcademicSession> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var type in builder.Model.GetEntityTypes())
            {
                type.Relational().TableName = type.DisplayName();

                //if (typeof(IHaveModified).IsAssignableFrom(type.ClrType))
                //{
                //    type.FindProperty(nameof(IHaveModified.Modified)).SetValueGeneratorFactory((property, entity) => new TemporaryDateTimeOffsetValueGenerator());
                //}
            }

            builder.ApplyConfiguration(new ClassConfiguration());
            builder.ApplyConfiguration(new ClassResourceConfiguration());
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new CourseResourceConfiguration());
            builder.ApplyConfiguration(new DemographicsConfiguration());
            builder.ApplyConfiguration(new MetadataConfiguration());
            builder.ApplyConfiguration(new OrganizationConfiguration());
            builder.ApplyConfiguration(new UserAgentConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserGradeConfiguration());
            builder.ApplyConfiguration(new UserOrganizationConfiguration());
        }
    }
}