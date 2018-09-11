namespace Questar.OneRoster.Data.Configurations
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class CourseResourceConfiguration : IEntityTypeConfiguration<CourseResource>
    {
        public void Configure(EntityTypeBuilder<CourseResource> builder)
        {
            builder.HasKey(entity => new { entity.CourseId, entity.ResourceId });
        }
    }
}