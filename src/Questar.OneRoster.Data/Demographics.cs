namespace Questar.OneRoster.Data
{
    using System;

    public class Demographics : IBaseObject
    {
        internal Demographics()
        {
        }

        public virtual User User { get; private set; }
        
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

        public virtual Guid Id { get; private set; }

        public virtual MetadataCollection MetadataCollection { get; private set; } = new MetadataCollection();

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual Status Status { get; private set; }

        public virtual DateTime Modified { get; private set; }

        #endregion
    }
}