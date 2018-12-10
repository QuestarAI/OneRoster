namespace Questar.OneRoster.Data.Profiles
{
    using AutoMapper;
    using Models;
    using AcademicSession = Data.AcademicSession;
    using Category = Data.Category;
    using Class = Data.Class;
    using Course = Data.Course;
    using Demographics = Data.Demographics;
    using Enrollment = Data.Enrollment;
    using LineItem = Data.LineItem;
    using Org = Data.Org;
    using Resource = Data.Resource;
    using Result = Data.Result;
    using User = Data.User;

    public class GuidRefProfile : Profile
    {
        public GuidRefProfile()
        {
            const string prefix = "/ims/oneroster/v1p1";

            CreateMap<AcademicSession, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/academicSessions/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.AcademicSession));
            CreateMap<Category, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/categories/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Category));
            CreateMap<Class, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/classes/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Class));
            CreateMap<Course, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/courses/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Course));
            CreateMap<Demographics, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/demographics/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Demographics));
            CreateMap<Enrollment, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/enrollments/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Enrollment));
            CreateMap<LineItem, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/lineItems/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.LineItem));
            CreateMap<Org, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/orgs/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Org));
            CreateMap<Resource, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/resources/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Resource));
            CreateMap<Result, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/results/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Result));
            CreateMap<User, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/users/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.User));
            CreateMap<UserAgent, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/users/{source.AgentId}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.AgentId))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.User));
            CreateMap<UserOrg, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/orgs/{source.OrgId}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.OrgId))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Org));
        }
    }
}