using AutoMapper;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.DataServices.EntityFrameworkCore;

namespace Questar.OneRoster.Data.Services
{
    public class OneRosterWorkspace : BaseWorkspace<OneRosterDbContext>, IOneRosterWorkspace
    {
        public OneRosterWorkspace(OneRosterDbContext context, IMapper mapper) : base(context)
        {
            AcademicSessions = new AcademicSessionRepository(Context, mapper);
            Categories = new CategoryRepository(Context, mapper);
            Classes = new ClassRepository(Context, mapper);
            Courses = new CourseRepository(Context, mapper);
            Demographics = new DemographicsRepository(Context, mapper);
            Enrollments = new EnrollmentRepository(Context, mapper);
            GradingPeriods = new GradingPeriodRepository(Context, mapper);
            LineItems = new LineItemRepository(Context, mapper);
            Orgs = new OrgRepository(Context, mapper);
            Resources = new ResourceRepository(Context, mapper);
            Results = new ResultRepository(Context, mapper);
            Schools = new SchoolRepository(Context, mapper);
            Students = new StudentRepository(Context, mapper);
            Teachers = new TeacherRepository(Context, mapper);
            Terms = new TermRepository(Context, mapper);
            Users = new UserRepository(Context, mapper);
        }

        public IAcademicSessionRepository AcademicSessions { get; }

        public ICategoryRepository Categories { get; }

        public IClassRepository Classes { get; }

        public ICourseRepository Courses { get; }

        public IDemographicsRepository Demographics { get; }

        public IEnrollmentRepository Enrollments { get; }

        public IGradingPeriodRepository GradingPeriods { get; }

        public ILineItemRepository LineItems { get; }

        public IOrgRepository Orgs { get; }

        public IResourceRepository Resources { get; }

        public IResultRepository Results { get; }

        public ISchoolRepository Schools { get; }

        public IStudentRepository Students { get; }

        public ITeacherRepository Teachers { get; }

        public ITermRepository Terms { get; }

        public IUserRepository Users { get; }
    }
}