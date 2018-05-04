namespace Questar.OneRoster.Model.Dto
{
    using System;

    public class GuidRef
    {
        public Uri Href { get; set; }
        public Guid SourcedId { get; set; }
        public GuidType Type { get; set; }
    }
}
