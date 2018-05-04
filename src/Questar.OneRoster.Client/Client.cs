using Questar.OneRoster.Model.Common;
using Questar.OneRoster.Model.Vocabulary.Sced;

namespace Questar.OneRoster.Client
{
    using System;
    using System.Linq;
    using Model.Dto;
    using Model.Vocabulary;
    using Model.Vocabulary.Ceds;

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
        public IQueryable<AcademicSession> AcademicSessions { get; } = new OrderedQueryable<AcademicSession>(GuidType.AcademicSession);
        public IQueryable<Category> Categories { get; } = new OrderedQueryable<Category>(GuidType.Category);
        public IQueryable<Class<TGrade, TSubjectCode>> Classes { get; } = new OrderedQueryable<Class<TGrade, TSubjectCode>>(GuidType.Class);
        public IQueryable<Course<TGrade, TSubjectCode>> Courses { get; } = new OrderedQueryable<Course<TGrade, TSubjectCode>>(GuidType.Course);
        public IQueryable<Demographics<TGender, TCountryCode, TStateCode, TPublicSchoolResidenceStatus>> Demographics { get; } = new OrderedQueryable<Demographics<TGender, TCountryCode, TStateCode, TPublicSchoolResidenceStatus>>(GuidType.Demographics);
        public IQueryable<Enrollment> Enrollments { get; } = new OrderedQueryable<Enrollment>(GuidType.Enrollment);
        public IQueryable<AcademicSession> GradingPeriods { get; } = new OrderedQueryable<AcademicSession>(GuidType.GradingPeriod);
        public IQueryable<LineItem> LineItems { get; } = new OrderedQueryable<LineItem>(GuidType.LineItem);
        public IQueryable<Org> Orgs { get; } = new OrderedQueryable<Org>(GuidType.Org);
        public IQueryable<Resource> Resources { get; } = new OrderedQueryable<Resource>(GuidType.Resource);
        public IQueryable<Result> Results { get; } = new OrderedQueryable<Result>(GuidType.Result);
        public IQueryable<Org> Schools { get; } = new OrderedQueryable<Org>(GuidType.School);
        public IQueryable<User<TGrade>> Students { get; } = new OrderedQueryable<User<TGrade>>(GuidType.Student);
        public IQueryable<User<TGrade>> Teachers { get; } = new OrderedQueryable<User<TGrade>>(GuidType.Teacher);
        public IQueryable<AcademicSession> Terms { get; } = new OrderedQueryable<AcademicSession>(GuidType.Term);
        public IQueryable<User<TGrade>> Users { get; } = new OrderedQueryable<User<TGrade>>(GuidType.User);
    }
}