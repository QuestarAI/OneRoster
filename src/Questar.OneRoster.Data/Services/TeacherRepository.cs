namespace Questar.OneRoster.Data.Services
{
    using System.Linq;
    using AutoMapper;
    using DataServices;

    public class TeacherRepository : BaseRepository<Models.User, User>, ITeacherRepository
    {
        public TeacherRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper, context.Set<User>().Where(user => user.Type == UserType.Teacher))
        {
        }
    }
}