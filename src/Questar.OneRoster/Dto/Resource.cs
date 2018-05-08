namespace Questar.OneRoster.Dto
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Vocabulary;

    public class Resource : Base
    {
        public string Title { get; set; }
        public IEnumerable<RoleType> Roles { get; set; } = Enumerable.Empty<RoleType>();
        public Importance? Importance { get; set; }
        public string VendorResourceId { get; set; }
        public string VendorId { get; set; }
        public string ApplicationId { get; set; }
    }
}