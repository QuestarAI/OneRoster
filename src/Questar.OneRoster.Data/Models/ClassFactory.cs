namespace Questar.OneRoster.Data.Models
{
    public class ClassFactory
    {
        public Class CreateHomeroom()
        {
            return new Class { Type = ClassType.Homeroom };
        }

        public Class CreateScheduled()
        {
            return new Class { Type = ClassType.Scheduled };
        }
    }
}