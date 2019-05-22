namespace Questar.OneRoster.Models
{
    using Serialization;

    public enum AcademicSessionType
    {
        [SerializationToken("gradingPeriod")]
        GradingPeriod,

        [SerializationToken("semester")]
        Semester,

        [SerializationToken("schoolYear")]
        SchoolYear,

        [SerializationToken("term")]
        Term
    }
}