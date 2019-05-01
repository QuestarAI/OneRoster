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
            using (var http = new FlurlClient(new HttpClient { BaseAddress = new Uri("http://localhost:14469") }))
            using (var client = new OneRosterClient(http))
            {
                var orgs = await client.Orgs.ToPageAsync();

                Console.WriteLine();
            }
        }
    }
}