using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questar.OneRoster.Data
{
    public class Result : IBaseObject
    {
        public Result(LineItem item)
        {
            LineItem = item;
        }

        internal Result()
        {
        }

        public virtual string Comment { get; set; }

        public virtual LineItem LineItem { get; internal set; }

        public virtual string LineItemId { get; internal set; }

        public virtual User Student { get; internal set; }

        public virtual string StudentId { get; internal set; }

        [Required] public virtual float? Score { get; set; }

        [Required] public virtual DateTime? ScoreDate { get; set; }

        [Required] public virtual ResultScoreStatus? ScoreStatus { get; set; }

        #region Base Object

        [DatabaseGenerated(DatabaseGeneratedOption.None)] [MaxLength(10)] public virtual string Id { get; internal set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual string MetadataCollectionId { get; internal set; }

        public virtual Status Status { get; internal set; }

        public virtual DateTime Modified { get; internal set; }

        #endregion
    }
}