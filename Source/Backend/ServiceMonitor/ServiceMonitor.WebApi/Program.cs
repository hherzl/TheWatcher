using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ServiceMonitor.WebApi
{
#pragma warning disable CS1591
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://localhost:1234")
                .UseStartup<Startup>();
    }
#pragma warning restore CS1591
}
