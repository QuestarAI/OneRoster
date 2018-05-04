namespace Questar.OneRoster.Model.Dto
{
    using System;
    using Common;
    using Vocabulary;

    public class Result : Base
    {
        public GuidRef LineItem { get; set; }
        public GuidRef Student { get; set; }
        public ScoreStatus ScoreStatus { get; set; }
        public double Score { get; set; }
        public DateTime ScoreDate { get; set; }
        public string Comment { get; set; }
    }
}