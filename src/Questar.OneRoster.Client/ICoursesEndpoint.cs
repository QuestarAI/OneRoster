namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface ICoursesEndpoint : IListEndpoint<Course>
    {
        ICourseEndpoint For(Guid id);
    }
}