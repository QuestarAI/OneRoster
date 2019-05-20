namespace Questar.OneRoster.Data.Services
{
    using AutoMapper;
    using DataServices;

    public class UserRepository : BaseRepository<Models.User, User>, IUserRepository
    {
        public UserRepository(OneRosterDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}