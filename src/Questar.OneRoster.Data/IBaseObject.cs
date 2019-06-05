namespace Questar.OneRoster.Data
{
    public interface IBaseObject : IMetadataContainer, IModifiable, IDeletable
    {
        int Id { get; }
    }
}