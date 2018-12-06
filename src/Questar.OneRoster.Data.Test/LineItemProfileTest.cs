namespace Questar.OneRoster.Data.Test
{
    using System;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.EquivalencyExpression;
    using AutoMapper.Extensions.ExpressionMapping;
    using Mappings;
    using Xunit;

    public class LineItemProfileTest : ProfileTest<LineItem, Models.LineItem>
    {
        public LineItemProfileTest() : base(new Mapper(new MapperConfiguration(config =>
        {
            config.AddExpressionMapping();
            config.AddCollectionMappers();
            config.AddProfile<GuidRefProfile>();
            config.AddProfile<MetadataProfile>();
            config.AddProfile<LineItemProfile>();
        })))
        {
        }

        [Fact]
        public void CanMapFromAssignDate()
            => CanMapFrom(entity => (DateTime) entity.AssignDate, model => model.AssignDate);

        [Fact]
        public void CanMapFromCategory()
            => CanMapFrom(entity => entity.Category, model => model.Category);

        [Fact]
        public void CanMapFromClass()
            => CanMapFrom(entity => entity.Class, model => model.Class);

        [Fact]
        public void CanMapFromDateLastModified()
            => CanMapFrom(entity => entity.Modified, model => model.DateLastModified);

        [Fact]
        public void CanMapFromDescription()
            => CanMapFrom(entity => entity.Description, model => model.Description);

        [Fact]
        public void CanMapFromDueDate()
            => CanMapFrom(entity => (DateTime) entity.DueDate, model => model.DueDate);

        [Fact]
        public void CanMapFromGradingPeriod()
            => CanMapFrom(entity => entity.GradingPeriod, model => model.GradingPeriod);

        [Fact]
        public void CanMapFromMetadata()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata, model => model.Metadata);

        [Fact]
        public void CanMapFromMetadataWithProjection()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata.Any(metadata => metadata.Key == "foo"), model => model.Metadata.Any(metadata => metadata.Key == "foo"));

        [Fact]
        public void CanMapFromResultValueMax()
            => CanMapFrom(entity => (float) entity.ResultValueMax, model => model.ResultValueMax);

        [Fact]
        public void CanMapFromResultValueMin()
            => CanMapFrom(entity => (float) entity.ResultValueMin, model => model.ResultValueMin);

        [Fact]
        public void CanMapFromSourcedId()
            => CanMapFrom(entity => entity.Id, model => model.SourcedId);

        [Fact]
        public void CanMapFromStatusType()
            => CanMapFrom(entity => entity.Status, model => model.StatusType);

        [Fact]
        public void CanMapFromTitle()
            => CanMapFrom(entity => entity.Title, model => model.Title);
    }
}