namespace Questar.OneRoster.Data.Models
{
    public class ClassFactory
    {
        public Class BuildHomeroom() => new Class { Type = ClassType.Homeroom };
        public Class BuildScheduled() => new Class { Type = ClassType.Scheduled };
    }
}