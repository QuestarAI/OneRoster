using System.Runtime.Serialization;

namespace Questar.OneRoster.Payloads
{
    /// <summary>
    ///     Minor code used in <see cref="StatusInfo" />.
    ///     Note the inconsistent space vs. underscore used in the spec.
    /// </summary>
    public enum CodeMinor
    {
        [EnumMember(Value = "full success")] FullSuccess,

        [EnumMember(Value = "unknown object")] UnknownObject,

        [EnumMember(Value = "invalid data")] InvalidData,

        [EnumMember(Value = "unauthorized")] Unauthorized,

        [EnumMember(Value = "invalid_sort_field")]
        InvalidSortField,

        [EnumMember(Value = "invalid_filter_field")]
        InvalidFilterField,

        [EnumMember(Value = "invalid_selection_field")]
        InvalidSelectionField,

        /// The specification mentions this, but doesn't explicitly define it.
        [EnumMember(Value = "invalid_blank_selection_field")]
        InvalidBlankSelectionField,

        /// The specification does not validate these; we do.
        [EnumMember(Value = "invalid_limit_field")]
        InvalidLimitField,

        /// The specification does not validate these; we do.
        [EnumMember(Value = "invalid_offset_field")]
        InvalidOffsetField,

        /// The specification mentions this, but doesn't explicitly define it.
        [EnumMember(Value = "forbidden")] Forbidden,

        /// The specification mentions this, but doesn't explicitly define it.
        [EnumMember(Value = "server_busy")] ServerBusy
    }
}