namespace Questar.OneRoster.Data.Mappings
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
            CreateMap<AcademicSession, GuidRef>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ConvertUsing(source => new GuidRef { Type = GuidType.AcademicSession });
            CreateMap<Category, GuidRef>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ConvertUsing(source => new GuidRef { Type = GuidType.Category });
            CreateMap<Class, GuidRef>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ConvertUsing(source => new GuidRef { Type = GuidType.Class });
            CreateMap<Course, GuidRef>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ConvertUsing(source => new GuidRef { Type = GuidType.Course });
            CreateMap<Demographics, GuidRef>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ConvertUsing(source => new GuidRef { Type = GuidType.Demographics });
            CreateMap<Enrollment, GuidRef>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ConvertUsing(source => new GuidRef { Type = GuidType.Enrollment });
            CreateMap<LineItem, GuidRef>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ConvertUsing(source => new GuidRef { Type = GuidType.LineItem });
            CreateMap<Org, GuidRef>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ConvertUsing(source => new GuidRef { Type = GuidType.Org });
            CreateMap<Resource, GuidRef>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ConvertUsing(source => new GuidRef { Type = GuidType.Resource });
            CreateMap<Result, GuidRef>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ConvertUsing(source => new GuidRef { Type = GuidType.Result });
            CreateMap<User, GuidRef>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ConvertUsing(source => new GuidRef { Type = GuidType.User });
            CreateMap<UserAgent, GuidRef>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.AgentId))
                .ConvertUsing(source => new GuidRef { Type = GuidType.User });
            CreateMap<UserOrg, GuidRef>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.OrgId))
                .ConvertUsing(source => new GuidRef { Type = GuidType.Org });
        }
    }
}