namespace Questar.OneRoster.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category : IBaseObject
    {
        [Required]
        public virtual string Title { get; set; }

        public virtual ICollection<LineItem> LineItems { get; } = new HashSet<LineItem>();

        #region Base Object

        public virtual Guid Id { get; private set; }

        public virtual MetadataCollection MetadataCollection { get; private set; } = new MetadataCollection();

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual bool Active { get; private set; }

        public virtual DateTimeOffset Modified { get; private set; }

        #endregion
    }
}