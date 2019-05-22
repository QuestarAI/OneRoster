namespace Questar.OneRoster.Data
{
    using System;

    public interface IMetadataContainer
    {
        MetadataCollection MetadataCollection { get; }

        Guid? MetadataCollectionId { get; }
    }
}