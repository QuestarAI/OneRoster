namespace Questar.OneRoster.Client
{
    internal interface IOneRosterQueryResultProvider<T>
    {
        OneRosterQueryResult<T> GetQueryResult();
    }
}