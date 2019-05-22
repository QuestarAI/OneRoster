namespace Questar.OneRoster.Payloads
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StatusInfoException : Exception
    {
        public StatusInfoException(IEnumerable<StatusInfo> statuses) =>
            Statuses = statuses.ToList().AsReadOnly();

        public IReadOnlyCollection<StatusInfo> Statuses { get; }
    }
}