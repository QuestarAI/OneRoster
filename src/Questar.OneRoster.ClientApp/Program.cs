namespace Questar.OneRoster.ClientApp
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Client;
    using Flurl.Http;
    using Models;
    using Sorting;

    internal class Program
    {
        private static async Task Main(string[] args)
        {
            using (var http = new FlurlClient(new HttpClient { BaseAddress = new Uri("http://localhost:14469/ims/oneroster/v1p1") }))
            using (var client = new OneRosterClient(http))
            {
                //var enrollments =
                //    await
                //        client
                //            .Schools
                //            .For(Guid.NewGuid())
                //            .Classes
                //            .For(Guid.NewGuid())
                //            .Enrollments
                //            .Filter(enrollment => enrollment.Role == RoleType.Parent)
                //            .Fields(enrollment => new {enrollment.User, enrollment.Class})
                //            .Sort(enrollment => enrollment.EndDate)
                //            .OrderBy(SortDirection.Desc)
                //            .Offset(1000)
                //            .Limit(200)
                //            .ToPageAsync();

                var schools = await client.Schools.ToPageAsync();

                Console.WriteLine();
            }
        }
    }
}