namespace Questar.OneRoster.Data.Configurations
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserOrganizationConfiguration : IEntityTypeConfiguration<UserOrganization>
    {
        public void Configure(EntityTypeBuilder<UserOrganization> builder)
        {
            builder.HasKey(entity => new { entity.UserId, entity.OrganizationId });

            builder
                .HasOne(dependent => dependent.User)
                .WithMany(principal => principal.Organizations)
                .HasForeignKey(dependent => dependent.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(dependent => dependent.Organization)
                .WithMany()
                .HasForeignKey(dependent => dependent.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}