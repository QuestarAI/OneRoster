using System;

namespace Questar.OneRoster.Data.Profiles
{
    using AutoMapper;

    public class GuidProfile : Profile
    {
        public GuidProfile()
        {
            CreateMap<string, Guid>()
                .ConvertUsing(s => Guid.Parse(s));
            CreateMap<string, Guid?>()
                .ConvertUsing(s => string.IsNullOrWhiteSpace(s) ? (Guid?) null : Guid.Parse(s));
            CreateMap<Guid?, string>()
                .ConvertUsing(g => g == null ? null : g.Value.ToString("N"));
            CreateMap<Guid, string>()
                .ConvertUsing(g => g.ToString("N"));
        }
    }
}
