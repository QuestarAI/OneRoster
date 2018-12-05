namespace Questar.OneRoster.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class LineItem : IBaseObject
    {
        [Required]
        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        [Required]
        public virtual DateTime? AssignDate { get; set; }

        [Required]
        public virtual DateTime? DueDate { get; set; }

        public virtual Class Class { get; private set; }

        public virtual Guid ClassId { get; private set; }

        public virtual Category Category { get; set; } // TODO one-time only?

        public virtual Guid CategoryId { get; private set; }

        public virtual AcademicSession GradingPeriod { get; set; } // TODO one-time only?

        public virtual Guid GradingPeriodId { get; private set; }

        public virtual IReadOnlyCollection<Result> Results { get; } = new HashSet<Result>();

        [Required]
        public virtual double? ResultValueMin { get; set; }

        [Required]
        public virtual double? ResultValueMax { get; set; }

        #region Base Object

        public virtual Guid Id { get; private set; }

        public virtual MetadataCollection MetadataCollection { get; private set; } = new MetadataCollection();

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual Status Status { get; private set; }

        public virtual DateTime Modified { get; private set; }

        #endregion
    }
}