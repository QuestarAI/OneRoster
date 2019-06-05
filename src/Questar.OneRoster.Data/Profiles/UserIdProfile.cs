using AutoMapper;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.Data.Profiles
{
    public class UserIdProfile : Profile
    {
        public UserIdProfile()
        {
            CreateMap<UserIdentifier, UserId>();
        }
    }
}