using System.Linq;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.DataServices.EntityFrameworkCore;

namespace Questar.OneRoster.Data.Services
{
    public class StudentRepository : BaseObjectRepository<Models.User, User>, IStudentRepository
    {
        public StudentRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper, context.Set<User>().Where(user => user.Type == UserType.Student))
        {
        }

        public IQuery<Models.Class> GetClassesForStudent(string userId)
        {
            return Context.Classes
                .Where(@class => @class.Enrollments.Any(enrollment => enrollment.UserId == userId))
                .UseAsDataSource(Mapper)
                .For<Models.Class>()
                .ToBaseQuery();
        }
    }
}