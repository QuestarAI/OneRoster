namespace Questar.OneRoster.Data.Profiles
{
    using AutoMapper;
    using Models;

    public class GuidRefProfile : Profile
    {
        public GuidRefProfile()
        {
            const string prefix = "/ims/oneroster/v1p1";

            CreateMap<Data.AcademicSession, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/academicSessions/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.AcademicSession));
            CreateMap<Data.Category, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/categories/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Category));
            CreateMap<Data.Class, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/classes/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Class));
            CreateMap<Data.Course, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/courses/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Course));
            CreateMap<Data.Demographics, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/demographics/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Demographics));
            CreateMap<Data.Enrollment, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/enrollments/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Enrollment));
            CreateMap<Data.LineItem, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/lineItems/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.LineItem));
            CreateMap<Data.Org, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/orgs/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Org));
            CreateMap<Data.Resource, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/resources/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Resource));
            CreateMap<Data.Result, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/results/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Result));
            CreateMap<Data.User, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/users/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.User));
            CreateMap<Data.UserAgent, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/users/{source.AgentId}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.AgentId))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.User));
            CreateMap<Data.UserOrg, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/orgs/{source.OrgId}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.OrgId))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Org));
        }
    }
}