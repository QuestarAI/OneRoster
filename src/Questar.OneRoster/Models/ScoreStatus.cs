using System.Runtime.Serialization;

namespace Questar.OneRoster.Models
{
    public enum ScoreStatus
    {
        [EnumMember(Value = "exempt")] Exempt,

        [EnumMember(Value = "fully graded")] FullyGraded,

        [EnumMember(Value = "not submitted")] NotSubmitted,

        [EnumMember(Value = "partially graded")]
        PartiallyGraded,

        [EnumMember(Value = "submitted")] Submitted
    }
}