namespace Questar.OneRoster.Data.Models
{
    using System;

    public interface IMetadataContainer
    {
        MetadataCollection MetadataCollection { get; }

        Guid? MetadataCollectionId { get; }
    }
}