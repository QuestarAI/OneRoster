using System.Collections.Generic;

namespace Questar.OneRoster.Models
{
    public class Org : Base
    {
        public string Name { get; set; }

        public OrgType Type { get; set; }

        public string Identifier { get; set; }

        public GuidRef Parent { get; set; }

        public ICollection<GuidRef> Children { get; set; }
    }
}