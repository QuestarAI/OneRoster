namespace Questar.OneRoster.Data.Test
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.EquivalencyExpression;
    using AutoMapper.Extensions.ExpressionMapping;
    using Mappings;
    using Xunit;

    public class EnrollmentProfileTest : ProfileTest<Enrollment, Models.Enrollment>
    {
        public EnrollmentProfileTest() : base(new Mapper(new MapperConfiguration(config =>
        {
            config.AddExpressionMapping();
            config.AddCollectionMappers();
            config.AddProfile<GuidRefProfile>();
            config.AddProfile<MetadataProfile>();
            config.AddProfile<EnrollmentProfile>();
        })))
        {
        }

        [Fact]
        public void CanMapFromBeginDate()
            => CanMapFrom(entity => entity.BeginDate, model => model.BeginDate);

        [Fact]
        public void CanMapFromClass()
            => CanMapFrom(entity => entity.Class, model => model.Class);

        [Fact]
        public void CanMapFromDateLastModified()
            => CanMapFrom(entity => entity.Modified, model => model.DateLastModified);

        [Fact]
        public void CanMapFromEndDate()
            => CanMapFrom(entity => entity.EndDate, model => model.EndDate);

        [Fact]
        public void CanMapFromMetadata()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata, model => model.Metadata);

        [Fact]
        public void CanMapFromMetadataWithProjection()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata.Any(metadata => metadata.Key == "foo"), model => model.Metadata.Any(metadata => metadata.Key == "foo"));

        [Fact]
        public void CanMapFromPrimary()
            => CanMapFrom(entity => entity.Primary, model => model.Primary);

        [Fact]
        public void CanMapFromRole()
            => CanMapFrom(entity => (UserType) entity.User.Type, model => model.Role); // TODO UserProfile?

        [Fact]
        public void CanMapFromSchool()
            => CanMapFrom(entity => entity.Class.School, model => model.School); // TODO ClassProfile?

        [Fact]
        public void CanMapFromSourcedId()
            => CanMapFrom(entity => entity.Id, model => model.SourcedId);

        [Fact]
        public void CanMapFromStatusType()
            => CanMapFrom(entity => entity.Status, model => model.StatusType);

        [Fact]
        public void CanMapFromUser()
            => CanMapFrom(entity => entity.User, model => model.User);
    }
}