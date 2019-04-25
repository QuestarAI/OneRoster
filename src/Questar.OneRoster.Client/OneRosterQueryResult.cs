namespace Questar.OneRoster.Client
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.Errors;

    public class OneRosterQueryResult<T> : EnumerableQuery<T>
    {
        public OneRosterQueryResult(IEnumerable<T> items, int total, IEnumerable<StatusInfo> statuses) : base(items)
        {
            Total = total;
            Statuses = statuses;
        }

        public IEnumerable<StatusInfo> Statuses { get; }

        public int Total { get; }
    }
}