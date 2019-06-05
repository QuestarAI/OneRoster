using AutoMapper;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.Data.Profiles
{
    public class GuidRefProfile : Profile
    {
        public GuidRefProfile()
        {
            const string prefix = "/ims/oneroster/v1p1";

            CreateMap<AcademicSession, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/academicSessions/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id.ToString()))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.AcademicSession));
            CreateMap<Category, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/categories/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id.ToString()))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Category));
            CreateMap<Class, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/classes/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id.ToString()))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Class));
            CreateMap<ClassAcademicSession, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/academicSessions/{source.AcademicSessionId}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.AcademicSessionId.ToString()))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.AcademicSession));
            CreateMap<ClassResource, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/resources/{source.ResourceId}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.ResourceId.ToString()))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Resource));
            CreateMap<Course, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/courses/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id.ToString()))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Course));
            CreateMap<CourseResource, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/resources/{source.ResourceId}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.ResourceId.ToString()))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Resource));
            CreateMap<Demographics, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/demographics/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id.ToString()))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Demographics));
            CreateMap<Enrollment, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/enrollments/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id.ToString()))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Enrollment));
            CreateMap<LineItem, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/lineItems/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id.ToString()))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.LineItem));
            CreateMap<Org, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/orgs/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id.ToString()))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Org));
            CreateMap<Resource, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/resources/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id.ToString()))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Resource));
            CreateMap<Result, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/results/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id.ToString()))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Result));
            CreateMap<User, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/users/{source.Id}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id.ToString()))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.User));
            CreateMap<UserAgent, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/users/{source.AgentId}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.AgentId.ToString()))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.User));
            CreateMap<UserOrg, GuidRef>()
                .ForMember(target => target.Href, config => config.MapFrom(source => $"{prefix}/orgs/{source.OrgId}"))
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.OrgId.ToString()))
                .ForMember(target => target.Type, config => config.MapFrom(source => GuidType.Org));
        }
    }
}