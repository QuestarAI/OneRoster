namespace Questar.OneRoster.Vocabulary
{
    using Serialization;

    public enum ScoreStatus
    {
        [SerializationToken("exempt")]
        Exempt,

        [SerializationToken("fully graded")]
        FullyGraded,

        [SerializationToken("not submitted")]
        NotSubmitted,

        [SerializationToken("partially graded")]
        PartiallyGraded,

        [SerializationToken("submitted")]
        Submitted,
    }
}