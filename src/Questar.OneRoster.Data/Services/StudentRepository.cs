namespace Questar.OneRoster.Data.Services
{
    using System.Linq;
    using AutoMapper;
    using DataServices;

    public class StudentRepository : BaseRepository<Models.User, User>, IStudentRepository
    {
        public StudentRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper, context.Set<User>().Where(user => user.Type == UserType.Student))
        {
        }
    }
}