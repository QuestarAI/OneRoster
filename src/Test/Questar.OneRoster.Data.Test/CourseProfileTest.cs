namespace Questar.OneRoster.Data.Test
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.EquivalencyExpression;
    using AutoMapper.Extensions.ExpressionMapping;
    using Models;
    using Profiles;
    using Xunit;
    using Course = Data.Course;

    public class CourseProfileTest : ProfileTest<Course, Models.Course>
    {
        public CourseProfileTest() : base(new Mapper(new MapperConfiguration(config =>
        {
            config.AddExpressionMapping();
            config.AddCollectionMappers();
            config.AddProfile<GuidRefProfile>();
            config.AddProfile<MetadataProfile>();
            config.AddProfile<CourseProfile>();
        })))
        {
        }

        [Fact]
        public void CanMapFromDateLastModified()
            => CanMapFrom(entity => entity.Modified, model => model.DateLastModified);

        [Fact]
        public void CanMapFromGrades()
            => CanMapFrom(entity => entity.Grades, model => model.Grades);

        [Fact]
        public void CanMapFromMetadata()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata, model => model.Metadata);

        [Fact]
        public void CanMapFromMetadataWithProjection()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata.Any(metadata => metadata.Key == "foo"), model => model.Metadata.Any(metadata => metadata.Key == "foo"));

        [Fact]
        public void CanMapFromResources()
            => CanMapFrom(entity => entity.Resources, model => model.Resources);

        [Fact]
        public void CanMapFromSourcedId()
            => CanMapFrom(entity => entity.Id, model => model.SourcedId);

        [Fact]
        public void CanMapFromStatusType()
            => CanMapFrom(entity => (StatusType) entity.Status, model => model.StatusType);

        [Fact]
        public void CanMapFromSubjectCodes()
            => CanMapFrom(entity => entity.Subjects.Select(relationship => relationship.Subject.Code), model => model.SubjectCodes);

        [Fact]
        public void CanMapFromSubjects()
            => CanMapFrom(entity => entity.Subjects.Select(relationship => relationship.Subject.Name), model => model.Subjects);

        [Fact]
        public void CanMapFromTitle()
            => CanMapFrom(entity => entity.Title, model => model.Title);
    }
}