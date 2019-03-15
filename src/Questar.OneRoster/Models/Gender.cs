namespace Questar.OneRoster.Models
{
    using Serialization;

    public enum Gender
    {
        [SerializationToken("male")] Male,

        [SerializationToken("female")] Female
    }
}