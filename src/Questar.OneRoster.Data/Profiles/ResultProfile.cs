using System;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.Data.Profiles
{
    public class ResultProfile : BaseProfile<Result, Models.Result>
    {
        public ResultProfile()
        {
            CreateMap()
                .ForMember(target => target.Score, config => config.MapFrom(source => (float) source.Score))
                .ForMember(target => target.ScoreDate, config => config.MapFrom(source => (DateTime) source.ScoreDate))
                .ForMember(target => target.ScoreStatus, config => config.MapFrom(source => (ScoreStatus) source.ScoreStatus));
        }
    }
}