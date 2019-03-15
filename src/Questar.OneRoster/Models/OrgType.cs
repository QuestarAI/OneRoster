namespace Questar.OneRoster.Models
{
    using Serialization;

    public enum OrgType
    {
        [SerializationToken("department")] Department,

        [SerializationToken("school")] School,

        [SerializationToken("district")] District,

        [SerializationToken("local")] Local,

        [SerializationToken("state")] State,

        [SerializationToken("national")] National
    }
}