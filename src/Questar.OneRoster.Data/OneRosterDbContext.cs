namespace Questar.OneRoster.Data
{
    using System;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using Models;

    public class OneRosterDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        public OneRosterDbContext(DbContextOptions<OneRosterDbContext> options)
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
            }

            //if (typeof(IHaveModified).IsAssignableFrom(type.ClrType))
            //{
            //    type.FindProperty(nameof(IHaveModified.Modified)).SetValueGeneratorFactory((property, entity) => new TemporaryDateTimeOffsetValueGenerator());
            //}

            // class

            builder
                .Entity<Class>()
                .HasOne(dependent => dependent.Course)
                .WithMany(principal => principal.Classes)
                .HasForeignKey(dependent => dependent.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // class resource

            builder
                .Entity<ClassResource>()
                .HasKey(entity => new
                {
                    entity.ClassId,
                    entity.ResourceId
                });

            // course

            builder
                .Entity<Course>()
                .HasOne(dependent => dependent.SchoolYear)
                .WithMany()
                .HasForeignKey(dependent => dependent.SchoolYearId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .Entity<Course>()
                .HasOne(dependent => dependent.Organization)
                .WithMany()
                .HasForeignKey(dependent => dependent.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .Entity<CourseResource>()
                .HasKey(entity => new
                {
                    entity.CourseId,
                    entity.ResourceId
                });
            // demographics

            builder
                .Entity<Demographics>()
                .HasKey(entity => entity.UserId);

            builder
                .Entity<Demographics>()
                .HasOne<User>()
                .WithOne(dependent => dependent.Demographics)
                .HasForeignKey<Demographics>(dependent => dependent.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // metadata

            builder
                .Entity<Metadata>()
                .HasKey(entity => new
                {
                    entity.CollectionId,
                    entity.Key
                });

            // organization

            builder
                .Entity<Organization>()
                .HasOne(dependent => dependent.Parent)
                .WithMany(principal => principal.Children)
                .HasForeignKey(dependent => dependent.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // user agent

            builder
                .Entity<UserAgent>()
                .HasKey(entity => new
                {
                    entity.UserId,
                    entity.AgentId
                });

            builder
                .Entity<UserAgent>()
                .HasOne(dependent => dependent.User)
                .WithMany(principal => principal.Agents)
                .HasForeignKey(dependent => dependent.UserId);

            builder
                .Entity<UserAgent>()
                .HasOne(dependent => dependent.Agent)
                .WithOne()
                .HasForeignKey<UserAgent>(dependent => dependent.AgentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // user grade

            builder
                .Entity<UserGrade>()
                .HasKey(entity => new
                {
                    entity.UserId,
                    entity.GradeId
                });

            // user organization

            builder
                .Entity<UserOrganization>()
                .HasKey(entity => new
                {
                    entity.UserId,
                    entity.OrganizationId
                });

            builder
                .Entity<UserOrganization>()
                .HasOne(dependent => dependent.User)
                .WithMany(principal => principal.Organizations)
                .HasForeignKey(dependent => dependent.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .Entity<UserOrganization>()
                .HasOne(dependent => dependent.Organization)
                .WithMany()
                .HasForeignKey(dependent => dependent.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}