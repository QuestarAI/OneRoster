namespace Questar.OneRoster.Data.Mappings
{
    using System;
    using AutoMapper;

    public class ResultProfile : Profile
    {
        public ResultProfile()
        {
            CreateMap<Result, Models.Result>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.DateLastModified, config => config.MapFrom(source => source.Modified))
                .ForMember(target => target.StatusType, config => config.MapFrom(source => source.Status))
                .ForMember(target => target.Metadata, config => config.MapFrom(source => source.MetadataCollection.Metadata))
                .ForMember(target => target.Score, config => config.MapFrom(source => (float) source.Score))
                .ForMember(target => target.ScoreDate, config => config.MapFrom(source => (DateTime) source.ScoreDate));
        }
    }
}