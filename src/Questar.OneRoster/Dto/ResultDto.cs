namespace Questar.OneRoster.Dto
{
    using System;
    using Common;
    using Vocabulary;

    public class ResultDto : Base
    {
        public GuidRefDto LineItem { get; set; }
        public GuidRefDto Student { get; set; }
        public ScoreStatus ScoreStatus { get; set; }
        public double Score { get; set; }
        public DateTime ScoreDate { get; set; }
        public string Comment { get; set; }
    }
}