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

    public class StudentRepository : BaseObjectRepository<Models.User, User>, IStudentRepository
    {
        public StudentRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper, context.Set<User>().Where(user => user.Type == UserType.Student))
        {
        }

        public IQuery<Class> GetClassesForStudent(string userId) =>
            Context.Classes
                .Where(@class => @class.Enrollments.Any(enrollment => enrollment.UserId == Guid.Parse(userId)))
                .UseAsDataSource(Mapper)
                .For<Class>()
                .ToBaseQuery();
    }
}