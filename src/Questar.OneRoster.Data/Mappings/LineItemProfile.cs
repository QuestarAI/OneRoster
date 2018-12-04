namespace Questar.OneRoster.Data.Mappings
{
    public class LineItemProfile : BaseProfile<LineItem>
    {
        public LineItemProfile()
        {
            CreateMap<LineItem, Models.LineItem>();
        }
    }
}