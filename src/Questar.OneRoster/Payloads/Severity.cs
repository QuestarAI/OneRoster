namespace Questar.OneRoster.Payloads
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Severity used in <see cref="StatusInfo" />.
    /// </summary>
    public enum Severity
    {
        [EnumMember(Value = "status")]
        Status = 0,

        [EnumMember(Value = "warning")]
        Warning = 1,

        [EnumMember(Value = "error")]
        Error = 2
    }
}