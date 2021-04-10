
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Pokedex.Domain;
using Pokedex.Domain.Contracts;

namespace Pokedex.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}