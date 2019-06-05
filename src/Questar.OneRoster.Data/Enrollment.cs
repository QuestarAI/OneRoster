using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questar.OneRoster.Data
{
    public class Enrollment : IBaseObject
    {
        internal Enrollment()
        {
        }

        public Enrollment(Class @class)
        {
            Class = @class;
        }

        public virtual DateTime? BeginDate { get; set; }

        public virtual DateTime? EndDate { get; set; }

        public virtual User User { get; set; }

        public virtual string UserId { get; internal set; }

        public virtual Class Class { get; set; }

        public virtual string ClassId { get; internal set; }

        // applicable only to teachers
        public virtual bool? Primary { get; set; }

        #region Base Object

        [DatabaseGenerated(DatabaseGeneratedOption.None)] [MaxLength(10)] public virtual string Id { get; internal set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual string MetadataCollectionId { get; internal set; }

        public virtual Status Status { get; internal set; }

        public virtual DateTime Modified { get; internal set; }

        #endregion
    }
}