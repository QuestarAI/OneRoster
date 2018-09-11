namespace Questar.OneRoster.Data.Configurations
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserAgentConfiguration : IEntityTypeConfiguration<UserAgent>
    {
        public void Configure(EntityTypeBuilder<UserAgent> builder)
        {
            builder.HasKey(entity => new { entity.UserId, entity.AgentId });

            builder
                .HasOne(dependent => dependent.User)
                .WithMany(principal => principal.Agents)
                .HasForeignKey(dependent => dependent.UserId);

            builder
                .HasOne(dependent => dependent.Agent)
                .WithOne()
                .HasForeignKey<UserAgent>(dependent => dependent.AgentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}