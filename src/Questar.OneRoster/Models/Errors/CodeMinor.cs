namespace Questar.OneRoster.Models.Errors
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

        /// The specification does not validate these; we do.
        [EnumMember(Value = "invalid_limit_field")]
        InvalidLimitField,

        /// The specification does not validate these; we do.
        [EnumMember(Value = "invalid_offset_field")]
        InvalidOffsetField,

        [EnumMember(Value = "invalid_blank_selection_field")]
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