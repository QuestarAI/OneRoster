namespace Questar.OneRoster.Data.Test
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.EquivalencyExpression;
    using AutoMapper.Extensions.ExpressionMapping;
    using Mappings;
    using Xunit;

    public class OrgProfileTest : ProfileTest<Org, Models.Org>
    {
        public OrgProfileTest() : base(new Mapper(new MapperConfiguration(config =>
        {
            config.AddExpressionMapping();
            config.AddCollectionMappers();
            config.AddProfile<GuidRefProfile>();
            config.AddProfile<MetadataProfile>();
            config.AddProfile<OrgProfile>();
        })))
        {
        }

        [Fact]
        public void CanMapFromChildren()
            => CanMapFrom(entity => entity.Children, model => model.Children);

        [Fact]
        public void CanMapFromDateLastModified()
            => CanMapFrom(entity => entity.Modified, model => model.DateLastModified);

        [Fact]
        public void CanMapFromIdentifier()
            => CanMapFrom(entity => entity.Identifier, model => model.Identifier);

        [Fact]
        public void CanMapFromMetadata()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata, model => model.Metadata);

        [Fact]
        public void CanMapFromMetadataWithProjection()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata.Any(metadata => metadata.Key == "foo"), model => model.Metadata.Any(metadata => metadata.Key == "foo"));

        [Fact]
        public void CanMapFromName()
            => CanMapFrom(entity => entity.Name, model => model.Name);

        [Fact]
        public void CanMapFromParent()
            => CanMapFrom(entity => entity.Parent, model => model.Parent);

        [Fact]
        public void CanMapFromSourcedId()
            => CanMapFrom(entity => entity.Id, model => model.SourcedId);

        [Fact]
        public void CanMapFromStatusType()
            => CanMapFrom(entity => entity.Status, model => model.StatusType);

        [Fact]
        public void CanMapFromType()
            => CanMapFrom(entity => (OrgType) entity.Type, model => model.Type);
    }
}