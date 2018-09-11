namespace Questar.OneRoster.Data.Configurations
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder
                .HasOne(dependent => dependent.Course)
                .WithMany(principal => principal.Classes)
                .HasForeignKey(dependent => dependent.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}