namespace Questar.OneRoster.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Result : IBaseObject
    {
        public Result(LineItem item)
        {
            LineItem = item;
        }

        private Result()
        {
        }

        public virtual LineItem LineItem { get; private set; }

        public virtual Guid LineItemId { get; private set; }

        public virtual User Student { get; private set; }

        public virtual Guid StudentId { get; private set; }

        [Required]
        public virtual int? Score { get; set; }

        [Required]
        public virtual DateTimeOffset? ScoreDate { get; set; }

        [Required]
        public virtual ResultScoreStatus? ScoreStatus { get; set; }

        #region Base Object

        public virtual Guid Id { get; private set; }

        public virtual MetadataCollection MetadataCollection { get; private set; } = new MetadataCollection();

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual bool Active { get; private set; }

        public virtual DateTimeOffset Modified { get; private set; }

        #endregion
    }
}