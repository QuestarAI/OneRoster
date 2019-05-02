namespace Questar.OneRoster.Client
{
    using System;
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class CoursesEndpoint : ListEndpoint<Course>
    {
        public CoursesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public CourseEndpoint For(Guid id) => new CourseEndpoint(Http, $"{Path}/{id}");
    }
}