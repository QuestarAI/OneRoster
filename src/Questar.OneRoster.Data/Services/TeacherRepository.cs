using System.Linq;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.DataServices.EntityFrameworkCore;

namespace Questar.OneRoster.Data.Services
{
    public class TeacherRepository : BaseObjectRepository<Models.User, User>, ITeacherRepository
    {
        public TeacherRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper, context.Set<User>().Where(user => user.Type == UserType.Teacher))
        {
        }

        public IQuery<Models.Class> GetClassesForTeacher(string userId)
        {
            return Context.Classes
                .Where(@class => @class.Enrollments.Any(enrollment => enrollment.UserId == int.Parse(userId)))
                .UseAsDataSource(Mapper)
                .For<Models.Class>()
                .ToBaseQuery();
        }
    }
}