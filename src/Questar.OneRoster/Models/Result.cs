using System;

namespace Questar.OneRoster.Models
{
    public class Result : Base
    {
        public GuidRef LineItem { get; set; }

        public GuidRef Student { get; set; }

        public ScoreStatus ScoreStatus { get; set; }

        public float Score { get; set; }

        public DateTime ScoreDate { get; set; }

        public string Comment { get; set; }
    }
}