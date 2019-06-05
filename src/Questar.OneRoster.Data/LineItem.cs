using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questar.OneRoster.Data
{
    public class LineItem : IBaseObject
    {
        [Required] public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        [Required] public virtual DateTime? AssignDate { get; set; }

        [Required] public virtual DateTime? DueDate { get; set; }

        public virtual Class Class { get; internal set; }

        public virtual string ClassId { get; internal set; }

        public virtual Category Category { get; set; }

        public virtual string CategoryId { get; internal set; }

        public virtual AcademicSession GradingPeriod { get; set; }

        public virtual string GradingPeriodId { get; internal set; }

        public virtual IReadOnlyCollection<Result> Results { get; } = new HashSet<Result>();

        [Required] public virtual float? ResultValueMin { get; set; }

        [Required] public virtual float? ResultValueMax { get; set; }

        #region Base Object

        [DatabaseGenerated(DatabaseGeneratedOption.None)] [MaxLength(10)] public virtual string Id { get; internal set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual string MetadataCollectionId { get; internal set; }

        public virtual Status Status { get; internal set; }

        public virtual DateTime Modified { get; internal set; }

        #endregion
    }
}