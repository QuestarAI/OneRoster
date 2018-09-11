namespace Questar.OneRoster.Data.Configurations
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserGradeConfiguration : IEntityTypeConfiguration<UserGrade>
    {
        public void Configure(EntityTypeBuilder<UserGrade> builder)
        {
            builder.HasKey(entity => new { entity.UserId, entity.GradeId });
        }
    }
}