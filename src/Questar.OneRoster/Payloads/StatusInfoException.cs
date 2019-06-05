using System;
using System.Collections.Generic;
using System.Linq;

namespace Questar.OneRoster.Payloads
{
    public class StatusInfoException : Exception
    {
        public StatusInfoException(IEnumerable<StatusInfo> statuses)
        {
            Statuses = statuses.ToList().AsReadOnly();
        }

        public IReadOnlyCollection<StatusInfo> Statuses { get; }
    }
}