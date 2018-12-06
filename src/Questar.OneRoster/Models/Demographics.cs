namespace Questar.OneRoster.Models
{
    using System;

    public class Demographics : Base
    {
        public DateTime? BirthDate { get; set; }

        public Gender? Sex { get; set; }

        public bool? AmericanIndianOrAlaskaNative { get; set; }

        public bool? Asian { get; set; }

        public bool? BlackOrAfricanAmerican { get; set; }

        public bool? NativeHawaiianOrOtherPacificIslander { get; set; }

        public bool? White { get; set; }

        public bool? DemographicRaceTwoOrMoreRaces { get; set; }

        public bool? HispanicOrLatinoEthnicity { get; set; }

        public string CountryOfBirthCode { get; set; } // TODO string

        public string StateOfBirthAbbreviation { get; set; } // TODO string

        public string CityOfBirth { get; set; }

        public string PublicSchoolResidenceStatus { get; set; } // TODO string
    }
}