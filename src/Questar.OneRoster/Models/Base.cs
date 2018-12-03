namespace Questar.OneRoster.Models
{
    using System;

    /// <summary>
    /// The base class used by all objects.
    /// </summary>
    public abstract class Base
    {
        /// <summary>
        /// Gets or sets the sourced identifier. This is the primary key for the object (as far as OneRoster is concerned).
        /// </summary>
        public Guid SourcedId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public StatusType Status { get; set; }

        /// <summary>
        /// Gets or sets the date this object was last modified.
        /// </summary>
        public DateTime DateLastModified { get; set; }

        /// <summary>
        /// Gets or sets the additional metadata associated with this object.
        /// Generally, this is used to extend an object with information outside the spec.
        /// </summary>
        public Metadata Metadata { get; set; }
    }
}