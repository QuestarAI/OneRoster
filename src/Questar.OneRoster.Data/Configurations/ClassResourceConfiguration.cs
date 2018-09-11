namespace Questar.OneRoster.Data.Configurations
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ClassResourceConfiguration : IEntityTypeConfiguration<ClassResource>
    {
        public void Configure(EntityTypeBuilder<ClassResource> builder)
        {
            builder.HasKey(entity => new { entity.ClassId, entity.ResourceId });
        }
    }
}