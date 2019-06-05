using System.Collections.Generic;

namespace Questar.OneRoster.Payloads
{
    /// <summary>
    ///     Represents a list of informational status about an API request/response.
    /// </summary>
    public class StatusInfoList : List<StatusInfo>
    {
        public StatusInfoList()
        {
        }

        public StatusInfoList(IEnumerable<StatusInfo> collection)
            : base(collection)
        {
        }

        public StatusInfoList(int capacity) : base(capacity)
        {
        }
    }
}