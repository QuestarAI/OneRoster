namespace Questar.OneRoster.Data.Configurations
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class DemographicsConfiguration : IEntityTypeConfiguration<Demographics>
    {
        public void Configure(EntityTypeBuilder<Demographics> builder)
        {
            builder.HasKey(entity => entity.UserId);
            builder
                .HasOne<User>()
                .WithOne(dependent => dependent.Demographics)
                .HasForeignKey<Demographics>(dependent => dependent.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}