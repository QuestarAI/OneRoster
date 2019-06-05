namespace Questar.OneRoster.Data
{
    public interface IMetadataContainer
    {
        MetadataCollection MetadataCollection { get; }

        int? MetadataCollectionId { get; }
    }
}