namespace Questar.OneRoster.Data.Test
{
    using AutoMapper;
    using AutoMapper.Extensions.ExpressionMapping;
    using Mappings;
    using Xunit;

    public class AcademicSessionProfileTest : ProfileTest<AcademicSession, Models.AcademicSession>
    {
        public AcademicSessionProfileTest() : base(new Mapper(new MapperConfiguration(config =>
        {
            config.AddExpressionMapping();
            config.AddProfile<AcademicSessionProfile>();
        })))
        {
        }

        [Fact]
        public void CanMapSourcedId() => CanMap(entity => entity.Id, model => model.SourcedId);

        [Fact]
        public void CanMapStatusType() => CanMap(entity => entity.Status, model => model.StatusType);

        [Fact]
        public void CanMapDateLastModified() => CanMap(entity => entity.Modified, model => model.DateLastModified);

        // TODO GuidRef
        //[Fact]
        //public void CanMapParent() => CanMap(entity => entity.Parent, entity => entity.Parent);

        // TODO GuidRef
        //[Fact]
        //public void CanMapChildren() => CanMap(entity => entity.Children, entity => entity.Children);

        // TODO Year
        //[Fact]
        //public void CanMapYear() => CanMap(entity => entity.Year, entity => entity.Year);

        [Fact]
        public void CanMapEndDate() => CanMap(entity => entity.EndDate, model => model.EndDate);

        [Fact]
        public void CanMapStartDate() => CanMap(entity => entity.StartDate, model => model.StartDate);

        [Fact]
        public void CanMapTitle() => CanMap(entity => entity.Title, model => model.Title);

        [Fact]
        public void CanMapType() => CanMap(entity => entity.Type, model => model.Type);
    }
}