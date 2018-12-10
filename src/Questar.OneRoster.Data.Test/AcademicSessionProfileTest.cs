namespace Questar.OneRoster.Data.Test
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.EquivalencyExpression;
    using AutoMapper.Extensions.ExpressionMapping;
    using Models;
    using Profiles;
    using Xunit;
    using AcademicSession = Data.AcademicSession;

    public class AcademicSessionProfileTest : ProfileTest<AcademicSession, Models.AcademicSession>
    {
        public AcademicSessionProfileTest() : base(new Mapper(new MapperConfiguration(config =>
        {
            config.AddExpressionMapping();
            config.AddCollectionMappers();
            config.AddProfile<GuidRefProfile>();
            config.AddProfile<MetadataProfile>();
            config.AddProfile<AcademicSessionProfile>();
        })))
        {
        }

        [Fact]
        public void CanMapFromChildren()
            => CanMapFrom(entity => entity.Children, entity => entity.Children);

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
        public void CanMapFromParent()
            => CanMapFrom(entity => entity.Parent, entity => entity.Parent);

        [Fact]
        public void CanMapFromSchoolYear()
            => CanMapFrom(entity => (Year) (int) entity.SchoolYear, entity => entity.SchoolYear);

        [Fact]
        public void CanMapFromSourcedId()
            => CanMapFrom(entity => entity.Id, model => model.SourcedId);

        [Fact]
        public void CanMapFromStartDate()
            => CanMapFrom(entity => entity.StartDate, model => model.StartDate);

        [Fact]
        public void CanMapFromStatusType()
            => CanMapFrom(entity => (StatusType) entity.Status, model => model.StatusType);

        [Fact]
        public void CanMapFromTitle()
            => CanMapFrom(entity => entity.Title, model => model.Title);

        [Fact]
        public void CanMapFromType()
            => CanMapFrom(entity => (AcademicSessionType) entity.Type, model => model.Type);
    }
}