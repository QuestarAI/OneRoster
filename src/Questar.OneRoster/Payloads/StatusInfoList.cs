namespace Questar.OneRoster.Payloads
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a list of informational status about an API request/response.
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