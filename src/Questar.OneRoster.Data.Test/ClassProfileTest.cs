namespace Questar.OneRoster.Data.Test
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.EquivalencyExpression;
    using AutoMapper.Extensions.ExpressionMapping;
    using Mappings;
    using Models;
    using Xunit;
    using Class = Data.Class;

    public class ClassProfileTest : ProfileTest<Class, Models.Class>
    {
        public ClassProfileTest() : base(new Mapper(new MapperConfiguration(config =>
        {
            config.AddExpressionMapping();
            config.AddCollectionMappers();
            config.AddProfile<GuidRefProfile>();
            config.AddProfile<MetadataProfile>();
            config.AddProfile<ClassProfile>();
        })))
        {
        }

        [Fact]
        public void CanMapFromClassCode()
            => CanMapFrom(entity => entity.Code, model => model.ClassCode);

        [Fact]
        public void CanMapFromClassType()
            => CanMapFrom(entity => (ClassType) entity.Type, model => model.ClassType);

        [Fact]
        public void CanMapFromCourse()
            => CanMapFrom(entity => entity.Course, model => model.Course);

        [Fact]
        public void CanMapFromDateLastModified()
            => CanMapFrom(entity => entity.Modified, model => model.DateLastModified);

        [Fact]
        public void CanMapFromGrades()
            => CanMapFrom(entity => entity.Grades, model => model.Grades);

        [Fact]
        public void CanMapFromLocation()
            => CanMapFrom(entity => entity.Location, model => model.Location);

        [Fact]
        public void CanMapFromMetadata()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata, model => model.Metadata);

        [Fact]
        public void CanMapFromMetadataWithProjection()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata.Any(metadata => metadata.Key == "foo"), model => model.Metadata.Any(metadata => metadata.Key == "foo"));

        [Fact]
        public void CanMapFromPeriods()
            => CanMapFrom(entity => entity.Periods.Select(container => container.Period), model => model.Periods);

        [Fact]
        public void CanMapFromResources()
            => CanMapFrom(entity => entity.Resources, model => model.Resources);

        [Fact]
        public void CanMapFromSchool()
            => CanMapFrom(entity => entity.School, model => model.School);

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
        public void CanMapFromTerms()
            => CanMapFrom(entity => entity.Terms, model => model.Terms);

        [Fact]
        public void CanMapFromTitle()
            => CanMapFrom(entity => entity.Title, model => model.Title);
    }
}