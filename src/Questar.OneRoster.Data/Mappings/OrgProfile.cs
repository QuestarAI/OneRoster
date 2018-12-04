namespace Questar.OneRoster.Data.Mappings
{
    public class OrgProfile : BaseProfile<Org>
    {
        public OrgProfile()
        {
            CreateMap<Org, Models.Org>();
        }
    }
}