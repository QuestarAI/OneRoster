namespace Questar.OneRoster.Data.Test
{
    using AutoMapper;
    using AutoMapper.EquivalencyExpression;
    using AutoMapper.Extensions.ExpressionMapping;
    using Mappings;
    using Xunit;

    public class AcademicSessionProfileTest : ProfileTest<AcademicSession, Models.AcademicSession>
    {
        public AcademicSessionProfileTest() : base(new Mapper(new MapperConfiguration(config =>
        {
            config.AddExpressionMapping();
            config.AddCollectionMappers();
            config.AddProfile<GuidRefProfile>();
            config.AddProfile<AcademicSessionProfile>();
        })))
        {
        }

        [Fact]
        public void CanMapFromChildren() => CanMapFrom(entity => entity.Children, entity => entity.Children);

        [Fact]
        public void CanMapFromDateLastModified() => CanMapFrom(entity => entity.Modified, model => model.DateLastModified);

        // TODO Year
        //[Fact]
        //public void CanMapFromYear() => CanMap(entity => entity.Year, entity => entity.Year);

        [Fact]
        public void CanMapFromEndDate() => CanMapFrom(entity => entity.EndDate, model => model.EndDate);

        [Fact]
        public void CanMapFromParent() => CanMapFrom(entity => entity.Parent, entity => entity.Parent);

        [Fact]
        public void CanMapFromSourcedId() => CanMapFrom(entity => entity.Id, model => model.SourcedId);

        [Fact]
        public void CanMapFromStartDate() => CanMapFrom(entity => entity.StartDate, model => model.StartDate);

        [Fact]
        public void CanMapFromStatusType() => CanMapFrom(entity => entity.Status, model => model.StatusType);

        [Fact]
        public void CanMapFromTitle() => CanMapFrom(entity => entity.Title, model => model.Title);

        [Fact]
        public void CanMapFromType() => CanMapFrom(entity => entity.Type, model => model.Type);
    }
}