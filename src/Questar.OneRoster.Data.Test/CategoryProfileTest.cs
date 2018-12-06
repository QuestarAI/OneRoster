namespace Questar.OneRoster.Data.Test
{
    using AutoMapper;
    using AutoMapper.EquivalencyExpression;
    using AutoMapper.Extensions.ExpressionMapping;
    using Mappings;
    using Xunit;

    public class CategoryProfileTest : ProfileTest<Category, Models.Category>
    {
        public CategoryProfileTest() : base(new Mapper(new MapperConfiguration(config =>
        {
            config.AddExpressionMapping();
            config.AddCollectionMappers();
            config.AddProfile<GuidRefProfile>();
            config.AddProfile<CategoryProfile>();
        })))
        {
        }

        [Fact]
        public void CanMapFromDateLastModified() => CanMapFrom(entity => entity.Modified, model => model.DateLastModified);

        [Fact]
        public void CanMapFromSourcedId() => CanMapFrom(entity => entity.Id, model => model.SourcedId);

        [Fact]
        public void CanMapFromStatusType() => CanMapFrom(entity => entity.Status, model => model.StatusType);
    }
}