namespace Questar.OneRoster.ClientApp
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Client;

    internal class Program
    {
        private static async Task Main(string[] args)
        {
            using (var http = new HttpClient {BaseAddress = new Uri("http://localhost:14469/ims/oneroster/v1p1")})
            using (var clientOld = new OneRosterClient(http))
            {
                var id = Guid.NewGuid();
                var modified = DateTime.Today.Subtract(TimeSpan.FromDays(7));

                //var sessionOld =
                //    clientOld
                //        .AcademicSessions
                //        .Where(session => session.DateLastModified > modified)
                //        .Where(session => session.SourcedId == id)
                //        .Select(session => new {session.Title, session.Parent})
                //        .Where(result =>
                //            result.Title.Contains("Foo")) // error - can't filter/fields anonymous (fields) type
                //        .Skip(1000)
                //        .Take(200)
                //        .Single( /* session => session.SourcedId == id */);

                var sessionsOld =
                    clientOld
                        .AcademicSessions
                        .Where(session => session.DateLastModified > modified)
                        .Select(session => new {session.Title, session.Parent})
                        .Skip(1000)
                        .Take(200)
                        .ToOneRosterQueryResult();

                Console.WriteLine();

                //var sessionNew =
                //    await clientNew
                //        .AcademicSessions
                //        .For(id)
                //        .Fields(o => new {o.Title, o.Parent})
                //        .SingleAsync(); // -- OneRosterItemResult

                //var sessionsNew =
                //    await clientNew
                //        .AcademicSessions
                //        .Filter(session => session.DateLastModified > modified)
                //        .Fields(o => new {o.Title, o.Parent})
                //        .Filter(session => session.Title.Contains("Foo"))
                //        .Offset(1000)
                //        .Limit(200)
                //        .ToPageAsync(); // -- OneRosterPageResult

                //var enrollments =
                //    await clientNew
                //        .Schools
                //            .For(Guid.NewGuid())
                //        .Classes
                //            .For(Guid.NewGuid())
                //        .Enrollments
                //            .Filter(enrollment => enrollment.CourseCode == "Foo")
                //            .Fields(enrollment => new {enrollment.Title})
                //            .OrderBy(enrollment => enrollment.Title)
                //            .Offset(1000)
                //            .Limit(200)
                //            .ToPageAsync();

                Console.WriteLine();
            }
        }
    }
}