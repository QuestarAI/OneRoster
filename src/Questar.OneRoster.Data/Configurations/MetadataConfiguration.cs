namespace Questar.OneRoster.Data.Configurations
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class MetadataConfiguration : IEntityTypeConfiguration<Metadata>
    {
        public void Configure(EntityTypeBuilder<Metadata> builder)
        {
            builder.HasKey(entity => new { entity.CollectionId, entity.Key });
        }
    }
}