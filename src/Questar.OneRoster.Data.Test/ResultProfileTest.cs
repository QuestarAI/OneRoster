namespace Questar.OneRoster.Data.Test
{
    using AutoMapper;
    using AutoMapper.Extensions.ExpressionMapping;
    using Mappings;
    using Xunit;

    public class ResultProfileTest : ProfileTest<Result, Models.Result>
    {
        public ResultProfileTest() : base(new Mapper(new MapperConfiguration(config =>
        {
            config.AddExpressionMapping();
            config.AddProfile<ResultProfile>();
        })))
        {
        }

        [Fact]
        public void CanMapSourcedId() => CanMap(entity => entity.Id, model => model.SourcedId);

        [Fact]
        public void CanMapStatusType() => CanMap(entity => entity.Status, model => model.StatusType);

        [Fact]
        public void CanMapDateLastModified() => CanMap(entity => entity.Modified, model => model.DateLastModified);
    }
}