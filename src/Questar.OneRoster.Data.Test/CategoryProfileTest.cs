namespace Questar.OneRoster.Data.Test
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.EquivalencyExpression;
    using AutoMapper.Extensions.ExpressionMapping;
    using Models;
    using Profiles;
    using Xunit;
    using Category = Data.Category;

    public class CategoryProfileTest : ProfileTest<Category, Models.Category>
    {
        public CategoryProfileTest() : base(new Mapper(new MapperConfiguration(config =>
        {
            config.AddExpressionMapping();
            config.AddCollectionMappers();
            config.AddProfile<GuidRefProfile>();
            config.AddProfile<MetadataProfile>();
            config.AddProfile<CategoryProfile>();
        })))
        {
        }

        [Fact]
        public void CanMapFromDateLastModified()
            => CanMapFrom(entity => entity.Modified, model => model.DateLastModified);

        [Fact]
        public void CanMapFromMetadata()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata, model => model.Metadata);

        [Fact]
        public void CanMapFromMetadataWithProjection()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata.Any(metadata => metadata.Key == "foo"), model => model.Metadata.Any(metadata => metadata.Key == "foo"));

        [Fact]
        public void CanMapFromSourcedId()
            => CanMapFrom(entity => entity.Id, model => model.SourcedId);

        [Fact]
        public void CanMapFromStatusType()
            => CanMapFrom(entity => (StatusType) entity.Status, model => model.StatusType);

        [Fact]
        public void CanMapFromTitle()
            => CanMapFrom(entity => entity.Title, model => model.Title);
    }
}