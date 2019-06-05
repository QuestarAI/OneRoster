using System.Collections.Generic;

namespace Questar.OneRoster.Models
{
    public class Resource : Base
    {
        public string Title { get; set; }

        public ICollection<RoleType> Roles { get; set; }

        public Importance? Importance { get; set; }

        public string VendorResourceId { get; set; }

        public string VendorId { get; set; }

        public string ApplicationId { get; set; }
    }
}