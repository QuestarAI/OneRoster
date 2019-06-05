using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questar.OneRoster.Data
{
    public class Category : IBaseObject
    {
        [Required] public virtual string Title { get; set; }

        public virtual ICollection<LineItem> LineItems { get; } = new HashSet<LineItem>();

        #region Base Object

        public virtual int Id { get; internal set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual int? MetadataCollectionId { get; internal set; }

        public virtual Status Status { get; internal set; }

        public virtual DateTime Modified { get; internal set; }

        #endregion
    }
}