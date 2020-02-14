using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using React.AspNet;

namespace React
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache()
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                .AddReact()
                .AddJsEngineSwitcher(opt => opt.DefaultEngineName = ChakraCoreJsEngine.EngineName)
                .AddChakraCore();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseReact(config => { })
                .UseDefaultFiles()
                .UseStaticFiles();
        }
    }
}
