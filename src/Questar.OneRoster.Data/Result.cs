namespace Questar.OneRoster.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Result : IBaseObject
    {
        public Result(LineItem item) =>
            LineItem = item;

        private Result()
        {
        }

        public virtual string Comment { get; set; }

        public virtual LineItem LineItem { get; private set; }
        
        [Required]
        public virtual string LineItemId { get; private set; }

        public virtual User Student { get; private set; }

        [Required]
        public virtual string StudentId { get; private set; }

        [Required]
        public virtual float? Score { get; set; }

        [Required]
        public virtual DateTime? ScoreDate { get; set; }

        [Required]
        public virtual ResultScoreStatus? ScoreStatus { get; set; }

        #region Base Object

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual string Id { get; private set; } = Guid.NewGuid().ToString().Substring(0, 10);

        public virtual MetadataCollection MetadataCollection { get; private set; } = new MetadataCollection();

        public virtual Guid? MetadataCollectionId { get; private set; }

        public virtual Status Status { get; private set; }

        public virtual DateTime Modified { get; private set; }

        #endregion
    }
}