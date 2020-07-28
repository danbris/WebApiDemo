using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JustForFunConsumer
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using var client = new HttpClient();
            var exit = false;
            while (!exit)
            {
                var result = await client.GetAsync("https://localhost:44373/api/todoitems");
                dynamic response = JsonConvert.DeserializeObject(await result.Content.ReadAsStringAsync());

                Console.WriteLine(response);
                Console.WriteLine("Read again? y/n");
                exit = Console.ReadKey().KeyChar == 'n';
            }
        }
    }
}
