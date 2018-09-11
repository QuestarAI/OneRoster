using Questar.OneRoster.Common;
using Questar.OneRoster.Vocabulary.Sced;

namespace Questar.OneRoster.Client
{
    using System;
    using System.Linq;
    using Dto;
    using Vocabulary;
    using Vocabulary.Ceds;

    public class RecommendedClient : Client<Gender, Grade, SubjectCode, CountryCode, StateCode, PublicSchoolResidenceStatus> { }

    public class Client<TGender, TGrade, TSubjectCode> : Client<TGender, TGrade, TSubjectCode, CountryCode, StateCode, PublicSchoolResidenceStatus>
        where TGender : struct, IConvertible, IComparable, IFormattable
        where TGrade : struct, IConvertible, IComparable, IFormattable
        where TSubjectCode : struct, IConvertible, IComparable, IFormattable
    {
    }

    public class Client<TGender, TGrade, TSubjectCode, TCountryCode, TStateCode, TPublicSchoolResidenceStatus>
        where TGender : struct, IConvertible, IComparable, IFormattable
        where TGrade : struct, IConvertible, IComparable, IFormattable
        where TSubjectCode : struct, IConvertible, IComparable, IFormattable
        where TCountryCode : struct, IConvertible, IComparable, IFormattable
        where TStateCode : struct, IConvertible, IComparable, IFormattable
        where TPublicSchoolResidenceStatus : struct, IConvertible, IComparable, IFormattable
    {
        public IQueryable<AcademicSessionDto> AcademicSessions { get; } = new OrderedQueryable<AcademicSessionDto>(GuidType.AcademicSession);
        public IQueryable<CategoryDto> Categories { get; } = new OrderedQueryable<CategoryDto>(GuidType.Category);
        public IQueryable<ClassDto<TGrade, TSubjectCode>> Classes { get; } = new OrderedQueryable<ClassDto<TGrade, TSubjectCode>>(GuidType.Class);
        public IQueryable<CourseDto<TGrade, TSubjectCode>> Courses { get; } = new OrderedQueryable<CourseDto<TGrade, TSubjectCode>>(GuidType.Course);
        public IQueryable<DemographicsDto<TGender, TCountryCode, TStateCode, TPublicSchoolResidenceStatus>> Demographics { get; } = new OrderedQueryable<DemographicsDto<TGender, TCountryCode, TStateCode, TPublicSchoolResidenceStatus>>(GuidType.Demographics);
        public IQueryable<EnrollmentDto> Enrollments { get; } = new OrderedQueryable<EnrollmentDto>(GuidType.Enrollment);
        public IQueryable<AcademicSessionDto> GradingPeriods { get; } = new OrderedQueryable<AcademicSessionDto>(GuidType.GradingPeriod);
        public IQueryable<LineItemDto> LineItems { get; } = new OrderedQueryable<LineItemDto>(GuidType.LineItem);
        public IQueryable<OrgData> Orgs { get; } = new OrderedQueryable<OrgData>(GuidType.Org);
        public IQueryable<ResourceDto> Resources { get; } = new OrderedQueryable<ResourceDto>(GuidType.Resource);
        public IQueryable<ResultDto> Results { get; } = new OrderedQueryable<ResultDto>(GuidType.Result);
        public IQueryable<OrgData> Schools { get; } = new OrderedQueryable<OrgData>(GuidType.School);
        public IQueryable<UserDto<TGrade>> Students { get; } = new OrderedQueryable<UserDto<TGrade>>(GuidType.Student);
        public IQueryable<UserDto<TGrade>> Teachers { get; } = new OrderedQueryable<UserDto<TGrade>>(GuidType.Teacher);
        public IQueryable<AcademicSessionDto> Terms { get; } = new OrderedQueryable<AcademicSessionDto>(GuidType.Term);
        public IQueryable<UserDto<TGrade>> Users { get; } = new OrderedQueryable<UserDto<TGrade>>(GuidType.User);
    }
}