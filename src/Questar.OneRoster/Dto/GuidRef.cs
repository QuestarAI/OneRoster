namespace Questar.OneRoster.Dto
{
    using System;
    using Common;

    public class GuidRef
    {
        public Uri Href { get; set; }
        public Guid SourcedId { get; set; }
        public GuidType Type { get; set; }
    }
}
