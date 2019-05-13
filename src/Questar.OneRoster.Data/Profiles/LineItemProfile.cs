namespace Questar.OneRoster.Data.Profiles
{
    using System;

    public class LineItemProfile : BaseProfile<LineItem, Models.LineItem>
    {
        public LineItemProfile()
        {
            CreateMap()
                .ForMember(target => target.AssignDate, config => config.MapFrom(source => (DateTime) source.AssignDate))
                .ForMember(target => target.DueDate, config => config.MapFrom(source => (DateTime) source.DueDate))
                .ForMember(target => target.ResultValueMin, config => config.MapFrom(source => (float) source.ResultValueMin))
                .ForMember(target => target.ResultValueMax, config => config.MapFrom(source => (float) source.ResultValueMax));
        }
    }
}