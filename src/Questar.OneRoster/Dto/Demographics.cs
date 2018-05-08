namespace Questar.OneRoster.Dto
{
    using System;
    using Common;
    using Vocabulary;
    using Vocabulary.Ceds;

    public class Demographics<TGender, TCountryCode, TStateCode, TPublicSchoolResidenceStatus> : Base
    {
        public DateTime BirthDate { get; set; }
        public TGender Sex { get; set; }
        public bool AmericanIndianOrAlaskaNative { get; set; }
        public bool Asian { get; set; }
        public bool BlackOrAfricanAmerican { get; set; }
        public bool NativeHawaiianOrOtherPacificIslander { get; set; }
        public bool White { get; set; }
        public bool DemographicRaceTwoOrMoreRaces { get; set; }
        public bool HispanicOrLatinoEthnicity { get; set; }
        public TCountryCode CountryOfBirthCode { get; set; }
        public TStateCode StateOfBirthAbbreviation { get; set; }
        public string CityOfBirth { get; set; }
        public TPublicSchoolResidenceStatus PublicSchoolResidenceStatus { get; set; }
    }

    public class RecommendedDemographics : Demographics<Gender, CountryCode, StateCode, PublicSchoolResidenceStatus> { }
}