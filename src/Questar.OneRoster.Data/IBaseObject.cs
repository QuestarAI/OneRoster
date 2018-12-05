namespace Questar.OneRoster.Data
{
    using System;

    public interface IBaseObject : IMetadataContainer, IModifiable, IDeletable
    {
        Guid Id { get; }
    }
}