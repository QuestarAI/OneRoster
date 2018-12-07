namespace Questar.OneRoster.Data.Test
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.EquivalencyExpression;
    using AutoMapper.Extensions.ExpressionMapping;
    using Mappings;
    using Models;
    using Xunit;
    using Resource = Data.Resource;

    public class ResourceProfileTest : ProfileTest<Resource, Models.Resource>
    {
        public ResourceProfileTest() : base(new Mapper(new MapperConfiguration(config =>
        {
            config.AddExpressionMapping();
            config.AddCollectionMappers();
            config.AddProfile<GuidRefProfile>();
            config.AddProfile<MetadataProfile>();
            config.AddProfile<ResourceProfile>();
        })))
        {
        }

        [Fact]
        public void CanMapFromApplicationId()
            => CanMapFrom(entity => entity.ApplicationId, model => model.ApplicationId);

        [Fact]
        public void CanMapFromDateLastModified()
            => CanMapFrom(entity => entity.Modified, model => model.DateLastModified);

        [Fact]
        public void CanMapFromImportance()
            => CanMapFrom(entity => entity.Importance, model => model.Importance);

        [Fact]
        public void CanMapFromMetadata()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata, model => model.Metadata);

        [Fact]
        public void CanMapFromMetadataWithProjection()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata.Any(metadata => metadata.Key == "foo"), model => model.Metadata.Any(metadata => metadata.Key == "foo"));

        [Fact]
        public void CanMapFromRoles()
            => CanMapFrom(entity => entity.Roles, model => model.Roles);

        [Fact]
        public void CanMapFromSourcedId()
            => CanMapFrom(entity => entity.Id, model => model.SourcedId);

        [Fact]
        public void CanMapFromStatusType()
            => CanMapFrom(entity => (StatusType) entity.Status, model => model.StatusType);

        [Fact]
        public void CanMapFromTitle()
            => CanMapFrom(entity => entity.Title, model => model.Title);

        [Fact]
        public void CanMapFromVendorId()
            => CanMapFrom(entity => entity.VendorId, model => model.VendorId);

        [Fact]
        public void CanMapFromVendorResourceId()
            => CanMapFrom(entity => entity.VendorResourceId, model => model.VendorResourceId);
    }
}