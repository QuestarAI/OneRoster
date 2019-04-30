namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class CoursesEndpoint : ListEndpoint<Course>, ICoursesEndpoint
    {
        public CoursesEndpoint(string host, string path) : base(host, path)
        {
        }

        public ICourseEndpoint For(Guid id) => throw new NotImplementedException();
    }
}