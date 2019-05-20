namespace Questar.OneRoster.Data.Services
{
    using AutoMapper;
    using DataServices;

    public class CourseRepository : BaseRepository<Models.Course, Course>, ICourseRepository
    {
        public CourseRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}