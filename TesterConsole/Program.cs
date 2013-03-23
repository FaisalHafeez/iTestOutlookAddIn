using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;

namespace TesterConsole
{
    class Program
    {
        static void Main()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.PostAsJsonAsync(
                    "http://localhost:3136/api/account",
                    new { username = "itest", password = "ilana" },
                    CancellationToken.None
                ).Result;
                response.EnsureSuccessStatusCode();

                var aspxauth = response.Headers.First(h => h.Key.ToLower() == "set-cookie").Value.First().Split('=')[1].Split(';')[0];

                bool success = response.Content.ReadAsAsync<bool>().Result;
                if (success)
                {
                    var secret = httpClient.GetStringAsync("http://localhost:3136/api/candidates").Result;
                    Console.WriteLine(secret);
                }
                else
                {
                    Console.WriteLine("Sorry you provided wrong credentials");
                }
            }

            Console.ReadKey();
        }
    }
}
