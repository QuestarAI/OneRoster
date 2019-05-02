namespace Questar.OneRoster.Data.Profiles
{
    using System.Linq;
    using AutoMapper;
    using Models;
    using Course = Data.Course;

    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, Models.Course>()
                .ForMember(target => target.SourcedId, config => config.MapFrom(source => source.Id))
                .ForMember(target => target.DateLastModified, config => config.MapFrom(source => source.Modified))
                .ForMember(target => target.StatusType, config => config.MapFrom(source => (StatusType) source.Status))
                .ForMember(target => target.Metadata, config => config.MapFrom(source => source.MetadataCollection.Metadata))
                .ForMember(target => target.Subjects, config => config.MapFrom(source => source.Subjects.Select(subject => subject.Subject.Name)))
                .ForMember(target => target.SubjectCodes, config => config.MapFrom(source => source.Subjects.Select(subject => subject.Subject.Code)));
        }
    }
}