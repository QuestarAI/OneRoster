namespace Questar.OneRoster.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net.Http;
    using Flurl.Http;
    using JetBrains.Annotations;
    using Models;
    using Remotion.Linq.Parsing.Structure;

    public class OneRosterRoute :  List<OneRosterRoute>
    {
        public OneRosterRoute(string template)
        {
            Template = template;
        }

        public string Template { get; }
    }

    public class OneRosterConfig
    {
        private readonly IList<OneRosterRoute> _routes;

        public OneRosterConfig()
        {
            _routes = new []
            {
                new OneRosterRoute("academicSessions")
                {
                    new OneRosterRoute("{id}")
                },
                new OneRosterRoute("classes")
                {
                    new OneRosterRoute("{id}")
                    {
                        new OneRosterRoute("students"),
                        new OneRosterRoute("teachers")
                    }
                },
                new OneRosterRoute("courses")
                {
                    new OneRosterRoute("{id}")
                    {
                        new OneRosterRoute("classes")
                    }
                },
                new OneRosterRoute("gradingPeriods")
                {
                    new OneRosterRoute("{id}")
                },
                new OneRosterRoute("demographics")
                {
                    new OneRosterRoute("{id}")
                },
                new OneRosterRoute("enrollments")
                {
                    new OneRosterRoute("{id}")
                },
                new OneRosterRoute("orgs")
                {
                    new OneRosterRoute("{id}")
                },
                new OneRosterRoute("schools")
                {
                    new OneRosterRoute("{id}")
                    {
                        new OneRosterRoute("courses"),
                        new OneRosterRoute("classes")
                        {
                            new OneRosterRoute("{classId}")
                            {
                                new OneRosterRoute("enrollments"),
                                new OneRosterRoute("students"),
                                new OneRosterRoute("teachers")
                            }
                        },
                        new OneRosterRoute("enrollments"),
                        new OneRosterRoute("students"),
                        new OneRosterRoute("teachers"),
                        new OneRosterRoute("terms")
                    }
                },
                new OneRosterRoute("students")
                {
                    new OneRosterRoute("{id}")
                    {
                        new OneRosterRoute("classes")
                    }
                },
                new OneRosterRoute("teachers")
                {
                    new OneRosterRoute("{id}")
                    {
                        new OneRosterRoute("classes")
                    }
                },
                new OneRosterRoute("terms")
                {
                    new OneRosterRoute("{id}")
                    {
                        new OneRosterRoute("classes"),
                        new OneRosterRoute("gradingPeriods")
                    }
                },
                new OneRosterRoute("users")
                {
                    new OneRosterRoute("{id}")
                    {
                        new OneRosterRoute("classes")
                    }
                }
            };
        }
    }

    public class OneRosterClient : IDisposable
    {
        private static readonly IQueryParser Parser = QueryParser.CreateDefault();

        public OneRosterClient([NotNull] IFlurlClient http)
        {
            Http = http;
            AcademicSessions = CreateQueryable<AcademicSession>(http, "academicSessions");
            Categories = CreateQueryable<Category>(http, "categories");
            Classes = CreateQueryable<Class>(http, "classes");
            Courses = CreateQueryable<Course>(http, "courses");
            Demographics = CreateQueryable<Demographics>(http, "demographics");
            Enrollments = CreateQueryable<Enrollment>(http, "categories");
            LineItems = CreateQueryable<LineItem>(http, "lineItems");
            Orgs = CreateQueryable<Org>(http, "orgs");
            Resources = CreateQueryable<Resource>(http, "resources");
            Results = CreateQueryable<Result>(http, "results");
            Users = CreateQueryable<User>(http, "users");
        }

        public OneRosterClient([NotNull] HttpClient http)
            : this(new FlurlClient(http))
        {
        }

        public IFlurlClient Http { get; }

        public IQueryable<AcademicSession> AcademicSessions { get; }

        public IQueryable<Category> Categories { get; }

        public IQueryable<Class> Classes { get; }

        public IQueryable<Course> Courses { get; }

        public IQueryable<Demographics> Demographics { get; }

        public IQueryable<Enrollment> Enrollments { get; }

        public IQueryable<LineItem> LineItems { get; }

        public IQueryable<Org> Orgs { get; }

        public IQueryable<Resource> Resources { get; }

        public IQueryable<Result> Results { get; }

        public IQueryable<User> Users { get; }

        public void Dispose() => Http.Dispose();

        private static OneRosterQueryable<T> CreateQueryable<T>(IFlurlClient http, string path) =>
            new OneRosterQueryable<T>(new OneRosterQueryProvider(Parser, new OneRosterQueryExecutor(http, path)));
    }
}