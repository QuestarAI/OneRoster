using System.Linq;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Questar.OneRoster.Data.Services
{
    public class OneRosterDbContext : IdentityDbContext<User, Role, string, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IDataProtectionKeyContext
    {
        public OneRosterDbContext()
        {
        }

        // ReSharper disable once SuggestBaseTypeForParameter
        public OneRosterDbContext(DbContextOptions<OneRosterDbContext> options)
            : base(options)
        {
        }

        public DbSet<AcademicSession> AcademicSessions { get; internal set; }

        public DbSet<Category> Categories { get; internal set; }

        public DbSet<Class> Classes { get; internal set; }

        public DbSet<Course> Courses { get; internal set; }

        public DbSet<Enrollment> Enrollments { get; internal set; }

        public DbSet<LineItem> LineItems { get; internal set; }

        public DbSet<Org> Orgs { get; internal set; }

        public DbSet<Resource> Resources { get; internal set; }

        public DbSet<Result> Results { get; internal set; }

        public DbSet<Subject> Subjects { get; internal set; }

        public DbSet<Grade> Grades { get; internal set; }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=.;Initial Catalog=OneRoster;Integrated Security=True");
            //options.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<Class>()
                .HasOne(dependent => dependent.School)
                .WithMany(principal => principal.Classes)
                .HasForeignKey(dependent => dependent.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            // class academic session

            builder
                .Entity<ClassAcademicSession>()
                .HasKey(entity => new {entity.ClassId, entity.AcademicSessionId});

            builder
                .Entity<ClassAcademicSession>()
                .HasOne(dependent => dependent.Class)
                .WithMany(principal => principal.Terms)
                .HasForeignKey(dependent => dependent.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            // class grade

            builder
                .Entity<ClassGrade>()
                .HasKey(entity => new {entity.ClassId, entity.GradeId});

            // class period

            builder
                .Entity<ClassPeriod>()
                .HasKey(entity => new {entity.ClassId, entity.Period});

            // class resource

            builder
                .Entity<ClassResource>()
                .HasKey(entity => new {entity.ClassId, entity.ResourceId});

            // class subject

            builder
                .Entity<ClassSubject>()
                .HasKey(entity => new {entity.ClassId, entity.SubjectId});

            // course grade

            builder
                .Entity<CourseGrade>()
                .HasKey(entity => new {entity.CourseId, entity.GradeId});

            // course resource

            builder
                .Entity<CourseResource>()
                .HasKey(entity => new {entity.CourseId, entity.ResourceId});

            // course subject

            builder
                .Entity<CourseSubject>()
                .HasKey(entity => new {entity.CourseId, entity.SubjectId});

            // demographics

            builder
                .Entity<Demographics>()
                .HasOne<User>()
                .WithOne(dependent => dependent.Demographics)
                .HasForeignKey<Demographics>(dependent => dependent.Id);

            // grade

            builder
                .Entity<Grade>()
                .HasIndex(entity => entity.Code);

            // line item

            builder
                .Entity<LineItem>()
                .HasOne(dependent => dependent.GradingPeriod)
                .WithMany(principal => principal.LineItems)
                .HasForeignKey(dependent => dependent.GradingPeriodId)
                .OnDelete(DeleteBehavior.Restrict);

            // metadata

            builder
                .Entity<Metadata>()
                .HasKey(entity => new {entity.CollectionId, entity.Key});

            // orgs

            builder
                .Entity<Org>()
                .HasIndex(entity => entity.Identifier);

            // resource role

            builder
                .Entity<ResourceRole>()
                .HasKey(entity => new {entity.ResourceId, entity.Role});

            // subject

            builder
                .Entity<Subject>()
                .HasIndex(entity => entity.Code);

            // user

            builder
                .Entity<User>()
                .Property(user => user.Id).HasMaxLength(10).ValueGeneratedNever();

            builder
                .Entity<User>()
                .HasIndex(entity => entity.Identifier);

            // user agent

            builder
                .Entity<UserAgent>()
                .HasKey(entity => new {entity.UserId, entity.AgentId});

            builder
                .Entity<UserAgent>()
                .HasOne(dependent => dependent.User)
                .WithMany(principal => principal.Agents)
                .HasForeignKey(dependent => dependent.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<UserAgent>()
                .HasOne(dependent => dependent.Agent)
                .WithMany()
                .HasForeignKey(dependent => dependent.AgentId);

            // user grade

            builder
                .Entity<UserGrade>()
                .HasKey(entity => new {entity.UserId, entity.GradeId});

            // user identifier

            builder
                .Entity<UserIdentifier>()
                .HasKey(entity => new {entity.UserId, entity.Type, entity.Identifier});

            // user orgs

            builder
                .Entity<UserOrg>()
                .HasKey(entity => new {entity.UserId, entity.OrgId});

            foreach (var type in builder.Model.GetEntityTypes().Where(type => !type.IsOwned()))
                builder.Entity(type.ClrType).ToTable(type.ClrType.Name);
        }
    }
}