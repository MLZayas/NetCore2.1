using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace JC_WindowsAutentication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        //public static void Main(string[] args) =>
        //BuildWebHost(args).Run();

        //public static IWebHost BuildWebHost(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>()
        //        .UseHttpSys(options =>
        //        {
        //            options.Authentication.Schemes =
        //                AuthenticationSchemes.NTLM |
        //                AuthenticationSchemes.Negotiate;
        //            options.Authentication.AllowAnonymous = false;
        //        })
        //        .Build();
    }
}
