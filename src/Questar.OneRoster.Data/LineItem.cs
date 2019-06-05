using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questar.OneRoster.Data
{
    public class LineItem : IBaseObject
    {
        [Required] public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        [Required] public virtual DateTime? AssignDate { get; set; }

        [Required] public virtual DateTime? DueDate { get; set; }

        public virtual Class Class { get; internal set; }

        public virtual int ClassId { get; internal set; }

        public virtual Category Category { get; set; }

        public virtual int CategoryId { get; internal set; }

        public virtual AcademicSession GradingPeriod { get; set; }

        public virtual int GradingPeriodId { get; internal set; }

        public virtual IReadOnlyCollection<Result> Results { get; } = new HashSet<Result>();

        [Required] public virtual float? ResultValueMin { get; set; }

        [Required] public virtual float? ResultValueMax { get; set; }

        #region Base Object

        public virtual int Id { get; internal set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual int? MetadataCollectionId { get; internal set; }

        public virtual Status Status { get; internal set; }

        public virtual DateTime Modified { get; internal set; }

        #endregion
    }
}