namespace Questar.OneRoster.Data
{
    public interface IMetadataContainer
    {
        MetadataCollection MetadataCollection { get; }

        string MetadataCollectionId { get; }
    }
}