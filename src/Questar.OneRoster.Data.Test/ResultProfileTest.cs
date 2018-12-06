namespace Questar.OneRoster.Data.Test
{
    using System;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.EquivalencyExpression;
    using AutoMapper.Extensions.ExpressionMapping;
    using Mappings;
    using Xunit;

    public class ResultProfileTest : ProfileTest<Result, Models.Result>
    {
        public ResultProfileTest() : base(new Mapper(new MapperConfiguration(config =>
        {
            config.AddExpressionMapping();
            config.AddCollectionMappers();
            config.AddProfile<GuidRefProfile>();
            config.AddProfile<MetadataProfile>();
            config.AddProfile<ResultProfile>();
        })))
        {
        }

        [Fact]
        public void CanMapFromComment()
            => CanMapFrom(entity => entity.Comment, model => model.Comment);

        [Fact]
        public void CanMapFromDateLastModified()
            => CanMapFrom(entity => entity.Modified, model => model.DateLastModified);

        [Fact]
        public void CanMapFromLineItem()
            => CanMapFrom(entity => entity.LineItem, model => model.LineItem);

        [Fact]
        public void CanMapFromMetadata()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata, model => model.Metadata);

        [Fact]
        public void CanMapFromMetadataWithProjection()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata.Any(metadata => metadata.Key == "foo"), model => model.Metadata.Any(metadata => metadata.Key == "foo"));

        [Fact]
        public void CanMapFromScore()
            => CanMapFrom(entity => (float) entity.Score, model => model.Score);

        [Fact]
        public void CanMapFromScoreDate()
            => CanMapFrom(entity => (DateTime) entity.ScoreDate, model => model.ScoreDate);

        [Fact]
        public void CanMapFromScoreStatus()
            => CanMapFrom(entity => entity.ScoreStatus, model => model.ScoreStatus);

        [Fact]
        public void CanMapFromSourcedId()
            => CanMapFrom(entity => entity.Id, model => model.SourcedId);

        [Fact]
        public void CanMapFromStatusType()
            => CanMapFrom(entity => entity.Status, model => model.StatusType);

        [Fact]
        public void CanMapFromStudent()
            => CanMapFrom(entity => entity.Student, model => model.Student);
    }
}