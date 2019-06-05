using System.Runtime.Serialization;

namespace Questar.OneRoster.Models
{
    public enum AcademicSessionType
    {
        [EnumMember(Value = "gradingPeriod")] GradingPeriod,

        [EnumMember(Value = "semester")] Semester,

        [EnumMember(Value = "schoolYear")] SchoolYear,

        [EnumMember(Value = "term")] Term
    }
}