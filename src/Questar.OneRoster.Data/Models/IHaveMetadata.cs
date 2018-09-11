namespace Questar.OneRoster.Data.Models
{
    using System;

    public interface IHaveMetadata
    {
        MetadataCollection MetadataCollection { get; }

        Guid? MetadataCollectionId { get; }
    }
}