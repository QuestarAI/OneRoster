namespace Questar.OneRoster.Data
{
    public interface IBaseObject : IMetadataContainer, IModifiable, IDeletable
    {
        string Id { get; }
    }
}