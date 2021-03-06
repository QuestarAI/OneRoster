namespace Questar.OneRoster.Models
{
    /// <summary>
    /// Represents a reference to an object.
    /// </summary>
    public class GuidRef
    {
        /// <summary>
        /// Gets or sets the URI/URL to retrieve this object.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Gets or sets the primary identifier.
        /// </summary>
        public string SourcedId { get; set; }

        /// <summary>
        /// Gets or sets the type of the object.
        /// </summary>
        public GuidType Type { get; set; }
    }
}