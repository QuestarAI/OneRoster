namespace Questar.OneRoster.Data.Entities
{
    using System;

    public interface IHaveMetadata
    {
        MetadataCollection MetadataCollection { get; }

        Guid? MetadataCollectionId { get; }
    }
}