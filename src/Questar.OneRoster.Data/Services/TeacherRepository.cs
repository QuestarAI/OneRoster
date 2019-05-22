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

    public class TeacherRepository : BaseObjectRepository<Models.User, User>, ITeacherRepository
    {
        public TeacherRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper, context.Set<User>().Where(user => user.Type == UserType.Teacher))
        {
        }

        public IQuery<Class> GetClassesForTeacher(string userId)
            => Context.Classes
                .Where(@class => @class.Enrollments.Any(enrollment => enrollment.UserId == Guid.Parse(userId)))
                .UseAsDataSource(Mapper)
                .For<Class>()
                .ToBaseQuery();
    }
}