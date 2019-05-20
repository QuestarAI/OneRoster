namespace Questar.OneRoster.DataServices
{
    public interface IOneRosterWorkspace : IWorkspace
    {
        IAcademicSessionRepository AcademicSessions { get; }

        ICategoryRepository Categories { get; }

        IClassRepository Classes { get; }

        ICourseRepository Courses { get; }

        IDemographicsRepository Demographics { get; }

        IEnrollmentRepository Enrollments { get; }

        IGradingPeriodRepository GradingPeriods { get; }

        ILineItemRepository LineItems { get; }

        IOrgRepository Orgs { get; }

        IResourceRepository Resources { get; }

        IResultRepository Results { get; }

        ISchoolRepository Schools { get; }

        IStudentRepository Students { get; }

        ITeacherRepository Teachers { get; }

        ITermRepository Terms { get; }

        IUserRepository Users { get; }
    }
}