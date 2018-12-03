namespace Questar.OneRoster.Client
{
    using System.Linq;
    using Models;

    public class Client
    {
        public IQueryable<AcademicSession> AcademicSessions { get; } = new OrderedQueryable<AcademicSession>();
        public IQueryable<Category> Categories { get; } = new OrderedQueryable<Category>();
        public IQueryable<Class> Classes { get; } = new OrderedQueryable<Class>();
        public IQueryable<Course> Courses { get; } = new OrderedQueryable<Course>();
        public IQueryable<Demographics> Demographics { get; } = new OrderedQueryable<Demographics>();
        public IQueryable<Enrollment> Enrollments { get; } = new OrderedQueryable<Enrollment>();
        public IQueryable<AcademicSession> GradingPeriods { get; } = new OrderedQueryable<AcademicSession>();
        public IQueryable<LineItem> LineItems { get; } = new OrderedQueryable<LineItem>();
        public IQueryable<Org> Orgs { get; } = new OrderedQueryable<Org>();
        public IQueryable<Resource> Resources { get; } = new OrderedQueryable<Resource>();
        public IQueryable<Result> Results { get; } = new OrderedQueryable<Result>();
        public IQueryable<Org> Schools { get; } = new OrderedQueryable<Org>();
        public IQueryable<User> Students { get; } = new OrderedQueryable<User>();
        public IQueryable<User> Teachers { get; } = new OrderedQueryable<User>();
        public IQueryable<AcademicSession> Terms { get; } = new OrderedQueryable<AcademicSession>();
        public IQueryable<User> Users { get; } = new OrderedQueryable<User>();
    }
}