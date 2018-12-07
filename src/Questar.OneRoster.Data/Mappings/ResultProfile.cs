namespace Questar.OneRoster.Data.Mappings
{
    using System;
    using AutoMapper;
    using Models;

    public class ResultProfile : Profile
    {
        public ResultProfile()
        {
            CreateMap<Data.Result, Result>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.DateLastModified, config => config.MapFrom(source => source.Modified))
                .ForMember(target => target.StatusType, config => config.MapFrom(source => (StatusType) source.Status))
                .ForMember(target => target.Metadata, config => config.MapFrom(source => source.MetadataCollection.Metadata))
                .ForMember(target => target.Score, config => config.MapFrom(source => (float) source.Score))
                .ForMember(target => target.ScoreDate, config => config.MapFrom(source => (DateTime) source.ScoreDate))
                .ForMember(target => target.ScoreStatus, config => config.MapFrom(source => (ScoreStatus) source.ScoreStatus));
        }
    }
}