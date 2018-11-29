namespace Questar.OneRoster.Models
{
    using System;
    using Common;
    using Vocabulary;
    using Vocabulary.Ceds;

    public class Demographics : Base
    {
        public DateTime BirthDate { get; set; }
        public Gender Sex { get; set; }
        public bool AmericanIndianOrAlaskaNative { get; set; }
        public bool Asian { get; set; }
        public bool BlackOrAfricanAmerican { get; set; }
        public bool NativeHawaiianOrOtherPacificIslander { get; set; }
        public bool White { get; set; }
        public bool DemographicRaceTwoOrMoreRaces { get; set; }
        public bool HispanicOrLatinoEthnicity { get; set; }
        public CountryCode CountryOfBirthCode { get; set; }
        public StateCode StateOfBirthAbbreviation { get; set; }
        public string CityOfBirth { get; set; }
        public PublicSchoolResidenceStatus PublicSchoolResidenceStatus { get; set; }
    }
}