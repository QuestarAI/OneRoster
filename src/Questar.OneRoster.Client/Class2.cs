namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface IClient : IDisposable
    {
        IAcademicSessionsEndpoint AcademicSessions { get; }

        ICategoriesEndpoint Categories { get; }

        IClassesEndpoint Classes { get; }

        ICourseEndpoint Courses { get; }

        IGradingPeriodsEndpoint GradingPeriods { get; }

        IDemographicsEndpoint Demographics { get; }

        IEnrollmentsEndpoint Enrollments { get; }

        ILineItemsEndpoint LineItems { get; }

        IOrgsEndpoint Orgs { get; }

        IResourcesEndpoint Resources { get; }

        IResultsEndpoint Results { get; }

        ISchoolsEndpoint Schools { get; }

        IStudentsEndpoint Students { get; }

        ITeachersEndpoint Teachers { get; }

        ITermsEndpoint Terms { get; }

        IUsersEndpoint Users { get; }
    }

    public interface IAcademicSessionsEndpoint : IListEndpoint<AcademicSession>
    {
        INodeEndpoint<AcademicSession> For(Guid id);
    }

    public interface ICategoriesEndpoint : IListEndpoint<Category>
    {
        IEditEndpoint<Category> For(Guid id);
    }

    public interface IClassesEndpoint : IListEndpoint<Class>
    {
        IClassEndpoint For(Guid id);
    }

    public interface IClassEndpoint : INodeEndpoint<Class>
    {
        IClassLineItemsEndpoint LineItems { get; }

        IListEndpoint<Resource> Resources { get; }

        IListEndpoint<Result> Results { get; }

        IClassStudentsEndpoint Students { get; }

        IListEndpoint<User> Teachers { get; }
    }

    public interface IClassLineItemsEndpoint : IListEndpoint<LineItem>
    {
        IListEndpoint<Result> ResultsFor(Guid id);
    }

    public interface IClassStudentsEndpoint : IListEndpoint<User>
    {
        IListEndpoint<Result> ResultsFor(Guid id);
    }

    public interface ICoursesEndpoint : IListEndpoint<Course>
    {
        ICourseEndpoint For(Guid id);
    }

    public interface ICourseEndpoint : INodeEndpoint<Course>
    {
        IListEndpoint<Class> Classes { get; }

        IListEndpoint<Resource> Resources { get; }
    }

    public interface IGradingPeriodsEndpoint : IListEndpoint<AcademicSession>
    {
        INodeEndpoint<AcademicSession> For(Guid id);
    }

    public interface IDemographicsEndpoint : IListEndpoint<Demographics>
    {
        INodeEndpoint<Demographics> For(Guid id);
    }

    public interface IEnrollmentsEndpoint : IListEndpoint<Enrollment>
    {
        INodeEndpoint<Enrollment> For(Guid id);
    }

    public interface ILineItemsEndpoint : IListEndpoint<LineItem>
    {
        IEditEndpoint<LineItem> For(Guid id);
    }

    public interface IOrgsEndpoint : IListEndpoint<Org>
    {
        INodeEndpoint<Org> For(Guid id);
    }

    public interface IResourcesEndpoint : IListEndpoint<Resource>
    {
        INodeEndpoint<Resource> For(Guid id);
    }

    public interface IResultsEndpoint : IListEndpoint<Result>
    {
        IEditEndpoint<Result> For(Guid id);
    }

    public interface ISchoolsEndpoint : IListEndpoint<Org>
    {
        ISchoolEndpoint For(Guid id);
    }

    public interface ISchoolEndpoint : INodeEndpoint<Org>
    {
        IListEndpoint<Course> Courses { get; }

        ISchoolClassesEndpoint Classes { get; }

        IListEndpoint<Enrollment> Enrollments { get; }

        IListEndpoint<User> Students { get; }

        IListEndpoint<User> Teachers { get; }

        IListEndpoint<AcademicSession> Terms { get; }
    }

    public interface ISchoolClassesEndpoint : IListEndpoint<Org>
    {
        ISchoolClassEndpoint For(Guid id);
    }

    public interface ISchoolClassEndpoint : INodeEndpoint<Org>
    {
        IListEndpoint<Course> Enrollments { get; }

        IListEndpoint<User> Students { get; }

        IListEndpoint<User> Teachers { get; }
    }

    public interface IStudentsEndpoint : IListEndpoint<User>
    {
        IStudentEndpoint For(Guid id);
    }

    public interface IStudentEndpoint : INodeEndpoint<User>
    {
        IListEndpoint<Class> Classes { get; }
    }

    public interface ITeachersEndpoint : IListEndpoint<User>
    {
        ITeacherEndpoint For(Guid id);
    }

    public interface ITeacherEndpoint : INodeEndpoint<User>
    {
        IListEndpoint<Class> Classes { get; }
    }

    public interface ITermsEndpoint : IListEndpoint<AcademicSession>
    {
        ITermEndpoint For(Guid id);
    }

    public interface ITermEndpoint : IListEndpoint<AcademicSession>
    {
        IListEndpoint<Class> Classes { get; }

        IListEndpoint<Class> GradingPeriods { get; }
    }

    public interface IUsersEndpoint : IListEndpoint<User>
    {
    }

    public interface IUserEndpoint : IListEndpoint<User>
    {
        IListEndpoint<Class> Classes { get; }
    }
}
