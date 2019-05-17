using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Roger.ParseTheParcel.Api
{
    /// <summary>
    /// </summary>
    public class Program
    {
        /// <summary>
        /// </summary>
        /// s
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// </summary>
        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseIISIntegration()
                .CaptureStartupErrors(true)
                .UseSetting("detailedErrors", "true")
                .Build();
        }
    }
}