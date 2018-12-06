namespace Questar.OneRoster.Data.Mappings
{
    using System;
    using AutoMapper;

    public class LineItemProfile : Profile
    {
        public LineItemProfile()
        {
            CreateMap<LineItem, Models.LineItem>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.DateLastModified, config => config.MapFrom(source => source.Modified))
                .ForMember(target => target.StatusType, config => config.MapFrom(source => source.Status))
                .ForMember(target => target.Metadata, config => config.MapFrom(source => source.MetadataCollection.Metadata))
                .ForMember(target => target.AssignDate, config => config.MapFrom(source => (DateTime) source.AssignDate))
                .ForMember(target => target.DueDate, config => config.MapFrom(source => (DateTime) source.DueDate))
                .ForMember(target => target.ResultValueMin, config => config.MapFrom(source => (float) source.ResultValueMin))
                .ForMember(target => target.ResultValueMax, config => config.MapFrom(source => (float) source.ResultValueMax));
        }
    }
}