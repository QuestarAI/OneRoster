namespace Questar.OneRoster.ClientApp
{
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
                var terms = await client.Terms.ToPageAsync();
                //var orgs = await client.Terms.For("1A903D47-6EEC-4D18-EFA1-08D6DD456FEE").Classes.ToPageAsync();
            }
        }
    }
}