namespace Questar.OneRoster.Data.Mappings
{
    public class UserProfile : BaseProfile<User>
    {
        public UserProfile()
        {
            CreateMap<User, Models.User>();
        }
    }
}