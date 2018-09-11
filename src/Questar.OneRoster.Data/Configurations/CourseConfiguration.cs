namespace Questar.OneRoster.Data.Configurations
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .HasOne(dependent => dependent.SchoolYear)
                .WithMany()
                .HasForeignKey(dependent => dependent.SchoolYearId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(dependent => dependent.Organization)
                .WithMany()
                .HasForeignKey(dependent => dependent.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}