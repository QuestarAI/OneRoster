namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class CoursesEndpoint : ListEndpoint<Course>, ICoursesEndpoint
    {
        public CoursesEndpoint(string path) : base(path)
        {
        }

        public ICourseEndpoint For(Guid id) => new CourseEndpoint($"{Path}/{{id}}");
    }
}