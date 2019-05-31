namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.Extensions.ExpressionMapping;
    using DataServices;
    using DataServices.EntityFrameworkCore;
    using Models;
    using User = Data.User;

    public class UserRepository : BaseObjectRepository<Models.User, User>, IUserRepository
    {
        public UserRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public IQuery<Class> GetClassesForUser(string userId) =>
            Context.Classes
                .Where(@class => @class.Enrollments.Any(enrollment => enrollment.UserId == userId))
                .UseAsDataSource(Mapper)
                .For<Class>()
                .ToBaseQuery();
    }
}