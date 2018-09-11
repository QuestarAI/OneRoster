namespace Questar.OneRoster.Data.Configurations
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder
                .HasOne(dependent => dependent.Parent)
                .WithMany(principal => principal.Children)
                .HasForeignKey(dependent => dependent.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}