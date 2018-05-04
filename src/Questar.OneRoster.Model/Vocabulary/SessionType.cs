namespace Questar.OneRoster.Model.Vocabulary
{
    using Serialization;

    public enum SessionType
    {
        [SerializationToken("gradingPeriod")]
        GradingPeriod,

        [SerializationToken("semester")]
        Semester,

        [SerializationToken("schoolYear")]
        SchoolYear,

        [SerializationToken("term")]
        Term,
    }
}