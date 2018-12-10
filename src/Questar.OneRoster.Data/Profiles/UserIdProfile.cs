namespace Questar.OneRoster.Data.Profiles
{
    using AutoMapper;
    using Models;

    public class UserIdProfile : Profile
    {
        public UserIdProfile()
        {
            CreateMap<UserIdentifier, UserId>();
        }
    }
}
