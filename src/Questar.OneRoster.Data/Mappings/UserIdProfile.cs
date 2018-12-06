using System;
using System.Collections.Generic;
using System.Text;

namespace Questar.OneRoster.Data.Mappings
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
