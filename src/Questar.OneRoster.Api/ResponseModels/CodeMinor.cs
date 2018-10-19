namespace Questar.OneRoster.Api.ResponseModels
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Minor code used in <see cref="StatusInfo" />.
    /// Note the inconsistent space vs. underscore used in the spec.
    /// </summary>
    public enum CodeMinor
    {
        [EnumMember(Value = "full success")]
        FullSuccess,

        [EnumMember(Value = "invalid_sort_field")]
        InvalidSortField,

        [EnumMember(Value = "invalid_selection_field")]
        InvalidSelectionField,

        [EnumMember(Value = "invalid data")]
        InvalidData,

        [EnumMember(Value = "invalid_filter_field")]
        InvalidFilterField,

        [EnumMember(Value = "invalid_ blank_selection _field")]
        InvalidBlankSelectionField,

        [EnumMember(Value = "unauthorized")]
        Unauthorized,

        [EnumMember(Value = "forbidden")]
        Forbidden,

        [EnumMember(Value = "unknown object")]
        UnknownObject,

        [EnumMember(Value = "server_busy")]
        ServerBusy,
    }
}