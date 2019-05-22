namespace Questar.OneRoster.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Errors;

    public class OneRosterException : Exception
    {
        public OneRosterException(IEnumerable<StatusInfo> statuses) =>
            Statuses = statuses.ToList().AsReadOnly();

        public IReadOnlyCollection<StatusInfo> Statuses { get; }
    }
}