namespace Questar.OneRoster.Data.Mappings
{
    public class ResultProfile : BaseProfile<Result>
    {
        public ResultProfile()
        {
            CreateMap<Result, Models.Result>();
        }
    }
}