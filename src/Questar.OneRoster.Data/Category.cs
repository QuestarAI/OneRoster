using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questar.OneRoster.Data
{
    public class Category : IBaseObject
    {
        [Required] public virtual string Title { get; set; }

        public virtual ICollection<LineItem> LineItems { get; } = new HashSet<LineItem>();

        #region Base Object

        [DatabaseGenerated(DatabaseGeneratedOption.None)] [MaxLength(10)] public virtual string Id { get; internal set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual string MetadataCollectionId { get; internal set; }

        public virtual Status Status { get; internal set; }

        public virtual DateTime Modified { get; internal set; }

        #endregion
    }
}