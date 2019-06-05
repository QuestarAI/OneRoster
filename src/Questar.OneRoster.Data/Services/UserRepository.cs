using System.Linq;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.DataServices.EntityFrameworkCore;

namespace Questar.OneRoster.Data.Services
{
    public class UserRepository : BaseObjectRepository<Models.User, User>, IUserRepository
    {
        public UserRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public IQuery<Models.Class> GetClassesForUser(string userId)
        {
            return Context.Classes
                .Where(@class => @class.Enrollments.Any(enrollment => enrollment.UserId == int.Parse(userId)))
                .UseAsDataSource(Mapper)
                .For<Models.Class>()
                .ToBaseQuery();
        }
    }
}