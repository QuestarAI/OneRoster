namespace Questar.OneRoster.Api.RequestModels
{
    using System;

    public class EndpointRequest<T>
    {
        public string Fields { get; set; }

        public Func<T, bool> Predicate = obj => true;
    }
}