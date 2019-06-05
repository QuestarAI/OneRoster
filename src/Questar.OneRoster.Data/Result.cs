using System;
using System.ComponentModel.DataAnnotations;

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

        public virtual int LineItemId { get; internal set; }

        public virtual User Student { get; internal set; }

        public virtual int StudentId { get; internal set; }

        [Required] public virtual float? Score { get; set; }

        [Required] public virtual DateTime? ScoreDate { get; set; }

        [Required] public virtual ResultScoreStatus? ScoreStatus { get; set; }

        #region Base Object

        public virtual int Id { get; internal set; }

        public virtual MetadataCollection MetadataCollection { get; set; }

        public virtual int? MetadataCollectionId { get; internal set; }

        public virtual Status Status { get; internal set; }

        public virtual DateTime Modified { get; internal set; }

        #endregion
    }
}