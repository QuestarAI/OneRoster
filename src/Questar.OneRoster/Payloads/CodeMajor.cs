namespace Questar.OneRoster.Payloads
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Major code used in <see cref="StatusInfo" />.
    /// </summary>
    public enum CodeMajor
    {
        [EnumMember(Value = "success")]
        Success,

        [EnumMember(Value = "failure")]
        Failure,

        [EnumMember(Value = "unsupported")]
        Unsupported
    }
}