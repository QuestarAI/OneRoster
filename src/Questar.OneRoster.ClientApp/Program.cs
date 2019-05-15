namespace Questar.OneRoster.ClientApp
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Client;
    using Flurl.Http;


    internal class Program
    {
        private static async Task Main(string[] args)
        {
            using (var http = new FlurlClient("http://localhost:14469"))
            using (var client = new OneRosterClient(http))
            {
                var orgs = await client.Orgs.ToPageAsync();
            }

            // lookup demographics, courses, and orgs

            // for each class in term

            // -- set class course/subject

            // -- set class school from lookup

            // -- set class district from lookup

            // -- for each student in class students

            // ---- add student

            // ---- add student demographics from lookup

            // ---- add student to class

            // ---- set student gender

            // ---- set student grade (take first and log error, if there are more than one)

            // -- for each teacher in class teachers

            // ---- add teacher

            // ---- add teacher to class
        }
    }
}