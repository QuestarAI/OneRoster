using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questar.OneRoster.Data
{
    public class Demographics : IBaseObject
    {
        internal Demographics()
        {
        }

        public virtual User User { get; internal set; }

        public virtual DateTime? BirthDate { get; set; }

        public virtual Gender? Sex { get; set; }

        public virtual bool? AmericanIndianOrAlaskaNative { get; set; }

        public virtual bool? Asian { get; set; }

        public virtual bool? BlackOrAfricanAmerican { get; set; }

        public virtual bool? NativeHawaiianOrOtherPacificIslander { get; set; }

        public virtual bool? White { get; set; }

        public virtual bool? DemographicRaceTwoOrMoreRaces { get; set; }

        public virtual bool? HispanicOrLatinoEthnicity { get; set; }

        // TODO https://ceds.ed.gov/CEDSElementDetails.aspx?TermxTopicId=20002
        public virtual string CountryOfBirthCode { get; set; }

        // TODO https://ceds.ed.gov/CEDSElementDetails.aspx?TermxTopicId=20837
        public virtual string StateOfBirthAbbreviation { get; set; }

        public virtual string CityOfBirth { get; set; }

        // TODO https://ceds.ed.gov/CEDSElementDetails.aspx?TermxTopicId=20863
        public virtual string PublicSchoolResidenceStatus { get; set; }

        #region Base Object

        [DatabaseGenerated(DatabaseGeneratedOption.None)] [MaxLength(10)] public virtual string Id { get; internal set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual string MetadataCollectionId { get; internal set; }

        public virtual Status Status { get; internal set; }

        public virtual DateTime Modified { get; internal set; }

        #endregion
    }
}