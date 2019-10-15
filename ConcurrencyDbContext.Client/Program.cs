using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConcurrencyDbContext.Client
{
    class Program
    {
#pragma warning disable IDE0060 // Remove unused parameter
        static void Main(string[] args)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            using var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44328/api/")
            };

            var tasks = new Task<string>[]
            {
                Work(httpClient),
                Work(httpClient)
            };

            var results = Task.WhenAll(tasks).GetAwaiter().GetResult();
            foreach (var str in results)
            {
                Console.WriteLine(str);
            }

            Console.ReadKey();
        }

        private static async Task<string> Work(HttpClient httpClient)
        {
            var result = await httpClient.GetAsync($"test?term={Guid.NewGuid().ToString()}");
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadAsStringAsync();
        }
    }
}
