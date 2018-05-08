namespace Questar.OneRoster.Vocabulary
{
    using Serialization;

    public enum RoleType
    {
        [SerializationToken("administrator")]
        Administrator,

        [SerializationToken("aide")]
        Aide,

        [SerializationToken("guardian")]
        Guardian,

        [SerializationToken("parent")]
        Parent,

        [SerializationToken("proctor")]
        Proctor,

        [SerializationToken("relative")]
        Relative,

        [SerializationToken("student")]
        Student,

        [SerializationToken("teacher")]
        Teacher,
    }
}