namespace Questar.OneRoster.Api.RequestModels
{
    using Query;

    public class CollectionEndpointRequest<T> : EndpointRequest<T>
    {
        public int Limit { get; set; } = 100;
        public int Offset { get; set; } = 0;
        public string Sort { get; set; }
        public SortDirection? OrderBy { get; set; }
        public string Filter { get; set; }
    }
}