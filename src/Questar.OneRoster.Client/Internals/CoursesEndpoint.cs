namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class CoursesEndpoint : ListEndpoint<Course>
    {
        public CoursesEndpoint(string path) : base(path)
        {
        }

        public CourseEndpoint For(Guid id) => new CourseEndpoint($"{Path}/{id}") { Http = Http };
    }
}