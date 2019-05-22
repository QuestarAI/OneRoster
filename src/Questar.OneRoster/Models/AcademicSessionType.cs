namespace Questar.OneRoster.Models
{
    using System.Runtime.Serialization;

    public enum AcademicSessionType
    {
        [EnumMember(Value = "gradingPeriod")]
        GradingPeriod,

        [EnumMember(Value = "semester")]
        Semester,

        [EnumMember(Value = "schoolYear")]
        SchoolYear,

        [EnumMember(Value = "term")]
        Term
    }
}