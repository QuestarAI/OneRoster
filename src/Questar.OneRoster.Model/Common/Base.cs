namespace Questar.OneRoster.Model.Common
{
    using System;
    using Vocabulary;

    public abstract class Base
    {
        public Guid SourceId { get; set; }

        public StatusType Status { get; set; }

        public DateTime DateLastModified { get; set; }

        public Metadata Metadata { get; set; }
    }
}