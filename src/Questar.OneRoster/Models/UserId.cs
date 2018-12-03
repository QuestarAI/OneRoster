namespace Questar.OneRoster.Models
{
    /// <summary>
    /// Represents external user identifiers, allowing storage of arbitrary information.
    /// That is, there is no vocabulary for this model and vendors must agree on conventions.
    /// </summary>
    public class UserId
    {
        public string Type { get; set; }
        public string Identifier { get; set; }
    }
}