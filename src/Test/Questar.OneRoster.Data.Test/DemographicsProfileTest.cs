namespace Questar.OneRoster.Data.Test
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.EquivalencyExpression;
    using AutoMapper.Extensions.ExpressionMapping;
    using Models;
    using Profiles;
    using Xunit;
    using Demographics = Data.Demographics;

    public class DemographicsProfileTest : ProfileTest<Demographics, Models.Demographics>
    {
        public DemographicsProfileTest() : base(new Mapper(new MapperConfiguration(config =>
        {
            config.AddExpressionMapping();
            config.AddCollectionMappers();
            config.AddProfile<GuidRefProfile>();
            config.AddProfile<MetadataProfile>();
            config.AddProfile<DemographicsProfile>();
        })))
        {
        }

        [Fact]
        public void CanMapFromAmericanIndianOrAlaskaNative()
            => CanMapFrom(entity => entity.AmericanIndianOrAlaskaNative, model => model.AmericanIndianOrAlaskaNative);

        [Fact]
        public void CanMapFromAsian()
            => CanMapFrom(entity => entity.Asian, model => model.Asian);

        [Fact]
        public void CanMapFromBirthDate()
            => CanMapFrom(entity => entity.BirthDate, model => model.BirthDate);

        [Fact]
        public void CanMapFromBlackOrAfricanAmerican()
            => CanMapFrom(entity => entity.BlackOrAfricanAmerican, model => model.BlackOrAfricanAmerican);

        [Fact]
        public void CanMapFromCityOfBirth()
            => CanMapFrom(entity => entity.CityOfBirth, model => model.CityOfBirth);

        [Fact]
        public void CanMapFromCountryOfBirthCode()
            => CanMapFrom(entity => entity.CountryOfBirthCode, model => model.CountryOfBirthCode);

        [Fact]
        public void CanMapFromDateLastModified()
            => CanMapFrom(entity => entity.Modified, model => model.DateLastModified);

        [Fact]
        public void CanMapFromDemographicRaceTwoOrMoreRaces()
            => CanMapFrom(entity => entity.DemographicRaceTwoOrMoreRaces, model => model.DemographicRaceTwoOrMoreRaces);

        [Fact]
        public void CanMapFromHispanicOrLatinoEthnicity()
            => CanMapFrom(entity => entity.HispanicOrLatinoEthnicity, model => model.HispanicOrLatinoEthnicity);

        [Fact]
        public void CanMapFromMetadata()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata, model => model.Metadata);

        [Fact]
        public void CanMapFromMetadataWithProjection()
            => CanMapFrom(entity => entity.MetadataCollection.Metadata.Any(metadata => metadata.Key == "foo"), model => model.Metadata.Any(metadata => metadata.Key == "foo"));

        [Fact]
        public void CanMapFromNativeHawaiianOrOtherPacificIslander()
            => CanMapFrom(entity => entity.NativeHawaiianOrOtherPacificIslander, model => model.NativeHawaiianOrOtherPacificIslander);

        [Fact]
        public void CanMapFromPublicSchoolResidenceStatus()
            => CanMapFrom(entity => entity.PublicSchoolResidenceStatus, model => model.PublicSchoolResidenceStatus);

        [Fact]
        public void CanMapFromSex()
            => CanMapFrom(entity => (Gender) entity.Sex, model => model.Sex);

        [Fact]
        public void CanMapFromSourcedId()
            => CanMapFrom(entity => entity.Id, model => model.SourcedId);

        [Fact]
        public void CanMapFromStateOfBirthAbbreviation()
            => CanMapFrom(entity => entity.StateOfBirthAbbreviation, model => model.StateOfBirthAbbreviation);

        [Fact]
        public void CanMapFromStatusType()
            => CanMapFrom(entity => (StatusType) entity.Status, model => model.StatusType);

        [Fact]
        public void CanMapFromWhite()
            => CanMapFrom(entity => entity.White, model => model.White);
    }
}