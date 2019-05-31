namespace Questar.OneRoster.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Enrollment : IBaseObject
    {
        public Enrollment(Class @class) =>
            Class = @class;

        private Enrollment()
        {
        }

        public virtual DateTime? BeginDate { get; set; }

        public virtual DateTime? EndDate { get; set; }

        public virtual User User { get; private set; }

        [Required]
        public virtual string UserId { get; private set; }

        public virtual Class Class { get; private set; }

        [Required]
        public virtual string ClassId { get; private set; }

        // applicable only to teachers
        public virtual bool? Primary { get; set; }

        #region Base Object

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual string Id { get; private set; } = Guid.NewGuid().ToString().Substring(0, 10);

        public virtual MetadataCollection MetadataCollection { get; private set; } = new MetadataCollection();

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual Status Status { get; private set; }

        public virtual DateTime Modified { get; private set; }

        #endregion
    }
}